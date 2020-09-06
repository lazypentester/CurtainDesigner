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
    class MCManage<L> : CurtainDesigner.Models.Interfaces.IObjectManage<L>
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private CurtainDesigner.Classes.MC fabricCurtain;
        private SqlConnection connection;

        public Task<bool> editObject()
        {

            throw new NotImplementedException();
        }

        public void closeConnection() => connection.Close();

        async public Task<SqlDataReader> getDataFromDB(string command)
        {
            if (command == null)
                throw new NullReferenceException();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlDataReader reader = null;
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            try
            {
                reader = await sqlCommand.ExecuteReaderAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return reader;
        }

        public L readObjects(L list)
        {
            if (list == null)
                throw new NullReferenceException();
            else
                (list as List<CurtainDesigner.Classes.MC2>).Clear();

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_get_mosquito_curtain = new SqlCommand("Select * From [Mosquito_curtains] order by Curtain_id desc;", connection);


            SqlDataReader reader_mosquito_curtain = null;
            SqlDataReader reader_type = null;
            SqlDataReader reader_other = null;
            CurtainDesigner.Classes.MC2 obj = null;

            try
            {
                reader_mosquito_curtain = command_get_mosquito_curtain.ExecuteReader();
                while (reader_mosquito_curtain.Read())
                {
                    obj = new CurtainDesigner.Classes.MC2();

                    //get id
                    obj.fb_id = reader_mosquito_curtain["Curtain_id"].ToString();

                    //Get start informations
                    obj.type_id = reader_mosquito_curtain["Type_id"].ToString();
                    obj.system_color_id = reader_mosquito_curtain["Color_id"].ToString();
                    obj.equipment_id = reader_mosquito_curtain["Equipment_id"].ToString();
                    obj.installation_id = reader_mosquito_curtain["Installation_id"].ToString();
                    obj.customer_id = reader_mosquito_curtain["Customer_id"].ToString();
                    //Get dates, image, price
                    obj.start_order_time = Convert.ToDateTime(reader_mosquito_curtain["Order_data"]);
                    obj.end_order_time = Convert.ToDateTime(reader_mosquito_curtain["End_date"]);
                    obj.picture = (reader_mosquito_curtain["Drawing"]).ToString();
                    obj.price = (float)Convert.ToDouble(reader_mosquito_curtain["Price"]);
                    //Get sizes and count
                    obj.width = (float)Convert.ToDouble(reader_mosquito_curtain["Width"]);
                    obj.height = (float)Convert.ToDouble(reader_mosquito_curtain["Height"]);
                    obj.yardage = (float)Convert.ToDouble(reader_mosquito_curtain["Yardage"]);
                    obj.count = Convert.ToInt32(reader_mosquito_curtain["Count"]);

                    //get type
                    string[] type = get_type(obj.type_id.ToString(), reader_type);
                    obj.type = type[0];
                    obj.type_price = type[1];

                    //Get system_color
                    obj.system_color_name = get_system_color(obj.system_color_id, reader_other);

                    //Get equipment
                    obj.equipment_price = (float)Convert.ToDouble(get_equipment(obj.equipment_id, reader_other));

                    //Get Installation
                    obj.installation_price = (float)Convert.ToDouble(get_installation(obj.installation_id, reader_other));


                    //add to list
                    (list as List<CurtainDesigner.Classes.MC2>).Add(obj);
                }

                if (reader_mosquito_curtain != null && !reader_mosquito_curtain.IsClosed)
                    reader_mosquito_curtain.Close();
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        async public Task<bool> writeObject(object obj)
        {
            if (obj != null)
                fabricCurtain = (CurtainDesigner.Classes.MC)obj;
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

                SqlCommand command_addFB = new SqlCommand($"Insert Into [Mosquito_curtains] Values ({fabricCurtain.width}, " +
                                                                                                    $"{fabricCurtain.height}, " +
                                                                                                    $"{fabricCurtain.count}, " +
                                                                                                    $"{fabricCurtain.yardage}, " +
                                                                                                    $"{fabricCurtain.equipment_id}, " +
                                                                                                    $"{fabricCurtain.customer_id}, " +
                                                                                                    $"{fabricCurtain.system_color_id}, " +
                                                                                                    $"@start_date, " +
                                                                                                    $"@end_date, " +
                                                                                                    $"{fabricCurtain.type_id}, " +
                                                                                                    $"@image, " +
                                                                                                    $"{fabricCurtain.price}, " +
                                                                                                    $"{fabricCurtain.installation_id});", connection);

                try
                {
                    command_addFB.Parameters.Add("@image", SqlDbType.NVarChar).Value = fabricCurtain.picture;
                    command_addFB.Parameters.Add("@start_date", SqlDbType.DateTime2).Value = fabricCurtain.start_order_time;
                    command_addFB.Parameters.Add("@end_date", SqlDbType.DateTime2).Value = fabricCurtain.end_order_time;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при конвертаціії дати або чертежа замовлення, подрбиці: \n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                await command_addFB.ExecuteNonQueryAsync();
            }
            catch (Exception exeption)
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

        private string[] get_type(string type_id, SqlDataReader reader)
        {
            string[] res = new string[2];

            SqlCommand command = new SqlCommand($"Select * From [MC_types] Where Type_id = {type_id};", new SqlConnection(connect_str));

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res[0] = reader["Type_name"].ToString();
                    res[1] = reader["Price"].ToString();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПомилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }

            return res;
        }

        private string get_system_color(string color_id, SqlDataReader reader)
        {
            string res = "";

            SqlCommand command = new SqlCommand($"Select * From [System_color] Where Color_id = {color_id};", new SqlConnection(connect_str));

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = reader["Name"].ToString();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }

            return res;
        }

        private string get_equipment(string equipment_id, SqlDataReader reader)
        {
            string res = "";

            SqlCommand command = new SqlCommand($"Select * From [MC_Additional_equipment] Where Equipment_id = {equipment_id};", new SqlConnection(connect_str));

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = reader["Price"].ToString();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }

            return res;
        }

        private string get_installation(string installation_id, SqlDataReader reader)
        {
            string res = "";

            SqlCommand command = new SqlCommand($"Select * From [Installation] Where Installation_id = {installation_id};", new SqlConnection(connect_str));

            if (command.Connection.State != ConnectionState.Open && command.Connection != null)
                command.Connection.Open();

            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    res = reader["Price"].ToString();
                }
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка при читанні данних з БД.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed && command.Connection != null)
                    command.Connection.Close();
            }

            return res;
        }
    }
}
