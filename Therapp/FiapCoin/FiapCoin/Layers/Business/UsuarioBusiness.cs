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

            // Efetuar o login
            var _usuario =
                    new UsuarioService().Login(new Usuario(email.ToLower(), senha));

            var _cliente = new Cliente();

                if (_usuario.id != 0)
                {
                    //_cliente = new ClienteService().Get(_usuario.id);
                    _cliente = new Cliente(_usuario.id);

                    if (_cliente != null)
                    {
                        // Grava os dados do cliente no dispositivo
                        new ClienteBusiness().SaveClienteLogged(_cliente);
                    }

                }

            if (_cliente == null)
            {
                throw new Exception("Não foi possível efetuar o logon");
            }


            return _cliente;


        }

    }
}
