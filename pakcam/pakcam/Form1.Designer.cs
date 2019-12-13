namespace pakcam
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
            this.components = new System.ComponentModel.Container();
            this.start = new System.Windows.Forms.Button();
            this.cameraBox = new Emgu.CV.UI.ImageBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(380, 23);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(332, 59);
            this.start.TabIndex = 1;
            this.start.Text = "Start Face Detection & Recognition";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // cameraBox
            // 
            this.cameraBox.Location = new System.Drawing.Point(26, 37);
            this.cameraBox.Name = "cameraBox";
            this.cameraBox.Size = new System.Drawing.Size(297, 384);
            this.cameraBox.TabIndex = 2;
            this.cameraBox.TabStop = false;
            this.cameraBox.Click += new System.EventHandler(this.cameraBox_Click);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(380, 110);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(332, 54);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(399, 197);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(71, 24);
            this.lblname.TabIndex = 4;
            this.lblname.Text = "Name:";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(476, 198);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(236, 20);
            this.txtname.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(778, 479);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.cameraBox);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button start;
        private Emgu.CV.UI.ImageBox cameraBox;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtname;
    }
}

