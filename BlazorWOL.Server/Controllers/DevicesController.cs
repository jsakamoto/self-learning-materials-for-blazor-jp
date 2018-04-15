using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BlazorWOL.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWOL.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/devices")]
    public class DevicesController : Controller
    {
        private DeviceStorage Storage { get; }

        public DevicesController(DeviceStorage storage)
        {
            Storage = storage;
        }

        [HttpGet]
        public IEnumerable<Device> GetDevices()
        {
            return Storage.GetDevices();
        }

        [HttpGet, Route("{guid}")]
        public IActionResult GetDevice(Guid guid)
        {
            var device = Storage.GetDevice(guid);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public IActionResult AddDevice([FromBody]Device device)
        {
            Storage.AddDevice(device);
            return Ok();
        }

        [HttpPut, Route("{guid}")]
        public IActionResult UpdateDevice(Guid guid, [FromBody]Device device)
        {
            Storage.UpdateDevice(guid, device);
            return Ok();
        }

        [HttpDelete, Route("{guid}")]
        public IActionResult DeleteDevice(Guid guid)
        {
            var deleted = Storage.DeleteDevice(guid);
            if (deleted == null) return NotFound();
            return Ok();
        }

        [HttpPost, Route("{guid}/wakeup")]
        public IActionResult WakeupDevice(Guid guid)
        {
            var device = Storage.GetDevice(guid);
            var macAddressBytes = device.MACAddress
                .Split(':')
                .Select(x => byte.Parse(x, System.Globalization.NumberStyles.HexNumber))
                .ToArray();
            IPAddress.Broadcast.SendWol(macAddressBytes);
            return Ok();
        }
    }
}