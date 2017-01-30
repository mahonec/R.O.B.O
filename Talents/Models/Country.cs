using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Talents.Models
{
    public class Country
    {
        [ScaffoldColumn(false)]
        public int CountryId { get; set; }                

        [Required]
        [StringLength(160)]
        public string Name { get; set; }          

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public Country()
        {                     
        }
    }
}