using WPF_Cinema_App.ViewModels;
using WPF_Cinema_App.Views.UserControls;

namespace WPF_Cinema_App.Static_Classes
{
    public static class ViewController
    {
        public static System.Windows.Controls.ContentControl MainView { get; set; }
        public static System.Windows.Controls.ContentControl SecondView { get; set; }

        public static void SetMainView(System.Windows.Controls.ContentControl control)
        { 
            MainView = control;
            MainView.Content = new FirstViewGuestOrAdmin();
        }

        public static void SetGuestSecondViewSecondColumn(System.Windows.Controls.ContentControl control)
        {
            SecondView = control;
        }

        public static void SetAdminMainViewSecondColumn(System.Windows.Controls.ContentControl control)
        {
            SecondView = control;
            LikedMovieViewModel likedMoviesViewModel = new LikedMovieViewModel();

            LikedMoviesView likedMoviesView = new LikedMoviesView
            {
                DataContext = likedMoviesViewModel
            };

            SecondView.Content = likedMoviesView;
        }
    }
}