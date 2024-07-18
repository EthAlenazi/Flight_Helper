using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO.Pipelines;
using TripSite.Models;
using TripSite.ViewModel;
using WebAPI.DTO;
using WebAPI.Services;

namespace TripSite.Controllers
{
    public class UserTripController : Controller
    {
        #region ctor
        private readonly ITransportTypeService _transportTypeService;
        private readonly IActivityTypeService _activityType;
        private readonly IDestinationService _destination;
        private readonly IAddServices _addService;
        private readonly ITripServices _tripsService;
        private readonly IAccommodationTypeService _accommodationType;
        private readonly IPdfService _pdfService;
        private readonly IMapper _mapper;
        public UserTripController(ITransportTypeService transportTypeService,IAddServices addService,
            ITripServices tripsService, IDestinationService destination,
            IAccommodationTypeService accommodationType, IActivityTypeService activityType,
            IPdfService pdfService)
        {
            _transportTypeService = transportTypeService;
            _addService = addService;
            _tripsService = tripsService;
            _destination = destination;
            _accommodationType = accommodationType;
            _activityType = activityType;
            _pdfService = pdfService;
        }
        #endregion

        [HttpGet]
        public IActionResult Create()
        {
            var model = new TripCreateDTO
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
               
            }; 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TripCreateDTO model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //var data = _mapper.Map<TripCreateDTO>(model);
                var result = await _tripsService.CreateTripAsync(model);

                if (result.Error != Errors.Success)
                    return BadRequest(result.ErrorMessage);

                return RedirectToAction("AddDestination", new { tripId = result.Result.TripId });
                //}
            }
            catch
            {
                return View(model);
            }
            // If validation fails, redisplay the form
            //

        }

        [HttpGet]
        public IActionResult AddDestination(int tripId)
        {
            var model = new DestinationDTO
            {
                TripID = tripId,
                ArrivalDate= DateTime.Now,
                DepartureDate= DateTime.Now.AddDays(6),
            };
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> AddDestination(DestinationDTO model)
        {
            if (ModelState.IsValid)
            {
               await _destination.AddDestinationAsync(model);
                return RedirectToAction("AddTransport", new { tripId = model.TripID });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTransport(int tripId)
        {
            var transportTypes = await _transportTypeService.GetAllTransportTypesAsync();
            var model = new TransportViewModel
            {
                TripID = tripId,
                TransportTypes = transportTypes.Results.Select(tt => new SelectListItem
                {
                    Value = tt.Id.ToString(),
                    Text = $"  {tt.Name}  - Cost : {tt.Cost}  , Description : {tt.Description} "
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransport(TransportViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _addService.AddTransportAsync(model);
                return RedirectToAction("AddAccommodation", new { tripId = model.TripID });
            }

            var transportTypes = await _transportTypeService.GetAllTransportTypesAsync();
            model.TransportTypes = transportTypes.Results.Select(tt => new SelectListItem
            {
                Value = tt.Id.ToString(),
                Text = $"  {tt.Name}  - Cost : {tt.Cost}  , Description : {tt.Description} "
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddAccommodation(int tripId)
        {
            var transportTypes = await _accommodationType.GetAllAccommodationTypesAsync();
            var model = new AccommodationViweModel
            {
                TripID = tripId,
                AccommodationTypes = transportTypes.Results.Select(tt => new SelectListItem
                {
                    Value = tt.Name.ToString(),
                    Text = $"  {tt.Name}  - Address : {tt.Address}  ,Cost  : {tt.Cost}"
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccommodation(AccommodationViweModel model)
        {
            if (ModelState.IsValid)
            {

                await _addService.AddAccommodationAsync(model);
                return RedirectToAction("AddActivity", new { tripId = model.TripID });
            }

            var transportTypes = await _accommodationType.GetAllAccommodationTypesAsync();
            model.AccommodationTypes = transportTypes.Results.Select(tt => new SelectListItem
            {
                Value = tt.Name.ToString(),
                Text = $"  {tt.Name}  - Address : {tt.Address}  ,Cost  : {tt.Cost}"
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddActivity(int tripId)
        {
            var transportTypes = await _activityType.GetAllActivityTypesAsync();
            var model = new ActivityDTO
            {
                TripID = tripId,
                ActivityTypes = transportTypes.Results.Select(tt => new SelectListItem
                {
                    Value = tt.Name.ToString(),
                    Text = $"  {tt.Name}  - Description : {tt.Description}  ,Cost  : {tt.Cost}"
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(ActivityDTO model)
        {
            if (ModelState.IsValid)
            {

                await _addService.AddActivityAsync(model);
                return RedirectToAction("GeneratePdf", new { tripId = model.TripID });
            }

            var transportTypes = await _activityType.GetAllActivityTypesAsync();
            model.ActivityTypes = transportTypes.Results.Select(tt => new SelectListItem
            {
                Value = tt.Name.ToString(),
                Text = $"  {tt.Name}  - Description : {tt.Description}  ,Cost  : {tt.Cost}"
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult GeneratePdf()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePdf(int  tripID)
        {
            if (ModelState.IsValid)
            {
                var trip =await _tripsService.GetTripWithDetailsAsync(tripID);

                byte[] pdfBytes = _pdfService.GenerateTripPdf(trip.Result);
                return File(pdfBytes, "application/pdf", "TripDetails.pdf");
            }

            return View(tripID);
        }

    }
}
