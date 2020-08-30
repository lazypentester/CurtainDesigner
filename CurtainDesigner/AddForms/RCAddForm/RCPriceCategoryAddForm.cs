using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurtainDesigner.AddForms.RCAddForm
{
    public partial class RCPriceCategoryAddForm : Form
    {
        private static string connect_str = CurtainDesigner.Classes.ConnectionString.conn;
        private SqlConnection connection;
        private bool isEditCategory;
        private string category_id;

        public RCPriceCategoryAddForm()
        {
            InitializeComponent();
            tooltips();
        }

        public RCPriceCategoryAddForm(string category_id, string category, decimal price)
        {
            InitializeComponent();
            labelName.Text = "  Редагування";
            isEditCategory = true;
            this.category_id = category_id;
            bunifuMetroTextboxCategory.Text = category;
            numericUpDownPrice.Value = price;
            tooltips();
        }

        public RCPriceCategoryAddForm(string id, UserControl control)
        {
            InitializeComponent();
            removeCategory(id, control);
        }

        private bool check_message_length(int max_length, string text)
        {
            if (text.Length > max_length)
                return false;
            return true;
        }

        private void tooltips()
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(buttonDrag, "Перетягнути вікно");
        }

        private bool checkIsEmpty()
        {
            if (string.IsNullOrWhiteSpace(bunifuMetroTextboxCategory.Text))
                return true;
            return false;
        }

        private void iconButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void removeCategory(string id, UserControl control)
        {
            bool send = await Task.Run(() => deleteCategory(id));
            if (send)
            {
                MessageBox.Show("Категорія успішно видалена.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (control as UserControls.UCSettingsRomanCurtain.UserControlCurt_categoryRC).load_categories();
            }
            else
                MessageBox.Show("Помилка при видаленні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void iconButtonOk_Click(object sender, EventArgs e)
        {
            if (checkIsEmpty())
            {
                MessageBox.Show("Одне з полів не заповнено.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!check_message_length(5000, bunifuMetroTextboxCategory.Text))
            {
                MessageBox.Show("Занадто великий обсяг тексту, помилка.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                string category = bunifuMetroTextboxCategory.Text;
                decimal price = numericUpDownPrice.Value;

                if (!isEditCategory)
                {
                    bool send = await Task.Run(() => sendNewCategory(category, price));
                    if (send)
                    {
                        MessageBox.Show("Нова категорія успішно додана до системи.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при додаванні нового клієнта.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool send = await Task.Run(() => editCategory(this.category_id, category, price));
                    if (send)
                    {
                        MessageBox.Show("Категорія успішно відредагована.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Помилка при редагуванні категорії.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> sendNewCategory(string category, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Insert Into [RC_category] Values (N'{category}', {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))});", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }

        private async Task<bool> editCategory(string _category_id, string category, decimal price)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Update [RC_category] Set Category = N'{category}', Price = {string.Join(".", Convert.ToString((float)Math.Round(Convert.ToDouble(price), 2, MidpointRounding.AwayFromZero)).Split(','))} Where Category_id = {_category_id};", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }

        private async Task<bool> deleteCategory(string _category_id)
        {
            bool sended = true;

            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connect_str);
                await connection.OpenAsync();
            }

            SqlCommand sqlCommand = new SqlCommand($"Delete From [RC_category] Where [RC_category].[Category_id] = {_category_id};", connection);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sended = false;
            }
            finally
            {
                connection.Close();
            }

            return sended;
        }
    }
}
