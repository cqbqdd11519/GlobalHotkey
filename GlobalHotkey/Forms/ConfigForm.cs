using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GlobalHotKey
{
    using HotKeyDict = Dictionary<int, ConfigClass>;
    public partial class ConfigForm : Form
    {
        private static ConfigForm openForm = null;

        private HotKeyDict hotKeys = new HotKeyDict();
        private List<ConfigClass> configList = new List<ConfigClass>();

        public static ConfigForm GetInstance() {
            if (openForm == null) {
                openForm = new ConfigForm();
                openForm.FormClosed += delegate { openForm = null; };
            }
            return openForm;
        }
        public ConfigForm()
        {
            InitializeComponent();
            this.Text = Properties.Resources.AppName + " Configuration";
            initListView();
            loadHotKeys();
        }

        private void initListView() {
            keysListView.View = View.Details;
            keysListView.FullRowSelect = true;
            keysListView.Columns.Add("Name",-2,HorizontalAlignment.Left);
            keysListView.Columns.Add("Keypair", -2, HorizontalAlignment.Left);
            keysListView.Columns.Add("Job", -2, HorizontalAlignment.Left);
            keysListView.Columns.Add("Job Detail", -2, HorizontalAlignment.Left);
        }

        private void loadHotKeys() {
            hotKeys = new HotKeyDict(HotKeyManager.getHotKeys());
            keysListView.Items.Clear();
            foreach (KeyValuePair<int, ConfigClass> obj in hotKeys) {
                addViewItem(obj.Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ConfigAddForm addForm = new ConfigAddForm();
            addForm.ShowDialog();
            ConfigClass val = addForm.config;
            if (val == null)
                return;
            hotKeys.Add(val.getKeyPairs().GetHashCode(),val);
            addViewItem(val);
            btnApply.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int idx = keysListView.SelectedItems[0].ImageIndex;
            ConfigAddForm editForm = new ConfigAddForm(hotKeys[idx]);
            editForm.ShowDialog();
            ConfigClass val = editForm.config;
            if (val == null)
                return;
            hotKeys.Remove(idx);
            hotKeys.Add(val.getKeyPairs().GetHashCode(), val);
            keysListView.Items.Remove(keysListView.SelectedItems[0]);
            addViewItem(val);
            btnApply.Enabled = true;
        }

        private void addViewItem(ConfigClass val)
        {
            keysListView.Items.Add(new ListViewItem(new[] { val.getName(), string.Join("+", val.getKeyPairs())
                , val.getType().ToString()
                , val.getType()==ConfigClass.CommandType.EXE ? val.getExeFile()+" "+val.getExeArg()
                :val.getType()==ConfigClass.CommandType.KEY ? val.getTargetKey().ToString() : val.getCmdLine()}, val.getKeyPairs().GetHashCode()));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = keysListView.SelectedItems[0];
            hotKeys.Remove(item.ImageIndex);
            keysListView.Items.Remove(item);
            btnApply.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            HotKeyManager.setHotKeys(hotKeys);
            btnApply.Enabled = false;
        }

        private void keysListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (keysListView.SelectedItems.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            HotKeyManager.setHotKeys(hotKeys);
            Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a Configuration Backup File";
            saveFileDialog1.Filter = "JSON Files|*.json";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                string backup_str = Properties.Settings.Default.HotKeys;
                byte[] backup_byte = new UTF8Encoding(true).GetBytes(backup_str);
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();
                fs.Write(backup_byte,0,backup_byte.Length);
                fs.Close();
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a Configuration Backup File";
            openFileDialog1.Filter = "JSON Files|*.json";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                Properties.Settings.Default.HotKeys = sr.ReadToEnd();
                sr.Close();
                Properties.Settings.Default.Save();
                HotKeyManager.parseHotKeys();
                loadHotKeys();
            }
        }
    }
}
