using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlythuvien
{
    public partial class FrmBCDSMT_thang_nam : Form
    {
        public FrmBCDSMT_thang_nam()
        {
            InitializeComponent();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            string connetionString = @"Data Source=.\sqlexpress;Initial Catalog=QLThuVien;Integrated Security=True";
            ReportDocument rptd = new ReportDocument();
            rptd.Load(@"D:\Documents\btlhsk\quanlythuvien\quanlythuvien\BaocaoDSMT_thang_nam.rpt");
            ParameterFieldDefinition pfd = rptd.DataDefinition.ParameterFields["nguoilap"];

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cnn.Open();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "prDSMT_thang_nam";
                    cmd.Parameters.Add(new SqlParameter("@thang", txtthang.Text));
                    cmd.Parameters.Add(new SqlParameter("@nam", txtnam.Text));
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    da.Fill(table);

                    BaocaoDSMT_thang_nam rpt = new BaocaoDSMT_thang_nam();
                    rpt.SetDataSource(table);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                }
            }
            crystalReportViewer1.ReportSource = rptd;
            crystalReportViewer1.Refresh();
        }
    }
}
