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
        List<KeyValuePair<string, object>> keyValuePairs = null;

        public FormSelectPrint()
        {
            InitializeComponent();
        }

        public FormSelectPrint(List<KeyValuePair<string, object>> keyValuePairs)
        {
            InitializeComponent();
            this.keyValuePairs = keyValuePairs;
        }

        private void bunifuImageButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButtonPrint_Click(object sender, EventArgs e)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
                print.print(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");
        }

        private void bunifuImageButtonSaveASWord_Click(object sender, EventArgs e)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
            {
                print.GetSavePath();
                if(print.savePathRes)
                    print.saveAsWord(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");
                this.Close();
            }
        }

        private void bunifuImageButtonSaveAsPdf_Click(object sender, EventArgs e)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
            {
                print.GetSavePath();
                if (print.savePathRes)
                    print.saveAsPdf(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");
                this.Close();
            }
        }
    }
}
