using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPF_Cinema_App.Static_Classes;
using WPF_Cinema_App.Static_File_Helper_Classes;
using WPF_Cinema_App.ViewModels;

namespace WPF_Cinema_App.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FirstViewGuestOrAdmin.xaml
    /// </summary>
    public partial class FirstViewGuestOrAdmin : UserControl
    {
        public FirstViewGuestOrAdmin()
        {
            InitializeComponent();
            this.DataContext = new GuestOrAdminViewModel();
            SetRecognizerDatas();
            SetAliDatasAndSpeak();
        }
    }
}