using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoAPI.Geometries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using RecycleAPI.Data;
using RecycleAPI.Data.Entities;
using RecycleAPI.ViewModel;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecyclesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/recycles
        [HttpGet]
        public ActionResult<RecycleFullViewModel> GetAll()
        {
            List<Models.Feature> recycle_query;

            recycle_query = (from recycle in _context.Recycles
                             join type in _context.Types
                             on recycle.TypeId equals type.Id
                             join status in _context.Statuses
                             on recycle.StatusId equals status.Id
                             select new Models.Feature
                             {
                                 Type = "Feature",
                                 Properties = new Models.Property(
                                         recycle.Id,
                                         type.Name,
                                         status.Name),
                                 Geometry = new Models.MyGeometry(
                                         recycle.Location.GeometryType,
                                         recycle.Location.X,
                                         recycle.Location.Y)
                             })
                         .ToList();

            if (recycle_query.Count() == 0)
            {
                return NotFound();
            }


            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return recycleFullViewModel;
        }

        // GET api/recycles/1
        [HttpGet("{id}", Name = "getRecycle")]
        public ActionResult<RecycleFullViewModel> GetById(string id)
        {
            List<Models.Feature> recycle_query = (from recycle in _context.Recycles
                                                  where recycle.Id.Equals(id.Trim())
                                                  join type in _context.Types
                                                  on recycle.TypeId equals type.Id
                                                  join status in _context.Statuses
                                                  on recycle.StatusId equals status.Id
                                                  select new Models.Feature
                                                  {
                                                      Type = "Feature",
                                                      Properties = new Models.Property(
                                                              recycle.Id,
                                                              type.Name,
                                                              status.Name),
                                                      Geometry = new Models.MyGeometry(
                                                              recycle.Location.GeometryType,
                                                              recycle.Location.X,
                                                              recycle.Location.Y)
                                                  })
                                                        .ToList();

            if (recycle_query.Count() == 0)
            {
                return NotFound();
            }

            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return Ok(recycleFullViewModel);
        }

        // GET api/recycles/1
        [HttpGet]
        [Route("getByType/{typeId}")]
        public ActionResult<RecycleFullViewModel> GetByType(TypeEnum typeId)
        {
            List<Models.Feature> recycle_query;

            recycle_query = (from recycle in _context.Recycles
                             where recycle.TypeId == typeId
                             join type in _context.Types
                             on recycle.TypeId equals type.Id
                             join status in _context.Statuses
                             on recycle.StatusId equals status.Id
                             select new Models.Feature
                             {
                                 Type = "Feature",
                                 Properties = new Models.Property(
                                         recycle.Id,
                                         type.Name,
                                         status.Name),
                                 Geometry = new Models.MyGeometry(
                                         recycle.Location.GeometryType,
                                         recycle.Location.X,
                                         recycle.Location.Y)
                             })
                         .ToList();

            if (recycle_query.Count() == 0)
            {
                return NotFound();
            }

            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return recycleFullViewModel;
        }

        // GET api/recycles/1
        [HttpGet("{statusId}")]
        [Route("getByStatus/{statusId}")]
        public ActionResult<RecycleFullViewModel> GetByStatus(StatusEnum statusId)
        {
            List<Models.Feature> recycle_query;

            recycle_query = (from recycle in _context.Recycles
                             where recycle.StatusId.Equals(statusId)
                             join type in _context.Types
                             on recycle.TypeId equals type.Id
                             join status in _context.Statuses
                             on recycle.StatusId equals status.Id
                             select new Models.Feature
                             {
                                 Type = "Feature",
                                 Properties = new Models.Property(
                                         recycle.Id,
                                         type.Name,
                                         status.Name),
                                 Geometry = new Models.MyGeometry(
                                         recycle.Location.GeometryType,
                                         recycle.Location.X,
                                         recycle.Location.Y)
                             })
                         .ToList();

            if (recycle_query.Count() == 0)
            {
                return NotFound();
            }

            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return Ok(recycleFullViewModel);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync(RecycleViewModel recycleViewModel)
        {
            IGeometry geometry = new Point(recycleViewModel.Longitude, recycleViewModel.Latitude)
            {
                SRID = 4326
            };
            Recycle recycle = new Recycle
            {
                Location = geometry.PointOnSurface,
                CreatedOn = recycleViewModel.CreatedOn,
                StatusId = recycleViewModel.StatusId,
                TypeId = recycleViewModel.TypeId
            };
            _context.Recycles.Add(recycle);
            await _context.SaveChangesAsync();
            return CreatedAtRoute("getRecycle", new { id = recycle.Id }, recycleViewModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id, RecycleViewModel recycleViewModel)
        {
            if (id != recycleViewModel.Id)
            {
                return BadRequest();
            }
            Recycle recycle = await _context.Recycles.FindAsync(id);

            recycle.StatusId = recycleViewModel.StatusId;
            recycle.TypeId = recycleViewModel.TypeId;

            _context.Recycles.Update(recycle);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
