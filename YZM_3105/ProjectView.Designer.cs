namespace YZM_3105
{
    partial class ProjectView
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
            this.btnListAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnListAdd
            // 
            this.btnListAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListAdd.ForeColor = System.Drawing.Color.White;
            this.btnListAdd.Location = new System.Drawing.Point(12, 12);
            this.btnListAdd.Name = "btnListAdd";
            this.btnListAdd.Size = new System.Drawing.Size(250, 60);
            this.btnListAdd.TabIndex = 2;
            this.btnListAdd.Text = "Liste Ekle";
            this.btnListAdd.UseVisualStyleBackColor = true;
            this.btnListAdd.Click += new System.EventHandler(this.btnListAdd_Click);
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(650, 371);
            this.Controls.Add(this.btnListAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProjectView";
            this.Text = "ProjectView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProjectView_FormClosing);
            this.Load += new System.EventHandler(this.ProjectView_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ProjectView_ControlAdded);
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ProjectView_ControlRemoved);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnListAdd;
    }
}