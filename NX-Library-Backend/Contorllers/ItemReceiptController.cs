using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;

namespace NXLibraryBackend.ItemReceiptContorller
{
    [ApiController]
    [Route("[controller]")]

    public class ItemReceiptController(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetItemReceipts")]

        public async Task<List<ItemReceipt>> GetItemReceipts()
        {
            var receipts = await _ctx.ItemReceipt
                .Include(vendor => vendor.Vendor)
                .ToListAsync();

                return receipts;
        }
    }
}
