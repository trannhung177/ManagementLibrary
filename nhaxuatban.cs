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
    public partial class nhaxuatban : Form
    {
        public nhaxuatban()
        {
            InitializeComponent();
        }

        public void rgLoadNXB()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vwDSNXB", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewNXB.DataSource = tb;
                    }
                }
            }
        }

        private void nhaxuatban_Load(object sender, EventArgs e)
        {
            rgLoadNXB();

            txtMaNXB.Enabled = false;
            txtTenNXB.Enabled = false;
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;
            txtTimkiem.Enabled = false;

            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void dataGridViewNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            txtMaNXB.Enabled = true;
            txtTenNXB.Enabled = true;
            txtDiachi.Enabled = true;
            txtEmail.Enabled = true;

            buttonSave.Enabled = false;

            int numrow;
            numrow = e.RowIndex;
            txtMaNXB.Text = dataGridViewNXB.Rows[numrow].Cells[0].Value.ToString();
            txtTenNXB.Text = dataGridViewNXB.Rows[numrow].Cells[1].Value.ToString();
            txtDiachi.Text = dataGridViewNXB.Rows[numrow].Cells[2].Value.ToString();
            txtEmail.Text = dataGridViewNXB.Rows[numrow].Cells[3].Value.ToString();

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            int currenIndex = dataGridViewNXB.CurrentCell.RowIndex;
            string userID = dataGridViewNXB.Rows[currenIndex].Cells[0].Value.ToString();
            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sTentacgia AS [Tác giả],sMaNXB AS [Mã NXB],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],sMaloai AS [Mã TL] FROM tblSach,tblTacGia WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND sMaNXB IN (SELECT sMaNXB FROM tblNXB WHERE sMaNXB ='" + userID + "')";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindSach, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewSach.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = true;
            txtMaNXB.ResetText();
            txtTenNXB.ResetText();
            txtDiachi.ResetText();
            txtEmail.ResetText();

            txtMaNXB.Enabled = false;
            txtTenNXB.Enabled = false;
            txtDiachi.Enabled = false;
            txtEmail.Enabled = false;

            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = false;
            txtMaNXB.ResetText();
            txtTenNXB.ResetText();
            txtDiachi.ResetText();
            txtEmail.ResetText();

            txtMaNXB.Enabled = true;
            txtTenNXB.Enabled = true;
            txtDiachi.Enabled = true;
            txtEmail.Enabled = true;

            buttonSave.Enabled = true;
        }

        private int kiemtra()
        {
            string k = txtMaNXB.Text;
            string sql = "SELECT * FROM tblNXB WHERE sMaNXB ='" + k.ToString() + "'";
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra() == 1)
                {
                    MessageBox.Show("Mã nhà xuất bản " + txtMaNXB.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaNXB.Focus();
                }
                else
                {
                    if (txtMaNXB.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemNXB";
                            cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);
                            cmd.Parameters.AddWithValue("@TenNXB", txtTenNXB.Text);
                            cmd.Parameters.AddWithValue("@Diachi", txtDiachi.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cnn.Open();
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công nhà xuất bản mã " + txtMaNXB.Text + "!", "Thông báo");
                            }
                            txtMaNXB.ResetText();
                            cnn.Close();
                            rgLoadNXB();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaNXB, "Bạn chưa nhập mã nhà xuất bản!");
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
                    cmd.CommandText = "prSuaNXB";
                    cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);
                    cmd.Parameters.AddWithValue("@TenNXB", txtTenNXB.Text);
                    cmd.Parameters.AddWithValue("@Diachi", txtDiachi.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadNXB();
                        cnn.Close();
                    }
                }
            }
        }

        public void rgLoadSach()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vwDSSach", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewSach.DataSource = tb;
                    }
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prXoaNXB";
                    cmd.Parameters.AddWithValue("@MaNXB", txtMaNXB.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtMaNXB.ResetText();
                        txtTenNXB.ResetText();
                        txtDiachi.ResetText();
                        txtEmail.ResetText();

                        DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã xóa thành công !", "Thông báo");
                                rgLoadSach();
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công !", "Thông báo");
                            }

                            cnn.Close();
                        }
                        rgLoadNXB();
                    }
                }
            } 
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindNXB = "SELECT sMaNXB AS [Mã NXB],sTenNXB AS [Tên nhà xuất bản],dDiachi AS [Trụ sở],sEmail AS [Email] FROM tblNXB WHERE sMaNXB LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindNXB, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewNXB.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sMaNXB AS [Mã NXB],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTacGia,tblTheLoai WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND tblSach.sMaloai = tblTheLoai.sMaloai AND sMaNXB LIKE '%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindSach, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewSach.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }
    }
}
