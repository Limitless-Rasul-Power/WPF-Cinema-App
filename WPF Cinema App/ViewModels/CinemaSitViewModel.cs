using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF_Cinema_App.Models;

namespace WPF_Cinema_App.ViewModels
{
    public class CinemaSitViewModel
    {       
        private CinemaSitViewModel()
        {
        }

        public CinemaSitViewModel(Sit sit)
        {
            Sit = sit;
            IsEnabled = !Sit.IsFull;
        }

        public Sit Sit{ get; set; }
        public bool IsEnabled { get; set; }
    }
}