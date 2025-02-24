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
    public class PODetails(NXLibDbContext _ctx): ControllerBase
    {
        [HttpGet("/GetPODetails")]
        public async Task<List<PODetail>> GetPODetails()
        {
            var poDetails = await _ctx.PODetail
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
