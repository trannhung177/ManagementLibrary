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
    public partial class quenmatkhau : Form
    {

        public quenmatkhau()
        {
            InitializeComponent();
            

        }
        void laymatkhau()
        {
            string tennv = txtTenNV.Text;
            string socc = txtCMND.Text;
            String query = "SELECT COUNT(*) FROM dbo.tblNhanVien  WHERE tblNhanVien.sTenNV=N'"+tennv+"' AND sCMND='"+socc+"'";
            if ((int)LoadData.Instance.ExcuteScalar(query) == 1)
            {
                string matkhau = "SELECT sMatkhau   FROM  dbo.tblDangNhap INNER JOIN  tblNhanVien ON tblNhanVien.sMaNV = tblDangNhap.sMaNV  WHERE sTenNV = N'"+tennv+"'";
                lbhienmk.Text = (string)LoadData.Instance.ExcuteScalar(matkhau);
            }
            else
            {
                MessageBox.Show("Tên nhân viên hoặc chứng minh không đúng","Thông báo");
            }

       
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void quenmatkhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng form không?", "formclosing", MessageBoxButtons
                .YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void lbhienmk_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            laymatkhau();
        }
    }
}
