using System;
using System.Collections.Generic;
using System.Linq;

namespace THERAPP.Layers.Data
{
    public class EventoData
    {
        private Config.DbConnection _dbConn;

        public EventoData()
        {
            _dbConn = new Config.DbConnection();
            _dbConn.Connection.CreateTable<Model.Evento>();
        }

        public List<Model.Evento> GetList()
        {
            return _dbConn.Connection.Table<Model.Evento>().ToList();
        }

        public Model.Evento Get(int _id)
        {
            return _dbConn.Connection.Table<Model.Evento>()
                          .Where(p => p.IdEvento == _id).SingleOrDefault();
        }

        public void Insert(Model.Evento _evento)
        {
            _dbConn.Connection.Insert(_evento);
        }

        public void Update(Model.Evento _evento)
        {
            _dbConn.Connection.Update(_evento);
        }

        public void Delete(Model.Evento _evento)
        {
            _dbConn.Connection.Delete(_evento);
        }


    }
}
