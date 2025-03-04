using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using NX_Library_Backend.Interfaces;

namespace NX_Library_Backend.Contorllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class VendorController : ControllerBase
    {
        private readonly IVendorController _vendorService;
        public VendorController(IVendorController vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("GetVendors")]
        public async Task<IActionResult> GetVendors()
        {
            try
            {
                var vendors = await _vendorService.GetVendors();
                return Ok(vendors);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetVendor/{vendorId}")]
        public async Task<IActionResult> GetVendor(int vendorId)
        {
            try
            {
                var vendor = await _vendorService.GetVendor(vendorId);
                if (vendor != null)
                {
                    return Ok(vendor);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddVendor")]
        public async Task<IActionResult> AddVendor(AddVendorDTO addVendorDto)
        {
            try
            {
                var result = await _vendorService.AddVendor(addVendorDto);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("UpdateVendor/{vendorId}")]
        public async Task<IActionResult> UpdateVendor(int vendorId, UpdateVendorDTO updateVendorDto)
        {
            try
            {
                var result = await _vendorService.UpdateVendor(vendorId, updateVendorDto);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("DeleteVendor/{vendorId}")]
        public async Task<IActionResult> DeleteVendor(int vendorId)
        {
            try
            {
                var result = await _vendorService.DeleteVendor(vendorId);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
