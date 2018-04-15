using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorWOL.Shared;
using Microsoft.AspNetCore.Blazor;

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
            return await HttpClient.GetJsonAsync<Device[]>("/api/devices");
        }

        public async Task AddDeviceAsync(Device device)
        {
            await HttpClient.PostJsonAsync("/api/devices", device);
        }

        public async Task<Device> GetDeviceAsync(Guid guid)
        {
            try
            {
                return await HttpClient.GetJsonAsync<Device>($"/api/devices/{guid}");
            }
            catch (HttpRequestException e) when (e.Message == "404 (Not Found)")
            {
                return null;
            }
        }

        public async Task UpdateDeviceAsync(Guid guid, Device device)
        {
            await HttpClient.PutJsonAsync($"/api/devices/{guid}", device);
        }

        public async Task DeleteDeviceAsync(Guid guid)
        {
            await HttpClient.DeleteAsync($"/api/devices/{guid}");
        }

        public async Task WakeupAsync(Guid guid)
        {
            await HttpClient.PostJsonAsync($"/api/devices/{guid}/wakeup", "");
        }
    }
}
