using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorWOL.Shared;

namespace BlazorWOL.Client
{
    public class DeviceService
    {
        private HttpClient HttpClient { get; }

        public DeviceService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await HttpClient.GetFromJsonAsync<Device[]>("api/devices");
        }

        public async Task AddDeviceAsync(Device device)
        {
            await HttpClient.PostAsJsonAsync("api/devices", device);
        }

        public async Task<Device> GetDeviceAsync(Guid id)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<Device>($"api/devices/{id}");
            }
            catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task UpdateDeviceAsync(Guid id, Device device)
        {
            await HttpClient.PutAsJsonAsync($"api/devices/{id}", device);
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            await HttpClient.DeleteAsync($"api/devices/{id}");
        }
    }
}
