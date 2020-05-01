using System;
using System.Collections.Generic;
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

        [HttpGet, Route("{id}")]
        public IActionResult GetDevice(Guid id)
        {
            var device = Storage.GetDevice(id);
            if (device == null) return NotFound();
            return Ok(device);
        }

        [HttpPost]
        public IActionResult AddDevice([FromBody]Device device)
        {
            Storage.AddDevice(device);
            return Ok();
        }

        [HttpPut, Route("{id}")]
        public IActionResult UpdateDevice(Guid id, [FromBody]Device device)
        {
            Storage.UpdateDevice(id, device);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public IActionResult DeleteDevice(Guid id)
        {
            var deleted = Storage.DeleteDevice(id);
            if (deleted == null) return NotFound();
            return Ok();
        }
    }
}