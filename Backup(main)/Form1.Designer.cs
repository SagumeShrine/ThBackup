namespace WindowsFormsApp92
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.thdir = new System.Windows.Forms.TextBox();
            this.scdat = new System.Windows.Forms.TextBox();
            this.only_save = new System.Windows.Forms.CheckBox();
            this.pc = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "全セーブデータ検出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "東方原作自動バックアップマネージャ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "東方紅魔郷",
            "東方妖々夢",
            "東方永夜抄",
            "東方花映塚",
            "東方風神録",
            "東方地霊殿",
            "東方星蓮船",
            "東方神霊廟",
            "東方輝針城",
            "東方紺珠伝",
            "東方天空璋",
            "東方鬼形獣",
            "東方虹龍洞",
            "東方獣王園"});
            this.comboBox1.Location = new System.Drawing.Point(137, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 33);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(27, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "作品の選択";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.thdir);
            this.groupBox1.Controls.Add(this.scdat);
            this.groupBox1.Controls.Add(this.only_save);
            this.groupBox1.Controls.Add(this.pc);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(32, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 263);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "バックアップ設定";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(335, 165);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 19);
            this.button6.TabIndex = 9;
            this.button6.Text = "選択";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(296, 214);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 43);
            this.button4.TabIndex = 8;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "ディレクトリ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "score.dat";
            // 
            // thdir
            // 
            this.thdir.Location = new System.Drawing.Point(75, 190);
            this.thdir.Name = "thdir";
            this.thdir.Size = new System.Drawing.Size(254, 19);
            this.thdir.TabIndex = 5;
            this.thdir.TextChanged += new System.EventHandler(this.thdir_TextChanged);
            // 
            // scdat
            // 
            this.scdat.Location = new System.Drawing.Point(75, 165);
            this.scdat.Name = "scdat";
            this.scdat.Size = new System.Drawing.Size(254, 19);
            this.scdat.TabIndex = 4;
            this.scdat.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // only_save
            // 
            this.only_save.AutoSize = true;
            this.only_save.Location = new System.Drawing.Point(20, 134);
            this.only_save.Name = "only_save";
            this.only_save.Size = new System.Drawing.Size(234, 16);
            this.only_save.TabIndex = 3;
            this.only_save.Text = "セーブデータのみのバックアップを行う(非推奨)";
            this.only_save.UseVisualStyleBackColor = true;
            this.only_save.CheckedChanged += new System.EventHandler(this.only_save_CheckedChanged);
            // 
            // pc
            // 
            this.pc.AutoSize = true;
            this.pc.Location = new System.Drawing.Point(20, 103);
            this.pc.Name = "pc";
            this.pc.Size = new System.Drawing.Size(199, 16);
            this.pc.TabIndex = 2;
            this.pc.Text = "PC起動ごとにバックアップを行う(推奨)";
            this.pc.UseVisualStyleBackColor = true;
            this.pc.CheckedChanged += new System.EventHandler(this.pc_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(207, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 49);
            this.button3.TabIndex = 1;
            this.button3.Text = "今すぐ復元";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 49);
            this.button2.TabIndex = 0;
            this.button2.Text = "今すぐバックアップ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(163, 53);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 48);
            this.button5.TabIndex = 5;
            this.button5.Text = "作品を指定してデータ検出";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Status.Location = new System.Drawing.Point(11, 450);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(63, 25);
            this.Status.TabIndex = 6;
            this.Status.Text = "Ready";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(312, 53);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(145, 48);
            this.button7.TabIndex = 10;
            this.button7.Text = "手動で作成";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 484);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "東方自動バックアップ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox only_save;
        private System.Windows.Forms.CheckBox pc;
        private System.Windows.Forms.TextBox scdat;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox thdir;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button7;
    }
}

