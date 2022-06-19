using MapViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MapViewer.Controllers
{
    [Route("api/place")]
    [ApiController]
    public class PlaceController : Controller
    {
        private readonly MapViewerContext _context;

        public PlaceController(MapViewerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получить Json-представление набора мест
        /// </summary>
        /// <returns>Набор мест</returns>
        [HttpGet]
        public async Task<JsonResult> GetData()
        {
            List<Place> places = await _context.Places.ToListAsync();

                return Json(places);
        }
    }
}
