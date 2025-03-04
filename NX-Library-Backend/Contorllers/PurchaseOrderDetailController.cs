using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;

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

    }
}
