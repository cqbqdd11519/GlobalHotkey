using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalHotKey
{
    partial class ConfigAddForm : Form
    {

        public ConfigClass config = null;
        
        private KeyPair keysSaved;
        private Keys targetKey;

        public ConfigAddForm()
        {
            Console.WriteLine((int)Keys.LControlKey);
            Console.WriteLine((int)Keys.ControlKey);
            Console.WriteLine((int)Keys.RControlKey);
            InitializeComponent();

            InterceptKeys.enableKeyHook = false;
            keysSaved = new KeyPair();
            targetKey = 0;
            this.Text = "Add Item";
        }
        public ConfigAddForm(ConfigClass _config): this()
        {
            this.Text = "Edit Item";
            config = _config;

            nameView.Text = config.getName();
            keysView.Text = string.Join("+",config.getKeyPairs());
            bool isCMD = config.getType() == ConfigClass.CommandType.CMD;
            typeView.SelectedIndex = isCMD ? 0 : 1;
            if (isCMD)
            {
                cmdFileView.Text = config.getCmdFile();
                cmdArgView.Text = config.getCmdArg();
            }
            else
            {
                targetKeyView.Text = config.getTargetKey().ToString();
            }

            keysSaved = new KeyPair(_config.getKeyPairs());
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = cmdFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = cmdFileDialog.FileName;
                cmdFileView.Text = file;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            hideDialog();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameView.Text == "" || keysSaved.Count < 1 || typeView.SelectedIndex < 0 || 
                (typeView.SelectedIndex == 0 && cmdFileView.Text == "") ||
                (typeView.SelectedIndex == 1 && targetKey == 0)) {
                MessageBox.Show("You need to set every fields", "Error");
                return;
            }
            config = new ConfigClass(nameView.Text,keysSaved,typeView.SelectedIndex == 0 ? ConfigClass.CommandType.CMD : ConfigClass.CommandType.KEY,
                cmdFileView.Text,cmdArgView.Text,targetKey);
            hideDialog();
        }

        private void hideDialog() {
            InterceptKeys.enableKeyHook = true;
            Hide();
        }

        private void typeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeView.SelectedIndex == 0)
            {
                cmdFileLabel.Visible = true;
                cmdFileView.Visible = true;
                btnBrowse.Visible = true;

                cmdArgLabel.Visible = true;
                cmdArgView.Visible = true;

                targetKeyLabel.Visible = false;
                targetKeyView.Visible = false;
            }
            else if (typeView.SelectedIndex == 1) {
                cmdFileLabel.Visible = false;
                cmdFileView.Visible = false;
                btnBrowse.Visible = false;

                cmdArgLabel.Visible = false;
                cmdArgView.Visible = false;

                targetKeyLabel.Visible = true;
                targetKeyView.Visible = true;
            }
        }

        private void ConfigAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                hideDialog();
            }
        }

        private void keysView_KeyDown(object sender, KeyEventArgs e)
        {
            if (InterceptKeys.getPressedKeys().Count == 0)
                keysSaved.Clear();
            keysSaved = new KeyPair(InterceptKeys.getPressedKeys());
            keysView.Text = string.Join("+",InterceptKeys.getPressedKeys());
            return;
        }
        private void keysView_KeyUp(object sender, KeyEventArgs e)
        {
            if(InterceptKeys.getPressedKeys().Count == 0)
            {
                if (e.KeyCode == Keys.Back)
                    keysSaved.Clear();
                keysView.Text = string.Join("+", keysSaved);
            }
            return;
        }
    }
}
