namespace PresentationLayer
{
    partial class ctrlSceduleTest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.lblWarningMessage = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.gbRetakeTestInfo = new System.Windows.Forms.GroupBox();
            this.lblRetakeTestAppIDResult = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalFeesResult = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRetakeAppFeesResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFeesResult = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTrialResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNameResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLicenseClassNameResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLDLAppIDResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblScheduleTestOrRetakeTest = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.gbTestInfo.SuspendLayout();
            this.gbRetakeTestInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.lblWarningMessage);
            this.gbTestInfo.Controls.Add(this.dateTimePicker1);
            this.gbTestInfo.Controls.Add(this.gbRetakeTestInfo);
            this.gbTestInfo.Controls.Add(this.lblFeesResult);
            this.gbTestInfo.Controls.Add(this.label8);
            this.gbTestInfo.Controls.Add(this.label6);
            this.gbTestInfo.Controls.Add(this.lblTrialResult);
            this.gbTestInfo.Controls.Add(this.label5);
            this.gbTestInfo.Controls.Add(this.lblNameResult);
            this.gbTestInfo.Controls.Add(this.label4);
            this.gbTestInfo.Controls.Add(this.lblLicenseClassNameResult);
            this.gbTestInfo.Controls.Add(this.label3);
            this.gbTestInfo.Controls.Add(this.lblLDLAppIDResult);
            this.gbTestInfo.Controls.Add(this.label2);
            this.gbTestInfo.Controls.Add(this.lblScheduleTestOrRetakeTest);
            this.gbTestInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbTestInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbTestInfo.Location = new System.Drawing.Point(5, 5);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(425, 440);
            this.gbTestInfo.TabIndex = 0;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "Vision Test";
            this.gbTestInfo.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblScheduleTestOrRetakeTest
            // 
            this.lblScheduleTestOrRetakeTest.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblScheduleTestOrRetakeTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblScheduleTestOrRetakeTest.Location = new System.Drawing.Point(10, 22);
            this.lblScheduleTestOrRetakeTest.Name = "lblScheduleTestOrRetakeTest";
            this.lblScheduleTestOrRetakeTest.Size = new System.Drawing.Size(405, 32);
            this.lblScheduleTestOrRetakeTest.TabIndex = 0;
            this.lblScheduleTestOrRetakeTest.Text = "Schedule Test";
            this.lblScheduleTestOrRetakeTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWarningMessage
            // 
            this.lblWarningMessage.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblWarningMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblWarningMessage.Location = new System.Drawing.Point(10, 56);
            this.lblWarningMessage.Name = "lblWarningMessage";
            this.lblWarningMessage.Size = new System.Drawing.Size(405, 18);
            this.lblWarningMessage.TabIndex = 15;
            this.lblWarningMessage.Text = "Person already sat for the test, appointment is locked";
            this.lblWarningMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarningMessage.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "L.D.L.AppID :";
            // 
            // lblLDLAppIDResult
            // 
            this.lblLDLAppIDResult.AutoSize = true;
            this.lblLDLAppIDResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLDLAppIDResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLDLAppIDResult.Location = new System.Drawing.Point(135, 82);
            this.lblLDLAppIDResult.Name = "lblLDLAppIDResult";
            this.lblLDLAppIDResult.Size = new System.Drawing.Size(26, 17);
            this.lblLDLAppIDResult.TabIndex = 2;
            this.lblLDLAppIDResult.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "D.L.Class Name :";
            // 
            // lblLicenseClassNameResult
            // 
            this.lblLicenseClassNameResult.AutoSize = true;
            this.lblLicenseClassNameResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLicenseClassNameResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLicenseClassNameResult.Location = new System.Drawing.Point(135, 110);
            this.lblLicenseClassNameResult.Name = "lblLicenseClassNameResult";
            this.lblLicenseClassNameResult.Size = new System.Drawing.Size(26, 17);
            this.lblLicenseClassNameResult.TabIndex = 4;
            this.lblLicenseClassNameResult.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(15, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name :";
            // 
            // lblNameResult
            // 
            this.lblNameResult.AutoSize = true;
            this.lblNameResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNameResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblNameResult.Location = new System.Drawing.Point(135, 138);
            this.lblNameResult.Name = "lblNameResult";
            this.lblNameResult.Size = new System.Drawing.Size(26, 17);
            this.lblNameResult.TabIndex = 6;
            this.lblNameResult.Text = "???";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(15, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Trial :";
            // 
            // lblTrialResult
            // 
            this.lblTrialResult.AutoSize = true;
            this.lblTrialResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTrialResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTrialResult.Location = new System.Drawing.Point(135, 166);
            this.lblTrialResult.Name = "lblTrialResult";
            this.lblTrialResult.Size = new System.Drawing.Size(26, 17);
            this.lblTrialResult.TabIndex = 8;
            this.lblTrialResult.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(15, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(135, 191);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 24);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(15, 224);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Fees :";
            // 
            // lblFeesResult
            // 
            this.lblFeesResult.AutoSize = true;
            this.lblFeesResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFeesResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFeesResult.Location = new System.Drawing.Point(135, 224);
            this.lblFeesResult.Name = "lblFeesResult";
            this.lblFeesResult.Size = new System.Drawing.Size(26, 17);
            this.lblFeesResult.TabIndex = 12;
            this.lblFeesResult.Text = "???";
            // 
            // gbRetakeTestInfo
            // 
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeTestAppIDResult);
            this.gbRetakeTestInfo.Controls.Add(this.label11);
            this.gbRetakeTestInfo.Controls.Add(this.lblTotalFeesResult);
            this.gbRetakeTestInfo.Controls.Add(this.label10);
            this.gbRetakeTestInfo.Controls.Add(this.lblRetakeAppFeesResult);
            this.gbRetakeTestInfo.Controls.Add(this.label9);
            this.gbRetakeTestInfo.Enabled = false;
            this.gbRetakeTestInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gbRetakeTestInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.gbRetakeTestInfo.Location = new System.Drawing.Point(12, 260);
            this.gbRetakeTestInfo.Name = "gbRetakeTestInfo";
            this.gbRetakeTestInfo.Size = new System.Drawing.Size(400, 165);
            this.gbRetakeTestInfo.TabIndex = 13;
            this.gbRetakeTestInfo.TabStop = false;
            this.gbRetakeTestInfo.Text = "Retake Test Info";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(15, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "R.App Fees :";
            // 
            // lblRetakeAppFeesResult
            // 
            this.lblRetakeAppFeesResult.AutoSize = true;
            this.lblRetakeAppFeesResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRetakeAppFeesResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRetakeAppFeesResult.Location = new System.Drawing.Point(135, 35);
            this.lblRetakeAppFeesResult.Name = "lblRetakeAppFeesResult";
            this.lblRetakeAppFeesResult.Size = new System.Drawing.Size(15, 17);
            this.lblRetakeAppFeesResult.TabIndex = 7;
            this.lblRetakeAppFeesResult.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(15, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 14;
            this.label11.Text = "R.Test App ID :";
            // 
            // lblRetakeTestAppIDResult
            // 
            this.lblRetakeTestAppIDResult.AutoSize = true;
            this.lblRetakeTestAppIDResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRetakeTestAppIDResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRetakeTestAppIDResult.Location = new System.Drawing.Point(135, 75);
            this.lblRetakeTestAppIDResult.Name = "lblRetakeTestAppIDResult";
            this.lblRetakeTestAppIDResult.Size = new System.Drawing.Size(26, 17);
            this.lblRetakeTestAppIDResult.TabIndex = 15;
            this.lblRetakeTestAppIDResult.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(15, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Total Fees :";
            // 
            // lblTotalFeesResult
            // 
            this.lblTotalFeesResult.AutoSize = true;
            this.lblTotalFeesResult.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTotalFeesResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTotalFeesResult.Location = new System.Drawing.Point(135, 115);
            this.lblTotalFeesResult.Name = "lblTotalFeesResult";
            this.lblTotalFeesResult.Size = new System.Drawing.Size(26, 17);
            this.lblTotalFeesResult.TabIndex = 13;
            this.lblTotalFeesResult.Text = "???";
            // 
            // ctrlSceduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbTestInfo);
            this.Name = "ctrlSceduleTest";
            this.Size = new System.Drawing.Size(435, 450);
            this.Load += new System.EventHandler(this.ctrlSceduleTest_Load);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.gbRetakeTestInfo.ResumeLayout(false);
            this.gbRetakeTestInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblScheduleTestOrRetakeTest;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblFeesResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTrialResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNameResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLicenseClassNameResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLDLAppIDResult;
        private System.Windows.Forms.GroupBox gbRetakeTestInfo;
        private System.Windows.Forms.Label lblRetakeTestAppIDResult;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTotalFeesResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRetakeAppFeesResult;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblWarningMessage;
    }
}