using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inreifunc;

namespace ConsoleApp20
{
    internal class Program
    {
        /// <summary>
        /// ディレクトリをコピーする
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
       static public void CopyDirectory(
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
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string inipath, apppath, thfpathAfter13;
                apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\THbackupBySuG";
                inipath = apppath+"\\settings.ini";
                thfpathAfter13= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\ShanghaiAlice\\";
                for (int i = 6; i<=19; i++)
                {
                    string num;
                    if(i<10)
                        num="0"+i.ToString();
                    else
                        num =i.ToString();

                    string s;
                    bool EXI = Inicontrol.Readfromini(inipath, $"th{num}", "pc", out s);
                    if (EXI)
                    {
                        if (Convert.ToBoolean(s))
                        {
                            Inicontrol.Readfromini(inipath, $"th{num}", "only_save", out s);
                            DateTime dateTime = DateTime.Now;
                            if (Convert.ToBoolean(s))//セーブのみ
                            {
                                Inicontrol.Readfromini(inipath, $"th{num}","path",out s);
                                string path = apppath+$"\\backups\\autosave\\th{num}\\{dateTime.ToString("yyyy-MMdd-HHmmss")}.dat";
                                if(!Directory.Exists(Path.GetDirectoryName(path)))
                                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                                File.Copy(s, path, true);

                            }
                            else//全体
                            {
                                Inicontrol.Readfromini(inipath, $"th{num}", "dirpath", out s);
                                string path = apppath+$"\\backups\\autosave\\th{num}\\{dateTime.ToString("yyyy-MMdd-HHmmss")}";
                                CopyDirectory(s, path);
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n次の画面を開発者に送信してください","東方原作バックアップツール",MessageBoxButtons.OK,MessageBoxIcon.Error);
                MessageBox.Show(ex.ToString(),"開発者にこのメッセージを送信してください");
            }
            
        }
    }
}
