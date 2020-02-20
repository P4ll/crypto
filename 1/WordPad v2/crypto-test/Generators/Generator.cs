using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Threading;

namespace crypto_test {
    abstract class Generator {
        protected RichTextBox _textBox;
        protected delegate string Generate(int length, Utils.Progress progressForm);

        public string Name { get; private set; }
        protected Generate Gen { get; set; }

        public Generator(ref RichTextBox textBox) {
            _textBox = textBox;
        }

        public void generate(object sender, EventArgs e) {
            string result = Interaction.InputBox("Введите длину генерируемой последовательности (10000)");
            int seqLength = 10000;
            try {
                int tLen = Int32.Parse(result);
                seqLength = tLen;
            }
            catch (FormatException e2) {
                MessageBox.Show("Неверное число");
            }
            catch (OverflowException e3) {
                MessageBox.Show("Переполнение");
            }
            Utils.Progress progressForm = new Utils.Progress(0, seqLength, 1);
            progressForm.Show();
            Thread genThread = new Thread(() => {
                Gen(seqLength, progressForm);
            });
            genThread.Start();
        }
    }
}
