using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Talents.Models
{
    public class People
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Id")]
        public int PeopleId { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Nome / Name:")]
        public string Name { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Email Adress:")]
        public string Email { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Skype: (please create an account if you don't have yet / bom criar caso não tenha)")]
        public string Skype { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone/Phone (Whatsapp):")]
        public string Phone { get; set; }

        [Required]
        [StringLength(160)]
        [Display(Name = "Linkedin:")]
        public string Linkedin { get; set; }

        [StringLength(160)]
        [Display(Name = "Portfolio:")]
        public string Portfolio { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "What is your hourly salary requirements? / Qual sua pretensão salarial por hora?")]
        public decimal Price { get; set; }

        [StringLength(160)]
        [Display(Name = "Bank Information: (Paypal, Itaú, Others)")]
        public string Bank { get; set; }

        [StringLength(160)]
        [Display(Name = "Agency / Agencia")]
        public string Agency { get; set; }

        [Display(Name = "Account Type / Tipo de conta")]
        public int? AccountType { get; set; }

        [StringLength(160)]
        [Display(Name = "Account Number / Número da conta")]
        public string AccountNumber { get; set; }

        [StringLength(160)]
        [Display(Name = "CPF (Only for Brazilians)")]
        public string CPF { get; set; }

        [ForeignKey("City")]
        [Display(Name = "City / Cidade:")]
        public int CityId { get; set; }
        //public IList<SelectListItem> CityNames { get; set; }
        public virtual City City { get; set; }


        [ForeignKey("Province")]
        [Display(Name = "Province / Estado:")]
        public int ProvinceId { get; set; }
        //public IList<SelectListItem> ProvinceNames { get; set; }
        public virtual Province Province { get; set; }


        [ForeignKey("Country")]
        [Display(Name = "Country / País:")]
        public int CountryId { get; set; }
        //public IList<SelectListItem> CountryNames { get; set; }
        public virtual Country Country { get; set; }

        public string ScheduleAvaiableAnswersCheckedString { get; set; }
        [NotMapped]
        public int[] ScheduleAvaiableAnswersChecked { get; set; }
        [NotMapped]
        public List<CheckBoxModel> ScheduleAvaiableAnswers { get; set; }

        public string BestScheduleAnswersCheckedString { get; set; }
        [NotMapped]
        public int[] BestScheduleAnswersChecked { get; set; }
        [NotMapped]
        public List<CheckBoxModel> BestScheduleAnswers { get; set; }
        [NotMapped]
        public List<CheckBoxModel> KnowledgeOptions { get; set; }

        [Display(Name = "Ionic:")]
        public string KnowledgeIonicSelected { get; set; }

        [Display(Name = "Android:")]
        public string KnowledgeAndroidSelected { get; set; }

        [Display(Name = "IOS:")]
        public string KnowledgeIOSSelected { get; set; }

        [Display(Name = "HTML:")]
        public string KnowledgeHTMLSelected { get; set; }

        [Display(Name = "CSS:")]
        public string KnowledgeCSSSelected { get; set; }

        [Display(Name = "Bootstrap:")]
        public string KnowledgeBootstrapSelected { get; set; }

        [Display(Name = "Jquery:")]
        public string KnowledgeJquerySelected { get; set; }

        [Display(Name = "AngularJs:")]
        public string KnowledgeAngularJsSelected { get; set; }

        [Display(Name = "Java:")]
        public string KnowledgeJavaSelected { get; set; }

        [Display(Name = "Asp.Net MVC:")]
        public string KnowledgeAspNetMVCSelected { get; set; }

        [Display(Name = "C#:")]
        public string KnowledgeCSharpSelected { get; set; }

        [Display(Name = "C:")]
        public string KnowledgeCSelected { get; set; }

        [Display(Name = "Cake:")]
        public string KnowledgeCakeSelected { get; set; }

        [Display(Name = "Jango:")]
        public string KnowledgeJangoSelected { get; set; }

        [Display(Name = "Majento:")]
        public string KnowledgeMajentoSelected { get; set; }

        [Display(Name = "PHP:")]
        public string KnowledgePHPSelected { get; set; }

        [Display(Name = "Wordpress:")]
        public string KnowledgeWordpressSelected { get; set; }

        [Display(Name = "Phyton:")]
        public string KnowledgePhytonSelected { get; set; }

        [Display(Name = "Ruby:")]
        public string KnowledgeRubySelected { get; set; }

        [Display(Name = "Microsoft SQL Server:")]
        public string KnowledgeSQLServerSelected { get; set; }

        [Display(Name = "MySQL:")]
        public string KnowledgeMySQLSelected { get; set; }

        [Display(Name = "Salesforce:")]
        public string KnowledgeSalesforceSelected { get; set; }

        [Display(Name = "Adobe Photoshop:")]
        public string KnowledgePhotoshopSelected { get; set; }

        [Display(Name = "Adobe Illustrator:")]
        public string KnowledgeIllustratorSelected { get; set; }

        [Display(Name = "Do you know any other language or framework that was not listed above? Tell us and evaluate yourself from 0 to 5. / Conhece mais alguma linguagem ou framework que não foi listado aqui em cima? Conte para nos e se auto avalie ainda de 0 a 5.")]
        public string AnotherKnowledges { get; set; }

        [Display(Name = "Link CRUD:")]
        public string LinkCrud { get; set; }

        /// <summary>
        /// TODO: Temporary hack to populate the orderdetails until EF does this automatically. 
        /// </summary>
        public People()
        {
            //this.City = new City();
            //this.CountryNames = new List<SelectListItem>();
            //this.ProvinceNames = new List<SelectListItem>();
            //this.CityNames = new List<SelectListItem>();
            this.ScheduleAvaiableAnswersCheckedString = "";
            this.ScheduleAvaiableAnswersChecked = new List<Int32>().ToArray();
            this.ScheduleAvaiableAnswers = new List<CheckBoxModel>
        {
            new CheckBoxModel {Text = "Up to 4 hours per day / Até 4 horas por dia", Value = 0},
            new CheckBoxModel {Text = "4 to 6 hours per day / De 4 á 6 horas por dia", Value = 1},
            new CheckBoxModel {Text = "6 to 8 hours per day /De 6 á 8 horas por dia", Value = 2},
            new CheckBoxModel {Text = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)", Value = 3},
            new CheckBoxModel {Text = "Only weekends / Apenas finais de semana", Value = 4}
        };
            this.BestScheduleAnswersCheckedString = "";
            this.BestScheduleAnswersChecked = new List<Int32>().ToArray();
            this.BestScheduleAnswers = new List<CheckBoxModel>
        {
            new CheckBoxModel {Text = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)", Value = 0},
            new CheckBoxModel {Text = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)", Value = 1},
            new CheckBoxModel {Text = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)", Value = 2},
            new CheckBoxModel {Text = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)", Value = 3},
            new CheckBoxModel {Text = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)", Value = 4}
        };

            this.KnowledgeIonicSelected = "";
            this.KnowledgeOptions = new List<CheckBoxModel>
        {
            new CheckBoxModel {Text = "0", Value = 0},
            new CheckBoxModel {Text = "1", Value = 1},
            new CheckBoxModel {Text = "2", Value = 2},
            new CheckBoxModel {Text = "3", Value = 3},
            new CheckBoxModel {Text = "4", Value = 4},
             new CheckBoxModel {Text = "5", Value = 5}
        };
        }
    }
}