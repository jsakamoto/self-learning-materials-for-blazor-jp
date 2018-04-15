using System;
using System.Collections.Generic;
using System.IO;
using BlazorWOL.Shared;
using Newtonsoft.Json;

namespace BlazorWOL.Server
{
    public class DeviceStorage
    {
        private string StoragePath { get; }

        private List<Device> Devices { get; } = new List<Device>();

        public DeviceStorage(string storagePath)
        {
            StoragePath = storagePath;
            if (File.Exists(StoragePath))
            {
                var json = File.ReadAllText(StoragePath);
                Devices.AddRange(JsonConvert.DeserializeObject<Device[]>(json));
            }
        }

        public List<Device> GetDevices()
        {
            lock (this) return Devices;
        }

        public void AddDevice(Device device)
        {
            lock (this)
            {
                this.Devices.Add(device);
                FlushToStorage();
            }
        }

        public Device GetDevice(Guid guid)
        {
            lock (this) return Devices.Find(dev => dev.Guid == guid);
        }

        public void UpdateDevice(Guid id, Device device)
        {
            lock (this)
            {
                var updateTo = GetDevice(id);
                updateTo.Name = device.Name;
                updateTo.MACAddress = device.MACAddress;
                FlushToStorage();
            }
        }

        public Device DeleteDevice(Guid id)
        {
            lock (this)
            {
                var device = GetDevice(id);
                if (device != null) Devices.Remove(device);
                FlushToStorage();
                return device;
            }
        }

        private void FlushToStorage()
        {
            lock (this)
            {
                var json = JsonConvert.SerializeObject(Devices);
                File.WriteAllText(StoragePath, json);
            }
        }
    }
}
