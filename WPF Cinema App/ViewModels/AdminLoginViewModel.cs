using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Cinema_App.Command;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.ViewModels
{
    public class AdminLoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _username;

        

        public AdminLoginViewModel()
        {
            try
            {
                Admins = JsonFileHelper.JsonDeserialization<Admin>("Database of Admins/admins");
            }
            catch (Exception)
            {
                Admins = new ObservableCollection<Admin>();
            }
            
            SubmitCommand = new RelayCommand(SubmitClick);
            BackCommand = new RelayCommand(BackClick);
        }

        public ObservableCollection<Admin> Admins { get; set; }
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand BackCommand { get; set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }


        private void SubmitClick(object data)
        {
            PasswordBox passwordBox = data as PasswordBox;

            Admin admin = Admins.FirstOrDefault(a => a.Username == Username && a.Password == passwordBox.Password.GetHashCode());

            if (admin == null)
            {
                System.Windows.MessageBox.Show("Wrong Username or password", "Mosaviena", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);

                Username = default;
                passwordBox.Password = default;
            }
            else
            {
                AdminMainViewModel adminMainViewModel = new AdminMainViewModel();//collection-u yeni like olunan movieleri json file-dan alacaq constructorda hem de observable collection prop-u olacaq

                AdminMainView adminMainView = new AdminMainView
                {
                    DataContext = adminMainViewModel
                };
                
                ViewController.MainView.Content = adminMainView;
            }


        }

        private void BackClick(object data = null)
        {
            ViewController.MainView.Content = new FirstViewGuestOrAdmin();
        }


        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}