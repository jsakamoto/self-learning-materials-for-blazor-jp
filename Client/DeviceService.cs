using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWOL.Shared;
using Microsoft.AspNetCore.Components;

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
            return await HttpClient.GetJsonAsync<Device[]>("api/devices");
        }

        public async Task AddDeviceAsync(Device device)
        {
            await HttpClient.PostJsonAsync("api/devices", device);
        }

        public async Task<Device> GetDeviceAsync(Guid id)
        {
            try
            {
                return await HttpClient.GetJsonAsync<Device>($"api/devices/{id}");
            }
            catch (HttpRequestException e) when (e.Message == "404 (Not Found)")
            {
                return null;
            }
        }

        public async Task UpdateDeviceAsync(Guid id, Device device)
        {
            await HttpClient.PutJsonAsync($"api/devices/{id}", device);
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            await HttpClient.DeleteAsync($"api/devices/{id}");
        }

        public async Task WakeupAsync(Guid id)
        {
            await HttpClient.PostJsonAsync($"api/devices/{id}/wakeup", "");
        }
    }
}
