using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.Models;


namespace ResortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        public readonly DataContext _context;

        public HotelController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Hotel>> CreateEdit(HotelDto Hotels)
        {
            var hotel = new Hotel
            {
                Name = Hotels.Name,
                City = Hotels.City
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return Ok(hotel);
        }


        [HttpPut]
        public async Task<ActionResult<List<Hotel>>> Update(Hotel Hotels)
        {
            

            var Editing = await _context.Hotels.FindAsync(Hotels.Id);
            

            if (Editing == null)
            {
                return BadRequest("Can't edit non-existent record");
            }



            Editing.Name = Hotels.Name;
            Editing.City = Hotels.City;

           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data: " + ex.Message);
            }
            var hotelsList = await _context.Hotels.ToListAsync();
            return Ok(hotelsList);






        }
        [HttpDelete]

        public async Task<ActionResult<List<Hotel>>> Delete(int Id)
        {

            var Deleting = _context.Hotels.Find(Id);
            if (Deleting == null)
            {
                return BadRequest("Can't delete non-existent record"); ;
            }

            _context.Hotels.Remove(Deleting);

            await _context.SaveChangesAsync();

            string message = "Deleted successfully";

            return Ok( await _context.Hotels.ToListAsync());

        }

        [HttpGet]

        public async Task<ActionResult<List<Hotel>>> Find()
        {

            return Ok(await _context.Hotels.ToListAsync());

        }


    }
}
