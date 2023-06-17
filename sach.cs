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
    public partial class sach : Form
    {
        public sach()
        {
            InitializeComponent();
        }

        private void sach_Load(object sender, EventArgs e)
        {
            rgLoadSach();
            layTacgia();
            layTheloai();
            layNXB();

            buttonSave.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;

            txtTimkiem.Enabled = false;
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtNamXB.Enabled = false;
            txtTinhtrang.Enabled = false;

            comboBoxTenTG.Enabled = false;
            comboBoxTenNXB.Enabled = false;
            comboBoxLoaisach.Enabled = false;
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
                        dataGridView1.DataSource = tb;
                    }
                }
            }
        }

        private void layTacgia()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblTacGia", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("TG");
                        ad.Fill(tb);
                        comboBoxTenTG.DataSource = tb;
                        comboBoxTenTG.DisplayMember = "sTentacgia";
                        comboBoxTenTG.ValueMember = "sMatacgia";
                    }
                }
            }
        }

        private void layTheloai()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblTheLoai", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("TL");
                        ad.Fill(tb);
                        comboBoxLoaisach.DataSource = tb;
                        comboBoxLoaisach.DisplayMember = "sTenloai";
                        comboBoxLoaisach.ValueMember = "sMaloai";
                    }
                }
            }
        }

        private void layNXB()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblNXB", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("NXB");
                        ad.Fill(tb);
                        comboBoxTenNXB.DataSource = tb;
                        comboBoxTenNXB.DisplayMember = "sTenNXB";
                        comboBoxTenNXB.ValueMember = "sMaNXB";
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
            buttonSave.Enabled = false;

            txtMaSach.Enabled = true;
            txtTenSach.Enabled = true;
            comboBoxTenTG.Enabled = true;
            comboBoxTenNXB.Enabled = true;
            txtNamXB.Enabled = true;
            txtTinhtrang.Enabled = true;
            comboBoxLoaisach.Enabled = true;

            int numrow;
            numrow = e.RowIndex;
            txtMaSach.Text = dataGridView1.Rows[numrow].Cells[0].FormattedValue.ToString();
            txtTenSach.Text = dataGridView1.Rows[numrow].Cells[1].FormattedValue.ToString();
            comboBoxTenTG.SelectedValue = dataGridView1.CurrentRow.Cells[2].FormattedValue.ToString();
            comboBoxTenNXB.SelectedValue = dataGridView1.CurrentRow.Cells[4].FormattedValue.ToString();
            txtNamXB.Text = dataGridView1.Rows[numrow].Cells[6].FormattedValue.ToString();
            txtTinhtrang.Text = dataGridView1.Rows[numrow].Cells[7].FormattedValue.ToString();
            comboBoxLoaisach.SelectedValue = dataGridView1.CurrentRow.Cells[8].FormattedValue.ToString();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = true;

            txtMaSach.ResetText();
            txtTenSach.ResetText();
            txtNamXB.ResetText();
            txtTinhtrang.ResetText();

            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            comboBoxTenTG.Enabled = false;
            comboBoxTenNXB.Enabled = false;
            txtNamXB.Enabled = false;
            txtTinhtrang.Enabled = false;
            comboBoxLoaisach.Enabled = false;

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;

            if(txtTimkiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sách !", "Thông báo");
            }
            else
            {
                rgLoadSach();
            }

           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            rgLoadSach();
            txtMaSach.ResetText();
            txtTenSach.ResetText();
            txtNamXB.ResetText();
            txtTinhtrang.ResetText();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = true;

            txtMaSach.Enabled = true;
            txtTenSach.Enabled = true;
            comboBoxTenTG.Enabled = true;
            comboBoxTenNXB.Enabled = true;
            txtNamXB.Enabled = true;
            txtTinhtrang.Enabled = true;
            comboBoxLoaisach.Enabled = true;
        }

        private int kiemtra()
        {
            string k = txtMaSach.Text;
            string sql = "SELECT * FROM tblSach WHERE sMasach ='" + k.ToString() + "'";
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
        private int kiemtra1()
        {
            string k = txtTenSach.Text;
            string sql = "SELECT * FROM tblSach WHERE sTensach =N'" + k.ToString() + "'";
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
        //kiem tra ma sach va ten tac gia cung trung
        private int kiemtramasach_tentacgia()
        {
            string masach = txtMaSach.Text;
            string tentg = Convert.ToString(comboBoxTenTG.SelectedValue);
            string sql = "SELECT * FROM tblSach,tblTacGia WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND sMasach= '" + masach + "' AND tblTacGia.sTentacgia= '" + tentg + "'";
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

        //kiem tra ma sach trung nhung ten tac gia khong trung
        private int kiemtramasachtrung_tentacgiakhongtrung()
        {
            string masach = txtMaSach.Text;
            string tentg = Convert.ToString(comboBoxTenTG.SelectedValue);
            string sql = "SELECT * FROM tblSach,tblTacGia WHERE tblSach.sTacgia = tblTacGia.sMatacgia AND sMasach= '" + masach + "' AND tblTacGia.sTentacgia != '" + tentg + "'";
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
            /*string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra() == 1)
                {
                    MessageBox.Show("Mã sách " + txtMaSach.Text + " đã có, không thể thêm !", "Thông báo");
                    txtMaSach.Focus();
                }
                else
                {
                    if (txtMaSach.Text != "")
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemSach";
                            cmd.Parameters.AddWithValue("@Masach",txtMaSach.Text);
                            cmd.Parameters.AddWithValue("@Tensach",txtTenSach.Text);
                            cmd.Parameters.AddWithValue("@Matacgia",comboBoxTenTG.SelectedValue);
                            cmd.Parameters.AddWithValue("@MaNXB",comboBoxTenNXB.SelectedValue);
                            cmd.Parameters.AddWithValue("@NamXB",txtNamXB.Text);
                            cmd.Parameters.AddWithValue("@Tinhtrang",txtTinhtrang.Text);
                            cmd.Parameters.AddWithValue("@Maloai",comboBoxLoaisach.SelectedValue);
                            cnn.Open();

                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công sách mã " + txtMaSach.Text + "!", "Thông báo");
                            }
                            txtMaSach.ResetText();
                            cnn.Close();
                            rgLoadSach();
                        }
                    }
                    else
                        errorProvider1.SetError(txtMaSach, "Bạn chưa nhập mã sách !");
                }
            }*/

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if(kiemtramasach_tentacgia() == 1)
                {
                    MessageBox.Show("Mã sách " + txtMaSach.Text + ", tên tác giả " + comboBoxTenTG.SelectedValue + " đã có, không thể thêm !", "Thông báo");
                    txtMaSach.Focus();
                    comboBoxTenTG.Focus();
                }
                else
                {
                    if (kiemtramasachtrung_tentacgiakhongtrung() == 1)
                    {
                        MessageBox.Show("Mã sách " + txtMaSach.Text + " đã có, không thể thêm !", "Thông báo");
                        txtMaSach.Focus();
                    }
                    else
                    {   if(kiemtra1() ==1)
                        {
                            MessageBox.Show("Tên sách " + txtTenSach.Text + " đã có, không thể thêm !", "Thông báo");
                        }
                        else
                        {
                            if (txtMaSach.Text != "")
                            {
                                using (SqlCommand cmd = cnn.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "prThemSach";
                                    cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);
                                    cmd.Parameters.AddWithValue("@Tensach", txtTenSach.Text);
                                    cmd.Parameters.AddWithValue("@Matacgia", comboBoxTenTG.SelectedValue);
                                    cmd.Parameters.AddWithValue("@MaNXB", comboBoxTenNXB.SelectedValue);
                                    cmd.Parameters.AddWithValue("@NamXB", txtNamXB.Text);
                                    cmd.Parameters.AddWithValue("@Tinhtrang", txtTinhtrang.Text);
                                    cmd.Parameters.AddWithValue("@Maloai", comboBoxLoaisach.SelectedValue);
                                    cnn.Open();

                                    int kq = cmd.ExecuteNonQuery();
                                    if (kq > 0)
                                    {
                                        MessageBox.Show("Đã thêm thành công sách mã " + txtMaSach.Text + "!", "Thông báo");
                                    }
                                    txtMaSach.ResetText();
                                    cnn.Close();
                                    rgLoadSach();
                                }
                            }
                            else
                                errorProvider1.SetError(txtMaSach, "Bạn chưa nhập mã sách !");
                        }
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
                    cmd.CommandText = "prSuaSach";
                    cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);
                    cmd.Parameters.AddWithValue("@Tensach", txtTenSach.Text);
                    cmd.Parameters.AddWithValue("@Matacgia", comboBoxTenTG.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaNXB", comboBoxTenNXB.SelectedValue);
                    cmd.Parameters.AddWithValue("@NamXB", txtNamXB.Text);
                    cmd.Parameters.AddWithValue("@Tinhtrang", txtTinhtrang.Text);
                    cmd.Parameters.AddWithValue("@Maloai", comboBoxLoaisach.SelectedValue);
                    cnn.Open();

                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadSach();
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
                    cmd.CommandText = "prXoaSach";
                    cmd.Parameters.AddWithValue("@Masach", txtMaSach.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtMaSach.ResetText();
                        txtTenSach.ResetText();
                        txtNamXB.ResetText();
                        txtTinhtrang.ResetText();

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
                        rgLoadSach();
                    }
                }
            } 
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindSach = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sMatacgia AS [Mã tác giả],sTentacgia AS [Tác giả],tblNXB.sMaNXB AS [Mã NXB],sTenNXB AS [Nhà xuất bản],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTacGia,tblTheLoai,tblNXB WHERE tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sTacgia = tblTacGia.sMatacgia AND tblSach.sMaloai = tblTheLoai.sMaloai AND sMasach LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {      
                    using (SqlCommand cmd = new SqlCommand(sqlFindSach, cnn))
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

        private void comboBoxTenTG_SelectedValueChanged(object sender, EventArgs e)
        {
            //string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            //string TG = comboBoxTenTG.Text;
            //string sqlTG = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sTacgia AS [Mã tác giả],sTentacgia AS [Tác giả],tblNXB.sMaNXB AS [Mã NXB], sTenNXB AS [Nhà xuất bản],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTheLoai,tblNXB,tblTacGia WHERE tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sMaloai = tblTheLoai.sMaloai AND tblSach.sTacgia = tblTacGia.sMatacgia AND tblTacGia.sTentacgia = N'" + TG + "'";
            //using (SqlConnection cnn = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(sqlTG, cnn))
            //    {
            //        cnn.Open();
            //        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            //        {
            //            DataTable tb = new DataTable();
            //            ad.Fill(tb);
            //            dataGridView1.DataSource = tb;
            //            cnn.Close();
            //            cnn.Dispose();
            //        }
            //    }
            //}
        }

        private void comboBoxTenTG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            //string TG = Convert.ToString(comboBoxTenTG.SelectedValue);
            ////string sqlTG = "SELECT sMasach AS [Mã sách],sTensach AS [Tên sách],sTacgia AS [Mã tác giả],tblNXB.sMaNXB AS [Mã NXB], sTenNXB AS [Nhà xuất bản],iNamXB AS [Năm xuất bản],sTinhtrangsach AS [Tình trạng sách],tblTheLoai.sMaloai AS [Mã TL],sTenloai AS [Thể loại] FROM tblSach,tblTheLoai,tblNXB WHERE tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sMaloai = tblTheLoai.sMaloai AND sTacgia = '" + TG + "'";
            //string test = "SELECT * FROM tblSach WHERE sTacgia= '" + TG + "'";
            //using (SqlConnection cnn = new SqlConnection(constr))
            //{
            //    using (SqlCommand cmd = new SqlCommand(test, cnn))
            //    {
            //        cnn.Open();
            //        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
            //        {
            //            DataTable tb = new DataTable();
            //            ad.Fill(tb);
            //            dataGridView1.DataSource = tb;
            //            cnn.Close();
            //            cnn.Dispose();
            //        }
            //    }
            //}
        }
    }
}
