using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cinema_App.Services
{
    public static class YoutubeServices
    {
        public static StringBuilder ConvertDataToYoutubeSearchableData(string data)
        {
            string[] movieWords = data.Split(' ');

            StringBuilder fullPath = new StringBuilder();

            for (int i = 0; i < movieWords.Length; i++)
            {
                fullPath.Append(movieWords[i]);

                if (i + 1 < movieWords.Length)
                    fullPath.Append('+');
            }

            return fullPath;
        }
    }
}