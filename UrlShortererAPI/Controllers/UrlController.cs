using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortererAPI.Data;
using UrlShortererAPI.Models;
using UrlShortererAPI.Services;

namespace UrlShortererAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly IConfiguration _configuration;

        public UrlController(IUrlService urlService, IConfiguration configuration)
        {
            _urlService = urlService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Add(UrlModel url)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            var result = await _urlService.AddAsync(url, ip.ToString());

            return Ok(_configuration["AppUrl" ]+ result);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> RedirecToUrl(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return BadRequest();

            var result = await _urlService.GetUrl(key);
            return Redirect(result);
        }
    }
}
