using System.Collections.ObjectModel;
using System.Windows;
using WPF_Cinema_App.Models;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;

namespace WPF_Cinema_App.Views
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {        
        public StartWindow()
        {
            InitializeComponent();       
            ViewController.SetMainView(ContentControlStart);
        }
    }
}