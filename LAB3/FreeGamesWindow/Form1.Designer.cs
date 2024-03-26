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
            labelCategories = new System.Windows.Forms.Label();
            panelCategories = new System.Windows.Forms.Panel();
            btnClearSelected = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            panelResults = new System.Windows.Forms.Panel();
            labelResults = new System.Windows.Forms.Label();
            labelSelectedCount = new System.Windows.Forms.Label();
            labelPlatforms = new System.Windows.Forms.Label();
            labelPageInfo = new System.Windows.Forms.Label();


            SuspendLayout();
            // 
            // labelCategories
            // 
            labelCategories.AutoSize = true;
            labelCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelCategories.ForeColor = System.Drawing.Color.White;
            labelCategories.Location = new System.Drawing.Point(10, 20);
            labelCategories.Name = "labelCategories";
            labelCategories.Size = new System.Drawing.Size(110, 21);
            labelCategories.Text = "CATEGORIES";
            // 
            // panelCategories
            // 
            panelCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            panelCategories.Location = new System.Drawing.Point(10, 50);
            panelCategories.Name = "panelCategories";
            panelCategories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panelCategories.Size = new System.Drawing.Size(200, 400);
            panelCategories.TabIndex = 0;
            // 
            // btnClearSelected
            // 
            btnClearSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            btnClearSelected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnClearSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClearSelected.ForeColor = System.Drawing.Color.White;
            btnClearSelected.Location = new System.Drawing.Point(10, 460 + 100);
            btnClearSelected.Name = "btnClearSelected";
            btnClearSelected.Size = new System.Drawing.Size(200, 40);
            btnClearSelected.TabIndex = 1;
            btnClearSelected.Text = "CLEAR";
            btnClearSelected.UseVisualStyleBackColor = false;
            btnClearSelected.Click += new System.EventHandler(btnClear_Click);
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(10, 510 + 100);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(200, 40);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += new System.EventHandler(btnSearch_Click);
            // 
            // panelResults
            // 
            panelResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            panelResults.Location = new System.Drawing.Point(220, 50);
            panelResults.Name = "panelResults";
            panelResults.Size = new System.Drawing.Size(760, 600);
            panelResults.TabIndex = 3;
            panelResults.AutoScroll = true;


            // 
            // labelResults
            // 
            labelResults.AutoSize = true;
            labelResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelResults.ForeColor = System.Drawing.Color.White;
            labelResults.Location = new System.Drawing.Point(220, 20);
            labelResults.Name = "labelResults";
            labelResults.Size = new System.Drawing.Size(81, 21);
            labelResults.Text = "RESULTS";
            // 
            // labelSelectedCount
            // 
            labelSelectedCount.AutoSize = true;
            labelSelectedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelSelectedCount.ForeColor = System.Drawing.Color.White;
            labelSelectedCount.BackColor = Color.Transparent;
            labelSelectedCount.Location = new System.Drawing.Point(10, 455);
            labelSelectedCount.Name = "labelSelectedCount";
            labelSelectedCount.Size = new System.Drawing.Size(200, 21);
            labelSelectedCount.Text = "Selected: 0";  
            Controls.Add(labelSelectedCount);
            // 
            // labelPlatforms
            // 
            labelPlatforms.AutoSize = true;
            labelPlatforms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPlatforms.ForeColor = System.Drawing.Color.White;
            labelPlatforms.Location = new System.Drawing.Point(10, 475);
            labelPlatforms.Name = "labelCategories";
            labelPlatforms.Size = new System.Drawing.Size(110, 21);
            labelPlatforms.Text = "PLATFORMS";
            Controls.Add(labelPlatforms);

            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            ClientSize = new System.Drawing.Size(1000, 800);
            Controls.Add(labelResults);
            Controls.Add(panelResults);
            Controls.Add(btnSearch);
            Controls.Add(btnClearSelected);
            Controls.Add(panelCategories);
            Controls.Add(labelCategories);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Free Games";
            ResumeLayout(false);
            PerformLayout();
            // 
            // labelResults
            // 
            labelPageInfo.AutoSize = true;
            labelPageInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelPageInfo.ForeColor = System.Drawing.Color.White;
            labelPageInfo.Location = new System.Drawing.Point(180 + panelResults.Width, 20);
            labelPageInfo.Name = "labelResults";
            labelPageInfo.Size = new System.Drawing.Size(81, 21);
            labelPageInfo.Text = "PAGE 0/0";
            Controls.Add(labelPageInfo);

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
        private System.Windows.Forms.Label labelPageInfo;

    }
}
