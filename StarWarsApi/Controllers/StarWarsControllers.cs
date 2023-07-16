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
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/people");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    PeopleResponse peopleResponse = JsonSerializer.Deserialize<PeopleResponse>(responseContent);

                    return Ok(peopleResponse.results);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("people/{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/people/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    People person = JsonSerializer.Deserialize<People>(responseContent);

                    return Ok(person);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet("planets")]//HttpClient nesneleri HTTP isteklerini yapmak için kullanılır.
        public async Task<IActionResult> GetPlanets()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/planets");
                //İstek sonucu bir HttpResponseMessage olarak alınır.

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    PlanetsResponse planetResponse = JsonSerializer.Deserialize<PlanetsResponse>(responseContent);
                    //Okunan yanıt içeriği, JsonSerializer.Deserialize<PlanetsResponse>(responseContent) ile PlanetsResponse sınıfına deserialized (çözümlenmiş) edilir. 

                    return Ok(planetResponse.results);//200
                    // Eğer istek başarılıysa, response.Content.ReadAsStringAsync() ile yanıt içeriği okunur ve bir string olarak alınır.
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                    //Eğer false olarak değerlendirilirse, StatusCode((int)response.StatusCode, response.ReasonPhrase) ifadesi ile ilgili hata durumunu ve durum açıklamasını içeren bir yanıt döndürülür.

                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);//Herhangi bir hata durumunda, catch bloğu içinde StatusCode(500, ex.Message) ifadesi ile 500 Internal Server Error durum koduyla birlikte hata mesajını içeren bir yanıt döndürülür.
            }
        }


        [HttpGet("planets/{id}")]
        public async Task<IActionResult> GetPlanetById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/planets/{id}/");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Planets planet = JsonSerializer.Deserialize<Planets>(responseContent);

                    return Ok(planet);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("films")]
        public async Task<IActionResult> GetFilms()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/films");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    FilmsResponse filmsResponse = JsonSerializer.Deserialize<FilmsResponse>(responseContent);

                    return Ok(filmsResponse.results);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("films/{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/films/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Films film = JsonSerializer.Deserialize<Films>(responseContent);

                    return Ok(film);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("species")]
        public async Task<IActionResult> GetSpecies()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/species");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    SpeciesResponse speciesResponse = JsonSerializer.Deserialize<SpeciesResponse>(responseContent);

                    return Ok(speciesResponse.results);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("species/{id}")]
        public async Task<IActionResult> GetSpeciesById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/species/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Species species = JsonSerializer.Deserialize<Species>(responseContent);

                    return Ok(species);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/vehicles");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    VehiclesResponse vehiclesResponse = JsonSerializer.Deserialize<VehiclesResponse>(responseContent);

                    return Ok(vehiclesResponse.results);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("vehicles/{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/vehicles/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Vehicles vehicle = JsonSerializer.Deserialize<Vehicles>(responseContent);

                    return Ok(vehicle);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("starships")]
        public async Task<IActionResult> GetStarships()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/starships");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    StarshipsResponse starshipsResponse = JsonSerializer.Deserialize<StarshipsResponse>(responseContent);

                    return Ok(starshipsResponse.results);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("starships/{id}")]
        public async Task<IActionResult> GetStarshipById(int id)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient();

                HttpResponseMessage response = await httpClient.GetAsync($"{_apiBaseUrl}/starships/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Starships starship = JsonSerializer.Deserialize<Starships>(responseContent);

                    return Ok(starship);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }



}