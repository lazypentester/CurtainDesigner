using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurtainDesigner.Models.Interfaces;

namespace CurtainDesigner.Models.Classes
{
    class FabricCurtainManage : CurtainDesigner.Models.Interfaces.IObjectManage
    {
        public static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        CurtainDesigner.Classes.FabricCurtain fabricCurtain;
        SqlConnection connection;

        Task<bool> IObjectManage.editObject()
        {
            throw new NotImplementedException();
        }

        Task<object[]> IObjectManage.readObjects()
        {
            throw new NotImplementedException();
        }

        async Task<bool> IObjectManage.writeObject(object obj)
        {
            if (obj != null)
                fabricCurtain = (CurtainDesigner.Classes.FabricCurtain)obj;
            else
            {
                throw new NullReferenceException();
            }

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            try
            {
                SqlCommand command_addFB = new SqlCommand($"Insert Into [Fabric_curtains] Values ({fabricCurtain.fabric_id}, " +
                                                                                                    $"{fabricCurtain.width}, " +
                                                                                                    $"{fabricCurtain.height}, " +
                                                                                                    $"{fabricCurtain.count}, " +
                                                                                                    $"{fabricCurtain.yardage}, " +
                                                                                                    $"{fabricCurtain.side_id}, " +
                                                                                                    $"{fabricCurtain.equipment_id}, " +
                                                                                                    $"{fabricCurtain.customer_id}, " +
                                                                                                    $"{fabricCurtain.system_color_id}, " +
                                                                                                    $"{fabricCurtain.start_order_time}, " +
                                                                                                    $"{fabricCurtain.end_order_time}, " +
                                                                                                    $"{fabricCurtain.type_id}, " +
                                                                                                    $"{fabricCurtain.picture}, " +
                                                                                                    $"{fabricCurtain.price}, " +
                                                                                                    $"{fabricCurtain.installation_id});", connection);
                await command_addFB.ExecuteNonQueryAsync();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
