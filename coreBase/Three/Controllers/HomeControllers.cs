using Microsoft.AspNetCore.Mvc;
using Three.Services;


namespace Three.Controllers{
    public class HomeControllers:Controller{
        public HomeControllers(IClock clock){
            
        }

        public JsonResult Index(){
            return Json("I am Index",);
        }
    }
}