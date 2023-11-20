using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace GalacticNavigator.Services
{
    public class NasaApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "BoAaZtrSAA7JrXhOxj1EFjJYffoz57VkGIi9TlM8";
        public NasaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AstronomyPictureOfTheDay> GetAstronomyPictureOfTheDayAsync()
        {
            var response = await _httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AstronomyPictureOfTheDay>(content);
        }
    }

}



