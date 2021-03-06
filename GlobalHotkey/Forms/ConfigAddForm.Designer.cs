﻿namespace GlobalHotKey
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
            this.exeFileView = new System.Windows.Forms.TextBox();
            this.exeFileLabel = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.exeArgView = new System.Windows.Forms.TextBox();
            this.exeArgLabel = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.cmdFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.targetKeyLabel = new System.Windows.Forms.Label();
            this.targetKeyView = new System.Windows.Forms.TextBox();
            this.cmdLineView = new System.Windows.Forms.TextBox();
            this.cmdLineLabel = new System.Windows.Forms.Label();
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
            "File Execution",
            "Key Input",
            "Command"});
            this.typeView.Location = new System.Drawing.Point(135, 87);
            this.typeView.Name = "typeView";
            this.typeView.Size = new System.Drawing.Size(336, 20);
            this.typeView.TabIndex = 5;
            this.typeView.SelectedIndexChanged += new System.EventHandler(this.typeView_SelectedIndexChanged);
            // 
            // exeFileView
            // 
            this.exeFileView.Location = new System.Drawing.Point(135, 120);
            this.exeFileView.Name = "exeFileView";
            this.exeFileView.ReadOnly = true;
            this.exeFileView.Size = new System.Drawing.Size(257, 21);
            this.exeFileView.TabIndex = 7;
            this.exeFileView.Visible = false;
            // 
            // exeFileLabel
            // 
            this.exeFileLabel.AutoSize = true;
            this.exeFileLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exeFileLabel.Location = new System.Drawing.Point(13, 125);
            this.exeFileLabel.Name = "exeFileLabel";
            this.exeFileLabel.Size = new System.Drawing.Size(34, 19);
            this.exeFileLabel.TabIndex = 6;
            this.exeFileLabel.Text = "File";
            this.exeFileLabel.Visible = false;
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
            // exeArgView
            // 
            this.exeArgView.Location = new System.Drawing.Point(135, 158);
            this.exeArgView.Name = "exeArgView";
            this.exeArgView.Size = new System.Drawing.Size(336, 21);
            this.exeArgView.TabIndex = 10;
            this.exeArgView.Visible = false;
            // 
            // exeArgLabel
            // 
            this.exeArgLabel.AutoSize = true;
            this.exeArgLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exeArgLabel.Location = new System.Drawing.Point(14, 161);
            this.exeArgLabel.Name = "exeArgLabel";
            this.exeArgLabel.Size = new System.Drawing.Size(97, 19);
            this.exeArgLabel.TabIndex = 9;
            this.exeArgLabel.Text = "Arguments";
            this.exeArgLabel.Visible = false;
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
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(315, 226);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
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
            // cmdLineView
            // 
            this.cmdLineView.Location = new System.Drawing.Point(135, 120);
            this.cmdLineView.Name = "cmdLineView";
            this.cmdLineView.Size = new System.Drawing.Size(336, 21);
            this.cmdLineView.TabIndex = 16;
            this.cmdLineView.Visible = false;
            // 
            // cmdLineLabel
            // 
            this.cmdLineLabel.AutoSize = true;
            this.cmdLineLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmdLineLabel.Location = new System.Drawing.Point(14, 125);
            this.cmdLineLabel.Name = "cmdLineLabel";
            this.cmdLineLabel.Size = new System.Drawing.Size(92, 19);
            this.cmdLineLabel.TabIndex = 15;
            this.cmdLineLabel.Text = "Key Event";
            this.cmdLineLabel.Visible = false;
            // 
            // ConfigAddForm
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(483, 261);
            this.Controls.Add(this.cmdLineView);
            this.Controls.Add(this.cmdLineLabel);
            this.Controls.Add(this.targetKeyView);
            this.Controls.Add(this.targetKeyLabel);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.exeArgView);
            this.Controls.Add(this.exeArgLabel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.exeFileView);
            this.Controls.Add(this.exeFileLabel);
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
        private System.Windows.Forms.TextBox exeFileView;
        private System.Windows.Forms.Label exeFileLabel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox exeArgView;
        private System.Windows.Forms.Label exeArgLabel;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.OpenFileDialog cmdFileDialog;
        private System.Windows.Forms.Label targetKeyLabel;
        private System.Windows.Forms.TextBox targetKeyView;
        private System.Windows.Forms.TextBox cmdLineView;
        private System.Windows.Forms.Label cmdLineLabel;
    }
}