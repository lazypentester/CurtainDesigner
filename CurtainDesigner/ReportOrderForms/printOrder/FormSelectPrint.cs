using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace CurtainDesigner.ReportOrderForms.printOrder
{
    public partial class FormSelectPrint : Form
    {
        List<KeyValuePair<string, object>> keyValuePairs = null;
        private Thread thread_1;
        private Thread thread_2;
        private delegate void Current_method(object form);
        private string savePath = Classes.PathCombiner.join_combine("");
        private bool is_process = false;

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
            if (is_process)
                return;

            this.Close();
        }

        private void start_check_thread(object num)
        {
            FormWait formWait = new FormWait();
            Current_method _Method = null;

            switch (Convert.ToInt32(num))
            {
                case 1:
                    _Method = print;
                    break;

                case 2:
                    _Method = saveAsPdf;
                    break;

                case 3:
                    _Method = saveAsWord;
                    break;

                default:
                    _Method = saveAsPdf;
                    break;
            }

            thread_1 = new Thread(new ParameterizedThreadStart(_Method));
            thread_1.Start(formWait);

            formWait.ShowDialog();
            if (formWait.DialogResult == DialogResult.OK)
            {
                is_process = false;

                formWait.Close();
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
        }

        private void print(object form)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
                print.print(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");

            if ((form as FormWait) != null)
                (form as FormWait).Invoke((MethodInvoker)delegate {
                    (form as FormWait).pictureBoxStatusOk.Visible = true;
                    (form as FormWait).iconButtonOk.Visible = true;
                });
        }

        private void saveAsPdf(object form)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
            {
                print.saveAsPdf(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");
            }

            if ((form as FormWait) != null)
                (form as FormWait).Invoke((MethodInvoker)delegate {
                    (form as FormWait).pictureBoxStatusOk.Visible = true;
                    (form as FormWait).iconButtonOk.Visible = true;
                });
        }

        private void saveAsWord(object form)
        {
            Classes.Print print = new Classes.Print();

            if (keyValuePairs != null)
            {
                print.saveAsWord(keyValuePairs, @"C:\Users\glebg\Desktop\doc.docx");
            }

            if ((form as FormWait) != null)
                (form as FormWait).Invoke((MethodInvoker)delegate {
                    (form as FormWait).pictureBoxStatusOk.Visible = true;
                    (form as FormWait).iconButtonOk.Visible = true;
                });
        }

        private void bunifuImageButtonPrint_Click(object sender, EventArgs e)
        {
            if (thread_1 != null || thread_2 != null || is_process)
                return;

            is_process = true;

            thread_2 = new Thread(new ParameterizedThreadStart(start_check_thread));
            thread_2.Start(1);
        }

        private void bunifuImageButtonSaveASWord_Click(object sender, EventArgs e)
        {
            if (thread_1 != null || thread_2 != null || is_process)
                return;

            is_process = true;

            Classes.Print.GetSavePath();
            if (Classes.Print.savePathRes)
            {
                thread_2 = new Thread(new ParameterizedThreadStart(start_check_thread));
                thread_2.Start(3);
            }
        }

        private void bunifuImageButtonSaveAsPdf_Click(object sender, EventArgs e)
        {
            if (thread_1 != null || thread_2 != null || is_process)
                return;

            is_process = true;

            Classes.Print.GetSavePath();
            if (Classes.Print.savePathRes)
            {
                thread_2 = new Thread(new ParameterizedThreadStart(start_check_thread));
                thread_2.Start(2);
            }
        }
    }
}
