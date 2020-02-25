using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;

namespace crypto_test {
    public class GeneratorStd : Generator {
        private RichTextBox _textBox;
        private Random _rand;

        public GeneratorStd(ref RichTextBox textBox) : base(ref textBox) {
            _rand = new Random();
            GenerateSequenceAbstract = generateSeq;
            GenerateNextAbstract = Next;
            _textBox = textBox;
        }

        public ulong Next() {
            return (ulong)_rand.Next();
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(_rand.Next(0, 2));
                progressForm.PerformStep();
            }
            progressForm.CloseFormSafe();
            Utils.MultiThreadHelper.SetTextBoxSafe(sb.ToString(), ref _textBox);
            
            return sb.ToString();
        }
    }
}
