using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            BindingSource source = new BindingSource();
            MySqlConnection connection;
            MySqlCommand command;

            connection = new MySqlConnection();
            connection.ConnectionString = "server=localhost; user id=root; port=3307;password=Embraer@Lufthansa; database=school";
            try
            {
                connection.Open();
                string query = "SELECT * FROM non_teaching_staff";
                command = new MySqlCommand(query, connection);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                source.DataSource = table;
                gunaDataGridView1.DataSource = source;
                adapter.Update(table);
                connection.Close();
            }
            catch(MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Dispose();         
            }
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (gunaComboBox1.SelectedIndex)
            {
                case 0:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.LightGreen;
                    break;
                case 1:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Lime;
                    break;
                case 2:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Yellow;
                    break;
                case 3:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Ember;
                    break;
                case 4:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Orange;
                    break;
                case 5:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.DeepOrange;
                    break;
                case 6:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Blue;
                    break;
                case 7:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.White;
                    break;
                case 8:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.WhiteGrid;
                    break;
                case 9:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Light;
                    break;
                case 10:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.LightGrid;
                    break;
                case 11:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Dark;
                    break;
                default:
                    gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
                    break;
            }
        }
    }
}
