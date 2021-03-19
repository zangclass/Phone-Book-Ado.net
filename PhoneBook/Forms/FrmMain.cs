using PhoneBook.Class;
using PhoneBook.Forms;
using PhoneBook.Repository;
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

namespace PhoneBook
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private int? _id = null;
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOstan_Click(object sender, EventArgs e)
        {
            var frm = new FrmOstan();
            frm.ShowDialog();

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BbInformation.ConnectionStringDatabase = "Server=.;Database=Daftarche Telephone;Trusted_Connection=True;";
            GetAshkhasList();
        }

        private void btnShahr_Click(object sender, EventArgs e)
        {
            var frm = new FrmShahr();
            frm.ShowDialog();
        }
        private void GetAshkhasList()
        {
            try
            {
                AshkhasRepository rep = new AshkhasRepository();
                dataGridView1.DataSource = rep.GetEntitytList();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "خطا در یتابیس");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در برنامه");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmAshkhas();
            frm.Id = null;
            frm.ShowDialog();
            
            if(frm.DialogResult== DialogResult.OK)
            {
                GetAshkhasList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frm = new FrmAshkhas();
            frm.Id = _id;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                GetAshkhasList();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        }
    }
}
