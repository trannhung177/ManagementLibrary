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
    public partial class muontra : Form
    {
        public muontra()
        {
            InitializeComponent();
        }

        public void rgLoadMT()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vwDSMuonTra", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewMT.DataSource = tb;
                    }
                }
            }
        }

        private void laySV()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSinhVien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("tblSinhVien");
                        ad.Fill(tb);
                        comboBoxSV.DataSource = tb;
                        comboBoxSV.DisplayMember = "sTenSV";
                        comboBoxSV.ValueMember = "sMaSV";
                    }
                }
            }
        }

        private void layNV()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblNhanVien", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("tblNhanVien");
                        ad.Fill(tb);
                        comboBoxNV.DataSource = tb;
                        comboBoxNV.DisplayMember = "sTenNV";
                        comboBoxNV.ValueMember = "sMaNV";
                    }
                }
            }
        }

        private void muontra_Load(object sender, EventArgs e)
        {
            rgLoadMT();
            laySV();
            layNV();

            layMT();
            layCTMT();

            rgLoadCTMT();

            txtTimkiem.Enabled = false;
            txtMaMT.Enabled = false;
            comboBoxSV.Enabled = false;
            comboBoxNV.Enabled = false;
            dateTimePicker1.Enabled = false;

            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
            buttonDelete.Enabled = false;

            txtTimkiem2.Enabled = false;
            comboBoxMaMT.Enabled = false;
            comboBoxTenSach.Enabled = false;
            dateTimePicker2.Enabled = false;

            buttonUpdate2.Enabled = false;
            buttonSave2.Enabled = false;
            buttonDelete2.Enabled = false;
        }

        private void dataGridViewMT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;

            txtMaMT.Enabled = true;
            comboBoxSV.Enabled = true;
            comboBoxNV.Enabled = true;
            dateTimePicker1.Enabled = true;

            buttonSave.Enabled = false;

            int numrow;
            numrow = e.RowIndex;
            txtMaMT.Text = dataGridViewMT.Rows[numrow].Cells[0].Value.ToString();
            comboBoxSV.Text = dataGridViewMT.Rows[numrow].Cells[2].Value.ToString();
            comboBoxNV.Text = dataGridViewMT.Rows[numrow].Cells[4].Value.ToString();
            dateTimePicker1.Text = dataGridViewMT.Rows[numrow].Cells[5].Value.ToString();
            

            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            int currenIndex = dataGridViewMT.CurrentCell.RowIndex;
            string userID = dataGridViewMT.Rows[currenIndex].Cells[0].Value.ToString();
            string sqlFindCTMT = "SELECT sMaMT AS [Mã mượn trả],tblSach.sMaSach AS [Mã sách],sTensach AS [Tên sách],dNgaytra AS [Ngày trả] FROM tblSach,tblCTMuonTra WHERE tblSach.sMasach = tblCTMuonTra.sMasach AND sMaMT IN (SELECT sMaMT FROM tblMuonTra WHERE sMaMT ='" + userID + "')";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindCTMT, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewCTMT.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = false;
            txtMaMT.Enabled = true;
            comboBoxSV.Enabled = true;
            comboBoxNV.Enabled = true;
            dateTimePicker1.Enabled = true;

            txtMaMT.ResetText();
            dateTimePicker1.ResetText();

            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            txtTimkiem.Enabled = true;
            txtMaMT.Enabled = false;
            comboBoxSV.Enabled = false;
            comboBoxNV.Enabled = false;
            dateTimePicker1.Enabled = false;

            txtMaMT.ResetText();
            dateTimePicker1.ResetText();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
            buttonSave.Enabled = false;
        }

        private int kiemtra()
        {
            string k = txtMaMT.Text;
            string sql = "SELECT * FROM tblMuonTra WHERE sMaMT ='" + k.ToString() + "'";
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
            //int solanmuon = (int)LoadData.Instance.ExcuteScalar("SELECT COUNT(a.sMaNV) FROM dbo.tblMuonTra a, dbo.tblNhanVien b WHERE a.sMaNV= b.sMaNV AND b.sTenNV = N'" + comboBoxNV.Text + "'");
            //if (solanmuon < 4)
            //{
                string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {
                    if (kiemtra() == 1)
                    {
                        MessageBox.Show("Mã mượn trả " + txtMaMT.Text + " đã có, không thể thêm !", "Thông báo");
                        txtMaMT.Focus();
                    }
                    else
                    {
                        if (txtMaMT.Text != "")
                        {
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "prThemMuonTra";
                                cmd.Parameters.AddWithValue("@MaMT", txtMaMT.Text);
                                cmd.Parameters.AddWithValue("@MaSV", comboBoxSV.SelectedValue);
                                cmd.Parameters.AddWithValue("@MaNV", comboBoxNV.SelectedValue);
                                cmd.Parameters.AddWithValue("@Ngaymuon", dateTimePicker1.Text);
                                cnn.Open();

                                int kq = cmd.ExecuteNonQuery();
                                if (kq > 0)
                                {
                                    MessageBox.Show("Đã thêm thành công phiếu mượn trả mã " + txtMaMT.Text + "!", "Thông báo");
                                    layMT();
                                }
                                txtMaMT.ResetText();
                                cnn.Close();
                                rgLoadMT();
                            }
                        }
                        else
                            errorProvider1.SetError(txtMaMT, "Bạn chưa nhập mã phiếu mượn trả !");
                        /*errorProvider2.SetError(comboBoxSV, "Bạn chưa nhập mã sinh viên !");
                        errorProvider3.SetError(comboBoxNV, "Bạn chưa nhập mã nhân viên !");*/
                    }
                }
            //}
            //else
            //{
            //    MessageBox.Show("Mỗi nhân viên chỉ được lập 5 hóa đơn", "Thông báo");
            //}
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prSuaMuonTra";
                    cmd.Parameters.AddWithValue("@MaMT", txtMaMT.Text);
                    cmd.Parameters.AddWithValue("@MaSV", comboBoxSV.SelectedValue);
                    cmd.Parameters.AddWithValue("@MaNV", comboBoxNV.SelectedValue);
                    cmd.Parameters.AddWithValue("@Ngaymuon", dateTimePicker1.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadMT();
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
                    cmd.CommandText = "prXoaMuonTra";
                    cmd.Parameters.AddWithValue("@MaMT", txtMaMT.Text);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

                        txtMaMT.ResetText();
                        dateTimePicker1.ResetText(); ;

                        DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã xóa thành công !", "Thông báo");
                                rgLoadCTMT();
                                layMT();
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công !", "Thông báo");
                            }

                            cnn.Close();
                        }
                        rgLoadMT();
                    }
                }
            } 
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindCTMT = "SELECT sMaMT AS [Mã mượn trả],tblSach.sMaSach AS [Mã sách],sTensach AS [Tên sách],dNgaytra AS [Ngày trả] FROM tblSach,tblCTMuonTra WHERE tblSach.sMasach = tblCTMuonTra.sMasach AND sMaMT IN (SELECT sMaMT FROM tblMuonTra WHERE sMaMT LIKE'%" + txtTimkiem.Text + "%')";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindCTMT, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewCTMT.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            string sqlFindMT = "SELECT sMaMT AS [Mã mượn trả],tblSinhVien.sMaSV AS [Mã sinh viên],sTenSV AS [Tên sinh viên],tblNhanVien.sMaNV AS [Mã nhân viên],sTenNV AS [Tên nhân viên],dNgaymuon AS [Ngày mượn] FROM tblMuonTra,tblNhanVien,tblSinhVien WHERE tblMuonTra.sMaSV = tblSinhVien.sMaSV AND tblMuonTra.sMaNV = tblNhanVien.sMaNV AND sMaMT LIKE'%" + txtTimkiem.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindMT, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewMT.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }

        //Phần chi tiết phiếu mượn trả

        private void layMT()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblMuonTra", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("tblMuonTra");
                        ad.Fill(tb);
                        comboBoxMaMT.DataSource = tb;
                        comboBoxMaMT.DisplayMember = "sTenMT";
                        comboBoxMaMT.ValueMember = "sMaMT";
                    }
                }
            }
        }

        private void layCTMT()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSach", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable("tblSach");
                        ad.Fill(tb);
                        comboBoxTenSach.DataSource = tb;
                        comboBoxTenSach.DisplayMember = "sTensach";
                        comboBoxTenSach.ValueMember = "sMasach";
                    }
                }
            }
        }

        private void dataGridViewCTMT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUpdate2.Enabled = true;
            buttonDelete2.Enabled = true;

            comboBoxMaMT.Enabled = true;
            comboBoxTenSach.Enabled = true;
            dateTimePicker2.Enabled = true;

            buttonSave2.Enabled = false;

            int numrow;
            numrow = e.RowIndex;
            comboBoxMaMT.Text = dataGridViewCTMT.Rows[numrow].Cells[0].Value.ToString();
            comboBoxTenSach.Text = dataGridViewCTMT.Rows[numrow].Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridViewCTMT.Rows[numrow].Cells[3].Value.ToString();
        }

        private int kiemtra1()
        {
            string mamt = Convert.ToString(comboBoxMaMT.SelectedValue);
            string sql = "SELECT * FROM tblCTMuonTra WHERE sMaMT ='" + mamt + "'";
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

        private int kiemtra2()
        {
            string tensach = Convert.ToString(comboBoxTenSach.SelectedValue);
            string mamt = Convert.ToString(comboBoxMaMT.SelectedValue);
            string sql = "SELECT * FROM tblCTMuonTra,tblSach WHERE tblSach.sMasach = tblCTMuonTra.sMasach AND tblSach.sTensach = N'" + tensach + "'";
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

        public void rgLoadCTMT()
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT sMaMT AS [Mã mượn trả],tblSach.sMasach AS [Mã sách],tblSach.sTensach AS [Tên sách],dNgaytra AS [Ngày trả] FROM tblSach,tblCTMuonTra WHERE tblSach.sMasach = tblCTMuonTra.sMasach", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewCTMT.DataSource = tb;
                    }
                }
            }
        }

        //kiem tra ma sach va ten sach cung trung
        private int kiemtramamt_tensach()
        {
            string mamt = Convert.ToString(comboBoxMaMT.SelectedValue);
            string tensach = Convert.ToString(comboBoxTenSach.SelectedValue);
            string sql = "SELECT * FROM tblCTMuonTra,tblSach WHERE tblCTMuonTra.sMasach = tblSach.sMasach AND sMaMT = '" + mamt + "'AND tblSach.sTensach = N'" + tensach + "'";
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

        //kiem tra ma mt trung nhung ten sach khong trung
        private int kiemtramamttrung_tensachkhongtrung()
        {
            string mamt = Convert.ToString(comboBoxMaMT.SelectedValue);
            string tensach = Convert.ToString(comboBoxTenSach.SelectedValue);
            string sql = "SELECT * FROM tblCTMuonTra,tblSach WHERE tblCTMuonTra.sMasach = tblSach.sMasach AND sMaMT = '" + mamt + "'AND tblSach.sMasach != N'" + tensach + "'";
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

        private int kiemtrangaytra()
        {
            string ngaytra = Convert.ToString(dateTimePicker2.Text);
            string sql = "SELECT * FROM tblMuonTra,tblCTMuonTra WHERE tblMuonTra.sMaMT = tblCTMuonTra.sMaMT AND dNgaymuon >'" + ngaytra +"'";
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

        private void buttonSave2_Click(object sender, EventArgs e)
        {
            /*string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                if (kiemtra1() == 1)
                {
                    if (kiemtra2() == 1)
                    {
                        MessageBox.Show("Tên sách " + comboBoxTenSach.Text + " đã có, không thể thêm !", "Thông báo");
                        comboBoxTenSach.Focus();
                    }
                    else
                    {
                        if (comboBoxTenSach.SelectedValue != null)
                        {
                            using (SqlCommand cmd = cnn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "prThemCTMT";
                                cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                                cmd.Parameters.AddWithValue("@Masach", comboBoxTenSach.SelectedValue);
                                cmd.Parameters.AddWithValue("@Ngaytra", dateTimePicker2.Text);
                                cnn.Open();

                                int kq = cmd.ExecuteNonQuery();
                                if (kq > 0)
                                {
                                    MessageBox.Show("Đã thêm thành công sách có tên " + comboBoxTenSach.SelectedValue + "!", "Thông báo");
                                }
                                cnn.Close();
                                rgLoadCTMT();
                            }
                        }
                        else
                            errorProvider5.SetError(comboBoxTenSach, "Bạn chưa nhập mã sách !");
                    }
                }
                else
                {
                    if (comboBoxTenSach.SelectedValue != null)
                    {
                        using (SqlCommand cmd = cnn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "prThemCTMT";
                            cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                            cmd.Parameters.AddWithValue("@Masach", comboBoxTenSach.SelectedValue);
                            cmd.Parameters.AddWithValue("@Ngaytra", dateTimePicker2.Text);
                            cnn.Open();

                            int kq = cmd.ExecuteNonQuery();
                            if (kq > 0)
                            {
                                MessageBox.Show("Đã thêm thành công sách tên " + comboBoxTenSach.SelectedValue + "!", "Thông báo");
                            }
                            cnn.Close();
                            rgLoadCTMT();
                        }
                    }
                    else
                        errorProvider5.SetError(comboBoxTenSach, "Bạn chưa nhập mã mượn trả !");
                }
            }*/
            
            int solanmuon = (int)LoadData.Instance.ExcuteScalar("SELECT COUNT(sMaMT) FROM dbo.tblCTMuonTra WHERE sMaMT='" + comboBoxMaMT.Text + "'");
            if (solanmuon < 5)
            {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                //kiem tra ma sach va ten tac gia cung trung
                if(kiemtramamt_tensach() == 1)
                {
                    MessageBox.Show("Mã mượn trả " + comboBoxMaMT.Text + ", tên sách "+ comboBoxTenSach.Text +" đã có, không thể thêm !", "Thông báo");
                    comboBoxTenSach.Focus();
                    comboBoxMaMT.Focus();
                }
                else
                {
                    //kiem tra ma mt trung nhung ten sach khong trung
                    if(kiemtramamttrung_tensachkhongtrung() == 1)
                    {
                        if(kiemtrangaytra() == 1)
                        {
                            MessageBox.Show("Ngày trả nhỏ hơn ngày mượn, không thể thêm", "Thông báo");
                            dateTimePicker2.Focus();
                        }
                        else
                        {
                        if (comboBoxTenSach.SelectedValue != null)
                        {
                                    using (SqlCommand cmd = cnn.CreateCommand())
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        cmd.CommandText = "prThemCTMT";
                                        cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                                        cmd.Parameters.AddWithValue("@Masach", comboBoxTenSach.SelectedValue);
                                        cmd.Parameters.AddWithValue("@Ngaytra", dateTimePicker2.Text);
                                        cnn.Open();

                                        int kq = cmd.ExecuteNonQuery();
                                        if (kq > 0)
                                        {
                                            MessageBox.Show("Đã thêm thành công mã mượn trả " + comboBoxMaMT.Text + ", tên sách " + comboBoxTenSach.Text + " !", "Thông báo");
                                        }
                                        cnn.Close();
                                        rgLoadCTMT();
                                    }
                               
                        }
                        else
                            errorProvider5.SetError(comboBoxTenSach, "Bạn chưa chọn tên sách !");
                        }
                    }
                    else
                    {
                        if (kiemtrangaytra() == 1)
                        {
                            MessageBox.Show("Ngày trả nhỏ hơn ngày mượn, không thể thêm", "Thông báo");
                            dateTimePicker2.Focus();
                        }
                        else
                        {
                            if (comboBoxMaMT.SelectedValue != null)
                            {
                                using (SqlCommand cmd = cnn.CreateCommand())
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.CommandText = "prThemCTMT";
                                    cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                                    cmd.Parameters.AddWithValue("@Masach", comboBoxTenSach.SelectedValue);
                                    cmd.Parameters.AddWithValue("@Ngaytra", dateTimePicker2.Text);
                                    cnn.Open();

                                    int kq = cmd.ExecuteNonQuery();
                                    if (kq > 0)
                                    {
                                        MessageBox.Show("Đã thêm thành công mã mượn trả " + comboBoxMaMT.Text + ", tên sách " + comboBoxTenSach.Text + " !", "Thông báo");
                                    }
                                    cnn.Close();
                                    rgLoadCTMT();
                                }
                            }
                            else
                                errorProvider4.SetError(comboBoxTenSach, "Bạn chưa chọn mã mượn trả !");
                        }
                    }
                }
            }
            }
            else
            {
                MessageBox.Show("Một độc giả không mượn quá 5 quyển sách");
            }

        }

        private void buttonAdd2_Click(object sender, EventArgs e)
        {
            rgLoadCTMT();

            txtTimkiem2.Enabled = false;
            comboBoxMaMT.Enabled = true;
            comboBoxTenSach.Enabled = true;
            dateTimePicker2.Enabled = true;

            buttonSave2.Enabled = true;
            buttonUpdate2.Enabled = false;
            buttonDelete2.Enabled = false;
        }

        private void txtTimkiem2_TextChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindCTMT = "SELECT sMaMT AS [Mã mượn trả],tblSach.sMaSach AS [Mã sách],sTensach AS [Tên sách],dNgaytra AS [Ngày trả] FROM tblSach,tblCTMuonTra WHERE tblSach.sMasach = tblCTMuonTra.sMasach AND sMaMT IN (SELECT sMaMT FROM tblMuonTra WHERE sMaMT LIKE'%" + txtTimkiem2.Text + "%')";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindCTMT, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewCTMT.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }

            string sqlFindMT = "SELECT sMaMT AS [Mã mượn trả],tblSinhVien.sMaSV AS [Mã sinh viên],sTenSV AS [Tên sinh viên],tblNhanVien.sMaNV AS [Mã nhân viên],sTenNV AS [Tên nhân viên],dNgaymuon AS [Ngày mượn] FROM tblMuonTra,tblNhanVien,tblSinhVien WHERE tblMuonTra.sMaSV = tblSinhVien.sMaSV AND tblMuonTra.sMaNV = tblNhanVien.sMaNV AND sMaMT LIKE'%" + txtTimkiem2.Text + "%'";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindMT, cnn))
                {
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridViewMT.DataSource = tb;
                        cnn.Close();
                        cnn.Dispose();
                    }
                }
            }
        }

        private void buttonFind2_Click(object sender, EventArgs e)
        {
            txtTimkiem2.Enabled = true;
            comboBoxMaMT.Enabled = false;
            comboBoxTenSach.Enabled = false;
            dateTimePicker2.Enabled = false;

            buttonDelete2.Enabled = false;
            buttonUpdate2.Enabled = false;
            buttonSave2.Enabled = false;
        }

        private void buttonUpdate2_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prSuaCTMT";
                    cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                    cmd.Parameters.AddWithValue("@Masach1", comboBoxTenSach.SelectedValue);
                    cmd.Parameters.AddWithValue("@Masach2", comboBoxTenSach.SelectedValue);
                    cmd.Parameters.AddWithValue("@Ngaytra", dateTimePicker2.Text);
                    cnn.Open();
                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn sửa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int kq = cmd.ExecuteNonQuery();
                        if (kq > 0)
                            MessageBox.Show("Đã sửa thành công !", "Thông báo");
                        else
                            MessageBox.Show("Sửa không thành công !", "Thông báo");
                        rgLoadCTMT();
                        cnn.Close();
                    }
                }
            }
        }

        private void buttonDelete2_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prXoaCTMT";
                    cmd.Parameters.AddWithValue("@MaMT", comboBoxMaMT.SelectedValue);
                    cmd.Parameters.AddWithValue("@Masach", comboBoxTenSach.SelectedValue);
                    cnn.Open();
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        /*DataTable tb = new DataTable();
                        ad.Fill(tb);
                        dataGridView1.DataSource = tb;*/

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
                        rgLoadCTMT();
                    }
                }
            } 
        }

        //kiểm tra xem form đã mở chưa
        private bool checkFormOpen(string FormName)
        {
            //groupBox1.Hide();
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

        private void buttonIn_Click(object sender, EventArgs e)
        {
            bool check = checkFormOpen("inphieuMT");
            if (check == false)
            {
                Form1 f1 = new Form1();
                //f1.MdiParent = this;
                f1.Show();
            }
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            bool check = checkFormOpen("inphieuCTMT");
            if (check == false)
            {
                inphieuCTMT f1 = new inphieuCTMT();
                //f1.MdiParent = this;
                f1.Show();
            }
        }*/

        private void buttonChuatra_Click(object sender, EventArgs e)
        {
            bool check = checkFormOpen("sachchuatra");
            if (check == false)
            {
                sachchuatra f1 = new sachchuatra();
                //f1.MdiParent = this;
                f1.Show();
            }
        }
    }
}
