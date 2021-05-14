using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class HallViewModel
    {
        public ObservableCollection<CinemaHall> CinemaHalls;

        public HallViewModel()
        {
            BackCommand = new RelayCommand(BackClick);
            BuyCommand = new RelayCommand(BuyClick);
        }

        public CinemaHall CinemaHall { get; set; }
        public List<int> EmptySitsIndexes { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public int FullSitsCount { get; set; }

        private void BackClick(object data = null)
        {
            for (int i = 0; i < EmptySitsIndexes.Count; i++)
            {
                CinemaHall.Sits[EmptySitsIndexes[i]].IsFull = false;
            }

            GuestBuyTicketViewModel guestBuyTicketViewModel = new GuestBuyTicketViewModel(CinemaHalls);

            GuestBuyTicketView guestBuyTicketView = new GuestBuyTicketView
            {
                DataContext = guestBuyTicketViewModel
            };

            ViewController.SecondView.Content = guestBuyTicketView;            

        }

        private void BuyClick(object data = null)
        {            
            int allFullSitsCount = CinemaHall.Sits.Count(sit => sit.IsFull);
            int guestBuyTicketCount = allFullSitsCount - FullSitsCount;

            if (guestBuyTicketCount == 0)
            {
                MessageBox.Show("You didn't choose any sit.", "Mosaviena");
                return;
            }

            MessageBoxResult result = MessageBox.Show($"Do You want to buy cinema ticket(s) to {CinemaHall.Movie.Title} ?\nYour payment equals to {CinemaHall.Movie.ImdbRating * guestBuyTicketCount} $", "Mosaviena", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                CinemaHall.FullSitsCount = allFullSitsCount;

                MessageBox.Show($"Operation {result} done successfully.", "Mosaviena");

                decimal totalBudget = BinaryFileHelper.BinaryDeserialization("Total Budget");
                totalBudget = totalBudget + (decimal)(CinemaHall.Movie.ImdbRating * guestBuyTicketCount);
                BinaryFileHelper.BinarySerialization(totalBudget, "Total Budget");


                StarViewModel starViewModel = new StarViewModel();
                StarWindow starView = new StarWindow
                {
                    DataContext = starViewModel
                };

                starView.ShowDialog();
                

                JsonFileHelper.JsonSerialization<CinemaHall>(CinemaHalls, "Database of Cinemas/cinemas");

                PdfFileHelper.WritePaymentToFile(
                    Tuple.Create(CinemaHall.Movie, CinemaHall.Movie.ImdbRating * guestBuyTicketCount, starViewModel.RatingNumber),
                    $"{PdfFileHelper.ConvertFileNameToAcceptableFileName(CinemaHall.Movie.Title)}");

                GuestBuyTicketViewModel guestBuyTicketViewModel = new GuestBuyTicketViewModel(CinemaHalls);

                GuestBuyTicketView guestBuyTicketView = new GuestBuyTicketView
                {
                    DataContext = guestBuyTicketViewModel
                };

                ViewController.SecondView.Content = guestBuyTicketView;
            }

        }
    }
}