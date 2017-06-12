using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Robo.Models
{
    public class Robo
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Cotovelo Esquerdo:")]
        public int CotoveloEsquerdo { get; set; }

        [Display(Name = "Cotovelo Direito:")]
        public int CotoveloDireito { get; set; }

        [Display(Name = "Pulso Esquerdo:")]
        public int PulsoEsquerdo { get; set; }

        [Display(Name = "Pulso Direito:")]
        public int PulsoDireito { get; set; }

        [Display(Name = "Joelho Esquerdo:")]
        public int JoelhoEsquerdo { get; set; }

        [Display(Name = "Joelho Direito:")]
        public int JoelhoDireito { get; set; }

        [Display(Name = "Quadril:")]
        public int Quadril { get; set; }

        [Display(Name = "Cabeça - Rotação:")]
        public int HeadRotation { get; set; }

        [Display(Name = "Cabeça - Inclinação:")]
        public int HeadInclination { get; set; }

        [NotMapped]
        public List<PartCategory> CotoveloEsquerdoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> CotoveloDireitoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> PulsoEsquerdoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> PulsoDireitoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> JoelhoEsquerdoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> JoelhoDireitoOptions { get; set; }

        [NotMapped]
        public List<PartCategory> QuadrilOptions { get; set; }

        [NotMapped]
        public List<PartCategory> HeadRotationOptions { get; set; }

        [NotMapped]
        public List<PartCategory> HeadInclinationOptions { get; set; }

        [NotMapped]
        public bool IsEditing { get; set; }

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public Robo()
        {
           
        }
    }
}