using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crypto_test.Utils {
    public partial class Progress : Form {
        public TextProgressBar textProgress;

        public Progress(ref TextProgressBar textProgress) {
            InitializeComponent();
            this.textProgress = textProgress;
        }
    }
}
