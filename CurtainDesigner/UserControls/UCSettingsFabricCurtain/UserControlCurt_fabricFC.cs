using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.UserControls.UCSettingsFabricCurtain
{
    public partial class UserControlCurt_fabricFC : UserControl
    {
        public UserControlCurt_fabricFC()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForms.FabricCurtainAddForm.FCFabricFabricAddForm fabricAddForm = new AddForms.FabricCurtainAddForm.FCFabricFabricAddForm();
            fabricAddForm.DialogResult = DialogResult.None;
            fabricAddForm.ShowDialog();
            //if (fabricAddForm.DialogResult == DialogResult.OK)
                //load_fabrics();
        }

        //internal async void load_fabrics()
        //{
        //    await Task.Run(() => load_data());
        //}

        //private async void load_data()
        //{
        //    if (bunifuCustomDataGridSubTypesDataBase.Rows.Count != 0)
        //    {
        //        if (bunifuCustomDataGridSubTypesDataBase.InvokeRequired)
        //            bunifuCustomDataGridSubTypesDataBase.Invoke((MethodInvoker)delegate
        //            {
        //                bunifuCustomDataGridSubTypesDataBase.Rows.Clear();
        //            });
        //        else
        //            bunifuCustomDataGridSubTypesDataBase.Rows.Clear();
        //    }

        //    if (connection == null || connection.State == ConnectionState.Closed)
        //    {
        //        connection = new SqlConnection(connect_str);
        //        await connection.OpenAsync();
        //    }

        //    SqlCommand command_loadclients = new SqlCommand("Select * From [Fabric_curtains_subtypes];", connection);

        //    SqlDataReader reader = null;

        //    try
        //    {
        //        reader = await command_loadclients.ExecuteReaderAsync();
        //        if (bunifuCustomDataGridSubTypesDataBase.InvokeRequired)
        //        {
        //            bunifuCustomDataGridSubTypesDataBase.Invoke((MethodInvoker)async delegate
        //            {
        //                string tp_name = "";
        //                while (await reader.ReadAsync())
        //                {
        //                    tp_name = get_TypeName(reader["Type_id"].ToString());
        //                    bunifuCustomDataGridSubTypesDataBase.Rows.Add(
        //                    new object[] { reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), tp_name, reader["Subtype_name"].ToString() });
        //                }
        //            });

        //        }
        //        else
        //        {
        //            string tp_name = "";
        //            while (await reader.ReadAsync())
        //            {
        //                tp_name = get_TypeName(reader["Type_id"].ToString());
        //                bunifuCustomDataGridSubTypesDataBase.Rows.Add(
        //                new object[] { reader["Type_id"].ToString(), reader["Subtype_id"].ToString(), tp_name, reader["Subtype_name"].ToString() });
        //            }
        //        }
        //    }
        //    catch (Exception exeption)
        //    {
        //        MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (reader != null && !reader.IsClosed)
        //            reader.Close();
        //        connection.Close();
        //    }
        //}
    }
}
