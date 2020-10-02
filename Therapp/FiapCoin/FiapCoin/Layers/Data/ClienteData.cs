using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace THERAPP.Layers.Data
{
    public class ClienteData
    {

        private Config.DbConnection _dbConn;

        public ClienteData()
        {
            _dbConn = new Config.DbConnection();
            _dbConn.Connection.CreateTable<Model.Cliente>();
        }


        public Model.Cliente Get()
        {
            return _dbConn.Connection.Table<Model.Cliente>().FirstOrDefault();
        }

        public void Insert(Model.Cliente _cliente)
        {
            _dbConn.Connection.Insert(_cliente);
        }


        public void Update(Model.Cliente _cliente)
        {
            _dbConn.Connection.Update(_cliente);
        }

        public void Delete(Model.Cliente _cliente)
        {
            _dbConn.Connection.Delete(_cliente);
        }

        public void DropTable()
        {
            _dbConn.Connection.DropTable<Model.Cliente>();
        }
    }
}
