using PhoneBook.Entity;
using PhoneBook.Repository;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PhoneBook.Forms
{
    public partial class FrmShahr : Form
    {
        public FrmShahr()
        {
            InitializeComponent();
        }
        private int? _id = null;
        private void GetAllOstan()
        {
            try
            {
                ShahrRepository rep = new ShahrRepository();
                comboOstan.DataSource = rep.GetOstanList();
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
        private void GetAllShahr()
        {
            try
            {
                ShahrRepository rep = new ShahrRepository();
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
        private void FrmShahr_Load(object sender, EventArgs e)
        {
            GetAllOstan();
            GetAllShahr();
            comboOstan.SelectedIndex = -1;
        }
        private void Add()
        {
            try
            {
                var strError = string.Empty;
                var c = 1;
                if (string.IsNullOrWhiteSpace(comboOstan.Text))
                {
                    strError += $"{c}- انخاب نمودن نام استان الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtShahr.Text))
                {
                    strError += $"{c}- وارد نمودن نام شهر الزامی می باشد.\n";
                    c++;
                }

                if (!string.IsNullOrWhiteSpace(strError))
                {
                    MessageBox.Show(strError);
                    return;
                }

                ShahrRepository rep = new ShahrRepository();
                rep.Add(new ShahrEntity
                {
                    OstanId = int.Parse(comboOstan.SelectedValue.ToString()),
                    NameShahr = txtShahr.Text
                });

                MessageBox.Show("نام شهر با موفقیت درج شد.");
                comboOstan.SelectedIndex = -1;
                txtShahr.Text = string.Empty;
                comboOstan.Focus();
                GetAllShahr();
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
                var strError = string.Empty;
                var c = 1;
                if (string.IsNullOrWhiteSpace(comboOstan.Text))
                {
                    strError += $"{c}- انخاب نمودن نام استان الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtShahr.Text))
                {
                    strError += $"{c}- وارد نمودن نام شهر الزامی می باشد.\n";
                    c++;
                }

                if (!string.IsNullOrWhiteSpace(strError))
                {
                    MessageBox.Show(strError);
                    return;
                }

                ShahrRepository rep = new ShahrRepository();
                rep.Edit(new ShahrEntity
                {
                    OstanId = int.Parse(comboOstan.SelectedValue.ToString()),
                    NameShahr = txtShahr.Text
                }, _id);

                MessageBox.Show("نام شهر با موفقیت ویرایش شد.");
                comboOstan.SelectedIndex = -1;
                txtShahr.Text = string.Empty;
                _id = null;
                comboOstan.Focus();
                GetAllShahr();
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
            comboOstan.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells["OstanId"].Value;
            txtShahr.Text = dataGridView1.Rows[e.RowIndex].Cells["NameShahr"].Value.ToString();
            _id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
        }
        private void Delete()
        {
            try
            {
                ShahrRepository rep = new ShahrRepository();
                rep.Delete(_id);

                MessageBox.Show("نام شهر با موفقیت حذف شد.");
                comboOstan.SelectedIndex = -1;
                txtShahr.Text = string.Empty;
                _id = null;
                comboOstan.Focus();
                GetAllShahr();
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
            if (MessageBox.Show("آیا از حذف شهر مورد نظر اطمینان دارید؟", "هشدار",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Delete();
            }
        }
    }
}
