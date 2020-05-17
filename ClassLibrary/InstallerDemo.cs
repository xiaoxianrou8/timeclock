using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{   
    public class InstallerDemo : Installer
    {
        protected override void OnAfterInstall(IDictionary savedState)
        {
            LogWrite("OnAfterInstall！");
            string path = this.Context.Parameters["targetdir"];//获取用户设定的安装目标路径, 注意，需要在Setup项目里面自定义操作的属性栏里面的CustomActionData添加上/targetdir="[TARGETDIR]\"
            LogWrite(path);                                                //开机启动
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            try
            {//64位系统在计算机\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run
                LogWrite("设置注册表！");
                LogWrite(path.Substring(0, path.Length - 1) + @"BingPic\BingPic.exe");
                run.CreateSubKey("Bing", true);
                run.SetValue("Bing", path.Substring(0, path.Length - 1) + @"BingPic\BingPic.exe");
                hklm.Close();
                LogWrite("设置结束！");

            }
            catch (Exception my)
            {
                my.ToString();
                LogWrite(my.ToString());
            }
            base.OnAfterInstall(savedState);
        }
        public override void Install(IDictionary stateSaver)
        {
            LogWrite("Install！");
            base.Install(stateSaver);
        }
        protected override void OnBeforeInstall(IDictionary savedState)
        {
            LogWrite("OnBeforeInstall!");
            base.OnBeforeInstall(savedState);
        }
        public override void Uninstall(IDictionary savedState)
        {
            LogWrite("Uninstall!");
            base.Uninstall(savedState);
        }
        public override void Rollback(IDictionary savedState)
        {
            LogWrite("Rollback");
            base.Rollback(savedState);
        }
        public void LogWrite(string str)
        {
            string LogPath = @"c:\log\";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(LogPath + @"SetUpLog.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + str + "\n");

            }
        }
    }
}
