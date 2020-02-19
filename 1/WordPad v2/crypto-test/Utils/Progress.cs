﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace crypto_test.Utils {
    public partial class Progress : Form {
        private delegate void SafeCallDelegate();

        public Progress(int start, int end, int step) {
            InitializeComponent();
            progressBar.Maximum = end;
            progressBar.Step = step;
            progressBar.Value = start;
        }

        public void PerformStep() {
            if (progressBar.InvokeRequired) {
                var d = new SafeCallDelegate(PerformStep);
                progressBar.Invoke(d, new object[] { });
            }
            else {
                progressBar.PerformStep();
                //Console.WriteLine(ToString());
            }
        }

        public override string ToString() {
            return $"Progress: {progressBar.Value}\\{progressBar.Maximum}";
        }

        private void Progress_Shown(object sender, EventArgs e) {
            
        }
    }
}
