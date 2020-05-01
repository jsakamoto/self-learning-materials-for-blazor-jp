using System;

namespace BlazorWOL.Shared
{
    public class Device
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string MACAddress { get; set; }
    }
}
