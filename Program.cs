using System;
using System.IO;
using System.Text;

namespace ConvEncPrj
{
    class Program
    {
        static private Encoding SrcEnc = null;
        static private string SrcPth = "";
        static private Encoding DstEnc = null;
        static private string DstPth = "";
        static void Main(string[] args)
        {
            try
            {
                ParseArg(args);
                using(var sw = new StreamWriter(DstPth, false, DstEnc))
                {
                    using(var sr = new StreamReader(SrcPth, SrcEnc))
                    {
                        while(sr.Peek() > -1)
                        {
                            sw.WriteLine(sr.ReadLine());
                        }
                    }
                }
                Console.WriteLine("変換完了!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ParseArg(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (args.Length != 4){
                Console.WriteLine($"第1引数：変換元コード  exp shift_jis");
                Console.WriteLine($"第2引数：変換元ファイルパス");
                Console.WriteLine($"第3引数：変換先コード  exp utf-8");
                Console.WriteLine($"第4引数：出力先ファイルパス");
                throw new Exception("引数がたりません");
            } 
            Console.WriteLine($"変換元：{args[0]}");
            Console.WriteLine($"変換元：{args[1]}");
            Console.WriteLine($"変換先：{args[2]}");
            Console.WriteLine($"変換先：{args[3]}");
            SrcEnc = Encoding.GetEncoding(args[0]);
            SrcPth = args[1];
            DstEnc = Encoding.GetEncoding(args[2]);
            DstPth = args[3];
            if (!File.Exists(SrcPth)) throw new Exception("入力元ファイルがありません");
        }
    }
}
