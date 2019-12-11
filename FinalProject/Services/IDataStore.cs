using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Services
{
    public interface IDataStore<C>
    {
        Task<List<Character>> GetCharactersAsync();
        Task<int> AddCharacterAsync(C character);
        Task<int> DeleteCharacterAsync(C character);
    }
}