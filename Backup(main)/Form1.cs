using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using inreifunc;

namespace WindowsFormsApp92
{
    public partial class Form1 : Form
    {
        //バージョンを定義
        int version = 104;
        //変数を用意
        string apppath, inipath,thfpathAfter13,backupfolder;
        bool menzyo;
        //URL開くやつ(コピペ)
        private Process OpenUrl(string url)
        {
            ProcessStartInfo pi = new ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
            };

            return Process.Start(pi);
        }
        private void Form1_Load(object sender, EventArgs e)

        {
            try
            {
                //新しいバージョンがあるかの確認
                WebClient client = new WebClient();
                if (version<int.Parse(client.DownloadString("http://sagume.net/html/versionthbackup.txt")))
                {
                    MessageBox.Show("新しいバージョンがあるようです\r\n直ちにダウンロードするようお願いします", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    OpenUrl("https://sagume.net/2023/12/09/318/");
                }

            }
            catch //失敗したとき用
            {
                MessageBox.Show("新しいバージョンがあるかの確認に失敗しました", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
           
            groupBox1.Enabled = false;
            button4.Enabled = false;
            //パスの定義
            apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\THbackupBySuG"; //このツールのデータがある場所
            inipath = apppath+"\\settings.ini"; //ini1ファイルの場所
            thfpathAfter13= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\ShanghaiAlice\\"; //東方のセーブデータの場所(th13~)
            Directory.CreateDirectory(apppath); //apppathを作っておく

            //ini無いなら作る
            if (!File.Exists(inipath))
            {
                using (FileStream fs = File.Create(inipath)) { };
                Directory.CreateDirectory(apppath+"\\backups\\autosave"); //autosaveフォルダまで作る
            }
        }
        /// <summary>
        /// GUIにiniの内容を適用する
        /// </summary>
        private void SettingsGUI(bool newone =false)
        {
            string s;

            if (Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "path", out s)&&!newone) //設定があるかどうか
            {
               
                thdir.Enabled=only_save.Enabled = true;
                //設定がある場合読み込む
                groupBox1.Enabled = true;
                scdat.Text=s;
                Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "dirpath", out s);
                thdir.Text=s;
                Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "pc", out s);
                pc.Checked=Convert.ToBoolean(s);
                Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "only_save", out s);
                only_save.Checked=Convert.ToBoolean(s);
                Inicontrol.Readfromini(inipath, "thall", "files", out s);

                Status.Text="バックアップ設定が見つかりました";

                if(int.Parse(thconvert(comboBox1.Text))<=12)
                    thdir.Enabled=only_save.Enabled = false;
                //設定を画面に反映するとき、チェックボックスなどの変更をプログラムが行うのでチェックボックスの変更を検知してプログラムが保存ボタンを押すまで作品の選択などを禁止してしまう。
                //そのため、プログラムがチェックボックスを変更するときはmenzyo(menjoでよくね？)をtrueにしてチェックボックスの変更があっても作品の選択を許可する。
                //iniの内容を適用し終わったのでmenzyoはfalseにしておく。
                menzyo=false;
            }
            else if (newone)
            {
                groupBox1.Enabled = pc.Checked=only_save.Checked=true;
                thdir.Enabled=only_save.Enabled = false;
                thdir.Text="";
                
            }
            else //そもそも設定が見つからない
            {
                Status.Text="バックアップ設定が見つかりません";
                groupBox1.Enabled=false;
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //作品の選択があったとき

        {
            //iniの設定を画面に反映するためmenjoをtrueにする(menzyoの説明はSettingsGUIの中にあります)
            menzyo=true;
            //iniの設定を画面に反映
            SettingsGUI();
        }
        /// <summary>
        /// xxで作品名を返し、作品名で06-19の値で返します
        /// </summary>
        /// <param name="s">作品名または作品番号06-19</param>
        /// <returns></returns>
        private string thconvert(string s)
        {
            switch(s)
            {
                case "06":
                    return "東方紅魔郷";
                case "07":
                    return "東方妖々夢";
                case "08":
                    return "東方永夜抄";
                case "09":
                    return "東方花映塚";
                case "10":
                    return "東宝風神録";
                case "11":
                    return "東方地霊殿";             
                case "12":
                    return "東方星蓮船";
                case "13":
                    return "東方神霊廟";
                case "14":
                    return "東方輝針城";
                case "15":
                    return "東方紺珠伝";
                case "16":
                    return "東方天空璋";
                case "17":
                    return "東方鬼形獣";
                case "18":
                    return "東方虹龍洞";
                case "19":
                    return "東方獣王園";
                case "東方紅魔郷":
                    return "06";
                case "東方妖々夢":
                    return "07";
                case "東方永夜抄":
                    return "08";
                case "東方花映塚":
                    return "09";
                case "東方風神録":
                    return "10";
                case "東方地霊殿":
                    return "11";
                case "東方星蓮船":
                    return "12";
                case "東方神霊廟":
                    return "13";
                case "東方輝針城":
                    return "14";
                case "東方紺珠伝":
                    return "15";
                case "東方天空璋":
                    return "16";
                case "東方鬼形獣":
                    return "17";
                case "東方虹龍洞":
                    return "18";
                case "東方獣王園":
                    return "19";


            }
           
            return s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BlockChangeing();
        }

        private void button4_Click(object sender, EventArgs e)　//保存ボタンが押されたとき
        {
            
            if(
            Inicontrol.Writetoini(inipath, "th"+thconvert(comboBox1.Text),"pc",pc.Checked.ToString())
            &&Inicontrol.Writetoini(inipath, "th"+thconvert(comboBox1.Text), "only_save", only_save.Checked.ToString())
            &&Inicontrol.Writetoini(inipath, "th"+thconvert(comboBox1.Text), "dirpath", thdir.Text)
            &&Inicontrol.Writetoini(inipath, "th"+thconvert(comboBox1.Text), "path", scdat.Text))
             //iniに設定を適用すると同時に全ての適用が上手くいったかを調べる
            {
                //適用は成功したらコントロールを戻してあげる
                button4.Enabled=false; 
                button7.Enabled=button3.Enabled=button2.Enabled=comboBox1.Enabled=button1.Enabled=button2.Enabled=button5.Enabled=true;
                MessageBox.Show("ほぞんしたお","完了",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //失敗
            {
                MessageBox.Show("保存に失敗しました");
            }

        }

        private void button5_Click(object sender, EventArgs e) //作品を選択して検出が押された
        {
            if(int.Parse(thconvert(comboBox1.Text))<13)
            {
                MessageBox.Show("星蓮船以前の整数作品のセーブを自動検出することはできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //バックアップ設定を上書きしてよいか尋ねる
            if (MessageBox.Show($"{comboBox1.Text}のバックアップ設定を上書きします。よろしいですか？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)==DialogResult.Cancel)
                return;
            //scorethxx.datが存在するか調べる
            if (File.Exists(thfpathAfter13+$"th{thconvert(comboBox1.Text)}\\scoreth{thconvert(comboBox1.Text)}.dat"))
            {
                //存在するとき、パスなどの情報をiniに書き込む
                Inicontrol.Writetoini(inipath, $"th{thconvert(comboBox1.Text)}", "path", thfpathAfter13+$"th{thconvert(comboBox1.Text)}\\scoreth{thconvert(comboBox1.Text)}.dat");
                Inicontrol.Writetoini(inipath, $"th{thconvert(comboBox1.Text)}", "dirpath", thfpathAfter13+$"th{thconvert(comboBox1.Text)}");
                Inicontrol.Writetoini(inipath, $"th{thconvert(comboBox1.Text)}", "pc", "true");
                Inicontrol.Writetoini(inipath, $"th{thconvert(comboBox1.Text)}", "only_save", "false");
                //GUIにiniを適用
                SettingsGUI();
                Status.Text="バックアップ設定を保存しました。";
            }
            else　//セーブがないとき
            {
                MessageBox.Show("セーブが見つかりません","エラー",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }
        
        /// <summary>
        /// 保存してないのに作品を切り替えるのを阻止する。
        /// </summary>
        private void BlockChangeing()
        {
            if (!menzyo)
            {
                button4.Enabled=true;
                button7.Enabled=button3.Enabled=button2.Enabled=comboBox1.Enabled=button1.Enabled=button2.Enabled=button5.Enabled=false;
                Status.Text="保存してください。";
            }

        }
        private void button3_Click(object sender, EventArgs e) //復元操作
        {
            //注意事項を表示
            if (MessageBox.Show($"注意。最新のバックアップから復元します。万が一最新のバックアップが破損したデータである場合(バックアップの過程で破損することはほぼありません)、破損したデータを復元することになります。\r\n復元後も依然として状況が変わらない場合、手動での復元をお勧めします。\r\n復元してよろしいですか？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)==DialogResult.Cancel)
                return;
            //自動バックアップから復元
            if (MessageBox.Show("自動バックアップから復元します？", "", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                string s;
                Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "only_save", out s);
                Restore(Convert.ToBoolean(s),true);
            }
            else
            {
                string s;
                Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "only_save", out s);
                Restore(Convert.ToBoolean(s), false);

            }

        }
        private void Restore(bool only_save,bool auto)
        {
            string folderPath;
            //バックアップフォルダからthxxのフォルダパスを定義
            if (auto)
                folderPath = apppath+$"\\backups\\autosave\\th{thconvert(comboBox1.Text)}";
            else
                folderPath = apppath+$"\\backups\\th{thconvert(comboBox1.Text)}";

            if (only_save)
            {
                string saki;
                Inicontrol.Readfromini(inipath,$"th{thconvert(comboBox1.Text)}","path",out  saki);
                DirectoryInfo di = new DirectoryInfo(folderPath);
                //datを全て検出,filesに格納
                List<FileInfo> files = di.GetFiles("*.dat").OrderBy(f => f.Name).ToList();
                //東方のセーブをを上書きする前にthxxBUCKUP.datとして保存しておく
                if (File.Exists(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP.dat"))
                    File.Delete(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP.dat");
                File.Move(saki, apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP.dat");
                if(auto)//autosaveが選択されたとき
                    //名前的に一番新しいバックアップから復元しておく
                    File.Copy(apppath+$"\\backups\\autosave\\th{thconvert(comboBox1.Text)}\\"+files[files.Count-1], saki, true);
                else//手動セーブから選択されたとき
                //名前的に(ry
                File.Copy(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}\\"+files[files.Count-1], saki, true);
                Status.Text="スコアのみ復元しました";
                MessageBox.Show("復元しましたよ", "復元完了",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                string saki;
                Inicontrol.Readfromini(inipath, $"th{thconvert(comboBox1.Text)}", "dirpath", out saki);

                DirectoryInfo di = new DirectoryInfo(folderPath);
                //すべてのディレクトリを取得,foldersに格納
                List<DirectoryInfo> folders = di.GetDirectories("*").OrderBy(f => f.Name).ToList();
                //上書きできるようにする
                if (Directory.Exists(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP"))
                    Directory.Delete(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP", true);
                //東方のセーブを上書きする前にthxxBUCKPUPというフォルダーを保存しておく
                Directory.Move(saki, apppath+$"\\backups\\th{thconvert(comboBox1.Text)}BACKUP");
                if(auto)//autosaveが選択されたとき
                    //名前的に一番新しいバックアップから復元しておく
                    CopyDirectory(apppath+$"\\backups\\autosave\\th{thconvert(comboBox1.Text)}\\{folders[folders.Count-1]}", saki);
                else
                    //名前的に略
                    CopyDirectory(apppath+$"\\backups\\th{thconvert(comboBox1.Text)}\\{folders[folders.Count-1]}", saki);

                Status.Text="全て復元しました";
                MessageBox.Show("復元しましたよ", "復元完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void button2_Click(object sender, EventArgs e) //バックアップをする
        {
            //今の時刻を取得
            DateTime dateTime = DateTime.Now;
            string s;
            //ini設定に基づいてバックアップするためにiniを読む
            Inicontrol.Readfromini(inipath, "th"+thconvert(comboBox1.Text), "only_save", out s);
            if(Convert.ToBoolean(s)==true)　//セーブデータのみの時
            {
                string path=apppath+$"\\backups\\th{thconvert(comboBox1.Text)}\\{dateTime.ToString("yyyy-MMdd-HHmmss")}.dat";
                string backuppath;
                Inicontrol.Readfromini(inipath, $"th{thconvert(comboBox1.Text)}","path",out backuppath);

                if (!Directory.Exists(Path.GetDirectoryName(path)))
                    Directory.CreateDirectory(Path.GetDirectoryName(path));

                //バックアップする
                File.Copy(backuppath,path,true);
                if (DialogResult.Yes== MessageBox.Show("バックアップしました。バックアップフォルダを開きますか？", "成功", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    System.Diagnostics.Process.Start("EXPLORER.EXE", $@"/select,""{path}""");
            }
            else //フォルダ全体をバックアップするとき
            {
                string path= apppath+$"\\backups\\th{thconvert(comboBox1.Text)}\\{dateTime.ToString("yyyy-MMdd-HHmmss")}";
                //バックアップする
                CopyDirectory(thfpathAfter13+$"th{thconvert(comboBox1.Text)}", path);
                if (DialogResult.Yes== MessageBox.Show("バックアップしました。バックアップフォルダを開きますか？", "成功", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    System.Diagnostics.Process.Start("EXPLORER.EXE", $@"/select,""{path}""");
            }

            Status.Text = "バックアップしました";
        }

        private void pc_CheckedChanged(object sender, EventArgs e)
        {
            BlockChangeing();
        }

        private void only_save_CheckedChanged(object sender, EventArgs e)
        {
            BlockChangeing();
        }

        private void thdir_TextChanged(object sender, EventArgs e)
        {
            BlockChangeing();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("星蓮船以前のscore.dat取得は説明書を見て行ってください","注意",MessageBoxButtons.OK,MessageBoxIcon.Information);
            string thfpathBefore13 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\VirtualStore\\Program Files";
            if (int.Parse(thconvert(comboBox1.Text))<13)
            {
                openFileDialog1.InitialDirectory = thfpathBefore13;
                if(int.Parse(thconvert(comboBox1.Text))<=9)
                openFileDialog1.Filter="東方scoreファイル|score.dat";
                else
                openFileDialog1.Filter=$"東方scoreファイル|scoreth{thconvert(comboBox1.Text)}.dat";

            }
            else
            {
                openFileDialog1.Filter=$"東方scoreファイル|scoreth{thconvert(comboBox1.Text)}.dat";

            }
            openFileDialog1.Title="score.datを選んでください";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                scdat.Text=openFileDialog1.FileName;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (groupBox1.Enabled)
            {
                MessageBox.Show("既に設定が読み込まれていますよ", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            menzyo=false;
            SettingsGUI(true);
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            BlockChangeing();
        }

        public Form1()
        {
            InitializeComponent();
 
        }
        private void button1_Click(object sender, EventArgs e) //全セーブ検出
        {
            if (MessageBox.Show("全セーブデータ検出機能では、神霊廟以降の整数作品のみを検出します。\r\nまた、現在保存されている全てのバックアップ設定を上書きします。よろしいですか？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)==DialogResult.Cancel)
                return;
            string Message="";
            //thn\scorethn.datが存在するか調べる
            for (int n = 13; n<=19;n++)
            {
                //存在するか
                if(File.Exists(thfpathAfter13+$"th{n}\\scoreth{n}.dat"))
                {
                    //messageに存在した原作名+改行を追加
                    Message=Message+thconvert(thconvert(n.ToString())+"\r\n");
                    //iniにscore.datのパス、ディレクトリのパス、ｐｃ起動時にやるか、セーブだけにするかを書き込む
                    Inicontrol.Writetoini(inipath, $"th{n}", "path", thfpathAfter13+$"th{n}\\scoreth{n}.dat");
                    Inicontrol.Writetoini(inipath, $"th{n}", "dirpath", thfpathAfter13+$"th{n}");
                    Inicontrol.Writetoini(inipath, $"th{n}", "pc", "true");
                    Inicontrol.Writetoini(inipath, $"th{n}", "only_save", "false");
                    Status.Text="バックアップ設定を保存しました。";
                    

                }
            }
            if(Message.Length > 0)
            {
            //探し終えたら発見したセーブを発表
             MessageBox.Show(Message+"のセーブを発見しました！","セーブ発見",MessageBoxButtons.OK,MessageBoxIcon.Information);
             SettingsGUI();
            }
            else
            {
                //なかったら
                MessageBox.Show("原作買えよ\r\n(現在神霊廟以降の原作にのみ対応しています。それ以外の作品にも適用できるよう努力しています。。。)","冷静",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

        }
        /// <summary>
        /// ディレクトリをコピーする　コピペねこれ
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        public void CopyDirectory(
            string sourceDirName, string destDirName)
        {
            //コピー先のディレクトリがないときは作る
            if (!System.IO.Directory.Exists(destDirName))
            {
                System.IO.Directory.CreateDirectory(destDirName);
                //属性もコピー
                System.IO.File.SetAttributes(destDirName,
                    System.IO.File.GetAttributes(sourceDirName));
            }

            //コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] !=
                    System.IO.Path.DirectorySeparatorChar)
                destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

            //コピー元のディレクトリにあるファイルをコピー
            string[] files = System.IO.Directory.GetFiles(sourceDirName);
            foreach (string file in files)
                System.IO.File.Copy(file,
                    destDirName + System.IO.Path.GetFileName(file), true);

            //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
                CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
        }
    }
}
