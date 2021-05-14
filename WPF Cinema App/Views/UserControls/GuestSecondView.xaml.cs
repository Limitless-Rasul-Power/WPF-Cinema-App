using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Cinema_App.Static_Classes;

namespace WPF_Cinema_App.Views.UserControls
{
    /// <summary>
    /// Interaction logic for GuestSecondView.xaml
    /// </summary>
    public partial class GuestSecondView : UserControl
    {
        public GuestSecondView()
        {
            InitializeComponent();
            ViewController.SetGuestSecondViewSecondColumn(ContentControlGuestSecondView);
        }
    }
}
