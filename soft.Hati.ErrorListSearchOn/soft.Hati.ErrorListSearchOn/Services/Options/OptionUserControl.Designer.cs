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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Engine";
            // 
            // SearchEngineCB
            // 
            this.SearchEngineCB.FormattingEnabled = true;
            this.SearchEngineCB.Location = new System.Drawing.Point(125, 27);
            this.SearchEngineCB.Name = "SearchEngineCB";
            this.SearchEngineCB.Size = new System.Drawing.Size(409, 24);
            this.SearchEngineCB.TabIndex = 1;
            this.SearchEngineCB.SelectionChangeCommitted += new System.EventHandler(this.SearchEngineCB_SelectionChangeCommitted);
            // 
            // LiteralsBC
            // 
            this.LiteralsBC.AutoSize = true;
            this.LiteralsBC.Location = new System.Drawing.Point(125, 74);
            this.LiteralsBC.Name = "LiteralsBC";
            this.LiteralsBC.Size = new System.Drawing.Size(299, 21);
            this.LiteralsBC.TabIndex = 3;
            this.LiteralsBC.Text = "Removel Literal (search for generic errors)";
            this.LiteralsBC.UseVisualStyleBackColor = true;
            this.LiteralsBC.CheckedChanged += new System.EventHandler(this.LiteralsBC_CheckedChanged);
            // 
            // OptionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LiteralsBC);
            this.Controls.Add(this.SearchEngineCB);
            this.Controls.Add(this.label1);
            this.Name = "OptionUserControl";
            this.Size = new System.Drawing.Size(633, 379);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SearchEngineCB;
        private System.Windows.Forms.CheckBox LiteralsBC;
    }
}
