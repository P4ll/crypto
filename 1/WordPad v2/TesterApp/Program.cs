using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crypto_test;

namespace TesterApp {
    class Program {
        static void Main() {
            //TestByteMult();
            AESTest();
            //TestRoundKey();
            //TestMixCols();
        }

        private static void TestByteMult() {
            byte a = 60;
            byte b = 161;
            AES aes = new AES();
            int c = aes.ByteMult(a, b);
            Console.WriteLine(Convert.ToString(a, 2));
            Console.WriteLine(Convert.ToString(b, 2));
            Console.WriteLine(Convert.ToString(c, 10));
        }
        private static void TestRoundKey() {
            byte[] bytes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int st = 0, en = 15;

            OutTable(ref bytes);
            AES aes = new AES();
            MD5Hash hasher = new MD5Hash();
            string hash = hasher.GetHash("abc", true);
            byte[] passBytes = aes.GetBytesFromHash(hash);
            List<byte> expKeys = aes.KeysExpansion(ref passBytes);
            aes.AddRoundKey(ref bytes, st, ref expKeys, 0);
            OutTable(ref bytes);
            expKeys = aes.KeysExpansion(ref passBytes);
            aes.AddRoundKey(ref bytes, st, ref expKeys, 0);
            OutTable(ref bytes);
        }
        private static void TestMixCols() {
            byte[] bytes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int st = 0, en = 15;
            OutTable(ref bytes);
            AES aes = new AES();
            aes.MixCols(ref bytes, st, en);
            OutTable(ref bytes);
            aes.InvMixCols(ref bytes, st, en);
            OutTable(ref bytes);
        }
        private static void TestSBox() {
            byte[] bytes = { 83, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int st = 0, en = 15;
            OutTable(ref bytes);
            AES aes = new AES();
            aes.SubBytes(ref bytes, st, en);
            OutTable(ref bytes);
            aes.InvSubBytes(ref bytes, st, en);
            OutTable(ref bytes);
        }
        private static void TestShiftRows() {
            byte[] bytes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            int st = 0, en = 15;
            OutTable(ref bytes);
            AES aes = new AES();
            aes.ShiftRows(ref bytes, st, en);
            OutTable(ref bytes);
            aes.InvShiftRow(ref bytes, st, en);
            OutTable(ref bytes);
        }
        private static void OutTable(ref byte[] bytes) {
            for (int i = 0; i < 4; ++i) {
                for (int j = 0; j < 4; ++j) {
                    Console.Write(bytes[i * 4 + j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void AESTest() {
            AES aes = new AES();
            MD5Hash hasher = new MD5Hash();
            string message = "GOVNDJSHSKHFKJLHSDNDFLN";
            string pass = "123456";
            string hash = hasher.GetHash(pass, true);
            string encrypted = aes.Encrypt(message, hash, true);
            string decrypted = aes.Decrypt(encrypted, hasher.GetHash("123456", true));
            Console.WriteLine($"message: {message}\npass: {pass}\n" +
                $"encrypted msg: {encrypted}\ndecrypted msg: {decrypted}");
        }

        private static void Md5Test() {
            Md5 md5 = new Md5();
            while (true) {
                //var input = Console.ReadLine();
                md5.StringValue = "";
                Console.WriteLine(md5.HexDigest);
            }
        }

        private static void GetMD5TableValues() {
            var a = File.ReadAllText("d:\\tt.txt");
            Console.Write(Helper.MD5Transform.FullTransform(a));
        }

        static private void TestShift() {
            Program pr = new Program();
            uint val = 2684354559;
            uint ans = pr.ShiftL(val, 100);
            Console.WriteLine(Convert.ToString(val, 2));
            Console.WriteLine(Convert.ToString(ans, 2));
        }

        private uint ShiftL(uint num, int steps) {
            steps = steps % 32;
            return (num << steps) + ((num & ((uint.MaxValue >> (32 - steps)) << (32 - steps))) >> (32 - steps));
        }

        static private void TestGen() {
            RichTextBox textBox = new RichTextBox();
            StdGenerator generatorStd = new StdGenerator(ref textBox);
            SquareGenerator squareConGen = new SquareGenerator(ref textBox);
            GeffeGenerator geffeGen = new GeffeGenerator(ref textBox);
            Testers.GeneratorsTester.Test(geffeGen, 10);
        }
    }
}
