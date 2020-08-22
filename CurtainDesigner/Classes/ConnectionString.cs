using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurtainDesigner.Classes
{
    public static class ConnectionString
    {
        public static string conn = $@"Data Source=(LocalDB)\gg;AttachDbFilename={Classes.PathCombiner.join_combine("")}\DB\Database.mdf;Integrated Security=True";
    }
    //MSSQLLocalDB
}
