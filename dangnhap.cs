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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            dangki f1 = new dangki();
            this.Hide();
            f1.Show();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
            int dem;
        private void button1_Click(object sender, EventArgs e)
        {
            //trangchu f1 = new trangchu();
            ////f1.Show();
            //trangchu.taikhoan = txtDangnhap.Text;
            //f1.ShowDialog();

            if (txtDangnhap.Text == "" && txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản và mật khẩu !", "Thông báo !");
                txtDangnhap.Focus();
            }
            else if (txtDangnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản ! ", "Thông báo !");
                txtDangnhap.Focus();
            }
            else if (txtMatkhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu !", "Thông báo !");
                txtMatkhau.Focus();
            }
            else
            {
                string dangnhap = Convert.ToString("SELECT sTenNV FROM tblNhanVien WHERE sMaNV =");
                string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                SqlConnection conn = new SqlConnection(constr);
                conn.Open();
                string sqlkt = "Select count(*) from tblDangNhap WHERE sMaNV='" + txtDangnhap.Text + "' and sMatkhau='" + txtMatkhau.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlkt, conn);
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    MessageBox.Show("Đăng nhập thành công !", "Thông báo");
                    trangchu.taikhoan = txtDangnhap.Text;
                    trangchu f1 = new trangchu();
                    this.Hide();
                    f1.Show();

                }
                else
                {
                    dem++;
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !", "Thông báo");
                    txtDangnhap.Focus();
                    if(dem == 5)
                    {
                        this.Hide();
                        this.Close();
                    }
                }
                conn.Close();
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtMatkhau.UseSystemPasswordChar = true;
            else
                txtMatkhau.UseSystemPasswordChar = false;
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
                this.Close();
            }
        }

        private void txtDangnhap_Validating(object sender, CancelEventArgs e)
        {
            if (txtDangnhap.Text == "")
                errorProvider1.SetError(txtDangnhap, "Bạn chưa nhập tên đăng nhập!");
            else
                errorProvider1.SetError(txtDangnhap, "");
        }

        private void maskedTextBoxMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatkhau.Text == "")
                errorProvider1.SetError(txtMatkhau, "Bạn chưa nhập mật khẩu!");
            else
                errorProvider1.SetError(txtMatkhau, "");
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dangnhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void linkLabel2_MouseClick(object sender, MouseEventArgs e)
        {
            quenmatkhau f2 = new quenmatkhau();
            this.Hide();
            f2.Show();
        }
        /*private void dangnhap_Load(object sender, EventArgs e)
{
   txtDangnhap.Text = Properties.Settings.Default.tendn;
   txtMatkhau.Text = Properties.Settings.Default.matkhau;
   if (Properties.Settings.Default.tendn != "")
   {
       checktn.Checked = true;
   }
}*/
        /*
          private void checktn_CheckedChanged(object sender, EventArgs e)
        {
            if(txtDangnhap.Text != "" && txtMatkhau.Text != "")
            {
                if(checktn.Checked == true)
                {
                    string user = txtDangnhap.Text;
                    string pw = txtMatkhau.Text;
                    Properties.Settings.Default.tendn = user;
                    Properties.Settings.Default.matkhau = pw;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }
         */
    }
}
