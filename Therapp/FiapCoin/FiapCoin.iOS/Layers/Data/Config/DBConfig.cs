using System;
using THERAPP.Layers.Data.Config;
using Xamarin.Forms;

[assembly: Dependency(typeof(THERAPP.iOS.Layers.Data.Config.DBConfig))]
namespace THERAPP.iOS.Layers.Data.Config
{
    public class DBConfig : IDBConfig
    {
        private String _path;
        public String Path
        {
            get
            {
                if (String.IsNullOrEmpty(_path))
                {
                    _path = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    _path = System.IO.Path.Combine(_path, "..", "Library");
                }
                return _path;
            }
        }
    }
}
