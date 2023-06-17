namespace quanlythuvien
{
    partial class sach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sach));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxLoaisach = new System.Windows.Forms.ComboBox();
            this.comboBoxTenNXB = new System.Windows.Forms.ComboBox();
            this.txtNamXB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxTenTG = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.txtTinhtrang = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.DarkGray;
            this.groupBox3.Controls.Add(this.txtTimkiem);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboBoxLoaisach);
            this.groupBox3.Controls.Add(this.comboBoxTenNXB);
            this.groupBox3.Controls.Add(this.txtNamXB);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.buttonDelete);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.buttonUpdate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.buttonSave);
            this.groupBox3.Controls.Add(this.comboBoxTenTG);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.buttonAdd);
            this.groupBox3.Controls.Add(this.txtMaSach);
            this.groupBox3.Controls.Add(this.txtTenSach);
            this.groupBox3.Controls.Add(this.buttonFind);
            this.groupBox3.Controls.Add(this.txtTinhtrang);
            this.groupBox3.Location = new System.Drawing.Point(-1, -6);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1205, 554);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.Location = new System.Drawing.Point(573, 90);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(212, 27);
            this.txtTimkiem.TabIndex = 26;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(859, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Loại sách:";
            // 
            // comboBoxLoaisach
            // 
            this.comboBoxLoaisach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxLoaisach.FormattingEnabled = true;
            this.comboBoxLoaisach.Location = new System.Drawing.Point(967, 134);
            this.comboBoxLoaisach.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxLoaisach.Name = "comboBoxLoaisach";
            this.comboBoxLoaisach.Size = new System.Drawing.Size(212, 28);
            this.comboBoxLoaisach.TabIndex = 7;
            // 
            // comboBoxTenNXB
            // 
            this.comboBoxTenNXB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTenNXB.FormattingEnabled = true;
            this.comboBoxTenNXB.Location = new System.Drawing.Point(177, 175);
            this.comboBoxTenNXB.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTenNXB.Name = "comboBoxTenNXB";
            this.comboBoxTenNXB.Size = new System.Drawing.Size(212, 28);
            this.comboBoxTenNXB.TabIndex = 4;
            // 
            // txtNamXB
            // 
            this.txtNamXB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamXB.Location = new System.Drawing.Point(573, 132);
            this.txtNamXB.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamXB.Name = "txtNamXB";
            this.txtNamXB.Size = new System.Drawing.Size(212, 27);
            this.txtNamXB.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sách:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(693, 34);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(278, 37);
            this.label8.TabIndex = 22;
            this.label8.Text = "QUẢN LÝ ĐẦU SÁCH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sách:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 236);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1157, 298);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDelete.Location = new System.Drawing.Point(984, 177);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 38);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(859, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tình trạng:";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.Location = new System.Drawing.Point(863, 177);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(113, 38);
            this.buttonUpdate.TabIndex = 12;
            this.buttonUpdate.Text = "Sửa";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên nhà xuất bản:";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(741, 177);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(113, 38);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Lưu";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxTenTG
            // 
            this.comboBoxTenTG.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTenTG.FormattingEnabled = true;
            this.comboBoxTenTG.Location = new System.Drawing.Point(177, 130);
            this.comboBoxTenTG.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxTenTG.Name = "comboBoxTenTG";
            this.comboBoxTenTG.Size = new System.Drawing.Size(212, 28);
            this.comboBoxTenTG.TabIndex = 3;
            this.comboBoxTenTG.SelectedIndexChanged += new System.EventHandler(this.comboBoxTenTG_SelectedIndexChanged);
            this.comboBoxTenTG.SelectedValueChanged += new System.EventHandler(this.comboBoxTenTG_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(432, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Năm xuất bản:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tên tác giả:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAdd.Location = new System.Drawing.Point(620, 177);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(113, 38);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSach.Location = new System.Drawing.Point(177, 46);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(212, 27);
            this.txtMaSach.TabIndex = 1;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(177, 87);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(212, 27);
            this.txtTenSach.TabIndex = 2;
            // 
            // buttonFind
            // 
            this.buttonFind.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFind.ForeColor = System.Drawing.Color.White;
            this.buttonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFind.Location = new System.Drawing.Point(499, 177);
            this.buttonFind.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(113, 38);
            this.buttonFind.TabIndex = 8;
            this.buttonFind.Text = "Tìm kiếm";
            this.buttonFind.UseVisualStyleBackColor = false;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // txtTinhtrang
            // 
            this.txtTinhtrang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTinhtrang.Location = new System.Drawing.Point(967, 90);
            this.txtTinhtrang.Margin = new System.Windows.Forms.Padding(4);
            this.txtTinhtrang.Name = "txtTinhtrang";
            this.txtTinhtrang.Size = new System.Drawing.Size(212, 27);
            this.txtTinhtrang.TabIndex = 6;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // sach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 543);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "sach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sách";
            this.Load += new System.EventHandler(this.sach_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtNamXB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxTenTG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox txtTinhtrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLoaisach;
        private System.Windows.Forms.ComboBox comboBoxTenNXB;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private System.Windows.Forms.ErrorProvider errorProvider4;

    }
}