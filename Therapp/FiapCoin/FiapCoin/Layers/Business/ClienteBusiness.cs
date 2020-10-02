using System;
using System.Linq;
using THERAPP.Model;
using THERAPP.Layers.Service;

namespace THERAPP.Layers.Business
{
    public class ClienteBusiness
    {

        public Model.Cliente GetClienteLogged()
        {
            var cliente = new Data.ClienteData().Get();

            if (cliente != null)
            {
                //cliente.EventoCliente = Global.Eventos.SingleOrDefault(p => p.IdEvento == cliente.IdEvento);
            }

            return cliente;
        }


        public Model.Cliente Get(int _id)
        {
            var cliente = new Service.ClienteService().Get(_id);

            if (cliente != null)
            {
                cliente.of_list =
                              Global.Eventos.SingleOrDefault(
                                  p => p.IdEvento == cliente.of_list.IdEvento);
            }

            // Atualiza os dados Globais com o cliente.
            Global.Cliente = cliente;

            return cliente;
        }


        public void SaveClienteLogged(Cliente _cliente)
        {
            new Data.ClienteData().Insert(_cliente);
        }

        public void Save(Cliente _cliente)
        {
            new Service.ClienteService().Save(_cliente);
            new Data.ClienteData().Update(_cliente);
        }

        public Cliente Cadastrar(Cliente cliente)
        {
            Cliente _cliente = new ClienteService().Cadastrar(cliente);
            return _cliente;
        }
        /*        public Cliente Cadastrar(string email, string username, string name, string senha, string fone, int idade, string cep, string sexo, double peso)
        {
            Cliente _cliente = new ClienteService().Cadastrar(new Cliente(email.ToLower(), username.ToLower(), senha, name, fone, idade, cep, sexo, peso));
            return _cliente;
        }*/

    }
}
