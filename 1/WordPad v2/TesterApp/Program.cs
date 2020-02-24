using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crypto_test;

namespace TesterApp {
    class Program {
        static void Main() {
            TestGen();
        }

        static private void TestGen() {
            RichTextBox textBox = new RichTextBox();
            GeneratorStd generatorStd = new GeneratorStd(ref textBox);
            SquareConGen squareConGen = new SquareConGen(ref textBox);
            GeffeGen geffeGen = new GeffeGen(ref textBox);
            Testers.GeneratorsTester.Test(geffeGen, 100);
        }
    }
}
