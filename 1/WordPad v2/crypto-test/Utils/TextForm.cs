﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_test.Utils {
    public partial class TextForm : Form {
        public TextForm(string ans) {
            InitializeComponent();
            richTextBox1.Text = ans;
        }
    }
}
