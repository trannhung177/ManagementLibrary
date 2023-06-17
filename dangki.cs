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
    public partial class dangki : Form
    {
        public dangki()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dangnhap f1 = new dangnhap();
            this.Hide();
            f1.Show();
        }

        private int kiemtra()
        {
            string k = txtMaNV.Text;
            string sql = "SELECT * FROM tblNhanVien WHERE sMaNV ='" + k.ToString() + "'";
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        if (tb.Rows.Count > 0) return 1;
                        else return 0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Đăng kí thành công !", "Thông báo");

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra() == 1)
                {
                    MessageBox.Show("Mã nhân viên " + txtMaNV.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaNV.Focus();
                }
                else
                {
                    if (txtMaNV.Text != "" && txtCMND.Text !="")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prDangKi";
                            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                            cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh",dateTimePickerNgaySinh.Text);
                            if (radioButtonNam.Checked)
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nam");
                            else
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nữ");
                            cmd.Parameters.AddWithValue("@Sdt", txtSdt.Text);
                            cmd.Parameters.AddWithValue("@Ngayvaolam", dateTimePickerNgayvaolam.Text);
                            cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                            cnn.Open();

                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đăng kí thành công !", "Thông báo");
                                txtMaNV.ResetText();
                                txtTenNV.ResetText();
                                txtSdt.ResetText();
                                txtCMND.ResetText();
                            }
                            cnn.Close();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaNV, "Bạn chưa nhập mã nhân viên!");
                        errorProvider4.SetError(txtCMND, "Bạn chưa nhập chứng minh nhân dân!");
                }
            }
            
        }

        private void txtMaNV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaNV.Text == "")
                errorProvider1.SetError(txtMaNV, "Bạn chưa nhập mã nhân viên!");
            else
                errorProvider1.SetError(txtMaNV, "");
        }
    }
}
