using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtermaForum.Infra.NoSql.Settings
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DataBaseName { get; set; }
    }
}
