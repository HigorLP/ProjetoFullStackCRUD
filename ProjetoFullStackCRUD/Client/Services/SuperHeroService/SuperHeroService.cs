using Microsoft.AspNetCore.Components;
using ProjetoFullStackCRUD.Client.Pages;
using ProjetoFullStackCRUD.Shared.Models;
using System.Net.Http.Json;

namespace ProjetoFullStackCRUD.Client.Services.SuperHeroService {
    public class SuperHeroService : ISuperHeroService {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigate;

        public SuperHeroService(HttpClient http, NavigationManager navigate) {
            this._http = http;
            this._navigate = navigate;
        }

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();


        public async Task GetComics() {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null) Comics = result;
            throw new Exception("Quadrinho não encontrado!");
        }
        public async Task<SuperHero> GetSingleHero(int id) {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null) return result;
            throw new Exception("Herói não encontrado!");

        }

        public async Task GetSuperHeroes() {
            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (result != null) Heroes = result;
        }
        public void setHeroes(List<SuperHero> response) {
            Heroes = response;
            _navigate.NavigateTo("superheroes");
        }
        public async Task CreateHero(SuperHero hero) {
            var result = await _http.PostAsJsonAsync("api/superhero", hero);
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            setHeroes(response);
        }
        public async Task UpdateHero(SuperHero hero, int id) {
            var result = await _http.PutAsJsonAsync($"api/superhero/{id}", hero);
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            setHeroes(response);
        }
        public async Task DeleteHero(int id) {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            setHeroes(response);

        }

    }
}
