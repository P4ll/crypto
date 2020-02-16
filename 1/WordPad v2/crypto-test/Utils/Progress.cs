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
        private TextProgressBar _textProgress;

        public delegate void Message(object sender, EventArgs e);
        public event Message OnPerformStep;

        public Progress(int start, int end, int step) {
            InitializeComponent();
            _textProgress = new TextProgressBar() {
                StartValue = start,
                EndValue = end,
                Step = step
            };
            progressLabel.Text = _textProgress.ToString();
        }

        public void PerformStep() {
            _textProgress.PerformStep();
            progressLabel.Text = _textProgress.ToString();
        }

        public override string ToString() {
            return _textProgress.ToString();
        }

        private void Progress_Shown(object sender, EventArgs e) {
            
        }
    }
}
