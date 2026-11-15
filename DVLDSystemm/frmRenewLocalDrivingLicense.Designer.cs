namespace PresentationLayer
{
    partial class frmRenewLocalDrivingLicense
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
            this.llShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRenew = new System.Windows.Forms.Button();
            this.ctrlLicenseInfo1 = new PresentationLayer.ctrlLicenseInfo();
            this.ctrlSearchOnInternattionalLicense1 = new PresentationLayer.ctrlSearchOnInternattionalLicense();
            this.ctrlApplicationNewLicenseInfo1 = new PresentationLayer.ctrlApplicationNewLicenseInfo();
            this.SuspendLayout();
            // 
            // llShowLicenseHistory
            // 
            this.llShowLicenseHistory.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.llShowLicenseHistory.AutoSize = true;
            this.llShowLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.llShowLicenseHistory.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.llShowLicenseHistory.Location = new System.Drawing.Point(20, 580);
            this.llShowLicenseHistory.Name = "llShowLicenseHistory";
            this.llShowLicenseHistory.Size = new System.Drawing.Size(140, 17);
            this.llShowLicenseHistory.TabIndex = 4;
            this.llShowLicenseHistory.TabStop = true;
            this.llShowLicenseHistory.Text = "Show License History";
            this.llShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llShowLicenseHistory_LinkClicked);
            // 
            // llNewLicenseInfo
            // 
            this.llNewLicenseInfo.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.llNewLicenseInfo.AutoSize = true;
            this.llNewLicenseInfo.Enabled = false;
            this.llNewLicenseInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.llNewLicenseInfo.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.llNewLicenseInfo.Location = new System.Drawing.Point(175, 580);
            this.llNewLicenseInfo.Name = "llNewLicenseInfo";
            this.llNewLicenseInfo.Size = new System.Drawing.Size(150, 17);
            this.llNewLicenseInfo.TabIndex = 5;
            this.llNewLicenseInfo.TabStop = true;
            this.llNewLicenseInfo.Text = "Show New License Info";
            this.llNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llNewLicenseInfo_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.button1.Location = new System.Drawing.Point(465, 575);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRenew
            // 
            this.btnRenew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnRenew.Enabled = false;
            this.btnRenew.FlatAppearance.BorderSize = 0;
            this.btnRenew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenew.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRenew.ForeColor = System.Drawing.Color.White;
            this.btnRenew.Location = new System.Drawing.Point(560, 575);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(85, 30);
            this.btnRenew.TabIndex = 7;
            this.btnRenew.Text = "Renew";
            this.btnRenew.UseVisualStyleBackColor = false;
            this.btnRenew.Click += new System.EventHandler(this.button2_Click);
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(15, 80);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(656, 250);
            this.ctrlLicenseInfo1.TabIndex = 3;
            // 
            // ctrlSearchOnInternattionalLicense1
            // 
            this.ctrlSearchOnInternattionalLicense1.BackColor = System.Drawing.Color.White;
            this.ctrlSearchOnInternattionalLicense1.Location = new System.Drawing.Point(23, 0);
            this.ctrlSearchOnInternattionalLicense1.Name = "ctrlSearchOnInternattionalLicense1";
            this.ctrlSearchOnInternattionalLicense1.Size = new System.Drawing.Size(449, 80);
            this.ctrlSearchOnInternattionalLicense1.TabIndex = 2;
            // 
            // ctrlApplicationNewLicenseInfo1
            // 
            this.ctrlApplicationNewLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlApplicationNewLicenseInfo1.Location = new System.Drawing.Point(15, 335);
            this.ctrlApplicationNewLicenseInfo1.Name = "ctrlApplicationNewLicenseInfo1";
            this.ctrlApplicationNewLicenseInfo1.Size = new System.Drawing.Size(630, 230);
            this.ctrlApplicationNewLicenseInfo1.TabIndex = 0;
            // 
            // frmRenewLocalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(696, 620);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.llNewLicenseInfo);
            this.Controls.Add(this.llShowLicenseHistory);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Controls.Add(this.ctrlSearchOnInternattionalLicense1);
            this.Controls.Add(this.ctrlApplicationNewLicenseInfo1);
            this.Name = "frmRenewLocalDrivingLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local Driving License";
            this.Load += new System.EventHandler(this.frmRenewLocalDrivingLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PresentationLayer.ctrlApplicationNewLicenseInfo ctrlApplicationNewLicenseInfo1;
        private PresentationLayer.ctrlSearchOnInternattionalLicense ctrlSearchOnInternattionalLicense1;
        private PresentationLayer.ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.LinkLabel llShowLicenseHistory;
        private System.Windows.Forms.LinkLabel llNewLicenseInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRenew;
    }
}