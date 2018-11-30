﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecycleAPI.Data;
using RecycleAPI.ViewModel;

namespace RecycleAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
            List<Models.Feature> recycle_query = (from recycle in _context.Recycles
                                                        join type in _context.Types
                                                        on recycle.TypeId equals type.Id
                                                        join status in _context.Statuses
                                                        on recycle.StatusId equals status.Id
                                                        select new Models.Feature
                                                        {                                                            
                                                                Type = "Feature",
                                                                Properties = new Models.Property(
                                                                    type.Name,
                                                                    status.Name),
                                                                Geometry = new Models.MyGeometry(
                                                                    recycle.Location.GeometryType,
                                                                    recycle.Location.X,
                                                                    recycle.Location.Y)                                                            
                                                        })
                                                        .ToList();
            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return recycleFullViewModel;
        }

        // GET api/recycles/1
        [HttpGet("{typeId}")]
        public ActionResult<RecycleFullViewModel> GetByType(TypeEnum typeId)
        {
            List<Models.Feature> recycle_query = (from recycle in _context.Recycles
                                                  where recycle.TypeId.Equals(typeId)
                                                  join type in _context.Types
                                                  on recycle.TypeId equals type.Id
                                                  join status in _context.Statuses
                                                  on recycle.StatusId equals status.Id
                                                  select new Models.Feature
                                                  {
                                                      Type = "Feature",
                                                      Properties = new Models.Property(
                                                              type.Name,
                                                              status.Name),
                                                      Geometry = new Models.MyGeometry(
                                                              recycle.Location.GeometryType,
                                                              recycle.Location.X,
                                                              recycle.Location.Y)
                                                  })
                                                        .ToList();
            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return recycleFullViewModel;
        }

        // GET api/recycles/1
        [HttpGet("{statusId}")]
        public ActionResult<RecycleFullViewModel> GetByStatus(StatusEnum statusId)
        {
            List<Models.Feature> recycle_query = (from recycle in _context.Recycles
                                                  where recycle.StatusId.Equals(statusId)
                                                  join type in _context.Types
                                                  on recycle.TypeId equals type.Id
                                                  join status in _context.Statuses
                                                  on recycle.StatusId equals status.Id
                                                  select new Models.Feature
                                                  {
                                                      Type = "Feature",
                                                      Properties = new Models.Property(
                                                              type.Name,
                                                              status.Name),
                                                      Geometry = new Models.MyGeometry(
                                                              recycle.Location.GeometryType,
                                                              recycle.Location.X,
                                                              recycle.Location.Y)
                                                  })
                                                        .ToList();
            RecycleFullViewModel recycleFullViewModel = new RecycleFullViewModel
            {
                Type = "FeatureCollection",
                Features = recycle_query
            };

            return recycleFullViewModel;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}