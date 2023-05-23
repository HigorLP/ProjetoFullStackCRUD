using ProjetoFullStackCRUD.Server.Models;
using System.Net.Http.Json;

namespace ProjetoFullStackCRUD.Client.Services.SuperHeroService;
public class SuperHeroService : ISuperHeroService {

    private readonly HttpClient _http;

    public SuperHeroService(HttpClient http) {
        this._http = http;
    }

    public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
    public List<Comic> Comics { get; set; } = new List<Comic>();


    public async Task GetSuperHeroes() {
        var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
        if (result != null) Heroes = result;

    }

    public async Task<SuperHero> GetSingleHero(int id) {
        var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        if (result != null) return result;

        throw new Exception("Herói não encontrado.");
    }
    public Task GetComics() {
        throw new NotImplementedException();
    }

}
