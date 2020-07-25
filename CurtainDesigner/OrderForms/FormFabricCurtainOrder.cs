using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner
{
    public partial class FormFabricCurtainOrder : Form
    {
        //private readonly BindingList<KeyValuePair<string, int>> types = new BindingList<KeyValuePair<string, int>>();

        public FormFabricCurtainOrder()
        {
            InitializeComponent();
            LoadDataFromDb();
            comboBoxCurtainType.SelectionChangeCommitted += new EventHandler(loadSubtypes);
            comboBoxCurtainSubtype.SelectionChangeCommitted += new EventHandler(loadNextDataFromDB);
            comboBoxFabric.SelectionChangeCommitted += new EventHandler(loadFabricCategoryFromBD);
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

        private async void loadSubtypes(object sender, EventArgs e)
        {
            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.load_subtype(this, comboBoxCurtainType.SelectedIndex));
            comboBoxCurtainSubtype.Enabled = true;
        }

        private async void loadNextDataFromDB(object sender, EventArgs e)
        {
            comboBoxFabric.Enabled = true;
            comboBoxEquipment.Enabled = true;

            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.load_data(this, comboBoxCurtainType.SelectedIndex, comboBoxCurtainSubtype.SelectedIndex));
        }

        private async void loadFabricCategoryFromBD(object sender, EventArgs e)
        {
            CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.load_FabricCategorydata(this, comboBoxCurtainType.SelectedIndex, comboBoxFabricCategory.SelectedIndex, comboBoxCurtainSubtype.SelectedIndex));

            comboBoxFabricCategory.Enabled = true;
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
            }
            else
            {
                numericUpDownCustomInstallationPrice.Enabled = false;
                comboBoxInstallation.Enabled = true;
            }
        }
    }
}
