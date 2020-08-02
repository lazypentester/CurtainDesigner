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
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanel;
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanelSplitter;
        Bunifu.Framework.UI.BunifuGradientPanel currentSelectedPanel;
        Bunifu.Framework.UI.BunifuElipse bunifuElipse;

        private bool operation_doing = false;

        Label write_client;

        ToolTip ToolTip;
        ToolTip mainFormToolTip;

        Label label_id;
        Label label_name;
        Label label_surname;
        Label label_address;
        Label label_phone;

        Label label_original_id;

        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public FormSelectClient()
        {
            InitializeComponent();
            this.ToolTip = new ToolTip();
            bunifuMaterialTextboxSearch.KeyDown += (s, e) => { enter_key_down(s, e); };
            operation_doing = true;
            load_clients();
        }

        public FormSelectClient(Label label, ToolTip tip)
        {
            InitializeComponent();
            this.ToolTip = new ToolTip();
            bunifuMaterialTextboxSearch.KeyDown += (s, e) => { enter_key_down(s, e); };
            operation_doing = true;
            if (label != null)
            write_client = label;
            if(tip != null)
            mainFormToolTip = tip;
            load_clients();
        }

        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Enter && e.KeyData == (Keys.Enter)))
                return;
            if (operation_doing)
                return;
            operation_doing = true;
            clear_subContainer();
            search_clients();
        }

        internal async void load_clients()
        {
            //panelSubContainer.Hide();
            //bunifuGradientPanel1.Visible = false;
            Task t1 = Task.Run(() => load_data());
            await Task.WhenAll(t1);
            //uCwaitLoad1.Hide();
            //panelSubContainer.BringToFront();
            //panelSubContainer.Show();
            //bunifuGradientPanel1.Visible = true;
        }

        internal async void search_clients()
        {
            if (uCwaitLoad1.InvokeRequired)
                uCwaitLoad1.Invoke((MethodInvoker)delegate
               {
                   uCwaitLoad1.BringToFront();
                   uCwaitLoad1.Show();
               });
            else
            {
                uCwaitLoad1.BringToFront();
                uCwaitLoad1.Show();
            }

            //Task t1;
            if (string.IsNullOrEmpty(bunifuMaterialTextboxSearch.Text))
                await Task.Run(() => search_data(""));
            else
                await Task.Run(() => search_data($" Where Surname Like N'%{bunifuMaterialTextboxSearch.Text}%' "));
            //await Task.WhenAll(t1);
        }

        private void clear_subContainer()
        {
            this.panelSubContainer.Controls.Clear();
        }

        private async void search_data(string search_text)
        {
            //Thread.Sleep(500);

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand($"Select * From [Clients] {search_text};", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (panelSubContainer.InvokeRequired)
                {
                    panelSubContainer.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                        {
                            //if (panelSubContainer.InvokeRequired)
                            //    panelSubContainer.Invoke((MethodInvoker)delegate
                            //    {
                            //        uCwaitLoad1.BringToFront();
                            //        uCwaitLoad1.Show();
                            //    });
                            //else
                            //{
                            //    uCwaitLoad1.BringToFront();
                            //    uCwaitLoad1.Show();
                            //}


                            create_panel();
                            create_panelSplitter();
                            create_elipse();
                            create_label(this.label_id, reader["Customer_id"].ToString(), 25, 8, gradientPanel, 3);
                            create_label(this.label_name, reader["Name"].ToString(), 85, 8, gradientPanel, 8);
                            create_label(this.label_surname, reader["Surname"].ToString(), 180, 8, gradientPanel, 13);
                            create_label(this.label_address, reader["Address"].ToString(), 325, 8, gradientPanel, 25);
                            create_label(this.label_phone, reader["Phone"].ToString(), 560, 8, gradientPanel, 13);

                            create_lable_originalId(label_original_id, reader["Customer_id"].ToString(), gradientPanel);

                            //if (panelSubContainer.InvokeRequired)
                            //    panelSubContainer.Invoke((MethodInvoker)delegate
                            //    {
                            //        uCwaitLoad1.BringToFront();
                            //        uCwaitLoad1.Show();
                            //    });
                            //else
                            //{
                            //    uCwaitLoad1.BringToFront();
                            //    uCwaitLoad1.Show();
                            //}
                        }
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                    {
                        //if (panelSubContainer.InvokeRequired)
                        //    panelSubContainer.Invoke((MethodInvoker)delegate
                        //    {
                        //        uCwaitLoad1.BringToFront();
                        //        uCwaitLoad1.Show();
                        //    });
                        //else
                        //{
                        //    uCwaitLoad1.BringToFront();
                        //    uCwaitLoad1.Show();
                        //}

                        create_panel();
                        create_panelSplitter();
                        create_elipse();
                        create_label(this.label_id, reader["Customer_id"].ToString(), 25, 8, gradientPanel, 3);
                        create_label(this.label_name, reader["Name"].ToString(), 85, 8, gradientPanel, 8);
                        create_label(this.label_surname, reader["Surname"].ToString(), 180, 8, gradientPanel, 13);
                        create_label(this.label_address, reader["Address"].ToString(), 325, 8, gradientPanel, 25);
                        create_label(this.label_phone, reader["Phone"].ToString(), 560, 8, gradientPanel, 13);

                        create_lable_originalId(label_original_id, reader["Customer_id"].ToString(), gradientPanel);
                    }
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();

                if (panelSubContainer.InvokeRequired)
                    panelSubContainer.Invoke((MethodInvoker)delegate
                    {
                        uCwaitLoad1.Hide();
                    });
                else
                {
                    uCwaitLoad1.Hide();
                }

                operation_doing = false;
            }
        }

        private async void load_data()
        {
            Thread.Sleep(500);

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand command_loadclients = new SqlCommand("Select * From [Clients];", connection);

            SqlDataReader reader = null;

            try
            {
                reader = await command_loadclients.ExecuteReaderAsync();
                if (panelSubContainer.InvokeRequired)
                {
                    panelSubContainer.Invoke((MethodInvoker)async delegate
                    {
                        while (await reader.ReadAsync())
                        {
                            create_panel();
                            create_panelSplitter();
                            create_elipse();
                            create_label(this.label_id, reader["Customer_id"].ToString(), 25, 8, gradientPanel, 3);
                            create_label(this.label_name, reader["Name"].ToString(), 85, 8, gradientPanel, 8);
                            create_label(this.label_surname, reader["Surname"].ToString(), 180, 8, gradientPanel, 13);
                            create_label(this.label_address, reader["Address"].ToString(), 325, 8, gradientPanel, 25);
                            create_label(this.label_phone, reader["Phone"].ToString(), 560, 8, gradientPanel, 13);

                            create_lable_originalId(label_original_id, reader["Customer_id"].ToString(), gradientPanel);
                        }                    
                    });

                }
                else
                {
                    while (await reader.ReadAsync())
                    {
                        create_panel();
                        create_panelSplitter();
                        create_elipse();
                        create_label(this.label_id, reader["Customer_id"].ToString(), 25, 8, gradientPanel, 3);
                        create_label(this.label_name, reader["Name"].ToString(), 85, 8, gradientPanel, 8);
                        create_label(this.label_surname, reader["Surname"].ToString(), 180, 8, gradientPanel, 13);
                        create_label(this.label_address, reader["Address"].ToString(), 325, 8, gradientPanel, 25);
                        create_label(this.label_phone, reader["Phone"].ToString(), 560, 8, gradientPanel, 13);

                        create_lable_originalId(label_original_id, reader["Customer_id"].ToString(), gradientPanel);
                    }
                }
            }
            catch (Exception exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
                connection.Close();

                if (panelSubContainer.InvokeRequired)
                    panelSubContainer.Invoke((MethodInvoker)delegate
                    {
                        uCwaitLoad1.Hide();
                    });
                else
                {
                    uCwaitLoad1.Hide();
                }

                operation_doing = false;
            }
        }

        private void select_panel(object sender, MouseEventArgs e)
        {
            if (currentSelectedPanel != null)
                unselect_panel();

            if (currentSelectedPanel != null)
            { 
                if ((sender as Bunifu.Framework.UI.BunifuGradientPanel) == currentSelectedPanel)
                {
                    currentSelectedPanel = null;
                    return;
                }
            }

            currentSelectedPanel = (Bunifu.Framework.UI.BunifuGradientPanel)sender;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomLeft = Color.Gold;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomRight = Color.OrangeRed;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopLeft = Color.Orange;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopRight = Color.Gold;
        }

        private void unselect_panel()
        {
            if (currentSelectedPanel != null)
            {
                currentSelectedPanel.GradientBottomLeft = Color.DodgerBlue;
                currentSelectedPanel.GradientBottomRight = Color.Aqua;
                currentSelectedPanel.GradientTopLeft = Color.DodgerBlue;
                currentSelectedPanel.GradientTopRight = Color.LightGray;
            }
        }

        private void create_elipse()
        {
            try
            {
                bunifuElipse = new Bunifu.Framework.UI.BunifuElipse()
                {
                    ElipseRadius = 7,
                    TargetControl = gradientPanel ?? throw new NullReferenceException()
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_panelSplitter()
        {
            gradientPanelSplitter = new Bunifu.Framework.UI.BunifuGradientPanel()
            {
                BackColor = Color.Gainsboro,
                Size = new Size(width: 719, height: 5),
                Dock = DockStyle.Top,
                GradientBottomLeft = Color.Gainsboro,
                GradientBottomRight = Color.Gainsboro,
                GradientTopLeft = Color.Silver,
                GradientTopRight = Color.DarkGray,
                Quality = 10
            };

            panelSubContainer.Controls.Add(gradientPanelSplitter);
            gradientPanelSplitter.BringToFront();
            gradientPanelSplitter.Show();
        }

        private void create_panel()
        {
            gradientPanel = new Bunifu.Framework.UI.BunifuGradientPanel()
            {
                BackColor = Color.Gainsboro,
                Size = new Size(width: 719, height: 32),
                Dock = DockStyle.Top,
                GradientBottomLeft = Color.DodgerBlue,
                GradientBottomRight = Color.Aqua,
                GradientTopLeft = Color.DodgerBlue,
                GradientTopRight = Color.LightGray,
                Quality = 10,
            };

            gradientPanel.MouseEnter += (s, e) => { panelOnEnter(s, e); };
            gradientPanel.MouseLeave += (s, e) => { panelOnLeave(s, e); };
            gradientPanel.MouseClick += (s, e) => { select_panel(s, e); };
            panelSubContainer.Controls.Add(gradientPanel);
            gradientPanel.BringToFront();
            gradientPanel.Show();
        }

        private void create_lable_originalId(Label label, string id, BunifuGradientPanel panel)
        {
            try
            {
                label = new Label()
                {
                    Text = id,
                    Name = "OriginalId"
                };

                if (panel == null)
                    throw new NullReferenceException();
                panel.Controls.Add(label);
                label.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_label(Label label, string name, int loc_x, int loc_y, BunifuGradientPanel panel, int tooltip_num)
        {
            bool create_tooltip = false;
            string tooltip_name = name;

            if (name.Length > tooltip_num)
            { name = string.Join("...", name.ToString().Remove(tooltip_num), ""); create_tooltip = true; }

            try
            {
                
                label = new Label()
                {
                    BackColor = Color.Transparent,
                    ForeColor = Color.FromArgb(18, 30, 54),
                    AutoSize = true,
                    Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                    Location = new System.Drawing.Point(loc_x, loc_y),
                    Size = new System.Drawing.Size(20, 16),
                    TabIndex = 1,
                    Text = name
                };

                if (create_tooltip)
                    this.ToolTip.SetToolTip(label, tooltip_name);

                if (panel == null)
                    throw new NullReferenceException();
                panel.Controls.Add(label);
                label.BringToFront();
                label.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelOnEnter(object sender, EventArgs e)
        {
            if (currentSelectedPanel != null)
                if ((sender as Bunifu.Framework.UI.BunifuGradientPanel) == currentSelectedPanel)
                    return;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomRight = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopRight = Color.DodgerBlue;
        }

        private void panelOnLeave(object sender, EventArgs e)
        {
            if (currentSelectedPanel != null)
                if ((sender as Bunifu.Framework.UI.BunifuGradientPanel) == currentSelectedPanel)
                    return;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientBottomRight = Color.Aqua;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopLeft = Color.DodgerBlue;
            (sender as Bunifu.Framework.UI.BunifuGradientPanel).GradientTopRight = Color.LightGray;
        }

        private void panelSubContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormSelectClient_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButtonOk_Click(object sender, EventArgs e)
        {
            if(currentSelectedPanel != null && write_client != null && mainFormToolTip != null)
            {
                if (write_client.InvokeRequired)
                    write_client.Invoke((MethodInvoker)delegate
                    {
                        write_client.Text = currentSelectedPanel.Controls["OriginalId"].Text;
                        mainFormToolTip.SetToolTip(write_client, string.Join(" ", currentSelectedPanel.Controls[2].Text, currentSelectedPanel.Controls[3].Text, currentSelectedPanel.Controls[4].Text));                   
                    });
                else
                {
                    write_client.Text = currentSelectedPanel.Controls["OriginalId"].Text;
                    mainFormToolTip.SetToolTip(write_client, string.Join(" ", currentSelectedPanel.Controls[2].Text, currentSelectedPanel.Controls[3].Text, currentSelectedPanel.Controls[4].Text));
                }

                this.Close();
            }
        }

        private void bunifuImageButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void bunifuFlatButtonSearch_Click(object sender, EventArgs e)
        {
            if (operation_doing)
                return;
            operation_doing = true;
            clear_subContainer();
            await Task.Run(() => search_clients());
        }

        private void bunifuFlatButtonSearchClear_Click(object sender, EventArgs e)
        {
            if (operation_doing)
                return;
            operation_doing = true;
            bunifuMaterialTextboxSearch.Text = "";
            clear_subContainer();
            search_clients();
        }
    }
}
