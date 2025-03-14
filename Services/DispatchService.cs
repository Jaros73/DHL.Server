using System.Net.Http.Json;
using DHL.Server.Components.Dispatch;
using DHL.Server.Models;

namespace DHL.Server.Services
{
    public class DispatchService
    {
        private readonly HttpClient _httpClient;

        public DispatchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DispatchModel>> GetDispatchesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DispatchModel>>("api/dispatch") ?? new List<DispatchModel>();
        }

        public async Task<List<DispatchModel>> GetFilteredDispatchesAsync(DispatchFilter filter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/dispatch/filter", filter);
            return await response.Content.ReadFromJsonAsync<List<DispatchModel>>() ?? new List<DispatchModel>();
        }

        public async Task CreateDispatchAsync(Dispatch newDispatch)
        {
            var response = await _httpClient.PostAsJsonAsync("api/dispatch", newDispatch);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateDispatchAsync(int id, Dispatch updatedDispatch)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/dispatch/{id}", updatedDispatch);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDispatchAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/dispatch/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<DispatchModel?> GetDispatchByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DispatchModel>($"api/dispatch/{id}");
        }

        public async Task CreateDispatchAsync(DispatchModel newDispatch)
        {
            var response = await _httpClient.PostAsJsonAsync("api/dispatch", newDispatch);
            response.EnsureSuccessStatusCode();
        }

        public async Task<DispatchMeta> GetMetadataAsync()
        {
            return await _httpClient.GetFromJsonAsync<DispatchMeta>("api/dispatch/meta") ?? new DispatchMeta();
        }

    }
}
