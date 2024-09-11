using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    public class TodosServices
    {
        internal async Task<ObservableCollection<Todos>> getTodos()
        {
            throw new NotImplementedException();
        }

        private class Todosservices
        {
            private HttpClient _httpClient;
            private Todos todos;
            private ObservableCollection<Todos> Todos;
            private HttpClient httpClient;
            private JsonSerializerOptions jsonSerializerOptions;


            public Todosservices()
            {
                httpClient = new HttpClient();
                jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

            }

            public async Task<ObservableCollection<Todos>> getTodos(ObservableCollection<Todos>? items)
            {
                Uri uri = new Uri("https://jsonplaceholder.typicode.com/todos");
                ObservableCollection < Todos > itens = new ObservableCollection<Todos>();

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        items = JsonSerializer.Deserialize< ObservableCollection < Todos >>(content, jsonSerializerOptions);
                    }
                }
                catch (Exception ex)
                {

                }
                return items;

            }

        }
    }
}

