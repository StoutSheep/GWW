namespace InvoiceMaker
{
    partial class InvoiceForm
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
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(53, 188);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 614);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(1215, 820);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(102, 51);
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(1093, 820);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(102, 51);
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 917);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.panel1);
            this.Name = "InvoiceForm";
            this.Text = "Invoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
    }
}