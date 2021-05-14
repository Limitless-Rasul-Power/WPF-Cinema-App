using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Static_Classes;

namespace WPF_Cinema_App.ViewModels
{
    public class StarViewModel : INotifyPropertyChanged
    {
        private readonly string _emptyStar = "../Functional Images/empty star.png";
        private readonly string _halfStar = "../Functional Images/half star.png";
        private readonly string _fullStar = "../Functional Images/filled star.png";
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isStarGiven;

        public StarViewModel()
        {
            ImagePaths = new ObservableCollection<string> { _emptyStar, _emptyStar, _emptyStar, _emptyStar, _emptyStar };
            OneLeftCommand = new RelayCommand(OneLeftClick);
            TwoLeftCommand = new RelayCommand(DoubleLeftClick);
            CloseWindowCommand = new RelayCommand(CloseWindowClick, delegate { return _isStarGiven; });
        }        

        public ObservableCollection<string> ImagePaths { get; set; }
        public RelayCommand OneLeftCommand { get; set; }
        public RelayCommand TwoLeftCommand { get; set; }

        public RelayCommand CloseWindowCommand { get; set; }

        private double _ratingNumber;

        public double RatingNumber
        {
            get { return _ratingNumber; }
            set { _ratingNumber = value; OnPropertyChanged(); }
        }


        private void OneLeftClick(object data = null)
        {
            if (data is string position)
            {
                switch (position)
                {
                    case StarNumbers.One:
                        {
                            ChangeImagesToHalfStarWhenLeftClick(1);
                        }
                        break;
                    case StarNumbers.Two:
                        {
                            ChangeImagesToHalfStarWhenLeftClick(2);
                        }
                        break;
                    case StarNumbers.Three:
                        {
                            ChangeImagesToHalfStarWhenLeftClick(3);
                        }
                        break;
                    case StarNumbers.Four:
                        {
                            ChangeImagesToHalfStarWhenLeftClick(4);
                        }
                        break;
                    case StarNumbers.Five:
                        {
                            ChangeImagesToHalfStarWhenLeftClick(5);
                        }
                        break;
                }
            }
        }

        private void DoubleLeftClick(object data = null)
        {
            if (data is string position)
            {
                switch (position)
                {
                    case StarNumbers.One:
                        {
                            ChangeImagesToFilledStarWhenDoubleLeftClick(1);
                        }
                        break;
                    case StarNumbers.Two:
                        {
                            ChangeImagesToFilledStarWhenDoubleLeftClick(2);
                        }
                        break;
                    case StarNumbers.Three:
                        {
                            ChangeImagesToFilledStarWhenDoubleLeftClick(3);
                        }
                        break;
                    case StarNumbers.Four:
                        {
                            ChangeImagesToFilledStarWhenDoubleLeftClick(4);
                        }
                        break;
                    case StarNumbers.Five:
                        {
                            ChangeImagesToFilledStarWhenDoubleLeftClick(5);
                        }
                        break;
                }
            }
        }

        private void CloseWindowClick(object data = null)
        {
            if (data is Window window)
            {
                window.Close();
            }
        }

        private void ChangeImagesToHalfStarWhenLeftClick(int upToThatNumber)
        {
            _isStarGiven = true;

            ChangeImagesToFilledStarWhenDoubleLeftClick(upToThatNumber);
            ImagePaths[upToThatNumber - 1] = _halfStar;
            RatingNumber = upToThatNumber - 0.5;
        }
        
        private void ChangeImagesToFilledStarWhenDoubleLeftClick(int upToThatNumber)
        {
            _isStarGiven = true;

            for (int i = 0; i < upToThatNumber; i++)
            {
                ImagePaths[i] = _fullStar;
            }

            RatingNumber = upToThatNumber;

            EmptyRemainingImages(upToThatNumber);
        }

        private void EmptyRemainingImages(int number)
        {
            for (int i = number; i < 5; i++)
            {
                ImagePaths[i] = _emptyStar;
            }
        }

        

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
