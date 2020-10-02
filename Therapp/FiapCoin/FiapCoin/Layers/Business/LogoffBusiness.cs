using System;
namespace THERAPP.Layers.Business
{
    public class LogoffBusiness
    {

        public void Logoff()
        {
            string message = string.Empty;
            
            try { 
            new Data.ClienteData().Delete(Model.Global.Cliente);
            Model.Global.Cliente = null;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

        }

    }
}
