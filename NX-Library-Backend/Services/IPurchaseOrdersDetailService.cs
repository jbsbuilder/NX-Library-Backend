using DTOs;
using Models;
using NX_Library_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NXLibraryBackend.Data;

namespace NX_Library_Backend.Services
{
    public class PurchaseOrdersDetailServices : IPurchaseOrderDetailController
    {
        private readonly NXLibDbContext _context;

        public PurchaseOrdersDetailServices(NXLibDbContext context)
        {
            _context = context;
        }

        public async Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetails()
        {
            return await _context.PurchaseOrderDetails.ToListAsync();
        }

        public async Task<PurchaseOrderDetail?> GetPurchaseOrderDetail(int purchaseOrderDetailId)
        {
            return await _context.PurchaseOrderDetails.FindAsync(purchaseOrderDetailId);
        }

        public async Task<ActionResult> AddPurchaseOrderDetail(AddPurchaseOrderDetailDTO purchaseOrderDetail)
        {
            var purchaseOrder = new PurchaseOrderDetail
            {
                PurchaseOrderId = purchaseOrderDetail.VendorId,
                BookId = purchaseOrderDetail.BookId,
                QTY = purchaseOrderDetail.QTY,
                Price = purchaseOrderDetail.Price
            };
            _context.PurchaseOrderDetails.Add(purchaseOrder);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, UpdatePurchaseOrderDetailDTO updatePurchaseOrderDetailDTO)
        {
            var purchaseOrder = await _context.PurchaseOrderDetails.FindAsync(purchaseOrderDetailId);
            if (purchaseOrder == null)
            {
                return new NotFoundResult();
            }

            purchaseOrder.PurchaseOrderId = updatePurchaseOrderDetailDTO.PurchaseOrderId;
            purchaseOrder.QTY = updatePurchaseOrderDetailDTO.QTY;

            _context.PurchaseOrderDetails.Update(purchaseOrder);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<ActionResult> DeletePurchaseOrderDetail(int purchaseOrderDetailId)
        {
            var purchaseOrder = await _context.PurchaseOrderDetails.FindAsync(purchaseOrderDetailId);
            if (purchaseOrder != null)
            {
                _context.PurchaseOrderDetails.Remove(purchaseOrder);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            return new NotFoundResult();
        }
    }
}