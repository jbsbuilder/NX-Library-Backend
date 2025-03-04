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

        [HttpGet("GetItemReceipts/{ItemReceiptId}")]
        public async Task<ItemReceipt?> GetItemReceipt(int ItemReceiptId)
        {
            var rslt = from c in _ctx.ItemReceipt
                       where c.Id == ItemReceiptId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("AddItemReceipt")]

        public async Task<ActionResult> AddItemReceipt(ItemReceipt itemReceipt)
        {
            _ctx.ItemReceipt.Add(itemReceipt);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/DeleteItemReceipt/{ItemReceiptId}")]

        public async Task<ActionResult> DeleteItemReceipt(int ItemReceiptId)
        {
            var rslt = from c in _ctx.ItemReceipt
                       where c.Id == ItemReceiptId
                       select c;
            ItemReceipt? itemReceipt = await rslt.FirstOrDefaultAsync();
            if(itemReceipt != null)
            {
                _ctx.ItemReceipt.Remove(itemReceipt);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
