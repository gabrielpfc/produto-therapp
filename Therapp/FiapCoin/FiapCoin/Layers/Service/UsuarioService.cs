using System;
using System.Net.Http;
using System.Text;
using THERAPP.Model;
using Newtonsoft.Json;

namespace THERAPP.Layers.Service
{
    public class UsuarioService
    {
        string message = string.Empty;
        public Model.Usuario Login(Usuario _user)
        {
            //var uri = String.Format("https://run.mocky.io/v3/74b32b82-c7c0-441e-a0ec-da9a143280de?email={0}&password={1}", _user.Email, _user.Senha);

            //var uri = String.Format("https://freetos.ml/api/loginClient?email={0}&password={1}", _user.Email, _user.Senha);

            var uri = "https://freetos.ml/api/loginClient";

            var conteudoJson = Newtonsoft.Json.JsonConvert.SerializeObject(_user);
            var conteudoJsonString = new StringContent(conteudoJson, Encoding.UTF8, "application/json");

            System.Net.Http.HttpClient client = new HttpClient();
            HttpResponseMessage resposta = client.PostAsync(uri, conteudoJsonString).Result;

            if (resposta.IsSuccessStatusCode)
            {
                var resultado = resposta.Content.ReadAsStringAsync().Result;
                _user = JsonConvert.DeserializeObject<Usuario>(resultado);
                return _user;
            }
            else
            {
                throw new Exception("Usuário não encontrado");
            }

            /*try { 

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }*/
        }

    }
}
