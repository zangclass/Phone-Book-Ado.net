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
    public partial class FrmAshkhas : Form
    {
        public FrmAshkhas()
        {
            InitializeComponent();
        }
        public int? Id { get; set; }
        private void GetAllOstan()
        {
            try
            {
                AshkhasRepository rep = new AshkhasRepository();
                comboOstan.DataSource = rep.GetOstan();
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
                if (comboOstan.SelectedValue == null) return;
                AshkhasRepository rep = new AshkhasRepository();
                comboShahr.DataSource = rep.Getshar(int.Parse(comboOstan.SelectedValue.ToString()));
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

        private void GetAshkhas()
        {
            try
            {
                AshkhasRepository rep = new AshkhasRepository();
                var obj = rep.GetShakhs(Id);
                if(obj.Rows.Count == 0)
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
                comboOstan.SelectedValue = obj.Rows[0]["OstanId"]; 
                comboShahr.SelectedValue = obj.Rows[0]["ShahrId"];

                txtName.Text = obj.Rows[0]["FirstName"].ToString();
                txtNameKhanevadegi.Text = obj.Rows[0]["NameKhanevadegi"].ToString();
                txtTel.Text = obj.Rows[0]["Tel"].ToString();
                txtCodePosti.Text = obj.Rows[0]["CodePosti"].ToString();
                txtAddress.Text = obj.Rows[0]["Address"].ToString();
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
        private void FrmAshkhas_Load(object sender, EventArgs e)
        {
            GetAllOstan();
            comboOstan.SelectedIndex = -1;

            if (Id != null)
            {
                GetAshkhas();
            }
        }


        private void Add()
        {
            try
            {
                var strError = string.Empty;
                var c = 1;
                if (string.IsNullOrWhiteSpace(comboOstan.Text))
                {
                    strError += $"{c}- انتخاب نمودن نام استان الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(comboShahr.Text))
                {
                    strError += $"{c}- انتخاب نمودن نام شهر الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    strError += $"{c}- وارد نمودن نام الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtNameKhanevadegi.Text))
                {
                    strError += $"{c}- وارد نمودن نام خانوادگی الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    strError += $"{c}- وارد نمودن تلفن الزامی می باشد.\n";
                    c++;
                }

                if (!string.IsNullOrWhiteSpace(strError))
                {
                    MessageBox.Show(strError);
                    return;
                }

                AshkhasRepository rep = new AshkhasRepository();
                rep.Add(new AshkhasEntity
                {
                    ShahrId = int.Parse(comboShahr.SelectedValue.ToString()),
                    Name = txtName.Text,
                    NameKhanevadegi = txtNameKhanevadegi.Text,
                    Tel = txtTel.Text,
                    CodePosti = txtCodePosti.Text,
                    Address = txtAddress.Text
                });

                MessageBox.Show("شخص مورد نظر با موفقیت درج شد.");
                DialogResult = DialogResult.OK;
                Close();
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
                    strError += $"{c}- انتخاب نمودن نام استان الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(comboShahr.Text))
                {
                    strError += $"{c}- انتخاب نمودن نام شهر الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    strError += $"{c}- وارد نمودن نام الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtNameKhanevadegi.Text))
                {
                    strError += $"{c}- وارد نمودن نام خانوادگی الزامی می باشد.\n";
                    c++;
                }

                if (string.IsNullOrWhiteSpace(txtTel.Text))
                {
                    strError += $"{c}- وارد نمودن تلفن الزامی می باشد.\n";
                    c++;
                }

                if (!string.IsNullOrWhiteSpace(strError))
                {
                    MessageBox.Show(strError);
                    return;
                }

                AshkhasRepository rep = new AshkhasRepository();
                rep.Edit(new AshkhasEntity
                {
                    ShahrId = int.Parse(comboShahr.SelectedValue.ToString()),
                    Name = txtName.Text,
                    NameKhanevadegi = txtNameKhanevadegi.Text,
                    Tel = txtTel.Text,
                    CodePosti = txtCodePosti.Text,
                    Address = txtAddress.Text
                }, Id);

                MessageBox.Show("شخص مورد نظر با موفقیت ویراش شد.");
                DialogResult = DialogResult.OK;
                Close();
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
            if (Id == null)
                Add();
            else Edit();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void comboOstan_TextChanged(object sender, EventArgs e)
        {
            if (comboOstan.SelectedValue == null)
            {
                comboShahr.DataSource = null;
                comboShahr.DisplayMember = "NameShahr";
                comboShahr.ValueMember = "Id";
                return;
            }
            GetAllShahr();
            comboShahr.SelectedIndex = -1;
            comboShahr.Text = string.Empty;
        }

    }
}
