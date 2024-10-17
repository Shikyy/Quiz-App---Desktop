
namespace DESKTOP_II__01_
{
    partial class QuizReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbQ = new System.Windows.Forms.ComboBox();
            this.lblAverageTimeTaken = new System.Windows.Forms.Label();
            this.lblAveragePercentage = new System.Windows.Forms.Label();
            this.lblTotalParticipant = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvR = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "View Quiz Report";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quiz";
            // 
            // cmbQ
            // 
            this.cmbQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQ.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQ.FormattingEnabled = true;
            this.cmbQ.Location = new System.Drawing.Point(66, 51);
            this.cmbQ.Name = "cmbQ";
            this.cmbQ.Size = new System.Drawing.Size(199, 23);
            this.cmbQ.TabIndex = 4;
            this.cmbQ.SelectedIndexChanged += new System.EventHandler(this.cmbQ_SelectedIndexChanged);
            // 
            // lblAverageTimeTaken
            // 
            this.lblAverageTimeTaken.AutoSize = true;
            this.lblAverageTimeTaken.Location = new System.Drawing.Point(290, 55);
            this.lblAverageTimeTaken.Name = "lblAverageTimeTaken";
            this.lblAverageTimeTaken.Size = new System.Drawing.Size(107, 13);
            this.lblAverageTimeTaken.TabIndex = 5;
            this.lblAverageTimeTaken.Text = "Average Time Taken";
            // 
            // lblAveragePercentage
            // 
            this.lblAveragePercentage.AutoSize = true;
            this.lblAveragePercentage.Location = new System.Drawing.Point(290, 80);
            this.lblAveragePercentage.Name = "lblAveragePercentage";
            this.lblAveragePercentage.Size = new System.Drawing.Size(142, 13);
            this.lblAveragePercentage.TabIndex = 6;
            this.lblAveragePercentage.Text = "Average Correct Percentage";
            // 
            // lblTotalParticipant
            // 
            this.lblTotalParticipant.AutoSize = true;
            this.lblTotalParticipant.Location = new System.Drawing.Point(290, 105);
            this.lblTotalParticipant.Name = "lblTotalParticipant";
            this.lblTotalParticipant.Size = new System.Drawing.Size(84, 13);
            this.lblTotalParticipant.TabIndex = 7;
            this.lblTotalParticipant.Text = "Total Participant";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvR);
            this.groupBox1.Location = new System.Drawing.Point(17, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 305);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail Data";
            // 
            // dgvR
            // 
            this.dgvR.AllowUserToAddRows = false;
            this.dgvR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR.Location = new System.Drawing.Point(8, 23);
            this.dgvR.Name = "dgvR";
            this.dgvR.Size = new System.Drawing.Size(577, 269);
            this.dgvR.TabIndex = 0;
            // 
            // QuizReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalParticipant);
            this.Controls.Add(this.lblAveragePercentage);
            this.Controls.Add(this.lblAverageTimeTaken);
            this.Controls.Add(this.cmbQ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuizReport";
            this.Text = "QuizReport";
            this.Load += new System.EventHandler(this.QuizReport_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbQ;
        private System.Windows.Forms.Label lblAverageTimeTaken;
        private System.Windows.Forms.Label lblAveragePercentage;
        private System.Windows.Forms.Label lblTotalParticipant;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvR;
    }
}