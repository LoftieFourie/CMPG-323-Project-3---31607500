using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();
        

        // GET: Zones
        public List<Zone> GetAll()
        {
            return _context.Zone.ToList();
        }

        // GET: Zones/Details/5
        public async Task<Zone> GetById(Guid? id)
        {

            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);

            return (zone);
        }

        public IEnumerable<Zone> Create()
        {
            return _context.Zone.ToList();
        }

        public async Task<Zone> Edit(Guid? id)
        {
            var zone = await _context.Zone.FindAsync(id);
            
            return (zone);
        }

        public async Task<Zone> Delete(Guid? id)
        {

            var zone = await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);

            return (zone);
        }

        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

    }
}
