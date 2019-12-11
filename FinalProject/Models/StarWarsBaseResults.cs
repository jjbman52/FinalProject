using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FinalProject.Models
{
    public class StarWarsBaseResults<T> : StarWarsBase where T : StarWarsBase
    {
            public string previous { get; set; }
            public string next { get; set; }
            public string previousPageNo { get; set; }
            public List<T> results { get; set; }
    }
}