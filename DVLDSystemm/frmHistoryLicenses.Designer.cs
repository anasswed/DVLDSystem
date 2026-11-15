namespace PresentationLayer
{
    partial class frmHistoryLicenses
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlFindPersonAndPersonDetails1 = new PresentationLayer.ctrlFindPersonAndPersonDetails();
            this.ctrlListDriverLicenses1 = new PresentationLayer.ctrlListDriverLicenses();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.button1.Location = new System.Drawing.Point(595, 701);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(260, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "License History";
            // 
            // ctrlFindPersonAndPersonDetails1
            // 
            this.ctrlFindPersonAndPersonDetails1.BackColor = System.Drawing.Color.White;
            this.ctrlFindPersonAndPersonDetails1.Location = new System.Drawing.Point(65, 65);
            this.ctrlFindPersonAndPersonDetails1.Name = "ctrlFindPersonAndPersonDetails1";
            this.ctrlFindPersonAndPersonDetails1.Size = new System.Drawing.Size(681, 316);
            this.ctrlFindPersonAndPersonDetails1.TabIndex = 4;
            // 
            // ctrlListDriverLicenses1
            // 
            this.ctrlListDriverLicenses1.BackColor = System.Drawing.Color.White;
            this.ctrlListDriverLicenses1.Location = new System.Drawing.Point(30, 390);
            this.ctrlListDriverLicenses1.Name = "ctrlListDriverLicenses1";
            this.ctrlListDriverLicenses1.Size = new System.Drawing.Size(650, 305);
            this.ctrlListDriverLicenses1.TabIndex = 5;
            // 
            // frmHistoryLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(786, 743);
            this.Controls.Add(this.ctrlListDriverLicenses1);
            this.Controls.Add(this.ctrlFindPersonAndPersonDetails1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "frmHistoryLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmHistoryLicenses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private PresentationLayer.ctrlFindPersonAndPersonDetails ctrlFindPersonAndPersonDetails1;
        private ctrlListDriverLicenses ctrlListDriverLicenses1;
    }
}