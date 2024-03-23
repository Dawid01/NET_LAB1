namespace FreeGamesWindow
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
            this.labelCategories = new System.Windows.Forms.Label();
            this.panelCategories = new System.Windows.Forms.Panel();
            this.btnClearSelected = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelResults = new System.Windows.Forms.Panel();
            this.labelResults = new System.Windows.Forms.Label();
            this.labelSelectedCount = new System.Windows.Forms.Label();
            this.labelPlatforms = new System.Windows.Forms.Label();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();


            this.SuspendLayout();
            // 
            // labelCategories
            // 
            this.labelCategories.AutoSize = true;
            this.labelCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategories.ForeColor = System.Drawing.Color.White;
            this.labelCategories.Location = new System.Drawing.Point(10, 20);
            this.labelCategories.Name = "labelCategories";
            this.labelCategories.Size = new System.Drawing.Size(110, 21);
            this.labelCategories.Text = "CATEGORIES";
            // 
            // panelCategories
            // 
            this.panelCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelCategories.Location = new System.Drawing.Point(10, 50);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCategories.Size = new System.Drawing.Size(200, 400);
            this.panelCategories.TabIndex = 0;
            // 
            // btnClearSelected
            // 
            this.btnClearSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnClearSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelected.ForeColor = System.Drawing.Color.White;
            this.btnClearSelected.Location = new System.Drawing.Point(10, 460 + 100);
            this.btnClearSelected.Name = "btnClearSelected";
            this.btnClearSelected.Size = new System.Drawing.Size(200, 40);
            this.btnClearSelected.TabIndex = 1;
            this.btnClearSelected.Text = "CLEAR";
            this.btnClearSelected.UseVisualStyleBackColor = false;
            this.btnClearSelected.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(10, 510 + 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(200, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelResults
            // 
            this.panelResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelResults.Location = new System.Drawing.Point(220, 50);
            this.panelResults.Name = "panelResults";
            this.panelResults.Size = new System.Drawing.Size(760, 700);
            this.panelResults.TabIndex = 3;

            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.LargeChange = 20;
            this.vScrollBar.Location = new System.Drawing.Point(740, 0);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(20, 700);
            this.vScrollBar.Minimum = 0;
            this.vScrollBar.Maximum = this.panelResults.Height;
            this.vScrollBar.LargeChange = this.panelResults.Height / 10;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            this.Controls.Add(this.vScrollBar);


            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResults.ForeColor = System.Drawing.Color.White;
            this.labelResults.Location = new System.Drawing.Point(220, 20);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(81, 21);
            this.labelResults.Text = "RESULTS";
            // 
            // labelSelectedCount
            // 
            this.labelSelectedCount.AutoSize = true;
            this.labelSelectedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedCount.ForeColor = System.Drawing.Color.White;
            this.labelSelectedCount.BackColor = Color.Transparent;
            this.labelSelectedCount.Location = new System.Drawing.Point(10, 455);
            this.labelSelectedCount.Name = "labelSelectedCount";
            this.labelSelectedCount.Size = new System.Drawing.Size(200, 21);
            this.labelSelectedCount.Text = "Selected: 0";  
            this.Controls.Add(this.labelSelectedCount);
            // 
            // labelPlatforms
            // 
            this.labelPlatforms.AutoSize = true;
            this.labelPlatforms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlatforms.ForeColor = System.Drawing.Color.White;
            this.labelPlatforms.Location = new System.Drawing.Point(10, 475);
            this.labelPlatforms.Name = "labelCategories";
            this.labelPlatforms.Size = new System.Drawing.Size(110, 21);
            this.labelPlatforms.Text = "PLATFORMS";
            this.Controls.Add(this.labelPlatforms);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.panelResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClearSelected);
            this.Controls.Add(this.panelCategories);
            this.Controls.Add(this.labelCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Free Games";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCategories;
        private System.Windows.Forms.Panel panelCategories;
        private System.Windows.Forms.Button btnClearSelected;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panelResults;
        private System.Windows.Forms.Label labelResults;
        private System.Windows.Forms.Label labelSelectedCount;
        private System.Windows.Forms.Label labelPlatforms;
        private System.Windows.Forms.VScrollBar vScrollBar;


    }
}
