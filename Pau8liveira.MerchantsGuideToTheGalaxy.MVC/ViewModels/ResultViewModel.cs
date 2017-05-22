using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        [Key]
        public int Id { get; set; }

        public int InputId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Text")]
        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string Text { get; set; }     

        [Required(ErrorMessage = "Preencha o campo Name")]
        [MaxLength(500, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string Translation { get; set; }        
    }
}