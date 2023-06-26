namespace SimpleOutlook_VSTO_AddIns
{
    partial class SidePanelControl
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
            this.SearchMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchMail
            // 
            this.SearchMail.AccessibleDescription = "";
            this.SearchMail.AccessibleName = "";
            this.SearchMail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SearchMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchMail.Cursor = System.Windows.Forms.Cursors.No;
            this.SearchMail.ForeColor = System.Drawing.SystemColors.InfoText;
            this.SearchMail.Location = new System.Drawing.Point(24, 44);
            this.SearchMail.Multiline = true;
            this.SearchMail.Name = "SearchMail";
            this.SearchMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SearchMail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SearchMail.Size = new System.Drawing.Size(214, 37);
            this.SearchMail.TabIndex = 0;
            this.SearchMail.TextChanged += new System.EventHandler(this.SearchMail_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search MailBox";
            // 
            // SidePanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchMail);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "SidePanelControl";
            this.Size = new System.Drawing.Size(267, 548);
            this.Load += new System.EventHandler(this.SidePanelControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
