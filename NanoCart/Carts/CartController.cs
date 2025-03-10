using Microsoft.AspNetCore.Mvc;
using NanoCart.Carts.Interfaces;

namespace NanoCart.Carts;

[ApiController]
[Route("[controller]")]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
    
}