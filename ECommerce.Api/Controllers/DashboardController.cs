using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ECommerce.Infrastructure.Persistence;

namespace ECommerce.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin")]   // Solo Admin puede ver esto
    [HttpGet]
    public async Task<IActionResult> GetSummary()
    {
        var totalProducts = await _context.Products.CountAsync();
        var totalStock = await _context.Products.SumAsync(p => p.Stock);
        var lowStock = await _context.Products.CountAsync(p => p.Stock < 5);

        return Ok(new
        {
            TotalProducts = totalProducts,
            TotalStock = totalStock,
            LowStockProducts = lowStock,
            Message = "Dashboard funcionando correctamente"
        });
    }
}