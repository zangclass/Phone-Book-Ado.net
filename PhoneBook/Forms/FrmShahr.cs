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
    public partial class FrmShahr : Form
    {
        public FrmShahr()
        {
            InitializeComponent();
        }
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
        private void FrmShahr_Load(object sender, EventArgs e)
        {
            GetAllOstan();
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

                MessageBox.Show("نام استان با موفقیت درج شد.");
                comboOstan.SelectedIndex = -1;
                txtShahr.Text = string.Empty;
                comboOstan.Focus();
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
            Add();
        }
    }
}
