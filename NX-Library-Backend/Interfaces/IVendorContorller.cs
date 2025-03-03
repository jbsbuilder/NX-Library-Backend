using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces
{
    public interface IVendorController
    {
        Task<List<Vendor>> GetVendors();
        Task<Vendor?> GetVendor(int vendorId);
        Task<ActionResult> AddVendor(AddVendorDTO vendor);
        Task<ActionResult> UpdateVendor(int vendorId, UpdateVendorDTO vendorDto);
        Task<ActionResult> DeleteVendor(int vendorId);
    }
}