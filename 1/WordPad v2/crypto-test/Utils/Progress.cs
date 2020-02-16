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
        public event EventHandler OnPerformStep;

        public Progress(int start, int end, int step) {
            InitializeComponent();
            progressBar = new ProgressBar() {
                Step = step,
                Minimum = start,
                Maximum = end
            };
        }

        public void PerformStep() {
            progressBar.PerformStep();
            //textBox1.Text = ToString();
            Console.WriteLine(ToString());
        }

        public override string ToString() {
            return $"Progress: {progressBar.Value}\\{progressBar.Maximum}";
        }

        private void Progress_Shown(object sender, EventArgs e) {
            
        }

        private void button1_Click(object sender, EventArgs e) {
            if (progressBar.Value >= progressBar.Maximum) progressBar.Value = 0;
            PerformStep();
            progressBar.Refresh();
            this.Refresh();
        }
    }
}
