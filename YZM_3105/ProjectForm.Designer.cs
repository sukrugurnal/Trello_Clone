namespace YZM_3105
{
    partial class ProjectForm
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
            this.lbProjectTitle = new System.Windows.Forms.Label();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnProjectView = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnProjectDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbProjectTitle
            // 
            this.lbProjectTitle.AutoSize = true;
            this.lbProjectTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbProjectTitle.ForeColor = System.Drawing.Color.White;
            this.lbProjectTitle.Location = new System.Drawing.Point(4, 6);
            this.lbProjectTitle.Name = "lbProjectTitle";
            this.lbProjectTitle.Size = new System.Drawing.Size(33, 16);
            this.lbProjectTitle.TabIndex = 0;
            this.lbProjectTitle.Text = "Title";
            // 
            // btnInvite
            // 
            this.btnInvite.BackColor = System.Drawing.Color.Transparent;
            this.btnInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvite.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInvite.ForeColor = System.Drawing.Color.White;
            this.btnInvite.Location = new System.Drawing.Point(7, 28);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(66, 31);
            this.btnInvite.TabIndex = 8;
            this.btnInvite.TabStop = false;
            this.btnInvite.Text = "Davet Et";
            this.btnInvite.UseVisualStyleBackColor = false;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // btnProjectView
            // 
            this.btnProjectView.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectView.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProjectView.ForeColor = System.Drawing.Color.White;
            this.btnProjectView.Location = new System.Drawing.Point(122, 28);
            this.btnProjectView.Name = "btnProjectView";
            this.btnProjectView.Size = new System.Drawing.Size(66, 31);
            this.btnProjectView.TabIndex = 9;
            this.btnProjectView.TabStop = false;
            this.btnProjectView.Text = "Göster";
            this.btnProjectView.UseVisualStyleBackColor = false;
            this.btnProjectView.Click += new System.EventHandler(this.btnProjectView_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(199, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 62);
            this.panel3.TabIndex = 12;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 62);
            this.panel4.TabIndex = 13;
            // 
            // btnProjectDelete
            // 
            this.btnProjectDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnProjectDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjectDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProjectDelete.ForeColor = System.Drawing.Color.White;
            this.btnProjectDelete.Location = new System.Drawing.Point(79, 28);
            this.btnProjectDelete.Name = "btnProjectDelete";
            this.btnProjectDelete.Size = new System.Drawing.Size(33, 31);
            this.btnProjectDelete.TabIndex = 14;
            this.btnProjectDelete.TabStop = false;
            this.btnProjectDelete.Text = "Sil";
            this.btnProjectDelete.UseVisualStyleBackColor = false;
            this.btnProjectDelete.Click += new System.EventHandler(this.btnProjectDelete_Click);
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(200, 64);
            this.Controls.Add(this.btnProjectDelete);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnProjectView);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.lbProjectTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectForm";
            this.Text = "Project";
            this.Load += new System.EventHandler(this.Project_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbProjectTitle;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Button btnProjectView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnProjectDelete;
    }
}