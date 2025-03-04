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
        public async Task<IActionResult> GetPurchaseOrderDetails()
        {
            try
            {
                var purchaseOrderDetails = await _purchaseOrderDetailService.GetPurchaseOrderDetails();
                return Ok(purchaseOrderDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetPurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<IActionResult> GetPurchaseOrderDetail(int purchaseOrderDetailId)
        {
            try
            {
                var purchaseOrderDetail = await _purchaseOrderDetailService.GetPurchaseOrderDetail(purchaseOrderDetailId);
                if (purchaseOrderDetail != null)
                {
                    return Ok(purchaseOrderDetail);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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
        public async Task<IActionResult> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, UpdatePurchaseOrderDetailDTO updatePurchaseOrderDetailDTO)
        {
            try 
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpDelete("DeletePurchaseOrderDetail/{purchaseOrderDetailId}")]
        public async Task<IActionResult> DeletePurchaseOrderDetail(int purchaseOrderDetailId)
        {
            try
            {
                var rslt = await _purchaseOrderDetailService.DeletePurchaseOrderDetail(purchaseOrderDetailId);
                    return Ok(rslt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}