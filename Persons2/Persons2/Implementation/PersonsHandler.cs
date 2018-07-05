using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persons3.API;
using Persons3.Models;
using Prism.Events;

namespace Persons3.Implementation
{
    public class PersonHandler : IPersonHandler
    {

        public async Task<List<Person>> LoadPersonsAsync()
        {
            // Adresse definieren
            var uri = "http://172.20.10.54:8080/persons";

            // HTTP-Client definieren
            var client = new HttpClient();

            // GET-request zum Server
            var response = await client.GetAsync(uri);

            // Hat's geklappt?
            if (response.IsSuccessStatusCode)
            {
                // JSON abholen
                var content = await response.Content.ReadAsStringAsync();

                // ...in Liste von Person-Objekten konvertieren
                var persons = JsonConvert.DeserializeObject<List<Person>>(content);

                // Fertig!
                return persons;
            }

            return new List<Person>();
        }
    }
}
