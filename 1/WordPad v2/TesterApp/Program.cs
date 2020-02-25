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
            StdGenerator generatorStd = new StdGenerator(ref textBox);
            SquareGenerator squareConGen = new SquareGenerator(ref textBox);
            GeffeGenerator geffeGen = new GeffeGenerator(ref textBox);
            Testers.GeneratorsTester.Test(geffeGen, 10);
        }
    }
}
