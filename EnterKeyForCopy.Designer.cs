using ProductivityClipboard;
using System.Diagnostics;
using System.Threading.Channels;

namespace learningForms
{
    partial class EnterKeyForCopy
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

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("----------entered key: " + e.KeyValue.ToString());
            if (ValidIdentifiers.IsValidIdentifier(e.KeyValue.ToString()))
            {

                int ChannelId = ValidIdentifiers.getChannelId(e.KeyValue.ToString());
                KeyLogger.ChannelId = ValidIdentifiers.getChannelId(e.KeyValue.ToString());
                if (ChannelManagement.CheckChannelIdAndRead(KeyLogger.ChannelIdsToStrings[ChannelId]))
                {
                    Program.MainForm.LoadDataOnChange(ChannelId);
                    // was successful
                }
                else
                {
                    //return error message
                }
                this.Close();

            }
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterKeyForCopy));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter 0-9 For Clipboards";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter M for adding to Mathematical Values";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Enter T for adding the text as Task!";
            // 
            // EnterKeyForCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 142);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnterKeyForCopy";
            this.Opacity = 0D;
            this.Text = "Enter Channel Name";
            this.Load += new System.EventHandler(this.EnterKeyForCopy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label2;
        private Label label3;
        private Label label4;
    }
}