using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cinema_App.Models
{
    public class CinemaHall
    {        
        public Movie Movie { get; set; }
        public Sit[] Sits { get; set; } = new Sit[20];
        public int FullSitsCount { get; set; }               
    }
}