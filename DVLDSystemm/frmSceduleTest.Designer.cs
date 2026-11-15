namespace PresentationLayer
{
    partial class frmSceduleTest
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
            this.ctrlSceduleTest2 = new PresentationLayer.ctrlSceduleTest();
            this.ctrlSceduleTest1 = new PresentationLayer.ctrlSceduleTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlSceduleTest2
            // 
            this.ctrlSceduleTest2._Mode = PresentationLayer.ctrlSceduleTest.enMode.AddAppointment;
            this.ctrlSceduleTest2.BackColor = System.Drawing.Color.White;
            this.ctrlSceduleTest2.IsFailed = false;
            this.ctrlSceduleTest2.Location = new System.Drawing.Point(30, 15);
            this.ctrlSceduleTest2.Name = "ctrlSceduleTest2";
            this.ctrlSceduleTest2.Size = new System.Drawing.Size(435, 450);
            this.ctrlSceduleTest2.TabIndex = 1;
            this.ctrlSceduleTest2.Load += new System.EventHandler(this.ctrlSceduleTest2_Load);
            // 
            // ctrlSceduleTest1
            // 
            this.ctrlSceduleTest1._Mode = PresentationLayer.ctrlSceduleTest.enMode.AddAppointment;
            this.ctrlSceduleTest1.BackColor = System.Drawing.Color.White;
            this.ctrlSceduleTest1.IsFailed = false;
            this.ctrlSceduleTest1.Location = new System.Drawing.Point(0, 0);
            this.ctrlSceduleTest1.Name = "ctrlSceduleTest1";
            this.ctrlSceduleTest1.Size = new System.Drawing.Size(0, 0);
            this.ctrlSceduleTest1.TabIndex = 0;
            this.ctrlSceduleTest1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnClose.Location = new System.Drawing.Point(285, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 32);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(380, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmSceduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 525);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlSceduleTest2);
            this.Controls.Add(this.ctrlSceduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSceduleTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmSceduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PresentationLayer.ctrlSceduleTest ctrlSceduleTest1;
        private ctrlSceduleTest ctrlSceduleTest2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}