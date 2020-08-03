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
using Bunifu.Framework.UI;

namespace CurtainDesigner.OrderForms.OrderFormSelectClient
{
    public partial class FormSelectClient : Form
    {
        private bool operation_doing = false;
        Label write_client;
        ToolTip mainFormToolTip;

        private UCSELECTCLIENT.SelectClient SelectClient;
        private UCWAITLOAD.UCwaitLoad CwaitLoad;
        private Thread second_thread;
        private Thread third_thread;

        public FormSelectClient()
        {
            InitializeComponent();

            operation_doing = true;

            CwaitLoad = new UCWAITLOAD.UCwaitLoad();
            panelSubContainer.Controls.Add(CwaitLoad);
            CwaitLoad.BringToFront();
            CwaitLoad.Show();

            bunifuMaterialTextboxSearch.KeyDown += (s, e) => { enter_key_down(s, e); };

            get_clients("");
        }

        public FormSelectClient(Label label, ToolTip tip)
        {
            InitializeComponent();

            operation_doing = true;

            CwaitLoad = new UCWAITLOAD.UCwaitLoad();
            panelSubContainer.Controls.Add(CwaitLoad);
            CwaitLoad.BringToFront();
            CwaitLoad.Show();

            bunifuMaterialTextboxSearch.KeyDown += (s, e) => { enter_key_down(s, e); };
            if (label != null)
            write_client = label;
            if(tip != null)
            mainFormToolTip = tip;

            get_clients("");
        }

        private void get_clients(string query)
        {
            if(CwaitLoad != null)
            {
                CwaitLoad.BringToFront();
                CwaitLoad.Show();
            }
            else
            {
                CwaitLoad = new UCWAITLOAD.UCwaitLoad();
                panelSubContainer.Controls.Add(CwaitLoad);
                CwaitLoad.BringToFront();
                CwaitLoad.Show();
            }

            if(SelectClient != null)
            {
                panelSubContainer.Controls.Remove(SelectClient);
            }

            if (second_thread != null && second_thread.IsAlive)
                second_thread.Abort();

            object query_obj = query;

            second_thread = new Thread(new ParameterizedThreadStart(start_uc_selectClietn));
            second_thread.Start(query_obj);

            if (third_thread != null && third_thread.IsAlive)
                third_thread.Abort();

            third_thread = new Thread(new ThreadStart(check_status_ucSelectClient));
            third_thread.Start();
        }

        private void check_status_ucSelectClient()
        {
            while (second_thread.IsAlive)
            {
                Console.WriteLine("Thread 2 is still working..");
            }

            Console.WriteLine("Thread 2 done.");

            if (SelectClient != null)
            {
                if (panelSubContainer.InvokeRequired)
                    panelSubContainer.Invoke((MethodInvoker)delegate
                   {
                       panelSubContainer.Controls.Add(SelectClient);
                       SelectClient.BringToFront();
                       SelectClient.Show();
                   });
                else
                {
                    panelSubContainer.Controls.Add(SelectClient);
                    SelectClient.BringToFront();
                    SelectClient.Show();
                }
                

                if (CwaitLoad != null)
                {
                    if (CwaitLoad.InvokeRequired)
                        CwaitLoad.Invoke((MethodInvoker)delegate
                       {
                           CwaitLoad.Hide();
                       });
                    else
                        CwaitLoad.Hide();
                }
            }

            operation_doing = false;
        }

        private void start_uc_selectClietn(object query)
        {
            SelectClient = new UCSELECTCLIENT.SelectClient((string)query);
        }

        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter && e.KeyData == (Keys.Enter)))
                return;
            if (operation_doing)
                return;
            operation_doing = true;

            if (string.IsNullOrEmpty(bunifuMaterialTextboxSearch.Text))
                get_clients("");
            else
                get_clients($" Where Surname Like N'%{bunifuMaterialTextboxSearch.Text}%'");
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (SelectClient != null && write_client != null && mainFormToolTip != null && !operation_doing)
            {
                if (!SelectClient.isSelectedPanel())
                    return;

                UCSELECTCLIENT.Client customer = SelectClient.acceptSelectedClient();

                if (write_client.InvokeRequired)
                    write_client.Invoke((MethodInvoker)delegate
                    {
                        write_client.Text = customer.id;
                        mainFormToolTip.SetToolTip(write_client, string.Join(" ", customer.surname, customer.name, customer.id));
                    });
                else
                {
                    write_client.Text = customer.id;
                    mainFormToolTip.SetToolTip(write_client, string.Join(" ", customer.surname, customer.name, customer.id));
                }

                this.Close();
            }
        }

        private void bunifuImageButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButtonSearch_Click(object sender, EventArgs e)
        {
            if (operation_doing)
                return;
            operation_doing = true;

            if (string.IsNullOrEmpty(bunifuMaterialTextboxSearch.Text))
                get_clients("");
            else
                get_clients($" Where Surname Like N'%{bunifuMaterialTextboxSearch.Text}%'");
        }

        private void bunifuFlatButtonSearchClear_Click(object sender, EventArgs e)
        {
            if (operation_doing)
                return;
            operation_doing = true;

            bunifuMaterialTextboxSearch.Text = "";
            get_clients("");
        }

    }
}
