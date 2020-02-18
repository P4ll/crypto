using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace crypto_test {
    class GeneratorStd : Generator {
        private RichTextBox _textBox;

        public GeneratorStd(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
            _textBox = textBox;
        }

        private string generateSeq(int numbers, ref Utils.Progress progress) {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(rand.Next(0, 2));
                progress.PerformStep();
            }
            
            _textBox.Text = sb.ToString();
            return sb.ToString();
            //string ans = "";
            //Task formTask = Task.Factory.StartNew(() => {
            //    Utils.Progress progress = new Utils.Progress(0, numbers, 1);
            //    progress.Show();

            //    Task<string> ffTask = Task<string>.Factory.StartNew(() => {
            //        Random rand = new Random();
            //        StringBuilder sb = new StringBuilder();
            //        for (int i = 0; i < numbers; ++i) {
            //            sb.Append(rand.Next(0, 2));
            //            progress.PerformStep();
            //        }
            //        return sb.ToString();
            //    });
            //    ffTask.Wait();
            //    ans = ffTask.Result;
            //});
            //formTask.Wait();
            //return ans;
        }
    }
}
