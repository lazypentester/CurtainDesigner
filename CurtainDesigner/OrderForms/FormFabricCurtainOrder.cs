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
        public FormFabricCurtainOrder formthis;
        private readonly BindingList<KeyValuePair<string, int>> types = new BindingList<KeyValuePair<string, int>>();

        public FormFabricCurtainOrder()
        {
            InitializeComponent();
            comboBoxCurtainType.DisplayMember = "Key";
            comboBoxCurtainType.ValueMember = "Value";
            comboBoxCurtainType.DataSource = types;
            types.Add(new KeyValuePair<string, int>("закритий", 0));
            types.Add(new KeyValuePair<string, int>("Відкритий", 1));
        }

        private void iconButtonNewOrder_Click(object sender, EventArgs e)
        {
            CurtainDesigner.Controllers.IControlerManage<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder>();
            controler.read_and_write(new Classes.FabricCurtain(), new List<Classes.FabricCurtain2>(), this);
        }
    }
}
