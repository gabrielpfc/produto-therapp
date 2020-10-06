using System;
using System.Linq;
using THERAPP.Layers.Service;
using THERAPP.Model;

namespace THERAPP.Layers.Business
{
    public class UsuarioBusiness
    {

        public Model.Cliente Login(string email, string senha)
        {
            Cliente _cliente = new Cliente();
            // Efetuar o login
            var _usuario = new UsuarioService().Login(new Usuario(email.ToLower(), senha));
            if (_usuario != null)
            {
                //User->Cliente
                _cliente = new ClienteService().Get(new Cliente(_usuario.id, _usuario.email, _usuario.username, _usuario.password));

                if (_cliente == null) {
                    // Grava os dados do cliente no dispositivo
                    _cliente.age = _cliente.idade;
                    new ClienteBusiness().SaveClienteLogged(new Cliente(_usuario.id, _usuario.email, _usuario.username, _usuario.password));
                }
                else
                {
                    new ClienteBusiness().SaveClienteLogged(_cliente);
                }
            }
            if (_usuario == null)
            {
                throw new Exception("Não foi possível efetuar o logon");
            }
            return _cliente;


        }
        /*Cliente _cliente = new Cliente(_usuario.id);

            if (_usuario.id != 0)
            {
                _cliente = new ClienteService().Get(_cliente);
        //teste                    _cliente = new Cliente(_usuario.id);

                if (_cliente != null)
                {
                    // Grava os dados do cliente no dispositivo
                    new ClienteBusiness().SaveClienteLogged(_cliente);
                }

            }
        */

    }
}
