using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CurtainDesigner.ReportOrderForms.printOrder
{
    public partial class FormSelectPrint : Form
    {
        public FormSelectPrint()
        {
            InitializeComponent();
        }

        private void bunifuImageButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
