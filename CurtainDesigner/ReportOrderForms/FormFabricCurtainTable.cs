using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.ReportOrderForms
{
    public partial class FormFabricCurtainTable : Form
    {
        public FormFabricCurtainTable()
        {
            InitializeComponent();
            //set_buttonsStyle();
            fillDataBase();
        }

        async internal void fillDataBase()
        {
            if (bunifuCustomDataGrid1.Rows.Count != 0)
                bunifuCustomDataGrid1.Invoke((MethodInvoker)delegate
                {
                    bunifuCustomDataGrid1.Rows.Clear();
                });

            CurtainDesigner.Controllers.IControlerManage<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.unpacking(Classes.FC_Caontainer.curtains, this.bunifuCustomDataGrid1));
        }

        private void set_buttonsStyle()
        {
            this.bunifuCustomDataGrid1.Rows.AddRange(new DataGridViewRow(), new DataGridViewRow(), new DataGridViewRow());
        }

        private void bunifuCustomDataGridClientsDataBase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 30)
            {
                Classes.FabricCurtain2 fabricCurtain = null;
                try
                {
                    fabricCurtain = new Classes.FabricCurtain2()
                    {
                        fb_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                        type = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString(),
                        type_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnType_id"].Value.ToString(),
                        subtype = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype"].Value.ToString(),
                        subtype_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSubtype_id"].Value.ToString(),
                        fabric_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric"].Value.ToString(),
                        fabric_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnFabric_id"].Value.ToString(),
                        fabric_category_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory"].Value.ToString().Split(' ')[0]),
                        fabric_category_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_id"].Value.ToString(),
                        fabric_category_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCategory_name"].Value.ToString(),
                        system_color_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSystemColor"].Value.ToString(),
                        system_color_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnColor_id"].Value.ToString(),
                        width = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnWidth"].Value.ToString()),
                        height = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnHeight"].Value.ToString()),
                        yardage = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnYardage"].Value.ToString()),
                        count = Convert.ToInt32(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCount"].Value.ToString()),
                        side_name = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSides"].Value.ToString(),
                        side_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnSide_id"].Value.ToString(),
                        equipment_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment_price"].Value.ToString().ToString().Split(' ')[0]),
                        equipment_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEquipment"].Value.ToString(),
                        installation_price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation_price"].Value.ToString().ToString().Split(' ')[0]),
                        installation_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnInstallation"].Value.ToString(),
                        customer_id = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnCustomer"].Value.ToString(),
                        start_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnStartDate"].Value),
                        end_order_time = Convert.ToDateTime(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnEndDate"].Value),
                        picture = bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPicture"].Value.ToString(),
                        price = (float)Convert.ToDouble(bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["ColumnPrice"].Value.ToString().ToString().Split(' ')[0])
                    };

                    EditOrderForms.Edit_FC_OrderForm edit_FC_Order = new EditOrderForms.Edit_FC_OrderForm(fabricCurtain);

                    edit_FC_Order.DialogResult = DialogResult.None;
                    edit_FC_Order.load_info();
                    edit_FC_Order.ShowDialog();

                    if (edit_FC_Order.DialogResult == DialogResult.OK)
                        fillDataBase();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Помилка при редагуванні.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.ColumnIndex == 31)
            {
                DialogResult dialog = MessageBox.Show("Ви дійсно бажаєте видалити цей об'єкт?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                    return;

                EditOrderForms.Edit_FC_OrderForm edit_FC_Order = new EditOrderForms.Edit_FC_OrderForm();
                edit_FC_Order.removeCurtain(
                    bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Number"].Value.ToString(),
                    this
                    );
            }
        }
    }
}
