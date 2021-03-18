using PhoneBook.Class;
using PhoneBook.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void btnShahr_Click(object sender, EventArgs e)
        {
            var frm = new FrmShahr();
            frm.ShowDialog();
        }
    }
}
