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
    public partial class nhanvien : Form
    {
        public nhanvien()
        {
            InitializeComponent();
        }
        public void rgLoadNV()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.vwDSNV", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;
                    }
                }
            }
        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            rgLoadNV();

            buttonSave.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            txtTimkiem.Enabled = false;
            txtSdt.Enabled = false;
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtSdt.Enabled = false;
            dateTimePicker2.Enabled = false;
            txtCMND.Enabled = false;
            radioButtonNam.Enabled = false;
            radioButtonNu.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonSave.Enabled = false;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            txtTimkiem.Enabled = false;
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtSdt.Enabled = true;
            dateTimePicker2.Enabled = true;
            txtCMND.Enabled = true;
            radioButtonNam.Enabled = true;
            radioButtonNu.Enabled = true;

            int numrow;
            numrow = e.RowIndex;
            txtMaNV.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenNV.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            string gt = this.dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            if (gt.Trim() == "Nam") //trim() cắt khoảng trắng 2 đầu
                radioButtonNam.Checked = true;
            else
                radioButtonNu.Checked = true;
            txtCMND.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
        }
        /*string ngaysinh = (Convert.ToDateTime(dgrNhanvien.Rows[index].Cells[3].Value, new CultureInfo("vi-VN")).ToString());
                if (ngaysinh.Length == 21) // ngay sinh 26/6/2000 thì length =21 ngay sinh 26/12/2000 = 22
                {
                    string ngay = ngaysinh.Substring(0, 2);
                    if (ngay.Contains("/")) // 3/12/2000 thiếu số ở ngày
                    {
                        mskNgaysinh.Text = "0"+ngaysinh.Substring(0, 1)+ngaysinh.Substring(2, 17);
                    }
                    else // thiếu số ở tháng 12/3/2000
                    {
                        mskNgaysinh.Text = ngaysinh.Substring(0, 2) + "0" + ngaysinh.Substring(2, 18);
                    }
                }
                else
                {
                    if (ngaysinh.Length == 22) // 12/12/2000 đủ số
                    {
                        mskNgaysinh.Text = ngaysinh;
                    }
                    if (ngaysinh.Length == 20) // 6/6/2000 thiếu 2 số
                    {
                        mskNgaysinh.Text = "0" + ngaysinh.Substring(0, 2) + "0" + ngaysinh.Substring(2, 16);
                    }
                }*/
        private void buttonFind_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = true;

            txtMaNV.ResetText();
            txtTenNV.ResetText();
            dateTimePicker1.ResetText();
            txtSdt.ResetText();
            dateTimePicker1.ResetText();
            txtCMND.ResetText();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;

            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtSdt.Enabled = false;
            dateTimePicker2.Enabled = false;
            txtCMND.Enabled = false;
            radioButtonNam.Enabled = false;
            radioButtonNu.Enabled = false;

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prTimNV";
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;
                        int kq = cmd.ExecuteNonQuery();
                        if (txtMaNV.Text == "")
                        {
                            rgLoadNV();
                        }
                        cnn.Close();
                    }
                }
            } 
        }

        private int kiemtra()
        {
            string k = txtMaNV.Text;
            string sql = "SELECT * FROM tblNhanVien WHERE sMaNV =N'" + k.ToString() + "'";
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
        /*private int kiemtra1()
        {
            string k = txtTenNV.Text;
            string sql = "SELECT * FROM tblNhanVien WHERE sTenNV =N'" + k.ToString() + "'";
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
        }*/
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra() == 1)
                {
                    MessageBox.Show("Mã nhân viên "+txtMaNV.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaNV.Focus();
                }
                else
                {
                    if (txtMaNV.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemNV";
                            cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                            cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh", /*Convert.ToDateTime(*/dateTimePicker1.Text/*)*/);
                            if (radioButtonNam.Checked)
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nam");
                            else
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nữ");
                            cmd.Parameters.AddWithValue("@Sdt", txtSdt.Text);
                            cmd.Parameters.AddWithValue("@Ngayvaolam", dateTimePicker2.Text);
                            cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                            cnn.Open();

                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công nhân viên " + txtMaNV.Text +"!", "Thông báo");
                            }
                            txtMaNV.ResetText();
                            cnn.Close();
                            rgLoadNV();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaNV, "Bạn chưa nhập mã nhân viên!");
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

        private void txtTenNV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenNV.Text == "")
                errorProvider2.SetError(txtTenNV, "Bạn chưa nhập tên nhân viên!");
            else
                errorProvider2.SetError(txtTenNV, "");
        }

        private void txtSdt_Validating(object sender, CancelEventArgs e)
        {
            if (txtSdt.Text == "")
                errorProvider3.SetError(txtSdt, "Bạn chưa nhập số điện thoại!");
            else
                errorProvider3.SetError(txtSdt, "");
        }

        private void txtCMND_Validating(object sender, CancelEventArgs e)
        {
            if (txtCMND.Text == "")
                errorProvider4.SetError(txtCMND, "Bạn chưa nhập chứng minh nhân dân!");
            else
                errorProvider4.SetError(txtCMND, "");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            rgLoadNV();
            txtMaNV.ResetText();
            txtTenNV.ResetText();
            txtSdt.ResetText();
            txtCMND.ResetText();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            txtCMND.ResetText();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = true;

            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtSdt.Enabled = true;
            dateTimePicker2.Enabled = true;
            txtCMND.Enabled = true;
            radioButtonNam.Enabled = true;
            radioButtonNu.Enabled = true;
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prXoaNV";
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtMaNV.ResetText();
                        txtTenNV.ResetText();
                        dateTimePicker1.ResetText();
                        txtSdt.ResetText();
                        dateTimePicker2.ResetText();
                        txtCMND.ResetText();
                        
                        DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã xóa thành công !", "Thông báo");
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công !", "Thông báo");                           
                            }
                            
                            cnn.Close();
                        }
                        rgLoadNV();
                    }
                }
            } 
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prSuaNV";
                    cmd.Parameters.AddWithValue("@MaNV", txtMaNV.Text);
                    cmd.Parameters.AddWithValue("@TenNV", txtTenNV.Text);
                    cmd.Parameters.AddWithValue("@Ngaysinh", /*Convert.ToDateTime(*/dateTimePicker1.Text/*)*/);
                    if (radioButtonNam.Checked)
                        cmd.Parameters.AddWithValue("@Gioitinh", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@Gioitinh", "Nữ");
                    cmd.Parameters.AddWithValue("@Sdt", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@Ngayvaolam", dateTimePicker2.Text);
                    cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadNV();
                        cnn.Close();
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindNV = "SELECT sMaNV AS [Mã nhân viên],sTenNV AS [Tên nhân viên],dNgaysinh AS [Ngày sinh],sGioitinh AS [Giới tính], sSDT AS [Số điện thoại], dNgayvaolam AS [Ngày vào làm],sCMND AS [Chứng minh nhân dân] FROM tblNhanVien WHERE sMaNV LIKE N'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindNV, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }


        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            
            int namht = DateTime.Now.Year;
            int namsinh = dateTimePicker1.Value.Year;
            if (namht - namsinh <18)
            {
                errorProvider5.SetError(dateTimePicker1, "Nhân viên chưa đủ 18!");
            }
            else
            {
                errorProvider5.SetError(dateTimePicker1, "");
            }
            /*DateTime tg = DateTime.Now;
            TimeSpan time = tg.Subtract(dateTimePicker1.Value);
            int tuoi = time.Days / 365;
            if (tuoi < 18)
            {
                errorProvider5.SetError(dateTimePicker1, "Tuổi phải lớn hơn 18");
            }
            else
            {
                errorProvider5.SetError(dateTimePicker1, "");
            }*/
        }
    }
}
