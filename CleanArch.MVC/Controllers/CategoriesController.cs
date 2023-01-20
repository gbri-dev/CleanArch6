using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    [Authorize]
  public class CategoriesController : Controller
  {
    private readonly ICategoryService _categoryService;
    public CategoriesController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var categories = await _categoryService.GetCategories();
      return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
      // primeiro apresenta o formulario para o usuario preencher
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO category)
    {
      // Segundo pegar os dados e executar o metodo desejado e retorna o resultado para o usuario
      if (ModelState.IsValid)
      {
        await _categoryService.Add(category);
        return RedirectToAction(nameof(Index));
      }
      return View(category);
    }
    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null) return NotFound();

      var categoryDTO = await _categoryService.GetCategoryById(id);

      if (categoryDTO == null) return NotFound();

      return View(categoryDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _categoryService.Update(categoryDTO);
        }
        catch (Exception)
        {
          throw;
        }
        return RedirectToAction(nameof(Index));
      }
      return View(categoryDTO);
    }

    [Authorize(Roles ="Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null) return NotFound();

      var categoryDTO = await _categoryService.GetCategoryById(id);

      if (categoryDTO == null) return NotFound();

      return View(categoryDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _categoryService.Remove(id);
      return RedirectToAction("Index");
    }
    [HttpGet()]
    public async Task<IActionResult> Details(int id)
    {
      var categoryDTO = await _categoryService.GetCategoryById(id);

      if (categoryDTO == null) return NotFound();

      return View(categoryDTO);
    }

  }
}
