using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace inreifunc
{
    /// <summary>
    /// iniファイルをコントロールする程度の能力
    /// <para>using inreifunc;</para>
    /// <para>inicontol.Writetoini("k....</para>
    /// </summary>
    
    static class Inicontrol
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);


        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        /// <summary>
        /// <para>iniファイルに値を書き込みます。ファイル・ディレクトリがない場合、作成します。</para>
        /// <para>使用例:Writetoini(@"C:\yaju.ini","touhou","sanae-old","17")</para>        
        ///  </summary>
        /// <param name="path">iniファイルパス</param>
        /// <param name="appname">データのセクション的な</param>
        /// <param name="keyname">キーの名前</param>
        /// <param name="content">キーの内容</param>
        /// <returns>書き込みが成功したらtrue。失敗したらfalse。</returns>

        public static bool Writetoini(string path, string appname, string keyname, string content)
        {

            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));


                FileStream fs = File.Create(path);
                fs.Close();
            }
            return WritePrivateProfileString(appname, keyname, content, path);

        }
        /// <summary>
        /// <para>iniファイルから値を読み込みます。</para>
        /// <para>使用例:Readfromini(@"C:\yaju.ini","touhou","sanae-old",out s)</para>
        /// </summary>
        /// <param name="path">iniファイルパス</param>
        /// <param name="appname">データセクション的な</param>
        /// <param name="keyname">キーの名前</param>
        /// <param name="result">読み取った結果を出力</param>
        /// <returns>参照が成功したらtrue。失敗したらfalse。</returns>
        public static bool Readfromini(string path, string appname, string keyname, out string result)
        {
            int capacitySize = 256;

            StringBuilder sb = new StringBuilder(capacitySize);
            uint ret = GetPrivateProfileString(appname, keyname, "", sb, Convert.ToUInt32(sb.Capacity), path);
            if (0 < ret)
            {
                result = sb.ToString();
                return true;
            }
            result = "";
            return false;


        }

      
    }
}
