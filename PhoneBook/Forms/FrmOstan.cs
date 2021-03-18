using PhoneBook.Entity;
using PhoneBook.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("وارد نمودن نام استان الزامی می باشد.");
                return;
            }

            OstanRepository rep = new OstanRepository();
            rep.Add(new OstanEntity
            {
                NameOstan = textBox1.Text
            }); 
        }
    }
}
