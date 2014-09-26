using System;
using System.Collections;
using System.Collections.Generic;
namespace Program
{
    public static class Module1
    {
        static int n;
        static int m;
        static int per;
        static List<int> desetinna = new List<int>();
        public static void Main(string[] args)
        {
            string[] text;
            if (args.Length == 0)
                text = Console.ReadLine().Split(Convert.ToChar(" "));
            else
                text = args[0].Split(Convert.ToChar(" "));

            n = Convert.ToInt32(text[0]);
            m = Convert.ToInt32(text[1]);
            if (n % m == 0)
            {
                Console.WriteLine((Convert.ToDouble(text[0]) / Convert.ToDouble(text[1])).ToString().Replace(",", "."));
                Console.ReadKey();
            }
            else
            {
                Console.Write(n / m + ".");
                string cislo = del(n % m, m);
                if (cislo.IndexOf(per.ToString()) != -1)
                {
                    cislo = cislo.Insert(cislo.IndexOf(per.ToString()), "(");
                }
                Console.WriteLine(cislo);
                Console.ReadKey();

            }

        }
        /// <summary>
        /// deli
        /// </summary>
        /// <param name="n">delenec</param>
        /// <param name="m">delitel</param>
        /// <returns></returns>
        public static string del(int n, int m)
        {
            if (n < m)
            {
                n *= 10;
            }
            desetinna.Add(n);
            if (check(m) == true)
                return ")";
            if (n == 0)
            {
                return "";
            }
            else
            {
                return n / m + del(n % m, m);
            }
        }
        public static bool check(int m)
        {

            if (!(desetinna.IndexOf(desetinna[desetinna.Count - 1], desetinna.IndexOf(desetinna[desetinna.Count - 1]) + 1) == -1))
            {
                per = desetinna[desetinna.Count - 1] / m;
                return true;
            }


            return false;
        }
    }
}