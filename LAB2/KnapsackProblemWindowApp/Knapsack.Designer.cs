namespace KnapsackProblemWindowApp
{
    partial class Knapsack
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
            this.run = new System.Windows.Forms.Button();
            this.numberOfItemsText = new System.Windows.Forms.TextBox();
            this.instance = new System.Windows.Forms.RichTextBox();
            this.result = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.seedText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.capacityText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.run.Location = new System.Drawing.Point(11, 203);
            this.run.Margin = new System.Windows.Forms.Padding(2);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(110, 30);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // numberOfItemsText
            // 
            this.numberOfItemsText.Location = new System.Drawing.Point(11, 45);
            this.numberOfItemsText.Name = "numberOfItemsText";
            this.numberOfItemsText.Size = new System.Drawing.Size(110, 20);
            this.numberOfItemsText.TabIndex = 1;
            this.numberOfItemsText.Text = "10";
            this.numberOfItemsText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // instance
            // 
            this.instance.Location = new System.Drawing.Point(274, 45);
            this.instance.Name = "instance";
            this.instance.ReadOnly = true;
            this.instance.Size = new System.Drawing.Size(298, 504);
            this.instance.TabIndex = 2;
            this.instance.Text = "";
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(12, 270);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(256, 279);
            this.result.TabIndex = 3;
            this.result.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "number of items";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(158, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "result";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(462, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "instance";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "seed";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seedText
            // 
            this.seedText.Location = new System.Drawing.Point(11, 101);
            this.seedText.Name = "seedText";
            this.seedText.Size = new System.Drawing.Size(110, 20);
            this.seedText.TabIndex = 5;
            this.seedText.Text = "1";
            this.seedText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "capacity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // capacityText
            // 
            this.capacityText.Location = new System.Drawing.Point(12, 161);
            this.capacityText.Name = "capacityText";
            this.capacityText.Size = new System.Drawing.Size(110, 20);
            this.capacityText.TabIndex = 7;
            this.capacityText.Text = "50";
            this.capacityText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Knapsack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.capacityText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seedText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.instance);
            this.Controls.Add(this.numberOfItemsText);
            this.Controls.Add(this.run);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Knapsack";
            this.Text = "Knapsack";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox capacityText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox seedText;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.RichTextBox result;

        private System.Windows.Forms.RichTextBox instance;

        private System.Windows.Forms.TextBox numberOfItemsText;

        private System.Windows.Forms.Button run;

        #endregion
    }
}