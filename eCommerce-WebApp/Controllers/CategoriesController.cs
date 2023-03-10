using eCommerce_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace eCommerce_WebApp.Controllers;

public class CategoriesController : Controller
{
    private readonly HttpClient _httpClient;
    private List<CategoryViewModel> _sessionList;

    public CategoriesController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ecommerce");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("/api/Categories");
        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<CategoryViewModel[]>(responseContent);
        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryViewModel obj)
    {
        if (ModelState.IsValid)
        {
            var request = JsonContent.Create(obj);
            var response = await _httpClient.PostAsync("/api/Categories", request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var key = Guid.NewGuid().ToString();
            HttpContext.Session.SetString(key, responseContent);
            Response.Cookies.Append(key, responseContent);

            var result = JsonSerializer.Deserialize<CategoryViewModel>(responseContent);
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        var response = await _httpClient.GetAsync($"/api/Categories/{id}");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CategoryViewModel>(responseContent);
            return View(result);
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryViewModel obj)
    {
        if (ModelState.IsValid)
        {
            var request = JsonContent.Create(obj);
            var response = await _httpClient.PutAsync("/api/Categories", request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CategoryViewModel>(responseContent);
            return RedirectToAction(nameof(Index));
        }

        return View(obj);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
            return NotFound();

        var response = await _httpClient.GetAsync($"/api/Categories/{id}");

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<CategoryViewModel>(responseContent);
            return View(result);
        }

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
        var response = await _httpClient.DeleteAsync($"/api/Categories/{id}");

        return RedirectToAction(nameof(Index));
    }
}
