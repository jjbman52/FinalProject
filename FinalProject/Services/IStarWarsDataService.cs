using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using Xamarin.Forms;

namespace FinalProject.Services
{
    public interface IStarWarsDataService
    {
        Task<IEnumerable<Character>> GetCharacters();
    }
}

