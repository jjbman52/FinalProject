using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using SQLite;
using Xamarin.Forms;

namespace FinalProject.Services
{
    public class DataStore : IDataStore<Character>
    {
        readonly SQLiteAsyncConnection database;

        public DataStore(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Character>().Wait();
        }

        public Task<List<Character>> GetCharactersAsync()
        {
            return database.Table<Character>().ToListAsync();
        }

        public Task<Character> GetCharacterAsync(string name)
        {
            return database.Table<Character>().Where(i => i.name == name).FirstOrDefaultAsync();
        }

        public Task<int> AddCharacterAsync(Character character)
        {
                return database.InsertAsync(character);
        }

        public Task<int> DeleteCharacterAsync(Character character)
        {
            return database.DeleteAsync(character);
        }
    }
}