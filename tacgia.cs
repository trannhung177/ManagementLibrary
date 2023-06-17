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
    public partial class tacgia : Form
    {
        public tacgia()
        {
            InitializeComponent();
        }

        public void rgLoadTacgia()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vwDSTacgia", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewTacgia.DataSource = tb;
                    }
                }
            }
        }

        private void tacgia_Load(object sender, EventArgs e)
        {
            rgLoadTacgia();

            txtMaTG.Enabled = false;
            txtTenTG.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtNoiCT.Enabled = false;
            txtTimkiem.Enabled = false;

            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void dataGridViewTacgia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            txtMaTG.Enabled = true;
            txtTenTG.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtNoiCT.Enabled = true;

            buttonSave.Enabled = false;

            int numrow;
            numrow = e.RowIndex;
            txtMaTG.Text = dataGridViewTacgia.Rows[numrow].Cells[0].Value.ToString();
            txtTenTG.Text = dataGridViewTacgia.Rows[numrow].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridViewTacgia.Rows[numrow].Cells[2].Value.ToString();
            txtNoiCT.Text = dataGridViewTacgia.Rows[numrow].Cells[3].Value.ToString();

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            int currenIndex = dataGridViewTacgia.CurrentCell.RowIndex;
            string userID = dataGridViewTacgia.Rows[currenIndex].Cells[0].Value.ToString();
            string sqlFindTG = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sTacgia AS [Mã tác giả],tblNXB.sMaNXB AS [Mã NXB], sTenNXB AS [Nhà xuất bản],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách], tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTheLoai,tblNXB WHERE tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sMaloai = tblTheLoai.sMaloai AND sTacgia IN (SELECT sMatacgia FROM tblTacGia WHERE sMatacgia ='" + userID + "')";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindTG, cnn))
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

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindTG = "SELECT sMatacgia AS [Mã tác giả],sTentacgia AS [Tên tác giả],dNgaysinh AS [Ngày sinh],sNoiCT AS [Đơn vị công tác] FROM tblTacGia WHERE sMatacgia LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindTG, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewTacgia.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sMaNXB AS [Mã NXB],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTacGia,tblTheLoai WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND tblSach.sMaloai = tblTheLoai.sMaloai AND sMatacgia LIKE '%" + txtTimkiem.Text + "%'";
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
            txtMaTG.ResetText();
            txtTenTG.ResetText();
            dateTimePicker1.ResetText();
            txtNoiCT.ResetText();

            txtMaTG.Enabled = false;
            txtTenTG.Enabled = false;
            dateTimePicker1.Enabled = false;
            txtNoiCT.Enabled = false;

            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = false;
            txtMaTG.ResetText();
            txtTenTG.ResetText();
            dateTimePicker1.ResetText();
            txtNoiCT.ResetText();

            txtMaTG.Enabled = true;
            txtTenTG.Enabled = true;
            dateTimePicker1.Enabled = true;
            txtNoiCT.Enabled = true;

            buttonSave.Enabled = true;
        }

        private int kiemtra()
        {
            string k = txtMaTG.Text;
            string sql = "SELECT * FROM tblTacGia WHERE sMatacgia ='" + k.ToString() + "'";
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
                    MessageBox.Show("Mã tác giả " + txtMaTG.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaTG.Focus();
                }
                else
                {
                    if (txtMaTG.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemTG";
                            cmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
                            cmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
                            cmd.Parameters.AddWithValue("@Ngaysinh", dateTimePicker1.Text);
                            cmd.Parameters.AddWithValue("@NoiCT", txtNoiCT.Text);
                            cnn.Open();
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công tác giả mã " + txtMaTG.Text + "!", "Thông báo");
                            }
                            txtMaTG.ResetText();
                            cnn.Close();
                            rgLoadTacgia();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaTG, "Bạn chưa nhập mã tác giả !");
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
                    cmd.CommandText = "prSuaTG";
                    cmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
                    cmd.Parameters.AddWithValue("@TenTG", txtTenTG.Text);
                    cmd.Parameters.AddWithValue("@Ngaysinh", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@NoiCT", txtNoiCT.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadTacgia();
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
                    cmd.CommandText = "prXoaTG";
                    cmd.Parameters.AddWithValue("@MaTG", txtMaTG.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtTenTG.ResetText();
                        txtMaTG.ResetText();
                        dateTimePicker1.ResetText();
                        txtNoiCT.ResetText();

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
                        rgLoadTacgia();
                    }
                }
            } 
        }
    }
}
