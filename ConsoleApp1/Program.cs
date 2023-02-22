// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(Hash_MD5_32("林祁1"));

            Console.WriteLine(Math.Atan2(1, 0));//y,x





            var bytes = Encoding.UTF8.GetBytes("🔒");//将其转为utf8格式
            var base64 = Convert.ToBase64String(bytes);//转为B64
            Console.WriteLine("BU8:"+base64);

            //Console.WriteLine("UTF8:"+ Encoding.UTF8.GetString(Encoding.UTF8.GetBytes("✨")));

            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(DateTime.Now.AddMinutes(30).ToString());

            Random rd = new Random();//随机数
            Console.WriteLine(rd.Next(1, 3));


            List<int> aaaa = new List<int>() {5555,6666,7777,7777 };
            aaaa.RemoveAll(o => o == 7777);
            for (int i = 0; i < aaaa.Count; i++)
            {
                Console.WriteLine(aaaa[i]);
            }



        }



        public static string[] GetBU8List(string Text)
        {
            string r = "<BU8:\"([a-zA-Z0-9\\+/]*={0,3})\">";//匹配b64
            Regex regex = new Regex(r, RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(Text);
            int i = 0;
            string[] bu8List = new string[matches.Count];
            foreach (Match match in matches)
                bu8List[i++] = match.Groups["1"].Value;
            return bu8List;
        }


        /// <summary>
        /// 计算32位MD5码
        /// </summary>
        /// <param name="word">字符串</param>
        /// <returns></returns>
        public static string Hash_MD5_32(string word)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP
                 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(word);
                byte[] bytHash = MD5CSP.ComputeHash(bytValue);
                MD5CSP.Clear();
                //根据计算得到的Hash码翻译为MD5码
                string sHash = "", sTemp = "";
                for (int counter = 0; counter < bytHash.Count(); counter++)
                {
                    long i = bytHash[counter] / 16;
                    if (i > 9)
                    {
                        sTemp = ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp = ((char)(i + 0x30)).ToString();
                    }
                    i = bytHash[counter] % 16;
                    if (i > 9)
                    {
                        sTemp += ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp += ((char)(i + 0x30)).ToString();
                    }
                    sHash += sTemp;
                }
                //根据大小写规则决定返回的字符串
                return sHash.ToLower();//小写
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string GetUserPasswordtext(string name, string word)
        {
            string text1 = name;
            string text2 = word;
            text1 = Hash_MD5_32(text1);
            string text3 = text1;
            text1 += text2;
            text2 = text3;
            text1 = Hash_MD5_32(text1);
            text3 = text1;
            text1 += text2;
            text2 = text3;
            text1 = Hash_MD5_32(text1);
            text3 = text1;
            text1 += text2;
            text2 = text3;
            text1 = Hash_MD5_32(text1);
            return text1;
        }
    }



}




//Console.WriteLine("Hello, World!");
//Console.WriteLine(DateTime.Now.ToString());

//int a = 7;
//Console.WriteLine(100 % 5);

//try
//{
//    System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP
//     = new System.Security.Cryptography.MD5CryptoServiceProvider();
//    byte[] bytValue = System.Text.Encoding.UTF8.GetBytes("66G6");
//    byte[] bytHash = MD5CSP.ComputeHash(bytValue);
//    MD5CSP.Clear();
//    根据计算得到的Hash码翻译为MD5码
//    string sHash = "", sTemp = "";
//    for (int counter = 0; counter < bytHash.Length; counter++)
//    {
//        long i = bytHash[counter] / 16;
//        if (i > 9)
//        {
//            sTemp = ((char)(i - 10 + 0x41)).ToString();
//        }
//        else
//        {
//            sTemp = ((char)(i + 0x30)).ToString();
//        }
//        i = bytHash[counter] % 16;
//        if (i > 9)
//        {
//            sTemp += ((char)(i - 10 + 0x41)).ToString();
//        }
//        else
//        {
//            sTemp += ((char)(i + 0x30)).ToString();
//        }
//        sHash += sTemp;
//    }
//    根据大小写规则决定返回的字符串
//    Console.WriteLine(sHash.ToLower());
//    return sHash.ToLower();//小写
//}
//catch (Exception ex)
//{
//    throw new Exception(ex.Message);
//}


///// <summary>
///// 计算32位MD5码
///// </summary>
///// <param name="word">字符串</param>
///// <returns></returns>
//public static string Hash_MD5_32(string word)
//{
//    try
//    {
//        System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP
//         = new System.Security.Cryptography.MD5CryptoServiceProvider();
//        byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(word);
//        byte[] bytHash = MD5CSP.ComputeHash(bytValue);
//        MD5CSP.Clear();
//        //根据计算得到的Hash码翻译为MD5码
//        string sHash = "", sTemp = "";
//        for (int counter = 0; counter < bytHash.Count(); counter++)
//        {
//            long i = bytHash[counter] / 16;
//            if (i > 9)
//            {
//                sTemp = ((char)(i - 10 + 0x41)).ToString();
//            }
//            else
//            {
//                sTemp = ((char)(i + 0x30)).ToString();
//            }
//            i = bytHash[counter] % 16;
//            if (i > 9)
//            {
//                sTemp += ((char)(i - 10 + 0x41)).ToString();
//            }
//            else
//            {
//                sTemp += ((char)(i + 0x30)).ToString();
//            }
//            sHash += sTemp;
//        }
//        //根据大小写规则决定返回的字符串
//        return sHash.ToLower();//小写
//    }
//    catch (Exception ex)
//    {
//        throw new Exception(ex.Message);
//    }
//}

