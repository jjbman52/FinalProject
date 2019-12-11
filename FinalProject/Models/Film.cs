using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinalProject.Models
{
    public class Film : StarWarsBase
    {
        public int episode_id { get; set; }
        public IEnumerable<string> starships { get; set; }
        public IEnumerable<string> species { get; set; }
        public string opening_crawl { get; set; }
        public IEnumerable<string> vehicles { get; set; }
        public IEnumerable<string> planets { get; set; }
        public string title { get; set; }
        public string producer { get; set; }
        public string director { get; set; }
        public IEnumerable<string> characters { get; set; }
    }
}