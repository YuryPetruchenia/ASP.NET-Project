using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Clietn.PresentationService.Interface;
using Data;
using DomainLogic.Model;

namespace Clietn.Controllers
{
    [Authorize]
    public partial class HomeController : Controller
    {
        private readonly ITrackPresentationService trackPresentationService;
        private readonly IGenrePresentationService genrePresentationService;

        public HomeController(ITrackPresentationService trackPresentationService, IGenrePresentationService genrePresentationService)
        {
            this.genrePresentationService = genrePresentationService;
            this.trackPresentationService = trackPresentationService;
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Subscription")]
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}