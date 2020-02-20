﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Threading;

namespace crypto_test {
    class GeneratorStd : Generator {
        private delegate void SafeCallDelegate(string text);
        private RichTextBox _textBox;

        public GeneratorStd(ref RichTextBox textBox) : base(ref textBox) {
            Gen = generateSeq;
            _textBox = textBox;
        }

        private string generateSeq(int numbers, Utils.Progress progressForm) {            
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers; ++i) {
                sb.Append(rand.Next(0, 2));
                progressForm.PerformStep();
            }
            progressForm.CloseFormSafe();
            setTextBoxSafe(sb.ToString());
            return sb.ToString();
        }

        private void setTextBoxSafe(string text) {
            if (_textBox.InvokeRequired) {
                var d = new SafeCallDelegate(setTextBoxSafe);
                _textBox.Invoke(d, new object[] { text });
            }
            else {
                _textBox.Text = text;
            }
        }
    }
}
