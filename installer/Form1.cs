using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp93
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //%appdata%の定義
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (DialogResult.Cancel==MessageBox.Show("インストールを始めますね", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                return; //キャンセルで中止
            //既にフォルダがあるならアップデートと見なす
            if (Directory.Exists(appdata+"\\ThbackupBySuG"))
                MessageBox.Show("アップデートのようです、上書きしますがデータは失われませんのでご安心をー", "COOOOOL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //既に一時インストールディレクトリがあれば一回消してもう一回作る
            if (Directory.Exists(appdata+"\\ThbackupBySuG\\install\\"))
            Directory.Delete(appdata+"\\ThbackupBySuG\\install\\", true);

            Directory.CreateDirectory(appdata+"\\ThbackupBySuG\\install");
            //zipファイルの書き出し
            File.WriteAllBytes(appdata+"\\ThbackupBySuG\\install\\temp.zip", Properties.Resources.temp);

            //zipを一時インストールディレクトリに解凍
            ZipFile.ExtractToDirectory(appdata+"\\ThbackupBySuG\\install\\temp.zip", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\ThbackupBySuG\\install");
            //一時インストールディレクトリからインストールディレクトリに移す
          foreach(string s in Directory.GetFiles(appdata+"\\ThbackupBySuG\\install","*.*",SearchOption.TopDirectoryOnly))
            {
                File.Copy(s, appdata+"\\ThbackupBySuG\\"+Path.GetFileName(s),true);
            }
            Directory.Delete(appdata+"\\ThbackupBySuG\\install\\",true);

            //コマンドプロンプトからスタートアップに登録する
            Process.Start("cmd", @"/c reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Run /v ""東方保存録"" /t REG_SZ /d """+appdata+@"\ThbackupBySuG\StartUP_ForThBackup.exe"" /f");
            //インストール出来たぜ　って言う
            MessageBox.Show("インストールできたぜ","COOOOOL",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //フォルダを開く
            System.Diagnostics.Process.Start(appdata+"\\ThbackupBySuG");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.SelectionStart = 0;
        }
    }
}
