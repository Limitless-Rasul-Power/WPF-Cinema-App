using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Services;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class MovieSearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _movieName;        
        private string _backButtonVisibility;
        private string _nextButtonVisibility;
        private string _templateVisibility;
        private int _currentNumber;
        private bool _isFound;
        private readonly bool _isGuestEntered;
        private bool _isAliGuidedPerson;
        private readonly SpeechSynthesizer _Ali = new SpeechSynthesizer();

        private MovieSearchViewModel()
        {
            BackButtonVisibility = NextButtonVisibility = TemplateVisibility = Visibility.Collapsed.ToString();

            Movies = new ObservableCollection<Movie>();

            MovieServices = new OMDBServices();
            SearchCommand = new RelayCommand(SearchClick);
            PreviousCommand = new RelayCommand(PreviousClick);
            NextCommand = new RelayCommand(NextClick);

            _Ali.SetOutputToDefaultAudioDevice();
            _Ali.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
            _Ali.Rate = -1;
            _Ali.Volume = 100;
        }

        public MovieSearchViewModel(bool isGuestEntered)
            :this()
        {
            _isGuestEntered = isGuestEntered;


            if (_isGuestEntered)
            {
                ViewModel = new MovieTemplateViewModel();

                Template = new MovieTemplate
                {
                    DataContext = ViewModel
                };
                
            }
            else
            {
                ViewModel = new CinemaTemplateViewModel();
                Template = new CinemaTemplate
                {
                    DataContext = ViewModel
                };
            }

        }

        public INotifyPropertyChanged ViewModel { get; set; }
        public UserControl Template { get; set; }

        public List<string> LikedMoviesImdbIdsForOneGuest { get; set; }
        public ObservableCollection<Movie> AllLikedMovies { get; set; }        
        public OMDBServices MovieServices { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand PreviousCommand { get; set; }
        public RelayCommand NextCommand { get; set; }

        public string MovieName
        {
            get { return _movieName; }
            set { _movieName = value; OnPropertyChanged(); }
        }

        public string BackButtonVisibility
        {
            get { return _backButtonVisibility; }
            set { _backButtonVisibility = value; OnPropertyChanged(); }
        }
        public string NextButtonVisibility
        {
            get { return _nextButtonVisibility; }
            set { _nextButtonVisibility = value; OnPropertyChanged(); }
        }
        public string TemplateVisibility
        {
            get { return _templateVisibility; }
            set { _templateVisibility = value; OnPropertyChanged(); }
        }

        private void SearchClick(object data = null)
        {
            try
            {
                Movies.Clear();
                _currentNumber = default;

                Movies = MovieServices.GetMoviesWithName(MovieName);
                _isFound = true;

                FindLikedMovieInAllLikedMoviesAndReplaceCurrentMovie();


                if (_isAliGuidedPerson == false)
                {
                    _Ali.SpeakAsync($"If you want to watch {MovieName} trailer, left click to movie image please.");
                    _isAliGuidedPerson = true;
                }

                TemplateVisibility = Visibility.Visible.ToString();
                NextButtonVisibility = Movies.Count > 1 ? Visibility.Visible.ToString() : Visibility.Collapsed.ToString();
                BackButtonVisibility = Visibility.Collapsed.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Movie did not exist or some problem happened while finding the movie.", "Mosaviena");
                MovieName = default;
                _isFound = false;

                if (_isGuestEntered)
                {
                    (ViewModel as MovieTemplateViewModel).Movie = null;
                }
                else
                {
                    (ViewModel as CinemaTemplateViewModel).Movie = null;
                }


                BackButtonVisibility = NextButtonVisibility = TemplateVisibility = Visibility.Collapsed.ToString();
            }

        }

        private void PreviousClick(object data = null)
        {
            if (_currentNumber - 1 >= 0 && _isFound)
            {
                --_currentNumber;

                FindLikedMovieInAllLikedMoviesAndReplaceCurrentMovie();

                if (_currentNumber - 1 == -1)
                {
                    BackButtonVisibility = Visibility.Collapsed.ToString();
                }

                NextButtonVisibility = Visibility.Visible.ToString();
            }
        }

        private void NextClick(object data = null)
        {
            if (_currentNumber + 1 < Movies.Count && _isFound)
            {
                ++_currentNumber;

                FindLikedMovieInAllLikedMoviesAndReplaceCurrentMovie();

                if (_currentNumber + 1 == Movies.Count)
                {
                    NextButtonVisibility = Visibility.Collapsed.ToString();
                }

                BackButtonVisibility = Visibility.Visible.ToString();
            }
        }

        private void FindLikedMovieInAllLikedMoviesAndReplaceCurrentMovie()
        {
            try
            {
                AllLikedMovies = JsonFileHelper.JsonDeserialization<Movie>("Database of Liked Movies/movies");
            }
            catch (Exception)
            {
            }

            Movie movie = AllLikedMovies?.FirstOrDefault(m => m.ImdbID == Movies[_currentNumber].ImdbID);

            if (_isGuestEntered)
            {
                (ViewModel as MovieTemplateViewModel).Movie = movie ?? Movies[_currentNumber];
            }
            else
            {
                (ViewModel as CinemaTemplateViewModel).Movie = movie ?? Movies[_currentNumber];
            }

        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}