namespace RenameGUI
{
    partial class frmMain
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
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNumFormat = new System.Windows.Forms.ComboBox();
            this.btnPadZero = new System.Windows.Forms.Button();
            this.txtStringOld = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStringNew = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStringReplace = new System.Windows.Forms.Button();
            this.cbApplyDir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(149, 20);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(569, 22);
            this.txtFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Source Folder";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delete string from";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(144, 66);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(175, 22);
            this.txtStart.TabIndex = 3;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(144, 111);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(175, 22);
            this.txtEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(18, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Until string";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(435, 66);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(203, 72);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Choose Number format";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbNumFormat
            // 
            this.cbNumFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNumFormat.FormattingEnabled = true;
            this.cbNumFormat.Location = new System.Drawing.Point(173, 191);
            this.cbNumFormat.Name = "cbNumFormat";
            this.cbNumFormat.Size = new System.Drawing.Size(189, 24);
            this.cbNumFormat.TabIndex = 8;
            // 
            // btnPadZero
            // 
            this.btnPadZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPadZero.Location = new System.Drawing.Point(435, 159);
            this.btnPadZero.Name = "btnPadZero";
            this.btnPadZero.Size = new System.Drawing.Size(203, 72);
            this.btnPadZero.TabIndex = 9;
            this.btnPadZero.Text = "Pad Zero";
            this.btnPadZero.UseVisualStyleBackColor = true;
            this.btnPadZero.Click += new System.EventHandler(this.btnPadZero_Click);
            // 
            // txtStringOld
            // 
            this.txtStringOld.Location = new System.Drawing.Point(144, 257);
            this.txtStringOld.Name = "txtStringOld";
            this.txtStringOld.Size = new System.Drawing.Size(175, 22);
            this.txtStringOld.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "String to Replace";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtStringNew
            // 
            this.txtStringNew.Location = new System.Drawing.Point(144, 295);
            this.txtStringNew.Name = "txtStringNew";
            this.txtStringNew.Size = new System.Drawing.Size(175, 22);
            this.txtStringNew.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "New String";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnStringReplace
            // 
            this.btnStringReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStringReplace.Location = new System.Drawing.Point(435, 257);
            this.btnStringReplace.Name = "btnStringReplace";
            this.btnStringReplace.Size = new System.Drawing.Size(203, 72);
            this.btnStringReplace.TabIndex = 14;
            this.btnStringReplace.Text = "Replace";
            this.btnStringReplace.UseVisualStyleBackColor = true;
            this.btnStringReplace.Click += new System.EventHandler(this.btnStringReplace_Click);
            // 
            // cbApplyDir
            // 
            this.cbApplyDir.AutoSize = true;
            this.cbApplyDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbApplyDir.Location = new System.Drawing.Point(12, 366);
            this.cbApplyDir.Name = "cbApplyDir";
            this.cbApplyDir.Size = new System.Drawing.Size(223, 33);
            this.cbApplyDir.TabIndex = 15;
            this.cbApplyDir.Text = "Apply to Directory";
            this.cbApplyDir.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 463);
            this.Controls.Add(this.cbApplyDir);
            this.Controls.Add(this.btnStringReplace);
            this.Controls.Add(this.txtStringNew);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStringOld);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPadZero);
            this.Controls.Add(this.cbNumFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolder);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNumFormat;
        private System.Windows.Forms.Button btnPadZero;
        private System.Windows.Forms.TextBox txtStringOld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStringNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStringReplace;
        private System.Windows.Forms.CheckBox cbApplyDir;
    }
}

