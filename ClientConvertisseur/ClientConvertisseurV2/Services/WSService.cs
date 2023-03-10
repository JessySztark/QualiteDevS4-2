using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Windows.Web.Http;
using HttpClient = System.Net.Http.HttpClient;

namespace ClientConvertisseurV2.Services {
    public class WSService : IService {
        HttpClient client = new HttpClient();
        public WSService(String parameter) {
        client.BaseAddress = new Uri(parameter);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Devise>> GetDevisesAsync(String nomControleur) {
            try {
                return await client.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception) {
                return null;
            }
        }
    }
}

