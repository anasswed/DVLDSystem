using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer
{
    partial class frmNewLocalDrivingLicense
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tapPersonalInfo = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tapApplicationInfo = new System.Windows.Forms.TabPage();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblApplicationDateResult = new System.Windows.Forms.Label();
            this.lblApplicationIDResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblStatusOfScreen = new System.Windows.Forms.Label();
            this.ctrlFindPersonAndPersonDetails1 = new PresentationLayer.ctrlFindPersonAndPersonDetails();
            this.tabControl1.SuspendLayout();
            this.tapPersonalInfo.SuspendLayout();
            this.tapApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tapPersonalInfo);
            this.tabControl1.Controls.Add(this.tapApplicationInfo);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tabControl1.Location = new System.Drawing.Point(12, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(811, 454);
            this.tabControl1.TabIndex = 0;
            // 
            // tapPersonalInfo
            // 
            this.tapPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tapPersonalInfo.Controls.Add(this.button1);
            this.tapPersonalInfo.Controls.Add(this.ctrlFindPersonAndPersonDetails1);
            this.tapPersonalInfo.Location = new System.Drawing.Point(4, 26);
            this.tapPersonalInfo.Name = "tapPersonalInfo";
            this.tapPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapPersonalInfo.Size = new System.Drawing.Size(803, 424);
            this.tapPersonalInfo.TabIndex = 0;
            this.tapPersonalInfo.Text = "Personal Info";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(655, 355);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tapApplicationInfo
            // 
            this.tapApplicationInfo.BackColor = System.Drawing.Color.White;
            this.tapApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tapApplicationInfo.Controls.Add(this.label6);
            this.tapApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tapApplicationInfo.Controls.Add(this.label4);
            this.tapApplicationInfo.Controls.Add(this.cbLicenseClass);
            this.tapApplicationInfo.Controls.Add(this.label3);
            this.tapApplicationInfo.Controls.Add(this.lblApplicationDateResult);
            this.tapApplicationInfo.Controls.Add(this.lblApplicationIDResult);
            this.tapApplicationInfo.Controls.Add(this.label2);
            this.tapApplicationInfo.Controls.Add(this.label1);
            this.tapApplicationInfo.Location = new System.Drawing.Point(4, 26);
            this.tapApplicationInfo.Name = "tapApplicationInfo";
            this.tapApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tapApplicationInfo.Size = new System.Drawing.Size(496, 424);
            this.tapApplicationInfo.TabIndex = 1;
            this.tapApplicationInfo.Text = "Application Info";
            this.tapApplicationInfo.Click += new System.EventHandler(this.tapApplicationInfo_Click);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCreatedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCreatedBy.Location = new System.Drawing.Point(170, 205);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(26, 17);
            this.lblCreatedBy.TabIndex = 9;
            this.lblCreatedBy.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label6.Location = new System.Drawing.Point(40, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Created By :";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApplicationFees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblApplicationFees.Location = new System.Drawing.Point(170, 165);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(22, 17);
            this.lblApplicationFees.TabIndex = 7;
            this.lblApplicationFees.Text = "15";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label4.Location = new System.Drawing.Point(40, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Application Fees :";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenseClass.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(170, 122);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(260, 25);
            this.cbLicenseClass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label3.Location = new System.Drawing.Point(40, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "License Class :";
            // 
            // lblApplicationDateResult
            // 
            this.lblApplicationDateResult.AutoSize = true;
            this.lblApplicationDateResult.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApplicationDateResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblApplicationDateResult.Location = new System.Drawing.Point(170, 85);
            this.lblApplicationDateResult.Name = "lblApplicationDateResult";
            this.lblApplicationDateResult.Size = new System.Drawing.Size(26, 17);
            this.lblApplicationDateResult.TabIndex = 3;
            this.lblApplicationDateResult.Text = "???";
            // 
            // lblApplicationIDResult
            // 
            this.lblApplicationIDResult.AutoSize = true;
            this.lblApplicationIDResult.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblApplicationIDResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblApplicationIDResult.Location = new System.Drawing.Point(170, 45);
            this.lblApplicationIDResult.Name = "lblApplicationIDResult";
            this.lblApplicationIDResult.Size = new System.Drawing.Size(26, 17);
            this.lblApplicationIDResult.TabIndex = 2;
            this.lblApplicationIDResult.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(40, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(40, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application ID :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.button2.Location = new System.Drawing.Point(566, 545);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(657, 545);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Save";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblStatusOfScreen
            // 
            this.lblStatusOfScreen.AutoSize = true;
            this.lblStatusOfScreen.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatusOfScreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblStatusOfScreen.Location = new System.Drawing.Point(194, 9);
            this.lblStatusOfScreen.Name = "lblStatusOfScreen";
            this.lblStatusOfScreen.Size = new System.Drawing.Size(443, 41);
            this.lblStatusOfScreen.TabIndex = 4;
            this.lblStatusOfScreen.Text = "New Local License Application";
            // 
            // ctrlFindPersonAndPersonDetails1
            // 
            this.ctrlFindPersonAndPersonDetails1.BackColor = System.Drawing.Color.White;
            this.ctrlFindPersonAndPersonDetails1.Location = new System.Drawing.Point(6, 3);
            this.ctrlFindPersonAndPersonDetails1.Name = "ctrlFindPersonAndPersonDetails1";
            this.ctrlFindPersonAndPersonDetails1.Size = new System.Drawing.Size(796, 415);
            this.ctrlFindPersonAndPersonDetails1.TabIndex = 0;
            this.ctrlFindPersonAndPersonDetails1.Load += new System.EventHandler(this.ctrlFindPersonAndPersonDetails1_Load);
            // 
            // frmNewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 587);
            this.Controls.Add(this.lblStatusOfScreen);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmNewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Local Driving License";
            this.Load += new System.EventHandler(this.frmNewLocalDrivingLicense_Load);
            this.tabControl1.ResumeLayout(false);
            this.tapPersonalInfo.ResumeLayout(false);
            this.tapApplicationInfo.ResumeLayout(false);
            this.tapApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tapPersonalInfo;
        private System.Windows.Forms.Button button1;
        private PresentationLayer.ctrlFindPersonAndPersonDetails ctrlFindPersonAndPersonDetails1;
        private System.Windows.Forms.TabPage tapApplicationInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApplicationDateResult;
        private System.Windows.Forms.Label lblApplicationIDResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblStatusOfScreen;
    }
}