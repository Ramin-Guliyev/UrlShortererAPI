using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortererAPI.Data;
using UrlShortererAPI.Models;
using UrlShortererAPI.Services;

namespace UrlShortererAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpPost]
        public async Task<IActionResult> Add(UrlModel url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            var result = await _urlService.AddAsync(url, ip.ToString());

            return Ok(result);
        }

       
    }
}
