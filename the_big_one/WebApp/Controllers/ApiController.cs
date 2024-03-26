using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; 

namespace WebApp.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApiService _apiService;

        public ApiController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> CallWebApi()
        {
            string result = await _apiService.GetFromWebApi();
            return Content(result);
        }

    }
}