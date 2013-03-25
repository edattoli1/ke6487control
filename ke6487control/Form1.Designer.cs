namespace Ke648x
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
            this.startGPIBbutton = new System.Windows.Forms.Button();
            this.gpibReadBox = new System.Windows.Forms.TextBox();
            this.initDeviceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startGPIBbutton
            // 
            this.startGPIBbutton.Location = new System.Drawing.Point(56, 49);
            this.startGPIBbutton.Name = "startGPIBbutton";
            this.startGPIBbutton.Size = new System.Drawing.Size(75, 44);
            this.startGPIBbutton.TabIndex = 0;
            this.startGPIBbutton.Text = "Start GPIB";
            this.startGPIBbutton.UseVisualStyleBackColor = true;
            this.startGPIBbutton.Click += new System.EventHandler(this.startGPIBbutton_Click);
            // 
            // gpibReadBox
            // 
            this.gpibReadBox.Location = new System.Drawing.Point(56, 146);
            this.gpibReadBox.Name = "gpibReadBox";
            this.gpibReadBox.Size = new System.Drawing.Size(100, 22);
            this.gpibReadBox.TabIndex = 1;
            // 
            // initDeviceButton
            // 
            this.initDeviceButton.Location = new System.Drawing.Point(246, 60);
            this.initDeviceButton.Name = "initDeviceButton";
            this.initDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.initDeviceButton.TabIndex = 2;
            this.initDeviceButton.Text = "Init 6487";
            this.initDeviceButton.UseVisualStyleBackColor = true;
            this.initDeviceButton.Click += new System.EventHandler(this.initDeviceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 256);
            this.Controls.Add(this.initDeviceButton);
            this.Controls.Add(this.gpibReadBox);
            this.Controls.Add(this.startGPIBbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGPIBbutton;
        private System.Windows.Forms.TextBox gpibReadBox;
        private System.Windows.Forms.Button initDeviceButton;
    }
}

