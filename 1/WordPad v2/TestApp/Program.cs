using System;
using crypto_test;
using System.Windows.Forms;

namespace TestApp {

    class Program {
        static void Main(string[] args) {
            RichTextBox textBox = new RichTextBox();
            GeneratorStd generatorStd = new GeneratorStd(ref textBox);
            Testers.GeneratorsTester.Test(generatorStd, 10);
        }
    }
}
