using Microsoft.AspNetCore.Mvc;
using Three.Services;


namespace Three.Controllers{
    [Route("{controller}")]
    public class HomeControllers:Controller{
        public HomeControllers(IClock clock){
            
        }

[Route("index")]
        public JsonResult Index()
        {
            return Json("{'aa':'cc'}");
        }
    }
}