using Microsoft.AspNetCore.Mvc;
using Models;
using DTOs;

namespace NX_Library_Backend.Interfaces
{
    public interface IPurchaseOrderDetailController
    {
        Task<List<PurchaseOrderDetail>> GetPurchaseOrderDetails();
        Task<PurchaseOrderDetail?> GetPurchaseOrderDetail(int purchaseOrderDetailId);
        Task<ActionResult> AddPurchaseOrderDetail(AddPurchaseOrderDetailDTO purchaseOrderDetail);
        Task<ActionResult> UpdatePurchaseOrderDetail(int purchaseOrderDetailId, UpdatePurchaseOrderDetailDTO purchaseOrderDetailDto);
        Task<ActionResult> DeletePurchaseOrderDetail(int purchaseOrderDetailId);
    }
}
