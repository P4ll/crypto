using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace Plugin
{
    public class Class1
    {
        public const string Name = "crypto-test";
        private RichTextBox textBox;
        Form form;
        private int _pos;
        private MenuStrip _menu;
        private string _delims = " .,\t";

        public void run(ref Form form, ref RichTextBox textBox)
        {
            this.textBox = textBox;
            this.form = form;
            _menu = (MenuStrip)form.Controls[1];
            ToolStripMenuItem item = new ToolStripMenuItem("Crypto test");
            item.DropDownItems.Add("Генерация");
            item.DropDownItems.Add("Тестирование последовательности");
            item.DropDownItems[0].Click += generate;
            item.DropDownItems[1].Click += test;
            _menu.Items.Add(item);
            _pos = _menu.Items.Count - 1;
        }

        private void generate(object sender, EventArgs e) {
            string result = Interaction.InputBox("Введите длину генерируемой последовательности (10000)");
            int seqLength = 10000;
            try
            {
                int tLen = Int32.Parse(result);
                seqLength = tLen;
            }
            catch (ArgumentNullException e1)
            {
            }
            catch (FormatException e2)
            {
                MessageBox.Show("Неаерный формат");
            }
            catch (OverflowException e3) {
                MessageBox.Show("Переполнение");
            }
            textBox.Text = generateSeq(seqLength);
        }

        private string generateSeq(int numbers) {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(rand.Next(0, 2));
            }
            return sb.ToString();
        }

        private void test(object sender, EventArgs e) {
            int[] vals = getVals(textBox.Text);
            for (int i = 0; i < vals.Length; ++i) {
                vals[i] = 2 * vals[i] - 1;
            }
            int res = 0;
            foreach (var i in vals) {
                res += vals[i];
            }
            double stat = (double)res / Math.Sqrt(vals.Length);
        }

        private int[] getVals(string str) {
            List<int> vals = new List<int>();
            foreach (var i in str) {
                bool isDel = false;
                foreach (var del in _delims) {
                    if (i == del) {
                        isDel = true;
                        break;
                    }
                }
                if (!isDel && (i != '1' || i != '0'))
                {
                    // error
                }
                else {
                    if (i == '1') vals.Add(1);
                    else vals.Add(0);
                }
            }
            return vals.ToArray();
        }

        public void stop()
        {
            _menu.Items.RemoveAt(_pos);
        }
    }
}
