using System;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities
{
    //Classe que representa a entidade no banco de dados
    public class Result
    {
        //inteiro auto numerico
        public int Id { get; set; }
        //inteiro - vinculo com input
        public int InputId { get; set; }
        //varchar(500) - representa o texto de entrada
        public string Text { get; set; }
        //varchar(500) - representa a traducao de cada liha do arquivo de input
        public string Translation { get; set; }
        //lazy load
        public virtual Input Input { get; set; }
    }
}
