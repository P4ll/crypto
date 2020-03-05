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
        private Plugin.Class1 _par;

        public InputForm(Plugin.Class1 parent) {
            InitializeComponent();
            _par = parent;
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                FileName = saveFileDialog.FileName;
                WordPad.Helpers.SaveHelper.SaveTextToFile(textBox.Text, saveFileDialog.FileName, WordPad.Form1.TxtExts);
                MD5Hash hasher = new MD5Hash();
                PassText = hasher.GetHash(textBox.Text, true);
                File.WriteAllText(FileName, PassText);
                _par.HashPass = PassText;
                this.Close();
            }
        }

        private void useBtn_Click(object sender, EventArgs e) {
            MD5Hash hasher = new MD5Hash();
            PassText = hasher.GetHash(textBox.Text, true);
            _par.HashPass = PassText;
            this.Close();
        }
    }
}
