namespace Items_Move_Store
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Execute = new System.Windows.Forms.Button();
            this.textBox_File_Kiniseis = new System.Windows.Forms.TextBox();
            this.button_kiniseis_file = new System.Windows.Forms.Button();
            this.textBox_File_Katastima = new System.Windows.Forms.TextBox();
            this.button_katastimata_file = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_Execute);
            this.panel1.Controls.Add(this.textBox_File_Kiniseis);
            this.panel1.Controls.Add(this.button_kiniseis_file);
            this.panel1.Controls.Add(this.textBox_File_Katastima);
            this.panel1.Controls.Add(this.button_katastimata_file);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 333);
            this.panel1.TabIndex = 0;
            // 
            // button_Execute
            // 
            this.button_Execute.BackColor = System.Drawing.Color.PaleGreen;
            this.button_Execute.Location = new System.Drawing.Point(482, 288);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(116, 23);
            this.button_Execute.TabIndex = 4;
            this.button_Execute.Text = "Εκτέλεση";
            this.button_Execute.UseVisualStyleBackColor = false;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // textBox_File_Kiniseis
            // 
            this.textBox_File_Kiniseis.Location = new System.Drawing.Point(258, 73);
            this.textBox_File_Kiniseis.Name = "textBox_File_Kiniseis";
            this.textBox_File_Kiniseis.ReadOnly = true;
            this.textBox_File_Kiniseis.Size = new System.Drawing.Size(340, 20);
            this.textBox_File_Kiniseis.TabIndex = 3;
            // 
            // button_kiniseis_file
            // 
            this.button_kiniseis_file.Location = new System.Drawing.Point(28, 71);
            this.button_kiniseis_file.Name = "button_kiniseis_file";
            this.button_kiniseis_file.Size = new System.Drawing.Size(192, 23);
            this.button_kiniseis_file.TabIndex = 2;
            this.button_kiniseis_file.Text = "Επιλογή αρχείου Κινήσεων";
            this.button_kiniseis_file.UseVisualStyleBackColor = true;
            this.button_kiniseis_file.Click += new System.EventHandler(this.button_kiniseis_file_Click);
            // 
            // textBox_File_Katastima
            // 
            this.textBox_File_Katastima.Location = new System.Drawing.Point(258, 33);
            this.textBox_File_Katastima.Name = "textBox_File_Katastima";
            this.textBox_File_Katastima.ReadOnly = true;
            this.textBox_File_Katastima.Size = new System.Drawing.Size(340, 20);
            this.textBox_File_Katastima.TabIndex = 1;
            // 
            // button_katastimata_file
            // 
            this.button_katastimata_file.Location = new System.Drawing.Point(28, 31);
            this.button_katastimata_file.Name = "button_katastimata_file";
            this.button_katastimata_file.Size = new System.Drawing.Size(192, 23);
            this.button_katastimata_file.TabIndex = 0;
            this.button_katastimata_file.Text = "Επιλογή αρχείου Καταστημάτων";
            this.button_katastimata_file.UseVisualStyleBackColor = true;
            this.button_katastimata_file.Click += new System.EventHandler(this.button_katastimata_file_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 388);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_katastimata_file;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_File_Katastima;
        private System.Windows.Forms.TextBox textBox_File_Kiniseis;
        private System.Windows.Forms.Button button_kiniseis_file;
        private System.Windows.Forms.Button button_Execute;
    }
}

