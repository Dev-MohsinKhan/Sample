using InterviewTask.Models;
using InterviewTask.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTask.Controllers
{
    public class RecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecordsController(ApplicationDbContext context)
        {

            _context = context;
        }
        // GET: RecordsController
        public ActionResult Index()
        {
            var regions = _context.Regions.ToList();
            var wiliyats = _context.Wiliyats.ToList();
            var areas = _context.Areas.ToList();
            var villages = _context.Villages.ToList();
            var entityTypes = _context.EntityType.ToList();

            var viewModel = new Records
            {
                Regions = regions,
                Wiliyats = wiliyats,
                Areas = areas,
                Villages = villages,
                EntityType = entityTypes
            };
            return View(viewModel);
        }
        public JsonResult GetWiliyatsByRegion(int regionId)
        {
            var wiliyats = _context.Wiliyats.Where(w => w.RegionId == regionId).ToList();
            return Json(wiliyats);
        }

        public JsonResult GetAreasByWiliyat(int wiliyatId)
        {
            var areas = _context.Areas.Where(a => a.WiliyatId == wiliyatId).ToList();
            return Json(areas);
        }

        public JsonResult GetVillagesByArea(int areaId)
        {
            var villages = _context.Villages.Where(v => v.AreaId == areaId).ToList();
            return Json(villages);
        }

        [HttpPost]
        public ActionResult SaveSelection(Records model)
        {

            if (model.SelectedRegionId != null
                && model.SelectedVillageId != null
                && model.SelectedAreaId != null
                && model.SelectedAreaId != null
                && model.DetailsODE != null
                && model.Email != null
                && model.PhoneNumber != null
                && model.SelectedEntityTypeID != null
                && model.Remarks != null)
            {
                var regionName = _context.Regions.Where(a => a.Id == model.SelectedRegionId).FirstOrDefault();
                var willayaName = _context.Wiliyats.FirstOrDefault(w => w.Id == model.SelectedWiliyatId);
                var areaName = _context.Areas.FirstOrDefault(a => a.Id == model.SelectedAreaId);
                var villageName = _context.Villages.FirstOrDefault(v => v.Id == model.SelectedVillageId);
                var entityTypeName = _context.EntityType.FirstOrDefault(e => e.Id == model.SelectedEntityTypeID);

                var newItem = new Item
                {
                    Name = model.Name ?? "",
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    EntityType = model.SelectedEntityTypeID, // Use the correct field from the model
                    Region = model.SelectedRegionId,
                    RegionName = regionName.Name,
                    WillayaName = willayaName.Name,
                    EntityTypeName = entityTypeName.Name,
                    AreaName = areaName.Name,
                    VillageName = villageName.Name,
                    Willaya = model.SelectedWiliyatId,
                    Area = model.SelectedAreaId,
                    Village = model.SelectedVillageId,
                    DetailsODE = model.DetailsODE,
                    Remarks = model.Remarks
                };

                // Add the new item to the database
                _context.Item.Add(newItem);
                _context.SaveChanges(); // 

                TempData["SuccessMessage"] = "Record saved successfully!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                //{
                //    ModelState.AddModelError(string.Empty, error.ErrorMessage);
                ////}
                //TempData["ErrorMessage"] = ModelState.Values.FirstOrDefault(a=>a.Errors.FirstOrDefault(a => a.ErrorMessage.FirstOrDefault()));
                var errorMessage = ModelState.Values
    .SelectMany(v => v.Errors) // Flatten the list of errors
    .Select(e => e.ErrorMessage) // Select the error messages
    .FirstOrDefault(msg => !string.IsNullOrEmpty(msg)); // Find the first non-empty message

                TempData["ErrorMessage"] = "Form not Filled Properly, Please add proper information";


                return RedirectToAction("Index", "Home");
            }
            // Handle form submission
            //return View("Index", model); // or redirect to another page
        }


        public ActionResult ListAll(Records records)
        {

            var regions = _context.Regions.ToList();
            var wiliyats = _context.Wiliyats.ToList();
            var areas = _context.Areas.ToList();
            var villages = _context.Villages.ToList();

            var itemsList = _context.Item.ToList();


            if (records.SelectedVillageId > 0)
                itemsList = itemsList.Where(a => a.Village == records.SelectedVillageId).ToList();
            if (records.SelectedRegionId > 0)
                itemsList = itemsList.Where(a => a.Region == records.SelectedRegionId).ToList();
            if (records.SelectedWiliyatId > 0)
                itemsList = itemsList.Where(a => a.Willaya == records.SelectedWiliyatId).ToList();
            if (records.SelectedAreaId > 0)
                itemsList = itemsList.Where(a => a.Area == records.SelectedAreaId).ToList();


            var viewModel = new Records
            {
                Regions = regions,
                Wiliyats = wiliyats,
                Areas = areas,
                Villages = villages,
                Items = itemsList

            };

            //var itemsList = itemsListFiltered;
            return View(viewModel);



        }
        //itemsList = itemsListF

        //return View();
    }

}

