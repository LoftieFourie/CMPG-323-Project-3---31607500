using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

       

        // GET: Devices
        public List<Device> GetAll()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return _context.Device.ToList();
        }

        // GET: Devices/Details/5
        public async Task<Device> GetById(Guid? id)
        {
            
            var device = await _context.Device.Include(d => d.Category).Include(d => d.Zone).FirstOrDefaultAsync(m => m.DeviceId == id);
            

            return (device);
        }

        public IEnumerable<Device> Create()
        {
            new SelectList(_context.Category, "CategoryId", "CategoryName");
            new SelectList(_context.Zone, "ZoneId", "ZoneName");
            return _context.Device.ToList(); ;
        }

        public async Task<Device> Edit(Guid? id)
        {
            
            var device = await _context.Device.FindAsync(id);
            
            new SelectList(_context.Category, "CategoryId", "CategoryName", device.CategoryId);
            new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);
            return (device);
        }

        public async Task<Device> Delete(Guid? id)
        {
            
            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            return (device);
        }

        private bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
