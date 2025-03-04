using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;



namespace NXLibraryBackend.ItemReceiptDetailContorller
{

    [ApiController]
    [Route("[controller]")]
    public class ItemReceiptDetailController(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetItemReceiptDetails")]

        public async Task<List<ItemReceiptDetail>> GetItemReceiptDetails()
        {
            var receiptDetails = await _ctx.ItemReceiptDetail
                .Include(vendor => vendor.Vendor)
                .Include(book => book.Book)
                .ToListAsync();

            return receiptDetails;
        }

        [HttpGet("GetItemReceiptDetails/{ItemReceiptDetailId}")]

        public async Task<ItemReceiptDetail?> GetItemReceiptDetail(int ItemReceiptDetailId)
        {
            var rslt = from c in _ctx.ItemReceiptDetail
                       where c.Id == ItemReceiptDetailId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("AddItemReceiptDetail")]

        public async Task<ActionResult> AddItemReceiptDetail(ItemReceiptDetail itemReceiptDetail)
        {
            _ctx.ItemReceiptDetail.Add(itemReceiptDetail);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/DeleteItemReceiptDetail/{ItemReceiptDetailId}")]

        public async Task<ActionResult> DeleteItemReceiptDetail(int ItemReceiptDetailId)
        {
            var rslt = from c in _ctx.ItemReceiptDetail
                       where c.Id == ItemReceiptDetailId
                       select c;
            ItemReceiptDetail? itemReceiptDetail = await rslt.FirstOrDefaultAsync();
            if(itemReceiptDetail != null)
            {
                _ctx.ItemReceiptDetail.Remove(itemReceiptDetail);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
