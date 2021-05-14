using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cinema_App.Models
{
    public class Movie : INotifyPropertyChanged
    {
        private int _likeCount;

        public Movie(string imdbID, string title, string plot, string poster, double imdbRating, string genre)
            => (ImdbID, Title, Plot, Poster, ImdbRating, Genre) = (imdbID, title, plot, poster, imdbRating, genre);
        

        public event PropertyChangedEventHandler PropertyChanged;
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public double ImdbRating { get; set; }
        public string Genre { get; set; }
        public string TitleAndImdbRatingCombination => $"Title : {Title}, Imdb Rating : {ImdbRating}";
        public int LikeCount
        {
            get { return _likeCount; }
            set { _likeCount = value; OnPropertyChanged(); }
        }

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}