using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class FrmBCDSMT_theoTenSV : Form
    {
        public FrmBCDSMT_theoTenSV()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=.\sqlexpress;Initial Catalog=QLThuVien;Integrated Security=True";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.Open();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prDSMT_SV_theoTen_dem";
                    cmd.Parameters.Add(new SqlParameter("@tenSV",txttensv.Text));
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    da.Fill(table);

                    BaocaoDSMT_theoTenSV rpt = new BaocaoDSMT_theoTenSV();
                    rpt.SetDataSource(table);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                }
            }
        }

        private void FrmBCDSMT_theoTenSV_Load(object sender, EventArgs e)
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
                        txttensv.DataSource = tb;
                        txttensv.DisplayMember = "sTenSV";
                        txttensv.ValueMember = "sMaSV";
                    }
                }
            }
        }
    }
}
