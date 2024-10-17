
namespace DESKTOP_II__01_
{
    partial class AddQuiz
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQn = new System.Windows.Forms.TextBox();
            this.txtQd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvQ = new System.Windows.Forms.DataGridView();
            this.btnA = new System.Windows.Forms.Button();
            this.txtOd = new System.Windows.Forms.TextBox();
            this.txtOc = new System.Windows.Forms.TextBox();
            this.txtOb = new System.Windows.Forms.TextBox();
            this.txtOa = new System.Windows.Forms.TextBox();
            this.Od = new System.Windows.Forms.RadioButton();
            this.Oc = new System.Windows.Forms.RadioButton();
            this.Ob = new System.Windows.Forms.RadioButton();
            this.Oa = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnC = new System.Windows.Forms.Button();
            this.btnS = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQ)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Quiz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Footlight MT Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fill in the quiz data below";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quiz Name";
            // 
            // txtQn
            // 
            this.txtQn.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQn.Location = new System.Drawing.Point(17, 85);
            this.txtQn.Name = "txtQn";
            this.txtQn.Size = new System.Drawing.Size(288, 23);
            this.txtQn.TabIndex = 3;
            this.txtQn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQn_KeyPress);
            // 
            // txtQd
            // 
            this.txtQd.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQd.Location = new System.Drawing.Point(318, 85);
            this.txtQd.Multiline = true;
            this.txtQd.Name = "txtQd";
            this.txtQd.Size = new System.Drawing.Size(470, 72);
            this.txtQd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(315, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quiz Description";
            // 
            // txtQc
            // 
            this.txtQc.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQc.Location = new System.Drawing.Point(17, 134);
            this.txtQc.MaxLength = 15;
            this.txtQc.Name = "txtQc";
            this.txtQc.Size = new System.Drawing.Size(288, 23);
            this.txtQc.TabIndex = 7;
            this.txtQc.TextChanged += new System.EventHandler(this.txtQc_TextChanged);
            this.txtQc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQc_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Quiz Code";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvQ);
            this.groupBox1.Controls.Add(this.btnA);
            this.groupBox1.Controls.Add(this.txtOd);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.txtOb);
            this.groupBox1.Controls.Add(this.txtOa);
            this.groupBox1.Controls.Add(this.Od);
            this.groupBox1.Controls.Add(this.Oc);
            this.groupBox1.Controls.Add(this.Ob);
            this.groupBox1.Controls.Add(this.Oa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtQ);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(17, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 357);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question Data";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvQ
            // 
            this.dgvQ.AllowUserToAddRows = false;
            this.dgvQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQ.Location = new System.Drawing.Point(15, 180);
            this.dgvQ.Name = "dgvQ";
            this.dgvQ.Size = new System.Drawing.Size(750, 167);
            this.dgvQ.TabIndex = 16;
            this.dgvQ.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQ_CellClick);
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.White;
            this.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.Location = new System.Drawing.Point(577, 40);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(116, 23);
            this.btnA.TabIndex = 15;
            this.btnA.Text = "Add Question";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // txtOd
            // 
            this.txtOd.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOd.Location = new System.Drawing.Point(347, 136);
            this.txtOd.Name = "txtOd";
            this.txtOd.Size = new System.Drawing.Size(200, 23);
            this.txtOd.TabIndex = 14;
            // 
            // txtOc
            // 
            this.txtOc.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOc.Location = new System.Drawing.Point(347, 104);
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(200, 23);
            this.txtOc.TabIndex = 13;
            // 
            // txtOb
            // 
            this.txtOb.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOb.Location = new System.Drawing.Point(347, 72);
            this.txtOb.Name = "txtOb";
            this.txtOb.Size = new System.Drawing.Size(200, 23);
            this.txtOb.TabIndex = 12;
            // 
            // txtOa
            // 
            this.txtOa.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOa.Location = new System.Drawing.Point(347, 40);
            this.txtOa.Name = "txtOa";
            this.txtOa.Size = new System.Drawing.Size(200, 23);
            this.txtOa.TabIndex = 9;
            // 
            // Od
            // 
            this.Od.AutoSize = true;
            this.Od.Location = new System.Drawing.Point(327, 140);
            this.Od.Name = "Od";
            this.Od.Size = new System.Drawing.Size(14, 13);
            this.Od.TabIndex = 4;
            this.Od.TabStop = true;
            this.Od.UseVisualStyleBackColor = true;
            // 
            // Oc
            // 
            this.Oc.AutoSize = true;
            this.Oc.Location = new System.Drawing.Point(327, 108);
            this.Oc.Name = "Oc";
            this.Oc.Size = new System.Drawing.Size(14, 13);
            this.Oc.TabIndex = 3;
            this.Oc.TabStop = true;
            this.Oc.UseVisualStyleBackColor = true;
            // 
            // Ob
            // 
            this.Ob.AutoSize = true;
            this.Ob.Location = new System.Drawing.Point(327, 76);
            this.Ob.Name = "Ob";
            this.Ob.Size = new System.Drawing.Size(14, 13);
            this.Ob.TabIndex = 2;
            this.Ob.TabStop = true;
            this.Ob.UseVisualStyleBackColor = true;
            // 
            // Oa
            // 
            this.Oa.AutoSize = true;
            this.Oa.Location = new System.Drawing.Point(327, 45);
            this.Oa.Name = "Oa";
            this.Oa.Size = new System.Drawing.Size(14, 13);
            this.Oa.TabIndex = 1;
            this.Oa.TabStop = true;
            this.Oa.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(324, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Answer";
            // 
            // txtQ
            // 
            this.txtQ.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQ.Location = new System.Drawing.Point(15, 40);
            this.txtQ.Multiline = true;
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(289, 119);
            this.txtQ.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Question";
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.White;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.Location = new System.Drawing.Point(687, 540);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(95, 23);
            this.btnC.TabIndex = 17;
            this.btnC.Text = "Cancel";
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.btnC_Click);
            // 
            // btnS
            // 
            this.btnS.BackColor = System.Drawing.Color.White;
            this.btnS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnS.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnS.Location = new System.Drawing.Point(591, 540);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(90, 23);
            this.btnS.TabIndex = 18;
            this.btnS.Text = "Save";
            this.btnS.UseVisualStyleBackColor = false;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // AddQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtQc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtQd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddQuiz";
            this.Text = "AddQuiz";
            this.Load += new System.EventHandler(this.AddQuiz_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQn;
        private System.Windows.Forms.TextBox txtQd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvQ;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.TextBox txtOd;
        private System.Windows.Forms.TextBox txtOc;
        private System.Windows.Forms.TextBox txtOb;
        private System.Windows.Forms.TextBox txtOa;
        private System.Windows.Forms.RadioButton Od;
        private System.Windows.Forms.RadioButton Oc;
        private System.Windows.Forms.RadioButton Ob;
        private System.Windows.Forms.RadioButton Oa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnS;
    }
}