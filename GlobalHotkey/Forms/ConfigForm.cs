using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace GlobalHotKey
{
    using HotKeyDict = Dictionary<int, ConfigClass>;
    public partial class ConfigForm : Form
    {

        private HotKeyDict hotKeys = new HotKeyDict();

        private List<ConfigClass> configList = new List<ConfigClass>();
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
            foreach (KeyValuePair<int, ConfigClass> obj in hotKeys) {
                ConfigClass val = obj.Value;
                addViewItem(val);
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            HotKeyManager.setHotKeys(hotKeys);
            this.Hide();
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
    }
}
