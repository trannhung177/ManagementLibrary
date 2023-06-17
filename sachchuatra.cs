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
    public partial class sachchuatra : Form
    {
        public sachchuatra()
        {
            InitializeComponent();
        }

        private void sachchuatra_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["QLThuVien"].ConnectionString;
            string sqlFindCTMT = "SELECT sTensach AS [Tên sách],sTentacgia AS [Tên tác giả],sTenNXB AS [Tên nhà xuất bản],sTenloai AS [Thể loại],dNgaytra AS [Ngày phải trả] FROM tblCTMuonTra,tblSach,tblTacGia,tblNXB,tblTheLoai WHERE tblSach.sMasach = tblCTMuonTra.sMasach AND tblSach.sTacgia = tblTacGia.sMatacgia AND tblSach.sMaNXB = tblNXB.sMaNXB AND tblSach.sMaloai = tblTheLoai.sMaloai AND dNgaytra > (GETDATE() - 1)";
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlFindCTMT, cnn))
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
