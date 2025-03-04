using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;

namespace NXLibraryBackend.PurchaseOrderContorller
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController(NXLibDbContext _ctx) : Controller
    {
        [HttpGet("GetItemReceiptDetails")]

        public async Task<List<PurchaseOrder>> GetPurchaseOrders()
        {
            var purchaseOrders = await _ctx.PurchaseOrder
                .Include(vendor => vendor.Vendor)
                .ToListAsync();
            return purchaseOrders;
        }

        public async Task<PurchaseOrder?> GetPurchaseOrder(int purchaseOrderId)
        {
            var rslt = from c in _ctx.PurchaseOrder
                       where c.Id == purchaseOrderId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("AddPurchaseOrder")]

        public async Task<ActionResult> AddPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            _ctx.PurchaseOrder.Add(purchaseOrder);
            await _ctx.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeletePurchaseOrder/{PurchaseOrderId}")]
        public async Task<ActionResult> DeletePurchaseOrder(int purchaseOrderId)
        {
            var rslt = from c in _ctx.PurchaseOrder
                       where c.Id == purchaseOrderId
                       select c;
            PurchaseOrder? PurchaseOrder = await rslt.FirstOrDefaultAsync();
            if(PurchaseOrder != null)
            {
                _ctx.PurchaseOrder.Remove(PurchaseOrder);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
