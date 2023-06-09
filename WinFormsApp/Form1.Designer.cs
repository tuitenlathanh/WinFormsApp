namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DocFile = new Button();
            GhiFile = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // DocFile
            // 
            DocFile.Location = new Point(160, 389);
            DocFile.Name = "DocFile";
            DocFile.Size = new Size(94, 29);
            DocFile.TabIndex = 0;
            DocFile.Text = "Upload";
            DocFile.UseVisualStyleBackColor = true;
            DocFile.Click += DocFile_Click;
            // 
            // GhiFile
            // 
            GhiFile.Location = new Point(408, 389);
            GhiFile.Name = "GhiFile";
            GhiFile.Size = new Size(94, 29);
            GhiFile.TabIndex = 1;
            GhiFile.Text = "DocFile.txt";
            GhiFile.UseVisualStyleBackColor = true;
            GhiFile.Click += GhiFile_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(204, 50);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(GhiFile);
            Controls.Add(DocFile);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DocFile;
        private Button GhiFile;
        private Label label1;
    }
}