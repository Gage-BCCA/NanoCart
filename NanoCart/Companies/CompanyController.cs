using Microsoft.AspNetCore.Mvc;
using NanoCart.Companies.Interfaces;

namespace NanoCart.Companies;

[ApiController]
[Route("[controller]")]
public class CompanyController : Controller
{
    private ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}