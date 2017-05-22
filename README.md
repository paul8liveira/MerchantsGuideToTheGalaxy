# MerchantsGuideToTheGalaxy
Desafio Merchant's Guide To The Galaxy

Veja o projeto em: http://paul8liveira.blog.br/MerchantsGuideToTheGalaxy

**Arquitetura do projeto**
* Utilizado método DDD (Domain Driven Design) como abordagem para modelagem do projeto, com arquitetura em 4 camadas (Presentation, Application, Domain e Infra). Acredito que essa arquitetura gera uma solução de qualidade​ e que pode ser executada​ e evoluída​ facilmente.

**Documentação para construção e execução**
* **IDE e Framework**
	* Visual Studio 2012
	* .NET Framework 4.5
	* MVC 4

**Antes da construção e execução**
* Atualizar referências dos projetos.   
	* Abrir o Package Manager Console (Tools / Library package Manager / Package Manager Console) e reinstalar todas as referências à solução através do comando `Update-Package -Reinstall`
	* Caso houver algum problema ou desejar instalar manualmente, abaixo seguem as referências por projeto:
	
	* **Pau8liveira.MerchantsGuideToTheGalaxy.MVC** 
		* `Install-Package WebGrease -Version 1.3.0`
		* `Install-Package EntityFramework -Version 6.1.3`
		* `Install-Package AutoMapper -Version 3.2.1`
		* `Install-Package Newtonsoft.Json -Version 4.5.11`
		* `Install-Package Ninject.MVC5`
		* `System.web.Optimization.dll` deve ser encontrada na pasta local onde foi instalado o ASP.NET MVC  (ex: C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET MVC 4\Packages\Microsoft.AspNet.Web.Optimization.1.0.0\lib\net40\)
		
	* **Paul8liveira.MerchantsGuideToTheGalaxy.Application** 
		* `Install-Package EntityFramework -Version 6.1.3`
		
	* **Paul8liveira.MerchantsGuideToTheGalaxy.Domain** 
		* `Install-Package EntityFramework -Version 6.1.3`
		
	* **Paul8liveira.MerchantsGuideToTheGalaxy.Infra.Data** 
		* `Install-Package EntityFramework -Version 6.1.3`
	
* Gerar banco de dados local através do comando `Update-Database -Verbose`
	* Este comando vai gerar o arquivo .mdf em Pau8liveira.MerchantsGuideToTheGalaxy.MVC\App_Data que vai representar o banco de dados local conforme definido no `web.config`
 
* No `web.config` alterar o caminho da pasta temp conforme configurado no seu computador.