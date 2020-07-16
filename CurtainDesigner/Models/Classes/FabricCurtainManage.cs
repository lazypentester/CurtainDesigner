using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        public Task<bool> editObject()
        {
            throw new NotImplementedException();
        }

        async public Task<L> readObjects(L list)
        {
            if (list == null)
                throw new NullReferenceException();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlDataReader reader_fabric_curtain = null;
            SqlCommand command_get_fabric_curtain = new SqlCommand("Select * From [Fabric_curtains];", connection);

            SqlDataReader reader_type = null;
            SqlDataReader reader_subtype = null;
            SqlDataReader reader_other = null;
            CurtainDesigner.Classes.FabricCurtain2 obj;

            try
            {
                reader_fabric_curtain = await command_get_fabric_curtain.ExecuteReaderAsync();
                while (await reader_fabric_curtain.ReadAsync())
                {
                    obj = new CurtainDesigner.Classes.FabricCurtain2();

                    //get id
                    obj.fb_id = reader_fabric_curtain["Curtain_id"].ToString();

                    //Get type and subtype
                    SqlCommand command_get_type = new SqlCommand($"Select * From [Fabric_curtains_types] Where Type_id = {reader_fabric_curtain["Type_id"]};", connection);
                    reader_type = await command_get_type.ExecuteReaderAsync();
                    while(await reader_type.ReadAsync())
                    {
                        obj.type = reader_type["Type_name"].ToString();
                        SqlCommand command_get_subtype = new SqlCommand($"Select * From [Fabric_curtains_subtypes] Where Subtype_id = {reader_type["Subtype_id"]};", connection);
                        reader_subtype = await command_get_subtype.ExecuteReaderAsync();
                        while (await reader_subtype.ReadAsync())
                            obj.subtype = reader_subtype["Subtype_name"].ToString();

                        if (reader_subtype != null && !reader_subtype.IsClosed)
                            reader_subtype.Close();
                    }
                    if (reader_type != null && !reader_type.IsClosed)
                        reader_type.Close();

                    //Get fabric
                    SqlCommand command_get_fabric = new SqlCommand($"Select * From [Fabric] Where Fabric_id = {reader_fabric_curtain["Fabric_id"]};", connection);
                    reader_other = await command_get_fabric.ExecuteReaderAsync();
                    while(await reader_other.ReadAsync())
                    {
                        obj.fabric_name = reader_other["Name"].ToString();
                        obj.fabric_additionally = reader_other["Additionally"].ToString();
                        obj.fabric_image = reader_other["Picture"].ToString();
                        obj.fabric_price = (float)Convert.ToDouble(reader_other["Price"]);
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get system_color
                    SqlCommand command_get_system_color = new SqlCommand($"Select * From [System_color] Where Color_id = {reader_fabric_curtain["Color_id"]};", connection);
                    reader_other = await command_get_system_color.ExecuteReaderAsync();
                    while (await reader_other.ReadAsync())
                    {
                        obj.system_color_name = reader_other["Name"].ToString();
                        obj.system_color_image = reader_other["Picture"].ToString();
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get sizes and count
                    obj.width = (float)Convert.ToDouble(reader_fabric_curtain["Width"]);
                    obj.height = (float)Convert.ToDouble(reader_fabric_curtain["Height"]);
                    obj.yardage = (float)Convert.ToDouble(reader_fabric_curtain["Yardage"]);
                    obj.count = Convert.ToInt32(reader_fabric_curtain["Count"]);

                    //Get control_side
                    SqlCommand command_get_control_side = new SqlCommand($"Select * From [Control] Where Control_id = {reader_fabric_curtain["Control_id"]};", connection);
                    reader_other = await command_get_control_side.ExecuteReaderAsync();
                    while (await reader_other.ReadAsync())
                    {
                        obj.side_name = reader_other["Control_side"].ToString();
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get equipment
                    SqlCommand command_get_equipment = new SqlCommand($"Select * From [Additional_equipment] Where Equipment_id = {reader_fabric_curtain["Equipment_id"]};", connection);
                    reader_other = await command_get_equipment.ExecuteReaderAsync();
                    while (await reader_other.ReadAsync())
                    {
                        obj.equipment_name = reader_other["Equipment"].ToString();
                        obj.equipment_price = (float)Convert.ToDouble(reader_other["Price"]);
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get Installation
                    SqlCommand command_get_installation = new SqlCommand($"Select * From [Installation] Where Installation_id = {reader_fabric_curtain["Installation_id"]};", connection);
                    reader_other = await command_get_installation.ExecuteReaderAsync();
                    while (await reader_other.ReadAsync())
                    {
                        obj.installation_obj = reader_other["Installation_object"].ToString();
                        obj.installation_price = (float)Convert.ToDouble(reader_other["Price"]);
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get customer
                    SqlCommand command_get_customer = new SqlCommand($"Select * From [Clients] Where Customer_id = {reader_fabric_curtain["Customer_id"]};", connection);
                    reader_other = await command_get_customer.ExecuteReaderAsync();
                    while (await reader_other.ReadAsync())
                    {
                        obj.customer_id = reader_other["Customer_id"].ToString();
                        obj.customer_name = reader_other["Name"].ToString();
                        obj.customer_surname = reader_other["Surname"].ToString();
                        obj.customer_address = reader_other["Address"].ToString();
                        obj.customer_phone = reader_other["Phone"].ToString();
                    }
                    if (reader_other != null && !reader_other.IsClosed)
                        reader_other.Close();

                    //Get dates, image, price
                    obj.start_order_time = Convert.ToDateTime(reader_fabric_curtain["Order_data"]);
                    obj.end_order_time = Convert.ToDateTime(reader_fabric_curtain["End_date"]);
                    obj.picture = (Image)(reader_fabric_curtain["Drawing"]);
                    obj.price = (float)Convert.ToDouble(reader_fabric_curtain["Price"]);

                    (list as List<CurtainDesigner.Classes.FabricCurtain2>).Add(obj);
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader_fabric_curtain != null && !reader_fabric_curtain.IsClosed)
                    reader_fabric_curtain.Close();
                connection.Close();
            }
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
                await connection.OpenAsync();
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
                MessageBox.Show(exeption.Message, "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
