using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace crypto_test {
    class Tester {
        private const string _delims = " .,\t";
        private RichTextBox textBox;

        public Tester(ref RichTextBox textBox) {
            this.textBox = textBox;
        }

        public void test(object sender, EventArgs e) {
            double bound = 1.82138636;
            int[] vals = getVals(textBox.Text, true);
            int res = 0;
            foreach (var i in vals) {
                res += i;
            }
            double stat = (double)Math.Abs(res) / Math.Sqrt(vals.Length);
            if (stat > bound) {
                MessageBox.Show($"Частотный тест не пройден. Значение статистики {stat}");
                return;
            }
            int[] valsWoTr = getVals(textBox.Text, true);
            int countOnes = 0;
            foreach (var i in valsWoTr) {
                countOnes += i;
            }
            double freq = (double)countOnes / valsWoTr.Length;
            int vn = 1;
            for (int i = 0; i < valsWoTr.Length - 1; ++i) {
                if (valsWoTr[i] != valsWoTr[i + 1])
                    vn++;
            }
            double statEqual = Math.Abs((double)vn - 2 * valsWoTr.Length * freq * (1 - freq)) / ((double)2 * Math.Sqrt(2 * valsWoTr.Length) * freq * ((double)1 - freq));

            int[] sums = new int[vals.Length + 2];
            sums[0] = sums[sums.Length - 1] = 0;
            int accum = 0;
            int zeroCount = 2;
            for (int i = 1, j = 0; i < sums.Length - 1; ++i, ++j) {
                accum += vals[j];
                sums[i] = accum;
                if (sums[i] == 0) zeroCount++;
            }
            int lValue = zeroCount - 1;

            int[] dzetas = new int[18];
            for (int i = -9; i < 10; ++i) {
                if (i == 0) continue;
                foreach (var sum in sums) {
                    if (i == sum) dzetas[_dzToArr(i)]++;
                }
            }

            double[] extendedStat = new double[18];
            for (int i = 0; i < 18; ++i) {
                extendedStat[i] = (double)Math.Abs(dzetas[i] - lValue) / Math.Sqrt((double)2 * lValue * (4 * Math.Abs(_arrToDz(i)) - 2));
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Частотный тест пройден\n");
            if (statEqual > bound) {
                sb.Append("Тест на последовательность одинаковых бит не пройден\n");
            }
            else {
                sb.Append("Тест на последовательность одинаковых бит пройден\n");
            }
            bool flag = false;
            foreach (var i in extendedStat) {
                if (i > bound) {
                    sb.Append("Расширенный тест на произвольные отклонения не пройден\n");
                    flag = true;
                    break;
                }
            }
            if (!flag) {
                sb.Append("Расширенный тест на произвольные отклонения пройден\n");
            }

            MessageBox.Show(sb.ToString());
        }

        private int _dzToArr(int pos) {
            if (pos <= -1) return pos + 9;
            else return pos + 8;
        }

        private int _arrToDz(int pos) {
            if (pos <= 8) return pos - 9;
            else return pos - 8;
        }

        private int[] getVals(string str, bool transform) {
            List<int> vals = new List<int>();
            for (int i = 0; i < str.Length; ++i) {
                bool isDel = false;
                foreach (var del in _delims) {
                    if (str[i] == del) {
                        isDel = true;
                        break;
                    }
                }
                if (!isDel && str[i] != '1' && str[i] != '0') {
                    MessageBox.Show($"Unexpected symbol at {i}");
                    return vals.ToArray();
                }
                else {
                    if (str[i] == '1') vals.Add(1);
                    else vals.Add(0);
                }
            }
            if (transform) {
                for (int i = 0; i < vals.Count; ++i) {
                    vals[i] = 2 * vals[i] - 1;
                }
            }
            return vals.ToArray();
        }
    }
}
