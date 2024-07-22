﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class DoacaoController : Controller
    {
        public DoacaoController()
        {
            
        }
    }
}
