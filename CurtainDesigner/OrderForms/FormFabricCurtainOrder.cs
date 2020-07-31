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

            comboBoxSide.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSide.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); };
            comboBoxSystemColor.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxSystemColor.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); };
            comboBoxEquipment.SelectionChangeCommitted += (s, e) => { setToolTip((Control)s, comboBoxEquipment.SelectedItem.ToString().Split(new char[] { '[', ',', ']' }, StringSplitOptions.None)[1]); };        
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
            await Task.Run(() => controler.load_subtypeAndAdditionall(this, boxCurtainType));
            comboBoxCurtainSubtype.Enabled = true;
            comboBoxEquipment.Enabled = true;
        }

        private async void loadNextDataFromDB(object sender, EventArgs e)
        {
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
            await Task.Run(() => controler.load_data(this, boxCurtainType, boxCurtainSubType));
            comboBoxFabric.Enabled = true;
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
            await Task.Run(() => controler.load_FabricCategorydata(this, boxCurtainType, boxCurtainFabric, boxCurtainSubType));
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
    }
}
