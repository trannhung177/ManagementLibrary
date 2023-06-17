using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlythuvien
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QLThuVien;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(*) FROM dbo.tblDangNhap WHERE sMaNV = N'" + txttendangnhapdmk.Text +"'AND sMatkhau = N'" + txtmatkhaucu.Text +"'", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if(dt.Rows[0][0].ToString() == "1")
            {
                if(txtmatkhaumoi.Text == txtnlmatkhau.Text)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("UPDATE dbo.tblDangNhap SET sMatkhau = N'" + txtmatkhaumoi.Text + "' WHERE sMaNV = N'" + txttendangnhapdmk.Text + "'AND sMatkhau = N'" + txtmatkhaucu.Text + "'", cnn);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    errorProvider1.SetError(txtmatkhaumoi, "Bạn chưa điền mật khẩu!");
                    errorProvider1.SetError(txtnlmatkhau, "Mật khẩu nhập lại chưa đúng!");
                }
            }
            else
            {
                errorProvider1.SetError(txttendangnhapdmk, "Tên đăng nhập người dùng chưa đúng!");
                errorProvider1.SetError(txtmatkhaucu, "Mật khẩu cũ không đúng!");
            }
        }

        private void DoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
