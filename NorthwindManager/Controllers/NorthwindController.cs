using Microsoft.AspNetCore.Mvc;
using NorthwindManager.Dtos;
using NorthwindManagerDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NorthwindManager.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class NorthwindController : ControllerBase
  {
    private readonly NorthwindManagerContext db;

    public NorthwindController(NorthwindManagerContext db)
    {
      this.db = db;
    }

    [HttpGet("GetProducts")]
    public object GetProducts()
    {
      try
      {
        int nr = db.Products.Count();
        return new { IsOk = true, Nr = nr };
      }
      catch (Exception exc)
      {
        return new { IsOk = false, Nr = -1, Error = exc.Message };
      }
    }

  }
}
