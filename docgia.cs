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
    public partial class docgia : Form
    {
        public docgia()
        {
            InitializeComponent();
        }

        public void rgLoadDocgia()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.vwDSSV", cnn))
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void docgia_Load(object sender, EventArgs e)
        {
            rgLoadDocgia();
            buttonLuu.Enabled = false;
            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;

            txtMaSV.Enabled = false;
            txtTenSV.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtCMND.Enabled = false;
            radioButtonNam.Enabled = false;
            radioButtonNu.Enabled = false;

            txtTimkiem.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonLuu.Enabled = false;
            buttonSua.Enabled = true;
            buttonXoa.Enabled = true;

            txtTimkiem.Enabled = false;

            txtMaSV.Enabled = true;
            txtTenSV.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtSdt.Enabled = true;
            txtEmail.Enabled = true;
            txtCMND.Enabled = true;
            radioButtonNam.Enabled = true;
            radioButtonNu.Enabled = true;

            int numrow;
            numrow = e.RowIndex;
            txtMaSV.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            txtTenSV.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            txtSdt.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            string gt = this.dataGridView1.Rows[numrow].Cells[3].Value.ToString();
            if (gt.Trim() == "Nam") //trim() cắt khoảng trắng 2 đầu
                radioButtonNam.Checked = true;
            else
                radioButtonNu.Checked = true;
            txtCMND.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
        }

        private void buttonTimkiem_Click(object sender, EventArgs e)
        {

            txtTimkiem.Enabled = true;

            txtMaSV.ResetText();
            txtTenSV.ResetText();
            dateTimePicker1.ResetText();
            txtSdt.ResetText();
            txtEmail.ResetText();
            txtCMND.ResetText();

            buttonXoa.Enabled = false;
            buttonSua.Enabled = false;
            buttonLuu.Enabled = false;

            txtMaSV.Enabled = false;
            txtTenSV.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtSdt.Enabled = false;
            txtEmail.Enabled = false;
            txtCMND.Enabled = false;
            radioButtonNam.Enabled = false;
            radioButtonNu.Enabled = false;

            if (txtTimkiem.Text != "")
                txtTimkiem.ResetText();

            /*string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prTimSV";
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;
                        int kq = cmd.ExecuteNonQuery();
                        if (txtMaSV.Text == "")
                        {
                            rgLoadDocgia();
                        }
                        cnn.Close();
                    }
                }
            }*/
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            /*string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindSV = "SELECT * FROM tblSinhVien WHERE sMaSV LIKE'%" + txtMaSV.Text + "%'";
            Console.WriteLine(sqlFindSV);
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindSV, cnn))
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
            }*/
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            rgLoadDocgia();
            txtMaSV.ResetText();
            txtTenSV.ResetText();
            dateTimePicker1.ResetText();
            txtSdt.ResetText();
            txtEmail.ResetText();
            txtCMND.ResetText();

            buttonXoa.Enabled = false;
            buttonSua.Enabled = false;
            buttonLuu.Enabled = true;

            txtMaSV.Enabled = true;
            txtTenSV.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtSdt.Enabled = true;
            txtEmail.Enabled = true;
            txtCMND.Enabled = true;
            radioButtonNam.Enabled = true;
            radioButtonNu.Enabled = true;
            
        }

        private int kiemtra()
        {
            string k = txtMaSV.Text;
            string sql = "SELECT * FROM tblSinhVien WHERE sMaSV ='" + k.ToString() + "'";
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

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra() == 1)
                {
                    MessageBox.Show("Mã sinh viên "+txtMaSV.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaSV.Focus();
                }
                else
                {
                    if (txtMaSV.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemSV";
                            cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                            cmd.Parameters.AddWithValue("@TenSV", txtTenSV.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh", /*Convert.ToDateTime(*/dateTimePicker1.Text/*)*/);
                            if (radioButtonNam.Checked)
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nam");
                            else
                                cmd.Parameters.AddWithValue("@Gioitinh", "Nữ");
                            cmd.Parameters.AddWithValue("@Sdt",txtSdt.Text);
                            cmd.Parameters.AddWithValue("@Email",txtEmail.Text);
                            cmd.Parameters.AddWithValue("@CMND", txtCMND.Text);
                            cnn.Open();

                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công sinh viên mã "+txtMaSV.Text +"!", "Thông báo");
                            }
                            txtMaSV.ResetText();
                            cnn.Close();
                            rgLoadDocgia();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaSV, "Bạn chưa nhập mã sinh viên!");
                }
            }
        }

        private void txtMaSV_Validating(object sender, CancelEventArgs e)
        {
            if (txtMaSV.Text == "")
                errorProvider1.SetError(txtMaSV, "Bạn chưa nhập mã sinh viên!");
            else
                errorProvider1.SetError(txtMaSV, "");
        }

        private void txtTenSV_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenSV.Text == "")
                errorProvider2.SetError(txtTenSV, "Bạn chưa nhập tên sinh viên!");
            else
                errorProvider2.SetError(txtTenSV, "");
        }

        private void txtSdt_Validating(object sender, CancelEventArgs e)
        {
            if (txtSdt.Text == "")
                errorProvider3.SetError(txtSdt, "Bạn chưa nhập số điện thoại!");
            else
                errorProvider3.SetError(txtSdt, "");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text == "")
                errorProvider4.SetError(txtEmail, "Bạn chưa nhập email!");
            else
                errorProvider4.SetError(txtEmail, "");
        }

        private void txtCMND_Validating(object sender, CancelEventArgs e)
        {
            if (txtCMND.Text == "")
                errorProvider4.SetError(txtCMND, "Bạn chưa nhập CMND!");
            else
                errorProvider5.SetError(txtCMND, "");
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prSuaSV";
                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@TenSV", txtTenSV.Text);
                    cmd.Parameters.AddWithValue("@Ngaysinh", /*Convert.ToDateTime(*/dateTimePicker1.Text/*)*/);
                    if (radioButtonNam.Checked)
                        cmd.Parameters.AddWithValue("@Gioitinh", "Nam");
                    else
                        cmd.Parameters.AddWithValue("@Gioitinh", "Nữ");
                    cmd.Parameters.AddWithValue("@Sdt", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
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
                        rgLoadDocgia();
                        cnn.Close();
                    }
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    int currenIndex = dataGridView1.CurrentCell.RowIndex;
                    string userID = dataGridView1.Rows[currenIndex].Cells[0].Value.ToString();
                    string deleteStr = "DELETE FROM tblSinhVien WHERE sMaSV = '" + userID + "'";
                    SqlCommand deleteCmd = new SqlCommand(deleteStr, cnn);
                    deleteCmd.CommandType = CommandType.Text;
                    txtMaSV.ResetText();
                    txtTenSV.ResetText();
                    dateTimePicker1.ResetText();
                    txtSdt.ResetText();
                    txtEmail.ResetText();
                    txtCMND.ResetText();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                       
                        int kq = deleteCmd.ExecuteNonQuery();
                        if (kq > 0)
                        {
                            MessageBox.Show("Đã xóa thành công !", "Thông báo");
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công !", "Thông báo");
                        }
                        rgLoadDocgia();
                        cnn.Close();
                    }
                }
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindSV = "SELECT sMaSV AS [Mã sinh viên],sTenSV AS [Tên sinh viên],dNgaysinh AS [Ngày sinh],sGioitinh AS [Giới tính], sSdt AS [Số điện thoại],sEmail AS [Địa chỉ Email],sCMND AS [Chứng minh nhân dân] FROM tblSinhVien WHERE sMaSV LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindSV, cnn))
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
    }
}
