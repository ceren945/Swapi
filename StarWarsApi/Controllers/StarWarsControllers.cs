using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using StarWarsApi.Models.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarWarsApi.Models;


namespace StarWarsApi.Controllers
{



    //OMER SARGIN CEREN DURMUS 
    [ApiController]
    [Route("api/[controller]")]
    public class StarWarsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;//IHttpClientFactory, HttpClient nesnelerini oluşturmak ve yönetmek için kullanılan bir fabrika desenidir.
                                                               //Bu fabrika, HttpClient nesnelerinin kullanıcı tarafından doğru bir şekilde yönetilmesini sağlar. Ayrıca, aynı HttpClient örneğini paylaşarak ağır işlem maliyetlerini ve kaynak kullanımını en aza indirir.
        private readonly string _apiBaseUrl = "https://swapi.dev/api";
        public StarWarsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //Bu yapı, HttpClient nesnelerini doğru şekilde yönetmeyi sağlayarak, özellikle çoklu istekler yapılması gereken durumlarda performansı artırır ve ağır kaynak kullanımını önler

        }
        private HttpClient GetHttpClient()
        {
            return _httpClientFactory.CreateClient();
        }

        private async Task<T> GetApiResponse<T>(string endpoint)
        {
            HttpClient httpClient = GetHttpClient();

            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/{endpoint}");
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseContent);
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }


        [HttpGet("people")]
        public async Task<IActionResult> GetPeople()
        {

            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/people");
            string responseContent = await response.Content.ReadAsStringAsync();
            PeopleResponse peopleResponse = JsonSerializer.Deserialize<PeopleResponse>(responseContent);
            return Ok(peopleResponse.results);


        }
        [HttpGet("people/{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/people/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            People person = JsonSerializer.Deserialize<People>(responseContent);
            return Ok(person);
        }

        [HttpGet("planets")]
        public async Task<IActionResult> GetPlanets()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/planets");
            string responseContent = await response.Content.ReadAsStringAsync();
            PlanetsResponse planetResponse = JsonSerializer.Deserialize<PlanetsResponse>(responseContent);
            return Ok(planetResponse.results);
        }

        [HttpGet("planets/{id}")]
        public async Task<IActionResult> GetPlanetById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/planets/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Planets planet = JsonSerializer.Deserialize<Planets>(responseContent);
            return Ok(planet);
        }

        // Diğer metotlar için de aynı düzenlemeyi yapabilirsiniz.



        [HttpGet("films")]
        public async Task<IActionResult> GetFilms()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/films");
            string responseContent = await response.Content.ReadAsStringAsync();
            FilmsResponse filmsResponse = JsonSerializer.Deserialize<FilmsResponse>(responseContent);
            return Ok(filmsResponse.results);
        }

        [HttpGet("films/{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/films/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Films film = JsonSerializer.Deserialize<Films>(responseContent);
            return Ok(film);
        }


        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/vehicles");
            string responseContent = await response.Content.ReadAsStringAsync();
            VehiclesResponse vehiclesResponse = JsonSerializer.Deserialize<VehiclesResponse>(responseContent);
            return Ok(vehiclesResponse.results);
        }

        [HttpGet("vehicles/{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/vehicles/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Vehicles vehicle = JsonSerializer.Deserialize<Vehicles>(responseContent);
            return Ok(vehicle);
        }
        [HttpGet("species")]
        public async Task<IActionResult> GetSpecies()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/species");
            string responseContent = await response.Content.ReadAsStringAsync();
            SpeciesResponse speciesResponse = JsonSerializer.Deserialize<SpeciesResponse>(responseContent);
            return Ok(speciesResponse.results);
        }

        [HttpGet("species/{id}")]
        public async Task<IActionResult> GetSpeciesById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/species/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Species species = JsonSerializer.Deserialize<Species>(responseContent);
            return Ok(species);
        }

        [HttpGet("starships")]
        public async Task<IActionResult> GetStarships()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/starships");
            string responseContent = await response.Content.ReadAsStringAsync();
            StarshipsResponse starshipsResponse = JsonSerializer.Deserialize<StarshipsResponse>(responseContent);
            return Ok(starshipsResponse.results);
        }

        [HttpGet("starships/{id}")]
        public async Task<IActionResult> GetStarshipById(int id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/starships/{id}");
            string responseContent = await response.Content.ReadAsStringAsync();
            Starships starship = JsonSerializer.Deserialize<Starships>(responseContent);
            return Ok(starship);
        }


    }

}
