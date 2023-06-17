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
    public partial class loaisach : Form
    {
        public loaisach()
        {
            InitializeComponent();
        }

        public void rgLoadTheloai()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vw_DSTheloai", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewLoaisach.DataSource = tb;
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

        private void loaisach_Load(object sender, EventArgs e)
        {
            rgLoadTheloai();

            txtMaloaisach.Enabled = false;
            txtTenloaisach.Enabled = false;
            txtTimkiem.Enabled = false;

            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void dataGridViewLoaisach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            txtMaloaisach.Enabled = true;
            txtTenloaisach.Enabled = true;

            buttonSave.Enabled = false;

            int numrow;
            numrow = e.RowIndex;
            txtMaloaisach.Text = dataGridViewLoaisach.Rows[numrow].Cells[0].Value.ToString();
            txtTenloaisach.Text = dataGridViewLoaisach.Rows[numrow].Cells[1].Value.ToString();

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            int currenIndex = dataGridViewLoaisach.CurrentCell.RowIndex;
            string userID = dataGridViewLoaisach.Rows[currenIndex].Cells[0].Value.ToString();
            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sTentacgia AS [Tác giả],sMaNXB AS [Mã NXB],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],sMaloai AS [Mã TL] FROM tblSach,tblTacGia WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND sMaloai IN (SELECT sMaloai FROM tblTheloai WHERE sMaloai ='" + userID + "')";
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

        private void dataGridViewSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindLoaisach = "SELECT sMaloai AS [Mã thể loại],sTenloai AS [Tên thể loại] FROM tblTheLoai WHERE sMaloai LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindLoaisach, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewLoaisach.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sTentacgia AS [Tác giả],tblNXB.sMaNXB AS [Mã NXB],sTenNXB AS [Nhà xuất bản],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTacGia,tblTheLoai,tblNXB WHERE tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sTacgia = tblTacGia.sMatacgia AND tblSach.sMaloai = tblTheLoai.sMaloai AND tblTheLoai.sMaloai LIKE'%" + txtTimkiem.Text + "%'";
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
            txtMaloaisach.Enabled = false;
            txtTenloaisach.Enabled = false;

            txtMaloaisach.ResetText();
            txtTenloaisach.ResetText();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            txtMaloaisach.ResetText();
            txtTenloaisach.ResetText();

            txtMaloaisach.Enabled = true;
            txtTenloaisach.Enabled = true;
            buttonSave.Enabled = true;

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prSuaTL";
                    cmd.Parameters.AddWithValue("@Matheloai", txtMaloaisach.Text);
                    cmd.Parameters.AddWithValue("@Tentheloai", txtTenloaisach.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadTheloai();
                        cnn.Close();
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
                    cmd.CommandText = "prXoaTL";
                    cmd.Parameters.AddWithValue("@Matheloai", txtMaloaisach.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtMaloaisach.ResetText();
                        txtTenloaisach.ResetText();

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
                        rgLoadTheloai();
                    }
                }
            } 
        }

        private int kiemtra()
        {
            string k = txtMaloaisach.Text;
            string sql = "SELECT * FROM tblTheLoai WHERE sMaloai ='" + k.ToString() + "'";
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
                    MessageBox.Show("Mã loại sách " + txtMaloaisach.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaloaisach.Focus();
                }
                else
                {
                    if (txtMaloaisach.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemTL";
                            cmd.Parameters.AddWithValue("@Matheloai", txtMaloaisach.Text);
                            cmd.Parameters.AddWithValue("@Tentheloai", txtTenloaisach.Text);
                            cnn.Open();
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công thể loại sách mã " + txtMaloaisach.Text + "!", "Thông báo");
                            }
                            txtMaloaisach.ResetText();
                            cnn.Close();
                            rgLoadTheloai();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaloaisach, "Bạn chưa nhập mã thể loại sách!");
                }
            }
        }
    }
}
