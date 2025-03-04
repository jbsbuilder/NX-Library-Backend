using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;
using Microsoft.Extensions.Localization;

namespace NX_Library_Backend.PurchaseOrderDetailContorllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class PurchaseOrderDetailsController(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetPurchaseOrderDetails")]
        public async Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetails()
        {
            var purchaseDetails = await _ctx.PurchaseOrderDetail
                .Include(purchaseOrder => purchaseOrder.PurchaseOrder)
                .Include(book => book.Book)
                .ToListAsync();
            return purchaseDetails;
        }

        [HttpGet("GetPurchaseOrderDetails/{PurchaseOrderDetailId}")]

        public async Task<PurchaseOrderDetail?> GetPurchaseOrderDetail(int PurchaseOrderDetailId)
        {
            var rslt = from c in _ctx.PurchaseOrderDetail
                       where c.Id == PurchaseOrderDetailId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("AddPurchaseOrderDetail")]

        public async Task<ActionResult> AddPurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail)
        {
            _ctx.PurchaseOrderDetail.Add(purchaseOrderDetail);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/DeletePurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<ActionResult> DeletePurchaseOrderDetail(int purchaseOrderDetailId)
        {
            var rslt = from c in _ctx.PurchaseOrderDetail
                       where c.Id == purchaseOrderDetailId
                       select c;
            PurchaseOrderDetail? purchaseOrderDetail = await rslt.FirstOrDefaultAsync();
            if(purchaseOrderDetail != null)
            {
                _ctx.PurchaseOrderDetail.Remove(purchaseOrderDetail);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
