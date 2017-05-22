using AutoMapper;
using Paul8liveira.MerchantsGuideToTheGalaxy.MVC.ViewModels;
using Paul8liveira.MerchantsGuideToTheGalaxy.Application.Interface;
using Paul8liveira.MerchantsGuideToTheGalaxy.Domain.Entities;
using Paul8liveira.MerchantsGuideToTheGalaxy.MVC.Util.Upload;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using Paul8liveira.MerchantsGuideToTheGalaxy.Infra.CrossCutting;

namespace Paul8liveira.MerchantsGuideToTheGalaxy.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Constantes
        private readonly IInputAppService _inputApp;
        private readonly IResultAppService _resultApp;
        #endregion

        #region Construtor
        public HomeController(IInputAppService inputApp, IResultAppService resultApp)
        {
            _inputApp = inputApp;
            _resultApp = resultApp;
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            HomeViewModel ViewModel = new HomeViewModel();
            ViewModel.UrlPost = Url.Action("Send", "Home");
            return View(ViewModel);
        }
        #endregion

        #region Envia arquivo e efetua leitura linha a linha
        public JsonResult Send()
        {
            InputViewModel InputViewModel = new InputViewModel();
            InputViewModel.ExceptionMessage = new List<ExceptionViewModel>();

            //Transaciona processo
            using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    //Arquivo enviado?
                    if (Request.Files != null && Request.Files.Count > 0)
                    {
                        //Obtem arquivo
                        HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;

                        //Arquivo valido?
                        if (file.ContentLength == 0)
                        {
                            throw new Exception("Input file sent is not valid. It's empty.");
                        }
                        else
                        {
                            //Salva dados do arquivo no mdf
                            string nomeArquivo = Path.GetFileName(file.FileName);
                            InputViewModel.Name = nomeArquivo;
                            var Input = Mapper.Map<InputViewModel, Input>(InputViewModel);
                            _inputApp.Add(Input);

                            //abrir o arquivo
                            var _local_file = Upload.SalvarArquivo(file, CaminhoPastaTemp());
                            using (StreamReader sr = new StreamReader(_local_file))
                            {
                                //Leitura linha a linha, salvando do mdf
                                try
                                {
                                    string line = "";
                                    ResultViewModel ResultViewModel = new ResultViewModel();
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        ResultViewModel.InputId = Input.Id;
                                        ResultViewModel.Text = line;
                                        ResultViewModel.Translation = Converter.Start(line);
                                        var Result = Mapper.Map<ResultViewModel, Result>(ResultViewModel);
                                        _resultApp.Add(Result);
                                    }
                                    
                                    //Carrega todos os dados do arquivo para retornar ao script
                                    InputViewModel.Results = Mapper.Map<IEnumerable<Result>, IEnumerable<ResultViewModel>>(_resultApp.GetAll(Input.Id));
                                }
                                catch (Exception e)
                                {
                                    throw new Exception("The input file could not be read: " + e.Message + "</br>" + e.InnerException);
                                }
                                finally
                                {
                                    sr.Close();
                                }
                            }                            
                        }
                        txscope.Complete();
                    }                    
                }
                catch (Exception e)
                {
                    InputViewModel.ExceptionMessage.Add(new ExceptionViewModel() { Message = e.Message + "</br>" + e.InnerException });                    
                }
                finally
                {
                    txscope.Dispose();
                }
            }
            //Retorna dados ao script
            JsonResult json = new JsonResult();
            json.Data = InputViewModel;
            return json;
        }
        #endregion

        #region Retorna caminho da pasta de anexo de evidências
        private string CaminhoPastaTemp()
        {
            string caminho = ConfigurationManager.AppSettings["CaminhoPastaTemp"];
            
            if (!Directory.Exists(caminho))
            {
                DirectoryInfo di = Directory.CreateDirectory(caminho);
            }

            return caminho;
        }
        #endregion
    }
}
