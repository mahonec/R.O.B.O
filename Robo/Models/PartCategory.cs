using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Robo.Models
{
    public class PartCategory
    {       
        public int Id { get; set; }        
        public string Name { get; set; }
               
        public PartCategory()
        {
           
        }
    }
}