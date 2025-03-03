using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NXLibraryBackend.Data;
using NX_Library_Backend.Interfaces;
using Models;
using DTOs;

namespace NX_Library_Backend.Services
{
    public class VendorServices : IVendorController
    {
        private readonly NXLibDbContext _context;
        public VendorServices(NXLibDbContext context)
        {
            _context = context;
        }
        public async Task<List<Vendor>> GetVendors()
        {
            return await _context.Vendors.ToListAsync();
        }
        public async Task<Vendor?> GetVendor(int vendorId)
        {
            return await _context.Vendors.FindAsync(vendorId);
        }
        public async Task<ActionResult> AddVendor(AddVendorDTO vendorDto)
        {
            var vendor = new Vendor
            {
                Name = vendorDto.Name,
            };
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
        public async Task<ActionResult> UpdateVendor(int vendorId, UpdateVendorDTO vendorDTO)
        {
            var vendor = await _context.Vendors.FindAsync(vendorId);
            if (vendor != null)
            {
                vendor.Name = vendorDTO.Name;

                _context.Vendors.Update(vendor);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
        public async Task<ActionResult> DeleteVendor(int vendorId)
        {
            var vendor = await _context.Vendors.FindAsync(vendorId);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}