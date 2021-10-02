using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortererWebUI.Models
{
    public class UrlModelBlazor
    {
        [Url]
        [Required]
        public string UrlAddress { get; set; }
    }
}
