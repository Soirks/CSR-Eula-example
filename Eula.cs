using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSR;

namespace Soirks
{
    public class Eula
    {
        public static void eula(MCCSAPI api)
        {
            //api.setCommandDescribe("qd", "签到");
            //api.addAfterActListener(EventKey.onInputCommand, x =>
            //{
            //    var a = BaseEvent.getFrom(x) as InputCommandEvent;
            //    if (a.cmd == "/wdnmd")
            //    {
            //        api.runcmd("say 1");
            //    }
            //    return true;

            //});
            //string yesORno;
            string flag = "true";
            string b = "false";
            string path = "./config/eula.txt";//eula目录
            if (File.Exists(path)) //是否存在eula
            {
                try
                {
                    string[] config = File.ReadAllLines(path, System.Text.Encoding.Default);
                    b = config[0].Substring(0);
                }//存在，读取
                catch { Console.WriteLine("读取文件失败"); }
            }
            else
            {
                Directory.CreateDirectory("config/");
                File.AppendAllText(path, "false", System.Text.Encoding.Default);
                Console.WriteLine("已生成eula文件于config文件夹，请前往确认");
            }//不存在，创建
            if (b != "true")
            {
                Console.WriteLine("未同意eula，已锁定");
                while (flag == "true")
                {
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("已同意ELUA");
            }
        }
    }
}
namespace CSR
{
    partial class Plugin
    {

        public static void onStart(MCCSAPI api)
        {
            // TODO 此接口为必要实现
            Soirks.Eula.eula(api);
            Console.WriteLine("[test]eula示例已加载");
        }
    }
}

