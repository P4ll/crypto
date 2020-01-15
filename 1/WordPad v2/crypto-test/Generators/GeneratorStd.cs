﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace crypto_test {
    class GeneratorStd : Generator {
        public GeneratorStd(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
        }

        private string generateSeq(int numbers, ProgressBar progress) {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(rand.Next(0, 2));
                progress.PerformStep();
            }
            return sb.ToString();
        }
    }
}
