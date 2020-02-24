using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Threading;

namespace crypto_test {
    public abstract class Generator {
        protected RichTextBox _textBox;
        protected delegate string GenerateSeqenceDelegate(int length, ref Utils.Progress progressForm);
        protected delegate long GenerateDelegate();

        public string Name { get; private set; }
        protected GenerateSeqenceDelegate GenerateSequence { get; set; }
        protected GenerateDelegate Generate { get; set; }

        public Generator(ref RichTextBox textBox) {
            _textBox = textBox;
        }

        public void generateSequence(object sender, EventArgs e) {
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
            Utils.Progress progressForm = new Utils.Progress(0, seqLength, 1, "Gen progress");
            progressForm.Show();
            Thread genThread = new Thread(() => {
                GenerateSequence(seqLength, ref progressForm);
            });
            genThread.Start();
        }

        public long generate() {
            return Generate();
        }
    }
}
