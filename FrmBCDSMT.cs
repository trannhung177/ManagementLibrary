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
    public partial class FrmBCDSMT : Form
    {
        public FrmBCDSMT()
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
                    cmd.CommandText = "prDSMT_SV";
                    cmd.Parameters.Add(new SqlParameter("@maSV", txtmasv.Text));
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable table = new DataTable();
                    da.Fill(table);

                    BaocaoDSMT rpt = new BaocaoDSMT();
                    rpt.SetDataSource(table);
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();


                }
            }
        }
    }
}
