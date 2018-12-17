namespace GlobalHotKey
{
    partial class ConfigAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigAddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nameView = new System.Windows.Forms.TextBox();
            this.keysView = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.typeView = new System.Windows.Forms.ComboBox();
            this.cmdFileView = new System.Windows.Forms.TextBox();
            this.cmdFileLabel = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.cmdArgView = new System.Windows.Forms.TextBox();
            this.cmdArgLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.cmdFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.targetKeyLabel = new System.Windows.Forms.Label();
            this.targetKeyView = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameView
            // 
            this.nameView.Location = new System.Drawing.Point(135, 11);
            this.nameView.Name = "nameView";
            this.nameView.Size = new System.Drawing.Size(336, 21);
            this.nameView.TabIndex = 1;
            // 
            // keysView
            // 
            this.keysView.Location = new System.Drawing.Point(135, 49);
            this.keysView.Name = "keysView";
            this.keysView.ReadOnly = true;
            this.keysView.Size = new System.Drawing.Size(336, 21);
            this.keysView.TabIndex = 3;
            this.keysView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keysView_KeyDown);
            this.keysView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keysView_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Keys";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Command";
            // 
            // typeView
            // 
            this.typeView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeView.FormattingEnabled = true;
            this.typeView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.typeView.Items.AddRange(new object[] {
            "Command",
            "Key Input"});
            this.typeView.Location = new System.Drawing.Point(135, 87);
            this.typeView.Name = "typeView";
            this.typeView.Size = new System.Drawing.Size(336, 20);
            this.typeView.TabIndex = 5;
            this.typeView.SelectedIndexChanged += new System.EventHandler(this.typeView_SelectedIndexChanged);
            // 
            // cmdFileView
            // 
            this.cmdFileView.Location = new System.Drawing.Point(135, 120);
            this.cmdFileView.Name = "cmdFileView";
            this.cmdFileView.ReadOnly = true;
            this.cmdFileView.Size = new System.Drawing.Size(257, 21);
            this.cmdFileView.TabIndex = 7;
            this.cmdFileView.Visible = false;
            // 
            // cmdFileLabel
            // 
            this.cmdFileLabel.AutoSize = true;
            this.cmdFileLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdFileLabel.Location = new System.Drawing.Point(13, 125);
            this.cmdFileLabel.Name = "cmdFileLabel";
            this.cmdFileLabel.Size = new System.Drawing.Size(34, 19);
            this.cmdFileLabel.TabIndex = 6;
            this.cmdFileLabel.Text = "File";
            this.cmdFileLabel.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(398, 120);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Visible = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cmdArgView
            // 
            this.cmdArgView.Location = new System.Drawing.Point(135, 158);
            this.cmdArgView.Name = "cmdArgView";
            this.cmdArgView.Size = new System.Drawing.Size(336, 21);
            this.cmdArgView.TabIndex = 10;
            this.cmdArgView.Visible = false;
            // 
            // cmdArgLabel
            // 
            this.cmdArgLabel.AutoSize = true;
            this.cmdArgLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdArgLabel.Location = new System.Drawing.Point(14, 161);
            this.cmdArgLabel.Name = "cmdArgLabel";
            this.cmdArgLabel.Size = new System.Drawing.Size(97, 19);
            this.cmdArgLabel.TabIndex = 9;
            this.cmdArgLabel.Text = "Arguments";
            this.cmdArgLabel.Visible = false;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(396, 226);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 11;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(315, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // cmdFileDialog
            // 
            this.cmdFileDialog.FileName = "cmdFileDialog";
            // 
            // targetKeyLabel
            // 
            this.targetKeyLabel.AutoSize = true;
            this.targetKeyLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.targetKeyLabel.Location = new System.Drawing.Point(14, 125);
            this.targetKeyLabel.Name = "targetKeyLabel";
            this.targetKeyLabel.Size = new System.Drawing.Size(92, 19);
            this.targetKeyLabel.TabIndex = 13;
            this.targetKeyLabel.Text = "Key Event";
            this.targetKeyLabel.Visible = false;
            // 
            // targetKeyView
            // 
            this.targetKeyView.Location = new System.Drawing.Point(135, 120);
            this.targetKeyView.Name = "targetKeyView";
            this.targetKeyView.Size = new System.Drawing.Size(336, 21);
            this.targetKeyView.TabIndex = 14;
            this.targetKeyView.Visible = false;
            // 
            // ConfigAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 261);
            this.Controls.Add(this.targetKeyView);
            this.Controls.Add(this.targetKeyLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.cmdArgView);
            this.Controls.Add(this.cmdArgLabel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.cmdFileView);
            this.Controls.Add(this.cmdFileLabel);
            this.Controls.Add(this.typeView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.keysView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameView);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfigAddForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigAddForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameView;
        private System.Windows.Forms.TextBox keysView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox typeView;
        private System.Windows.Forms.TextBox cmdFileView;
        private System.Windows.Forms.Label cmdFileLabel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox cmdArgView;
        private System.Windows.Forms.Label cmdArgLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.OpenFileDialog cmdFileDialog;
        private System.Windows.Forms.Label targetKeyLabel;
        private System.Windows.Forms.TextBox targetKeyView;
    }
}