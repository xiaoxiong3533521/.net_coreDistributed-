using Microsoft.AspNetCore.Mvc;
using Three.Services;


namespace Three.Controllers{

    public class HomeController:Controller{
        public HomeController(IClock clock){
            
        }


        public JsonResult Index()
        {
            return Json("{'aa':'cc'}");
        }

        public ActionResult xxx(){
            return Content("ccc");
        }
    }
}