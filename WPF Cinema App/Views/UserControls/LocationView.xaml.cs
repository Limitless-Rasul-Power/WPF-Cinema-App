using System.Windows.Controls;
using WPF_Cinema_App.ViewModels;

namespace WPF_Cinema_App.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LocationView.xaml
    /// </summary>
    public partial class LocationView : UserControl
    {
        public LocationView()
        {
            InitializeComponent();
            this.DataContext = new LocationViewModel();
        }
    }
}