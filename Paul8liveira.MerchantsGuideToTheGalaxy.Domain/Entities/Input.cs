using System;
using System.Collections.Generic;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities
{
    //Classe que representa a entidade no banco de dados
    public class Input
    {
        //inteiro auto numerico
        public int Id { get; set; }
        //varchar(100) - representa o nome do arquivo enviado
        public string Name { get; set; }
        //lazy load
        public IEnumerable<Result> Results { get; set; }
    }
}