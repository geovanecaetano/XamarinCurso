using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servico;
using App1_ConsultarCEP.Servico.Modelo;

namespace App1_ConsultarCEP
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			vBotao.Clicked += BuscarCep;
		}
		private void BuscarCep( object sender, EventArgs args) {
			//logica do programa

			//validações
			string cep = vCep.Text.Trim();

			if (isValidaCep(cep)){
				try
				{
					Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
					if (end != null)
					{

						vResultado.Text = string.Format("Endereço: {0}, {1}, {2}", end.localidade, end.uf, end.logradouro);
					}
					else {
						DisplayAlert("Erro", "Cep nao encontrado", "OK");
					}
				 }
				catch (Exception e) {
					DisplayAlert("ERRO CRITICO", e.Message, "OK");
				}
			}
		}

		private bool isValidaCep(string cep) {
			bool valido = true;
			
				if (cep.Length != 8) {
					DisplayAlert("Erro", "CEP inválido! o cep deve conter 8 caracteres.", "OK");
					valido = false;
				}
				int novoCep = 0;
				
				if (!int.TryParse(cep, out novoCep)) {
					DisplayAlert("Erro", "CEP inválido! o cep deve conter numeros.", "OK");
					valido = false;
				}
			return valido;
		}
	}
}
