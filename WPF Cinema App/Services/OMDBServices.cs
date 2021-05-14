using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_Cinema_App.Models;

namespace WPF_Cinema_App.Services
{
    public class OMDBServices
    {
        private readonly HttpClient httpClient = new HttpClient();
        public HttpResponseMessage ResponseMessage { get; private set; }
        public string ApiKey { get; private set; } = ConfigurationManager.AppSettings["OmdbAPIKey"];

        public ObservableCollection<Movie> GetMoviesWithName(string movieName)
        {
            ResponseMessage = httpClient.GetAsync($@"http://www.omdbapi.com/?s={movieName}&apikey={ApiKey}&plot=full").Result;
            string dataSetsFromMovieName = ResponseMessage.Content.ReadAsStringAsync().Result;
            dynamic dataCollection = JsonConvert.DeserializeObject(dataSetsFromMovieName);

            return GetMoviesFromCollection(dataCollection);
        }
        private ObservableCollection<Movie> GetMoviesFromCollection(dynamic collection)
        {
            ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

            for (int i = 0; i < collection.Search.Count; i++)
            {

                ResponseMessage = httpClient.GetAsync($@"http://www.omdbapi.com/?i={collection.Search[i].imdbID}&apikey={ApiKey}&plot=full").Result;

                string dataSetFromMovieImdbID = ResponseMessage.Content.ReadAsStringAsync().Result;

                dynamic movie = JsonConvert.DeserializeObject(dataSetFromMovieImdbID);

                movies.Add(new Movie
                    (
                        movie.imdbID.ToString(),
                        movie.Title.ToString(),
                        movie.Plot.ToString(),
                        movie.Poster.ToString(),
                        Convert.ToDouble(movie.imdbRating),
                        movie.Genre.ToString())
                    );
            }

            return movies;
        }

    }
}