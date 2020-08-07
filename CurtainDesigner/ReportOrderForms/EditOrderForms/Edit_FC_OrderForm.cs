using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.ReportOrderForms.EditOrderForms
{
    public partial class Edit_FC_OrderForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        private OrderForms.OrderFormSelectClient.UCWAITLOAD.UCwaitLoad load;

        private Classes.FabricCurtain2 curtain2;


        public Edit_FC_OrderForm(Classes.FabricCurtain2 obj)
        {
            InitializeComponent();

            curtain2 = obj;

            bunifuGradientPanel4.Visible = false;

            load = new OrderForms.OrderFormSelectClient.UCWAITLOAD.UCwaitLoad();
            load.Dock = DockStyle.Fill;
            bunifuGradientPanel5.Controls.Add(load);
            load.BringToFront();
            load.Show();
        }

        internal void load_info()
        {
            if (curtain2 == null)
                return;

            labelSystemType.Text = curtain2.type;
            bunifuMetroTextboxSubtype.Text = curtain2.subtype;
            labelFabricCategoryId.Text = curtain2.fabric_category_id;
            labelCategory.Text = curtain2.fabric_category_price.ToString();
            numericUpDownWidth.Value = (decimal)curtain2.width;
            numericUpDownHeight.Value = (decimal)curtain2.height;
            numericUpDownCount.Value = curtain2.count;
            labelYardage.Text = curtain2.yardage.ToString();
            labelCustomer_id.Text = curtain2.customer_id;
            labelCustomer_id.Text = curtain2.customer_id;
            dateTimePickerDateStart.Value = curtain2.start_order_time;
            dateTimePickerDateEnd.Value = curtain2.end_order_time;
            numericUpDownPrice.Value = (decimal)curtain2.price;


            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            Task t1 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxSide, "Select * From Control;", "Control_side", "Control_id", Convert.ToInt32(curtain2.side_id)));
            Task t2 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxFabric, "Select * From Fabric;", "Name", "Fabric_id", Convert.ToInt32(curtain2.fabric_id)));
            Task t3 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxSystemColor, "Select * From System_color;", "Name", "Color_id", Convert.ToInt32(curtain2.system_color_id)));
            Task t4 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxEquipment, "Select * From Additional_equipment;", "Equipment", "Equipment_id", Convert.ToInt32(curtain2.equipment_id)));
            Task t5 = Task.Run(() => controler.load_data_once_comboboxes(comboBoxInstallation, "Select * From Installation;", "Price", "Installation_id", Convert.ToInt32(curtain2.installation_id)));
            //Task t6 = Task.Run(() =>  load.Invoke((MethodInvoker)delegate { load.Hide(); }));

            Thread load_done = new Thread(new ThreadStart(loaded));
            load_done.Start();
        }

        private void loaded()
        {
            Thread.Sleep(700);
            load.Invoke((MethodInvoker)delegate
            {
                load.Hide();
            });

            bunifuGradientPanel4.Invoke((MethodInvoker)delegate
            {
                bunifuGradientPanel4.Show();
            });
        }

        private void set_values()
        {
            //while (comboBoxSide.DataSource == null || comboBoxSide.Items.Count == 0 ||
            //        comboBoxFabric.DataSource == null || comboBoxFabric.Items.Count == 0 ||
            //        comboBoxSystemColor.DataSource == null || comboBoxSystemColor.Items.Count == 0 ||
            //        comboBoxEquipment.DataSource == null || comboBoxEquipment.Items.Count == 0 ||
            //        comboBoxInstallation.DataSource == null || comboBoxInstallation.Items.Count == 0)
            //{ }
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
