using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using crypto_test;
using WordPad;

namespace cipher_plugin.Utils {
    public partial class InputForm : Form {
        public string FileName { get; set; }
        public string PassText { get; set; }

        public InputForm() {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                FileName = saveFileDialog.FileName;
                WordPad.Helpers.SaveHelper.SaveTextToFile(textBox.Text, saveFileDialog.FileName, WordPad.Form1.TxtExts);
                MD5Hash hasher = new MD5Hash();
                PassText = hasher.GetHash(textBox.Text, true);
                File.WriteAllText(FileName, PassText);
                this.Close();
            }
        }
    }
}
