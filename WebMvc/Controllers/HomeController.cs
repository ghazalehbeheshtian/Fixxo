using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;

namespace _01_AspNetMVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        using var client = new HttpClient();
        //var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7049/api/products");

        //IEnumerable<ProductModel> products = new List<ProductModel>()
        //{


        //};

        var result = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7049/api/products");

       return View(result);

    }
}
