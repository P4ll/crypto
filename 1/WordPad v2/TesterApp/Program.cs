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
            //TestGen();
            //StringBuilder sb = new StringBuilder();
            //var a = File.ReadAllText("d:\\tt.txt");
            //Console.Write(Helper.MD5Transform.FullTransform(a));
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
