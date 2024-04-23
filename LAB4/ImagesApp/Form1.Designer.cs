namespace ImagesApp
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
            this.load_image = new System.Windows.Forms.Button();
            this.orginal = new System.Windows.Forms.PictureBox();
            this.image2 = new System.Windows.Forms.PictureBox();
            this.image4 = new System.Windows.Forms.PictureBox();
            this.image1 = new System.Windows.Forms.PictureBox();
            this.image3 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image3)).BeginInit();
            this.SuspendLayout();
            // 
            // load_image
            // 
            this.load_image.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.load_image.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.load_image.FlatAppearance.BorderSize = 5;
            this.load_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.load_image.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.load_image.Location = new System.Drawing.Point(278, 401);
            this.load_image.Name = "load_image";
            this.load_image.Size = new System.Drawing.Size(111, 37);
            this.load_image.TabIndex = 0;
            this.load_image.Text = "Load Image";
            this.load_image.UseVisualStyleBackColor = false;
            this.load_image.Click += new System.EventHandler(this.load_image_Click);
            // 
            // orginal
            // 
            this.orginal.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.orginal.Location = new System.Drawing.Point(12, 12);
            this.orginal.Name = "orginal";
            this.orginal.Size = new System.Drawing.Size(350, 350);
            this.orginal.TabIndex = 1;
            this.orginal.TabStop = false;
            // 
            // image2
            // 
            this.image2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.image2.Location = new System.Drawing.Point(618, 12);
            this.image2.Name = "image2";
            this.image2.Size = new System.Drawing.Size(165, 165);
            this.image2.TabIndex = 3;
            this.image2.TabStop = false;
            // 
            // image4
            // 
            this.image4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.image4.Location = new System.Drawing.Point(618, 197);
            this.image4.Name = "image4";
            this.image4.Size = new System.Drawing.Size(165, 165);
            this.image4.TabIndex = 4;
            this.image4.TabStop = false;
            // 
            // image1
            // 
            this.image1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.image1.Location = new System.Drawing.Point(422, 12);
            this.image1.Name = "image1";
            this.image1.Size = new System.Drawing.Size(165, 165);
            this.image1.TabIndex = 2;
            this.image1.TabStop = false;
            // 
            // image3
            // 
            this.image3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.image3.Location = new System.Drawing.Point(422, 197);
            this.image3.Name = "image3";
            this.image3.Size = new System.Drawing.Size(165, 165);
            this.image3.TabIndex = 3;
            this.image3.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.start.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.start.FlatAppearance.BorderSize = 5;
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.start.Location = new System.Drawing.Point(395, 401);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(111, 37);
            this.start.TabIndex = 5;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.start);
            this.Controls.Add(this.image4);
            this.Controls.Add(this.image2);
            this.Controls.Add(this.image3);
            this.Controls.Add(this.image1);
            this.Controls.Add(this.orginal);
            this.Controls.Add(this.load_image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Images App";
            ((System.ComponentModel.ISupportInitialize)(this.orginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image3)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button start;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.PictureBox orginal;
        private System.Windows.Forms.PictureBox image2;
        private System.Windows.Forms.PictureBox image4;
        private System.Windows.Forms.PictureBox image1;
        private System.Windows.Forms.PictureBox image3;

        private System.Windows.Forms.Button load_image;

        #endregion
    }
}