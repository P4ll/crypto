using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace crypto_test {
    public class GeffeGen : Generator {
        LFSR lfsr1, lfsr2, lfsr3;

        public GeffeGen(ref RichTextBox textBox) : base(ref textBox) {
            GenerateSequence = generateSeq;
            Generate = Next;
            lfsr1 = new LFSR(new int[] { 0, 1, 4, 18 });
            lfsr3 = new LFSR(new int[] { 2, 30 });
            lfsr2 = new LFSR(new int[] { 0, 3, 5, 29 });
        }

        private string generateSeq(int numbers, ref Utils.Progress progressForm) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(NextBit() & 1);
                progressForm.PerformStep();
            }
            progressForm.CloseFormSafe();
            Utils.MultiThreadHelper.SetTextBoxSafe(sb.ToString(), ref _textBox);
            return sb.ToString();
        }

        public ulong NextBit() {
            byte x1 = (byte)lfsr1.GetNextBit();
            byte x2 = (byte)lfsr2.GetNextBit();
            byte x3 = (byte)lfsr3.GetNextBit();
            return (ulong)((x1 & x2) ^ (x2 & x3));
        }

        public ulong Next() {
            ulong ans = 0;
            for (int i = 0; i < 64; ++i) {
                ans ^= (NextBit() << i);
            }
            return ans;
        }
    }
}
