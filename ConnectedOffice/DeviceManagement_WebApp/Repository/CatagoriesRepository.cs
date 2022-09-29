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
    public class CatagoriesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // GET: Categories
        public List<Category> GetAll()
        {
            return  _context.Category.ToList();
        }

        // GET: Categories/Details/5
        public async Task<Category> GetById(Guid? id)
        {
            
            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);
            
            return (category);
        }

        public IEnumerable<Category> Create()
        {
            return _context.Category.ToList();
        }

        public async Task<Category> Edit(Guid? id)
        {

            var category = await _context.Category.FindAsync(id);
            
            return (category);
        }

        public async Task<Category> Delete(Guid? id)
        {
          
            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
           
            return (category);
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
