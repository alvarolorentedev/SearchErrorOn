namespace soft.Hati.ErrorListSearchOn.Services.Options
{
    partial class OptionUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.SearchEngineCB = new System.Windows.Forms.ComboBox();
            this.LiteralsBC = new System.Windows.Forms.CheckBox();
            this.InternalBrowserCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Engine";
            // 
            // SearchEngineCB
            // 
            this.SearchEngineCB.FormattingEnabled = true;
            this.SearchEngineCB.Location = new System.Drawing.Point(113, 27);
            this.SearchEngineCB.Name = "SearchEngineCB";
            this.SearchEngineCB.Size = new System.Drawing.Size(299, 24);
            this.SearchEngineCB.TabIndex = 1;
            this.SearchEngineCB.SelectionChangeCommitted += new System.EventHandler(this.SearchEngineCB_SelectionChangeCommitted);
            // 
            // LiteralsBC
            // 
            this.LiteralsBC.AutoSize = true;
            this.LiteralsBC.Location = new System.Drawing.Point(113, 57);
            this.LiteralsBC.Name = "LiteralsBC";
            this.LiteralsBC.Size = new System.Drawing.Size(299, 21);
            this.LiteralsBC.TabIndex = 3;
            this.LiteralsBC.Text = "Removel Literal (search for generic errors)";
            this.LiteralsBC.UseVisualStyleBackColor = true;
            this.LiteralsBC.CheckedChanged += new System.EventHandler(this.LiteralsBC_CheckedChanged);
            // 
            // InternalBrowserCB
            // 
            this.InternalBrowserCB.AutoSize = true;
            this.InternalBrowserCB.Location = new System.Drawing.Point(113, 30);
            this.InternalBrowserCB.Name = "InternalBrowserCB";
            this.InternalBrowserCB.Size = new System.Drawing.Size(287, 21);
            this.InternalBrowserCB.TabIndex = 4;
            this.InternalBrowserCB.Text = "Search on Visual Studio Internal Browser";
            this.InternalBrowserCB.UseVisualStyleBackColor = true;
            this.InternalBrowserCB.CheckedChanged += new System.EventHandler(this.InternalBrowserCB_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SearchEngineCB);
            this.groupBox1.Controls.Add(this.LiteralsBC);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(627, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InternalBrowserCB);
            this.groupBox2.Location = new System.Drawing.Point(6, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 71);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Browser Options";
            // 
            // OptionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionUserControl";
            this.Size = new System.Drawing.Size(633, 379);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchEngineCB;
        private System.Windows.Forms.CheckBox LiteralsBC;
        private System.Windows.Forms.CheckBox InternalBrowserCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
