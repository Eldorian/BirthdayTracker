using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BirthdayTracker.API.Models;

namespace BirthdayTracker.UI.Services
{
    public interface IApiClient
    {
        Task<List<Birthday>> GetBirthdays();
        Task<Birthday> GetBirthday(int id);
        Task PutBirthday(Birthday birthdayToUpdate);
        Task AddBirthday(Birthday birthdayToAdd);
        Task RemoveBirthday(int id);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Birthday>> GetBirthdays()
        {
            var response = await httpClient.GetAsync("/api/birthdays");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<Birthday>>();
        }

        public async Task<Birthday> GetBirthday(int id)
        {
            var response = await httpClient.GetAsync($"/api/birthdays/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<Birthday>();
        }

        public async Task PutBirthday(Birthday birthdayToUpdate)
        {
            var response = await httpClient.PutJsonAsync($"api/birthdays/{birthdayToUpdate.Id}", birthdayToUpdate);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddBirthday(Birthday birthdayToAdd)
        {
            var response = await httpClient.PostJsonAsync("api/birthdays", birthdayToAdd);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveBirthday(int id)
        {
            var response = await httpClient.DeleteAsync($"/api/birthdays/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
