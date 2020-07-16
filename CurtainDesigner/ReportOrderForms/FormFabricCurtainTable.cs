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
            set_buttonsStyle();
            fillDataBase();
        }

        async private void fillDataBase()
        {
            CurtainDesigner.Controllers.IControlerManage<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView> controler = new CurtainDesigner.Controllers.Classes.FabricCurtainControlerManager<Classes.FabricCurtain, List<Classes.FabricCurtain2>, FormFabricCurtainOrder, DataGridView>();
            await Task.Run(() => controler.unpacking(new List<Classes.FabricCurtain2>(), this.bunifuCustomDataGrid1));
        }

        private void set_buttonsStyle()
        {
            this.bunifuCustomDataGrid1.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewImageColumn() { Visible = true },
                new DataGridViewImageColumn() { Visible = true },
                new DataGridViewImageColumn() { Visible = true }
                });
        }
    }
}
