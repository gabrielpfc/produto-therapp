using System;
using System.Net.Http;
using System.Text;
using THERAPP.Model;
using Newtonsoft.Json;

namespace THERAPP.Layers.Service
{
    public class ClienteService
    {
        string message = string.Empty;

        public Model.Cliente Get(Cliente cliente)
        {
            var uri = String.Format("https://freetos.ml/api/getClient");

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(cliente);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient client = new HttpClient();
            HttpResponseMessage resposta = client.PostAsync(uri, conteudoJsonString).Result;

             if (resposta.IsSuccessStatusCode)
             {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                try { 
                    cliente = JsonConvert.DeserializeObject<Cliente>(resultado);
                    //cliente.IdEvento = cliente.of_list.id;
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    App.MensagemAlerta("Erro", "cadastro incompleto "+ ex);
                    return null;
                }
                return cliente;
             }
             else
             {
                throw new Exception("Dados não encontrados");
             }
        }

        public void Save(Cliente _cliente)
        {
            //falta????
            var uri = String.Format("https://freetos.ml/api/getClient/{0}", _cliente.id);

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(_cliente);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient client = new HttpClient();
            var resposta = client.PutAsync(uri, conteudoJsonString).Result;

            if (!resposta.IsSuccessStatusCode)
            {
                throw new Exception("Dados do cliente não encontrado!");
            }

        }


        public Model.Cliente Cadastrar(Cliente cliente)
        {
            //var uri = String.Format("https://freetos.ml/api/registerClient?username={0}&password={1}&email={0}", _user.email, _user.password);

            var uri = String.Format("https://freetos.ml/api/registerClient");

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(cliente);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");
            
            try
            {
                System.Net.Http.HttpClient client = new HttpClient();
                HttpResponseMessage resposta = client.PostAsync(uri, conteudoJsonString).Result;

                if (resposta.IsSuccessStatusCode)
                {
                    var resultado = resposta.Content.ReadAsStringAsync().Result;
                    App.MensagemAlerta("Tudo certo!", "Registrado com sucesso!");

                    return cliente;
                }
                else
                {
                    throw new Exception("Não foi possivel cadastrar");
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                App.MensagemAlerta("Erro", "Não foi possivel cadastrar");
                return null;
            }
            
        }
    }
}
