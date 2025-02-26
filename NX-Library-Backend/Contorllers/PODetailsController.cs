using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NX_Library_Backend.Data;
using Models;
using NXLibraryBackend.Data;
using DTOs;

namespace NX_Library_Backend.PODetailsContorllers
{
    [ApiController]
    [Route("[controller]")]
    public class PODetails(NXLibDbContext _ctx) : ControllerBase
    {
        [HttpGet("/GetPODetails")]
        public async Task<List<PODetail>> GetPODetails()
        {
            var poDetails = await _ctx.PODetail
                .Include(p => p.PONumber!)
                .ThenInclude(po => po.Vendor!)
                .Include(p => p.Book!)
                .ThenInclude(po => po.BookAuthor!) //fix to include the author
                .ToListAsync();
            return poDetails;
        }

        [HttpGet("/GetPODetail/{PODetailId}")]
        public async Task<PODetail?> GetPODetail(int PODetailId)
        {
            var rslt = from c in _ctx.PODetail
                       where c.Id == PODetailId
                       select c;
            return await rslt.FirstOrDefaultAsync();
        }

        [HttpPost("/AddPODetail")]
        public async Task<ActionResult<PODetail>> AddPODetail(AddPODTO poDetail)
        {
            var maxPONumber = await _ctx.PONumber.MaxAsync(po => po.PONumbers);
            var poNumber = new PONumber
            {
                PONumbers = maxPONumber + 1,
                Vendor = await _ctx.Vendor.FindAsync(poDetail.VendorId)
            };
            var book = await _ctx.Books.FindAsync(poDetail.BookId);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            var newPODetail = new PODetail
            {
                PONumber = poNumber,
                Book = book,
                Quantity = poDetail.Quantity ?? book.Copies,
                Price = poDetail.Price * poDetail.Quantity
            };

            _ctx.PODetail.Add(newPODetail);


            _ctx.PONumber.Add(poNumber);
            await _ctx.SaveChangesAsync();
            return newPODetail;
        }

        [HttpPut("/UpdatePODetail/{poDetailId}")]
        public async Task<ActionResult<PODetail>> UpdatePODetail(int poDetailId, [FromBody] UpdatePODTO poDto)
        {
            var poDetail = await _ctx.PODetail
                .Include(p => p.PONumber)
                    .ThenInclude(po => po.Vendor!)
                .Include(p => p.Book)
                    .ThenInclude(po => po.BookAuthor!)
                .FirstOrDefaultAsync(p => p.Id == poDetailId);
            if (poDetail == null)
            {
                return NotFound();
            }

            poDetail.PONumber.VendorId = poDto.VendorId;
            poDetail.BookId = poDto.BookId;
            poDetail.Quantity = poDto.Quantity;
            poDetail.Price = poDto.Price * poDto.Quantity;


            _ctx.PODetail.Update(poDetail);
            await _ctx.SaveChangesAsync();
            return Ok();


        }


        [HttpDelete("/DeleteBook{PODetailId}")]
        public async Task<ActionResult> DeletePODetail(int PODetailId)
        {
            var rslt = from c in _ctx.PODetail
                       where c.Id == PODetailId
                       select c;
            PODetail? poDetail = await rslt.FirstOrDefaultAsync();
            if (poDetail != null)
            {
                _ctx.PODetail.Remove(poDetail);
                await _ctx.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
