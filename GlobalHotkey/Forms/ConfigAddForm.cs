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
            switch (config.getType()) {
                case ConfigClass.CommandType.EXE:
                    {
                        typeView.SelectedIndex = 0;
                        exeFileView.Text = config.getExeFile();
                        exeArgView.Text = config.getExeArg();
                        break;
                    }
                case ConfigClass.CommandType.KEY:
                    {
                        typeView.SelectedIndex = 1;
                        targetKeyView.Text = config.getTargetKey().ToString();
                        break;
                    }
                case ConfigClass.CommandType.CMD:
                    {
                        typeView.SelectedIndex = 2;
                        cmdLineView.Text = config.getCmdLine();
                        break;
                    }
                default:
                    break;
            }

            keysSaved = new KeyPair(_config.getKeyPairs());
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = cmdFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = cmdFileDialog.FileName;
                exeFileView.Text = file;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            hideDialog();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (nameView.Text == "" || keysSaved.Count < 1 || typeView.SelectedIndex < 0 || 
                (typeView.SelectedIndex == 0 && exeFileView.Text == "") ||
                (typeView.SelectedIndex == 1 && !Enum.TryParse<Keys>(targetKeyView.Text,out targetKey)) ||
                (typeView.SelectedIndex == 2 && cmdLineView.Text == "")) {
                MessageBox.Show("You need to set every fields", "Error");
                return;
            }
            config = new ConfigClass(nameView.Text,keysSaved
                ,typeView.SelectedIndex == 0 ? ConfigClass.CommandType.EXE
                : typeView.SelectedIndex == 1 ? ConfigClass.CommandType.KEY : ConfigClass.CommandType.CMD,
                exeFileView.Text,exeArgView.Text,targetKey,cmdLineView.Text);
            hideDialog();
        }

        private void hideDialog() {
            InterceptKeys.enableKeyHook = true;
            Hide();
        }

        private void typeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeView.SelectedIndex) {
                case 0:
                    {
                        exeFileLabel.Visible = true;
                        exeFileView.Visible = true;
                        btnBrowse.Visible = true;

                        exeArgLabel.Visible = true;
                        exeArgView.Visible = true;

                        targetKeyLabel.Visible = false;
                        targetKeyView.Visible = false;

                        cmdLineLabel.Visible = false;
                        cmdLineView.Visible = false;
                        break;
                    }
                case 1:
                    {
                        exeFileLabel.Visible = false;
                        exeFileView.Visible = false;
                        btnBrowse.Visible = false;

                        exeArgLabel.Visible = false;
                        exeArgView.Visible = false;

                        targetKeyLabel.Visible = true;
                        targetKeyView.Visible = true;

                        cmdLineLabel.Visible = false;
                        cmdLineView.Visible = false;
                        break;
                    }
                case 2:
                    {
                        exeFileLabel.Visible = false;
                        exeFileView.Visible = false;
                        btnBrowse.Visible = false;

                        exeArgLabel.Visible = false;
                        exeArgView.Visible = false;

                        targetKeyLabel.Visible = false;
                        targetKeyView.Visible = false;

                        cmdLineLabel.Visible = true;
                        cmdLineView.Visible = true;
                        break;
                    }
                default:
                    break;
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
