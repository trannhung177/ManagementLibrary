using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace quanlythuvien
{
    public partial class trangchu : Form
    {
        public trangchu()
        {
            InitializeComponent();
        }

        private void quảnLýThẻThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void danhSáchThẻThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("nhanvien");
            if (check == false)
            {
                nhanvien f1 = new nhanvien();
                f1.MdiParent = this;
                f1.Show();
            }
            /*thethuvien f1 = new thethuvien();
            f1.MdiParent = this;
            f1.Show();*/
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("docgia");
            if (check == false)
            {
                docgia f1 = new docgia();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("dangki");
            if (check == false)
            {
                dangki f1 = new dangki();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            dangnhap f1 = new dangnhap();
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
                //f1.MdiParent = this;
                f1.Show();
                this.Close();
            }
            else
                f1.Hide();
            //f1.Close();
        }

        private void trangchu_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sTenNV FROM tblNhanVien WHERE sMaNV = '" +taikhoan+ "'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("tblNhanVien");
                        ad.Fill(tb);
                        //dataGridView1.DataSource = tb;
                    }
                }
            }

            txtUser.Text = "Xin chào " +taikhoan;
            txtUser.Enabled = false;
        }

        public static string taikhoan;
        public static string matkhau;

        //kiểm tra xem form đã mở chưa
        private bool checkFormOpen(string FormName)
        {
            groupBox1.Hide();
            FormCollection fc = Application.OpenForms;
            bool FormFound = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == FormName)
                {
                    frm.Focus();
                    FormFound = true;
                }
            }
            return FormFound;
        }

        private void quảnLýLoạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("loaisach");
            if (check == false)
            {
                loaisach f1 = new loaisach();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("sach");
            if (check == false)
            {
                sach f1 = new sach();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void quảnLýNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("nhaxuatban");
            if (check == false)
            {
                nhaxuatban f1 = new nhaxuatban();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("tacgia");
            if (check == false)
            {
                tacgia f1 = new tacgia();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void danhSáchMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Hide();
            bool check = checkFormOpen("muontra");
            if (check == false)
            {
                muontra f1 = new muontra();
                f1.MdiParent = this;
                f1.Show();
            }
        }

        private void trangchu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng form không?", "formclosing", MessageBoxButtons
                .YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.ShowDialog();

        }

       
    }
}
