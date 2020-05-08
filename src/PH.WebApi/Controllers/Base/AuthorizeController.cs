using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PH.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorizeController : ControllerBase
    {
    }
}