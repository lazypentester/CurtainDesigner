using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner
{
    public partial class FormFabricCurtainOrder : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        //private readonly BindingList<KeyValuePair<string, int>> types = new BindingList<KeyValuePair<string, int>>();
        private ToolTip tip;

        public FormFabricCurtainOrder()
        {
            InitializeComponent();
            this.tip = new ToolTip();
            tip.UseAnimation = true;
            tip.UseFading = true;

            tip.SetToolTip(bunifuButtonCustomInstallPrice, "Зберегти ціну в БД");

            LoadDataFromDb();
            comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(loadSubtypesAndAdditional);
            comboBoxCurtainSubtype.SelectionChangeCommitted += new EventHandler(loadNextDataFromDB);
            comboBoxFabric.SelectionChangeCommitted += new EventHandler(loadFabricCategoryFromBD);

            comboBoxSide.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSide.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); update_status(s, e); };
            comboBoxSystemColor.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSystemColor.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); update_status(s, e);  };
            comboBoxEquipment.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxEquipment.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); update_status(s, e);  };

            //comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(update_status);
            //comboBoxCurtainSubtype.SelectionChangeCommitted += new EventHandler(update_status);
            //comboBoxSide.SelectionChangeCommitted += new EventHandler(update_status);
            //comboBoxFabric.SelectionChangeCommitted += new EventHandler(update_status);
            //comboBoxSystemColor.SelectionChangeCommitted += new EventHandler(update_status);
            //comboBoxEquipment.SelectionChangeCommitted += new EventHandler(update_status);
            comboBoxInstallation.SelectionChangeCommitted += new EventHandler(update_status);
            labelCustomer.TextChanged += (s, e) => { update_status_onlabel(s, e); };
            labelPrice.TextChanged += (s, e) => { update_status_onlabel(s, e); };
        }

        private void iconButtonNewOrder_Click(object sender, EventArgs e)
        {
            CurtainDesigner.Controllers.IControlerManage<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            controler.packing(new Classes.FabricCurtain(), new List<Classes.FabricCurtain2>(), this);
        }

        private async void LoadDataFromDb()
        {
            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.load_data(this));
        }

        private async void loadSubtypesAndAdditional(object sender, EventArgs e)
        {
            comboBoxCurtainSubtype.DataSource = null;
            comboBoxCurtainSubtype.Invalidate();
            comboBoxEquipment.DataSource = null;
            comboBoxEquipment.Invalidate();
            comboBoxFabric.DataSource = null;
            comboBoxFabric.Invalidate();
            labelFabricCategory.Text = "0$";
            labelFabricCategoryId.Text = "0";
            setToolTip((Control)sender, comboBoxCurtainType.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]);
            string boxCurtainType = "";
            if (comboBoxCurtainType.InvokeRequired)
                comboBoxCurtainType.Invoke((MethodInvoker)delegate
               {
                   boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();
               });
            else
                boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();

            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            Task t1 = Task.Run(() => controler.load_subtypeAndAdditionall(this, boxCurtainType));
            comboBoxCurtainSubtype.Enabled = true;
            comboBoxEquipment.Enabled = true;
            await Task.WhenAll(t1);
            update_status(sender, e);
            update_status(comboBoxEquipment, e);
        }

        private async void loadNextDataFromDB(object sender, EventArgs e)
        {
            comboBoxFabric.DataSource = null;
            comboBoxFabric.Invalidate();
            labelFabricCategory.Text = "0$";
            labelFabricCategoryId.Text = "0";
            setToolTip((Control)sender, comboBoxCurtainSubtype.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]);
            string boxCurtainType = "";
            if (comboBoxCurtainType.InvokeRequired)
                comboBoxCurtainType.Invoke((MethodInvoker)delegate
                {
                    boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();
                });
            else
                boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();

            string boxCurtainSubType = "";
            if (comboBoxCurtainSubtype.InvokeRequired)
                comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                {
                    boxCurtainSubType = comboBoxCurtainSubtype.SelectedValue.ToString();
                });
            else
                boxCurtainSubType = comboBoxCurtainSubtype.SelectedValue.ToString();

            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            Task t1 = Task.Run(() => controler.load_data(this, boxCurtainType, boxCurtainSubType));
            comboBoxFabric.Enabled = true;
            await Task.WhenAll(t1);
            update_status(sender, e);
            update_status(comboBoxFabric, e);
        }

        private async void loadFabricCategoryFromBD(object sender, EventArgs e)
        {
            setToolTip((Control)sender, comboBoxFabric.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]);
            string boxCurtainType = "";
            if (comboBoxCurtainType.InvokeRequired)
                comboBoxCurtainType.Invoke((MethodInvoker)delegate
                {
                    boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();
                });
            else
                boxCurtainType = comboBoxCurtainType.SelectedValue.ToString();

            string boxCurtainSubType = "";
            if (comboBoxCurtainSubtype.InvokeRequired)
                comboBoxCurtainSubtype.Invoke((MethodInvoker)delegate
                {
                    boxCurtainSubType = comboBoxCurtainSubtype.SelectedValue.ToString();
                });
            else
                boxCurtainSubType = comboBoxCurtainSubtype.SelectedValue.ToString();

            string boxCurtainFabric = "";
            if (comboBoxFabric.InvokeRequired)
                comboBoxFabric.Invoke((MethodInvoker)delegate
                {
                    boxCurtainFabric = comboBoxFabric.SelectedValue.ToString();
                });
            else
                boxCurtainFabric = comboBoxFabric.SelectedValue.ToString();

            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            Task t1 = Task.Run(() => controler.load_FabricCategorydata(this, boxCurtainType, boxCurtainFabric, boxCurtainSubType));
            await Task.WhenAll(t1);
            update_status(sender, e);
        }

        private void panel37_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCheckboxCustomInstallation_OnChange(object sender, EventArgs e)
        {
            if(bunifuCheckboxCustomInstallation.Checked == true)
            {
                numericUpDownCustomInstallationPrice.Enabled = true;
                comboBoxInstallation.Enabled = false;
                bunifuButtonCustomInstallPrice.Enabled = true;
            }
            else
            {
                numericUpDownCustomInstallationPrice.Enabled = false;
                comboBoxInstallation.Enabled = true;
                bunifuButtonCustomInstallPrice.Enabled = false;
            }
        }

        private void setToolTip(Control control, string tooltip)
        {
            if(control.GetType().Name == "ComboBox")
            {
                tip.SetToolTip(control, tooltip);
            }
        }

        private async void bunifuButtonCustomInstallPrice_Click(object sender, EventArgs e)
        {
            comboBoxInstallation.DataSource = null;
            decimal numericPrice = 0;

            if (numericUpDownCustomInstallationPrice.InvokeRequired)
                numericUpDownCustomInstallationPrice.Invoke((MethodInvoker)delegate
                {
                    numericPrice = numericUpDownCustomInstallationPrice.Value;
                });
            else
                numericPrice = numericUpDownCustomInstallationPrice.Value;

            bool send = await Task.Run(() => sendNewInstallation("Особиста ціна", numericPrice));
            if (!send)
            {
                MessageBox.Show("Помилка при додаванні нового встановлення.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            load_installations();

            numericUpDownCustomInstallationPrice.Value = 0;
            numericUpDownCustomInstallationPrice.Enabled = false;
            bunifuButtonCustomInstallPrice.Enabled = false;
            comboBoxInstallation.Enabled = true;
            bunifuCheckboxCustomInstallation.Checked = false;

            update_status(sender, e);
        }

        private async Task<bool> sendNewInstallation(string name, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [Installation] Values (N'{name}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))});", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }

        private async void load_installations()
        {
            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.load_installations(this));
        }

        private void update_status(object sender, EventArgs e)
        {
            switch((sender as ComboBox).Name)
            {
                case "comboBoxCurtainType":
                case "comboBoxCurtainSubtype":
                case "comboBoxSide":
                    if (comboBoxCurtainType.SelectedValue != null && comboBoxCurtainType.Items.Count != 0 && comboBoxCurtainSubtype.SelectedValue != null && comboBoxCurtainSubtype.Items.Count != 0 && comboBoxCurtainSubtype.DataSource != null && comboBoxSide.SelectedValue != null && comboBoxSide.Items.Count != 0)
                    {
                        ucStatusNotOk1.Hide();
                        ucStatusOk1.BringToFront();
                        ucStatusOk1.Show();
                    }
                    else
                    {
                        ucStatusOk1.Hide();
                        ucStatusNotOk1.BringToFront();
                        ucStatusNotOk1.Show();
                    }
                    break;

                case "comboBoxFabric":
                case "comboBoxSystemColor":
                case "comboBoxEquipment":
                    if (comboBoxFabric.SelectedValue != null && comboBoxFabric.Items.Count != 0 && comboBoxFabric.DataSource != null && comboBoxSystemColor.SelectedValue != null && comboBoxSystemColor.Items.Count != 0 && comboBoxEquipment.SelectedValue != null && comboBoxEquipment.Items.Count != 0)
                    {
                        ucStatusNotOk2.Hide();
                        ucStatusOk2.BringToFront();
                        ucStatusOk2.Show();
                    }
                    else
                    {
                        ucStatusOk2.Hide();
                        ucStatusNotOk2.BringToFront();
                        ucStatusNotOk2.Show();
                    }
                    break;

                case "comboBoxInstallation":
                    if (comboBoxInstallation.SelectedValue != null && comboBoxInstallation.Items.Count != 0)
                    {
                        ucStatusNotOk3.Hide();
                        ucStatusOk3.BringToFront();
                        ucStatusOk3.Show();
                    }
                    else
                    {
                        ucStatusOk3.Hide();
                        ucStatusNotOk3.BringToFront();
                        ucStatusNotOk3.Show();
                    }
                    break;
            }
        }

        private void FormFabricCurtainOrder_Load(object sender, EventArgs e)
        {
            panel22.Controls.Add(ucStatusOk1);
            panel22.Controls.Add(ucStatusNotOk1);

            panel32.Controls.Add(ucStatusOk2);
            panel32.Controls.Add(ucStatusNotOk2);

            panel4.Controls.Add(ucStatusOk3);
            panel4.Controls.Add(ucStatusNotOk3);

            panel12.Controls.Add(ucStatusOk4);
            panel12.Controls.Add(ucStatusNotOk4);

            panel17.Controls.Add(ucStatusOk5);
            panel17.Controls.Add(ucStatusNotOk5);

            panel37.Controls.Add(ucStatusOk6);
            panel37.Controls.Add(ucStatusNotOk6);

            ucStatusOk1.Hide();
            ucStatusOk2.Hide();
            ucStatusOk3.Hide();
            ucStatusOk4.Hide();
            ucStatusNotOk5.Hide();
            ucStatusOk6.Hide();

            ucStatusNotOk1.BringToFront();
            ucStatusNotOk2.BringToFront();
            ucStatusNotOk3.BringToFront();
            ucStatusNotOk4.BringToFront();
            ucStatusOk5.BringToFront();
            ucStatusNotOk6.BringToFront();

            ucStatusNotOk1.Show();
            ucStatusNotOk2.Show();
            ucStatusNotOk3.Show();
            ucStatusNotOk4.Show();
            ucStatusOk5.Show();
            ucStatusNotOk6.Show();
        }

        private void update_status_onlabel(object sender, EventArgs e)
        {
            switch ((sender as Label).Name)
            { 
                case "labelCustomer":
                    if (!string.IsNullOrEmpty(labelCustomer.Text))
                    {
                        ucStatusNotOk4.Hide();
                        ucStatusOk4.BringToFront();
                        ucStatusOk4.Show();
                    }
                    else
                    {
                        ucStatusOk4.Hide();
                        ucStatusNotOk4.BringToFront();
                        ucStatusNotOk4.Show();
                    }
                    break;

                case "labelPrice":
                    if (iconButtonSeeElse.Enabled)
                    {
                        ucStatusNotOk4.Hide();
                        ucStatusOk4.BringToFront();
                        ucStatusOk4.Show();
                    }
                    else
                    {
                        ucStatusOk4.Hide();
                        ucStatusNotOk4.BringToFront();
                        ucStatusNotOk4.Show();
                    }
                    break;
            }
        }

        private void iconButtonSelectClient_Click(object sender, EventArgs e)
        {
            OrderForms.OrderFormSelectClient.FormSelectClient formSelectClient = new OrderForms.OrderFormSelectClient.FormSelectClient();
            formSelectClient.Show();
        }
    }
}
