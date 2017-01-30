using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Talents.Models
{
    public class CheckBoxModel
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public CheckBoxModel()
        {

        }
    }
}