using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using NX_Library_Backend.Interfaces;

namespace NXLibraryBackend.PurchaseOrderDetailController
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class PurchaseOrderDetailContorller : ControllerBase
    {
        private readonly IPurchaseOrderDetailController _purchaseOrderDetailService;
        public PurchaseOrderDetailContorller (IPurchaseOrderDetailController purchaseOrderDetailService)
        {
            _purchaseOrderDetailService = purchaseOrderDetailService;
        }
        [HttpGet("GetPurchaseOrderDetails")]
        public async Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetails()
        {
            return await _purchaseOrderDetailService.GetPurchaseOrderDetails();
        }
        [HttpGet("GetPurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<PurchaseOrderDetail?> GetPurchaseOrderDetail(int purchaseOrderDetailId)
        { 
            return await _purchaseOrderDetailService.GetPurchaseOrderDetail(purchaseOrderDetailId);
        }
        //Needs a builder method <--------------------------------
        //[HttpPost("AddPurchaseOrderDetail")]
        //public async Task<ActionResult> AddPurchaseOrderDetail(AddPurchaseOrderDetailDTO addPurchaseOrderDetailDTO)
        //{
        //    var puchaseOrderDetail = new PurchaseOrderDetail
        //    {
        //        //PurchaseOrderId = addPurchaseOrderDetailDTO.VendorId, 
        //        BookId = addPurchaseOrderDetailDTO.BookId,
        //        QTY = addPurchaseOrderDetailDTO.QTY,
        //        Price = addPurchaseOrderDetailDTO.Price
        //    };
        //    if (puchaseOrderDetail != null)
        //    {
        //        return await _purchaseOrderDetailService.AddPurchaseOrderDetail(puchaseOrderDetail);
        //    }
        //    return new BadRequestResult();
        //}
        [HttpPut("UpdatePurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<ActionResult> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, UpdatePurchaseOrderDetailDTO updatePurchaseOrderDetailDTO)
        {
            var purchaseOrderDetail = new PurchaseOrderDetail
            {
                PurchaseOrderId = updatePurchaseOrderDetailDTO.PurchaseOrderId,
                QTY = updatePurchaseOrderDetailDTO.QTY,
            };
            if (purchaseOrderDetail != null)
            {
                return await _purchaseOrderDetailService.UpdatePurchaseOrderDetail(purchaseOrderDetailId, updatePurchaseOrderDetailDTO);
            }
            return new BadRequestResult();
        }
        [HttpDelete("DeletePurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<ActionResult> DeletePurchaseOrderDetail(int purchaseOrderDetailId)
        {
            return await _purchaseOrderDetailService.DeletePurchaseOrderDetail(purchaseOrderDetailId);
        }
    }
}