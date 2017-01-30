using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Talents.Models
{
    public class Province
    {
        [ScaffoldColumn(false)]
        public int ProvinceId { get; set; }                

        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        public int CountryId { get; set; }        
        public virtual Country Country { get; set; }       

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public Province()
        {
            Country = new Country();           
        }
    }
}