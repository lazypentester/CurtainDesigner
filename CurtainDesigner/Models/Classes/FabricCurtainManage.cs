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
    class FabricCurtainManage<L> : CurtainDesigner.Models.Interfaces.IObjectManage<L>
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private CurtainDesigner.Classes.FabricCurtain fabricCurtain;
        private SqlConnection connection;
        public L list { get; set; }

        public Task<bool> editObject()
        {
            throw new NotImplementedException();
        }

        async public Task<L> readObjects()
        {
            return list;
            
        }

        async public Task<bool> writeObject(object obj)
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
                /*
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
                */

                SqlCommand command_addFB = new SqlCommand($"Insert Into [Fabric_curtains] (Width) Values ({fabricCurtain.width});", connection);
                await command_addFB.ExecuteNonQueryAsync();
            }
            catch(Exception exeption)
            {
                MessageBox.Show(exeption.ToString(), "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
