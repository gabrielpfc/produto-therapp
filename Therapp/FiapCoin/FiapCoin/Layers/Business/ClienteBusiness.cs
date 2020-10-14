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

            return cliente;
        }


        public Model.Cliente Get(Cliente cliente)
        {
            cliente = new Service.ClienteService().Get(cliente);

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

    }
}
