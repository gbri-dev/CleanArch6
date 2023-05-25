using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.MVC.Controllers
{
    [Authorize]
  public class IncomeExpenseController : Controller
  {
    private readonly IIncomeExpenseService _incomeExpenseService;
    public IncomeExpenseController(IIncomeExpenseService incomeExpenseService)
    {
      _incomeExpenseService = incomeExpenseService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var incomesEnpenses = await _incomeExpenseService.GetAllAsync();
      return View(incomesEnpenses);
    }

    [HttpGet]
    public IActionResult Create()
    {
      // primeiro apresenta o formulario para o usuario preencher
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(IncomeExpenseDTO incomeExpense)
    {
      // Segundo pegar os dados e executar o metodo desejado e retorna o resultado para o usuario
      if (ModelState.IsValid)
      {
        await _incomeExpenseService.CreateAsync(incomeExpense);
        return RedirectToAction(nameof(Index));
      }
      return View(incomeExpense);
    }
    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null) return NotFound();

      var incomeExpenseDTO = await _incomeExpenseService.GetByIdAsync(id);

      if (incomeExpenseDTO == null) return NotFound();

      return View(incomeExpenseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(IncomeExpenseDTO incomeExpenseDTO)
    {
      if (ModelState.IsValid)
      {
        try
        {
          await _incomeExpenseService.UpdateAsync(incomeExpenseDTO);
        }
        catch (Exception)
        {
          throw;
        }
        return RedirectToAction(nameof(Index));
      }
      return View(incomeExpenseDTO);
    }

    [Authorize(Roles ="Admin")]
    [HttpGet()]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null) return NotFound();

      var incomeExpenseDTO = await _incomeExpenseService.GetByIdAsync(id);

      if (incomeExpenseDTO == null) return NotFound();

      return View(incomeExpenseDTO);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      await _incomeExpenseService.RemoveAsync(id);
      return RedirectToAction("Index");
    }
    [HttpGet()]
    public async Task<IActionResult> Details(int id)
    {
      var incomeExpenseDTO = await _incomeExpenseService.GetByIdAsync(id);

      if (incomeExpenseDTO == null) return NotFound();

      return View(incomeExpenseDTO);
    }

  }
}
