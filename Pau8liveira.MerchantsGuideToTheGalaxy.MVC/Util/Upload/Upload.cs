using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.Util.Upload
{
    public static class Upload
    {
        #region Salva arquivo em pasta temporária
        public static string SalvarArquivo(HttpPostedFileBase arquivo, string local, string novoNome = null)
        {
            string fileName = string.Empty;
            string tempFileName = string.Empty;
            string pathCombine = string.Empty;

            try
            {
                fileName = Path.GetFileName(arquivo.FileName);

                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    if (novoNome == null)
                        tempFileName = string.Format(fileName, DateTime.Now);
                    else
                        tempFileName = string.Format(novoNome, DateTime.Now);

                    pathCombine = Path.Combine(local, tempFileName);

                    arquivo.SaveAs(pathCombine);
                    return pathCombine;
                }
                else
                {
                    throw new Exception("Nome do arquivo enviado inválido.");
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}