using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bunifu.Framework.UI;

namespace CurtainDesigner.OrderForms.OrderFormSelectClient.UCSELECTCLIENT
{
    public partial class SelectClient : UserControl
    {
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanel;
        Bunifu.Framework.UI.BunifuGradientPanel gradientPanelSplitter;
        Bunifu.Framework.UI.BunifuGradientPanel currentSelectedPanel;
        Bunifu.Framework.UI.BunifuElipse bunifuElipse;

        ToolTip ToolTip;

        Label label_id;
        Label label_name;
        Label label_surname;
        Label label_address;
        Label label_phone;

        Label label_original_id;

        private List<Client> clients;

        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;

        public SelectClient()
        {
            InitializeComponent();
        }

        public SelectClient(string query)
        {
            InitializeComponent();
            clients = new List<Client>();
            this.ToolTip = new ToolTip();
            load_clients(query);
            show_clients();
        }

        private void load_clients(string query)
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                connection.Open();
            }

            SqlCommand command_loadclients = new SqlCommand($"Select * From [Clients] {query};", connection);

            SqlDataReader reader = null;

            try
            {
                if (clients == null)
                    clients = new List<Client>();

                reader = command_loadclients.ExecuteReader();

                while (reader.Read())
                {
                    clients.Add(new Client()
                    {
                        id = reader["Customer_id"].ToString(),
                        name = reader["Name"].ToString(),
                        surname = reader["Surname"].ToString(),
                        address = reader["Address"].ToString(),
                        phone = reader["Phone"].ToString()
                    });
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
            }
        }

        private void show_clients()
        {
            foreach (Client client in clients)
            {
                create_panel();
                create_panelSplitter();
                //create_elipse();
                create_label(this.label_id, client.id, 25, 8, gradientPanel, 3);
                create_label(this.label_name, client.name, 85, 8, gradientPanel, 8);
                create_label(this.label_surname, client.surname, 180, 8, gradientPanel, 13);
                create_label(this.label_address, client.address, 325, 8, gradientPanel, 25);
                create_label(this.label_phone, client.phone, 560, 8, gradientPanel, 13);

                create_lable_originalId(label_original_id, client.id, gradientPanel);
            }

            clients.Clear();          
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
            panelContainer.Controls.Add(gradientPanel);
            gradientPanel.BringToFront();
            gradientPanel.Show();
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
            catch (Exception ex)
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

            panelContainer.Controls.Add(gradientPanelSplitter);
            gradientPanelSplitter.BringToFront();
            gradientPanelSplitter.Show();
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

        public bool isSelectedPanel()
        {
            bool res = currentSelectedPanel == null ? false : true;
            return res;
        }

        public Client acceptSelectedClient()
        {
            Client customer = new Client()
            {
                id = currentSelectedPanel.Controls["OriginalId"].Text,
                name = currentSelectedPanel.Controls[3].Text,
                surname = currentSelectedPanel.Controls[2].Text,
                address = currentSelectedPanel.Controls[1].Text,
                phone = currentSelectedPanel.Controls[0].Text
            };

            return customer;
        }
    }
}
