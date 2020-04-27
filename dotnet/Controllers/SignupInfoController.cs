using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnet.Models;

namespace dotnet.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SignupInfoController : ControllerBase
  {
    private readonly ILogger<SignupInfoController> _logger;
    private readonly List<SignupInfo> _signups;

    public SignupInfoController(ILogger<SignupInfoController> logger)
    {
      _logger = logger;
      _signups = new List<SignupInfo>()
      {
        new SignupInfo()
        {
          Id = 1, FirstName = "Joe", LastName = "Smith"
        },
        new SignupInfo()
        {
          Id = 2, FirstName = "Ron", LastName = "Zil"
        }
      };
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SignupInfo>>> Get()
    {
      _logger.LogInformation("Entering SignupInfoController.Get", null);

      _logger.LogInformation("Exiting SignupInfoController.Get", null);

      return _signups;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<SignupInfo>> Get(int id)
    {
      var info = _signups.Where(signup => signup.Id == id).FirstOrDefault();

      if (info != null)
      {
        return info;
      }
      else
      {
        return NotFound();
      }
    }

    [HttpPost]
    public async Task<ActionResult<SignupInfo>> Post(SignupInfo newSignup)
    {
      _signups.Add(newSignup);

      _logger.LogInformation("Added new signup with Id {id}", newSignup.Id);

      return newSignup;
    }
  }
}
