using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.ViewModels
{
    public class InputViewModel : BaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Name")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Minimo {0} caracteres")]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriatedAt { get; set; }

        public virtual IEnumerable<ResultViewModel> Results { get; set; }
    }
}