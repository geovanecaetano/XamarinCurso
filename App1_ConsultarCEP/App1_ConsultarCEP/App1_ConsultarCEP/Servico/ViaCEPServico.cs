using System;
using System.Collections.Generic;
using System.Text;
using System.Net;// webclient
using App1_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCEP.Servico
{
	public class ViaCEPServico
	{
		private static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";

		public static Endereco BuscarEnderecoViaCEP(string cep)
		{
			string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

			WebClient wc = new WebClient();

			string Conteudo = wc.DownloadString(NovoEnderecoUrl);

			Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
			if (end.cep == null) return null;

			return end;
		}
	}
}
