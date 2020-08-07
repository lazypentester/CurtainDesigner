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

        async private void fillDataBase()
        {
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
    }
}
