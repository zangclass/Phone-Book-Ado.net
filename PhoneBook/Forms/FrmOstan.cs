using PhoneBook.Entity;
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

namespace PhoneBook.Forms
{
    public partial class FrmOstan : Form
    {
        public FrmOstan()
        {
            InitializeComponent();
        }
        int? _id = null;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetAllOstan()
        {
            try
            {
                OstanRepository rep = new OstanRepository();
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
        private void FrmOstan_Load(object sender, EventArgs e)
        {
            GetAllOstan();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Add()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOstan.Text))
                {
                    MessageBox.Show("وارد نمودن نام استان الزامی می باشد.");
                    return;
                }


                OstanRepository rep = new OstanRepository();
                rep.Add(new OstanEntity
                {
                    NameOstan = txtOstan.Text
                });

                MessageBox.Show("نام استان با موفقیت درج شد.");
                txtOstan.Text = string.Empty;
                txtOstan.Focus();
                GetAllOstan();
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
        private void Edit()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOstan.Text))
                {
                    MessageBox.Show("وارد نمودن نام استان الزامی می باشد.");
                    return;
                }


                OstanRepository rep = new OstanRepository();
                rep.Edit(new OstanEntity
                {
                    NameOstan = txtOstan.Text
                }, _id);

                MessageBox.Show("نام استان با موفقیت ویرایش شد.");
                txtOstan.Text = string.Empty;
                _id = null;
                txtOstan.Focus();
                GetAllOstan();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_id == null)
                Add();
            else Edit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOstan.Text = dataGridView1.Rows[e.RowIndex].Cells["NameOstan"].Value.ToString();
            _id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
        }
        private void Delete()
        {
            try
            {
                OstanRepository rep = new OstanRepository();
                rep.Delete(_id);

                MessageBox.Show("نام استان با موفقیت حذف شد.");
                txtOstan.Text = string.Empty;
                _id = null;
                txtOstan.Focus();
                GetAllOstan();
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از حذف استان مورد نظر اطمینان دارید؟", "هشدار",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Delete();
            }
        }


    }
}
