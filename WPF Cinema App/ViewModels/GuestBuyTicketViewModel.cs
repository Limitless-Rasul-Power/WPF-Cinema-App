using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Services;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class GuestBuyTicketViewModel
    {
        public static bool IsAliGuidedGuest;
        private readonly SpeechSynthesizer _Ali = new SpeechSynthesizer();

        public GuestBuyTicketViewModel(ObservableCollection<CinemaHall> cinemaHalls)
        {
            CinemaHalls = cinemaHalls;
            ShowTrailerCommand = new RelayCommand(ShowTrailerLeftDoubleClick);
            BuyTicketCommand = new RelayCommand(BuyTicketClick);

            if (IsAliGuidedGuest == false && CinemaHalls.Count != 0)
            {
                _Ali.SetOutputToDefaultAudioDevice();
                _Ali.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult);
                _Ali.Rate = -1;
                _Ali.Volume = 100;

                _Ali.SpeakAsync($"If you want to watch movie trailer, double left click to movie image please.");

                IsAliGuidedGuest = true;
            }
        }
        public ObservableCollection<CinemaHall> CinemaHalls { get; set; }
        public RelayCommand ShowTrailerCommand { get; set; }
        public RelayCommand BuyTicketCommand { get; set; }

        private void ShowTrailerLeftDoubleClick(object data)
        {
            if (data is Movie movie)
            {
                TrailerViewModel trailerViewModel = new TrailerViewModel
                {
                    VideoSource = $@"https://www.youtube.com/results?search_query={YoutubeServices.ConvertDataToYoutubeSearchableData(movie.Title)}+trailer"
                };

                TrailerWindow trailerWindow = new TrailerWindow
                {
                    DataContext = trailerViewModel
                };

                trailerWindow.ShowDialog();
                trailerViewModel.VideoSource = @"https://www.youtube.com/";
            }
        }

        private void BuyTicketClick(object data)
        {
            if (data is CinemaHall cinemaHall)
            {

                if (cinemaHall.Sits[default] == null)
                {
                    for (int i = 0; i < cinemaHall.Sits.Length; i++)
                    {
                        cinemaHall.Sits[i] = new Sit
                        {
                            Number = i + 1
                        };
                    }
                }
                else
                {
                    if (cinemaHall.Sits.Count(sit => sit.IsFull) == cinemaHall.Sits.Length)
                    {
                        System.Windows.MessageBox.Show("All Sits Are Full.");

                        return;
                    }
                }


                HallViewModel hallViewModel = new HallViewModel
                {
                    CinemaHall = cinemaHall,
                    CinemaHalls = this.CinemaHalls
                };

                int fullSitsCount = 0;

                List<int> emptySitIndexes = new List<int>
                {
                    Capacity = cinemaHall.Sits.Length - 1
                };


                for (int i = 0; i < cinemaHall.Sits.Length; i++)
                {
                    if (cinemaHall.Sits[i].IsFull)
                    {
                        fullSitsCount = fullSitsCount + 1;
                    }
                    else
                    {
                        emptySitIndexes.Add(i);
                    }
                }


                hallViewModel.FullSitsCount = fullSitsCount;
                hallViewModel.EmptySitsIndexes = emptySitIndexes;

                HallView hallView = new HallView
                {
                    DataContext = hallViewModel
                };


                int currentSitIndex = 0;

                for (int i = 2; i <= 5; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        CinemaSitViewModel cinemaSitViewModel = new CinemaSitViewModel(cinemaHall.Sits[currentSitIndex]);

                        CinemaSitView cinemaSitView = new CinemaSitView
                        {
                            DataContext = cinemaSitViewModel
                        };

                        hallView.MainGrid.Children.Add(cinemaSitView);

                        Grid.SetRow(cinemaSitView, i);
                        Grid.SetColumn(cinemaSitView, j);

                        currentSitIndex = currentSitIndex + 1;
                    }
                }

                ViewController.SecondView.Content = hallView;
            }

        }

    }
}
