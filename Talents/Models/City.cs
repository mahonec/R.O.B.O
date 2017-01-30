using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Talents.Models
{
    public class City
    {
        [ScaffoldColumn(false)]
        public int CityId { get; set; }        

        //public int ArtistId { get; set; }

        [Required]
        [StringLength(160)]
        public string Name { get; set; }

        public int ProvinceId { get; set; }        
        public virtual Province Province { get; set; }        

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public City()
        {
            Province = new Province();           
        }
    }
}