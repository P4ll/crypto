using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace crypto_test {
    public class SquareConGen : Generator {
        private RichTextBox _textBox;
        
        private const ulong Seed = 19;
        private const ulong AConst = 1103515245;
        private const ulong BConst = 65539;//65539;48271
        private const ulong CConst = 12345; //12345;
        private const ulong MConst = (ulong)1 << 31;
        private ulong _curAns = Seed;

        public SquareConGen(ref RichTextBox textBox) : base(ref textBox) {
            GenerateSequenceAbstract = generateSeq;
            GenerateNextAbstract = Next;
            _textBox = textBox;
        }

        public ulong Next() {
            //curAns = ((AConst * AConst * curAns) % MConst + BConst * curAns + CConst) % MConst;
            //curAns = Add(Mult(BConst, curAns), CConst);
            _curAns = Add(Add(Mult(Mult(AConst, AConst), _curAns), Mult(BConst, _curAns)), CConst);
            Console.WriteLine(_curAns);
            return _curAns;
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                Next();
                sb.Append(_curAns & 1);
                progressForm.PerformStep();
            }
            progressForm.CloseFormSafe();
            string strAns = sb.ToString();
            Utils.MultiThreadHelper.SetTextBoxSafe(strAns, ref _textBox);
            return strAns;
        }

        private ulong Mult(ulong num1, ulong num2) {
            return (num1 * num2) % MConst;
        }

        private ulong Add(ulong num1, ulong num2) { 
            return (num1 + num2) % MConst;
        }
    }
}
