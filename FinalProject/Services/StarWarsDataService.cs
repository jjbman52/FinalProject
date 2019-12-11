using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using FinalProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinalProject.Services
{
    public class StarWarsDataService : IStarWarsDataService
    {
        public async Task<IEnumerable<Character>> GetCharacters()
        {
            var url = $@"https://swapi.co/api/people";

            var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            var responseObject = JObject.Parse(response);

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<IEnumerable<Character>>(responseObject["results"].ToString()));
        }
    }
}