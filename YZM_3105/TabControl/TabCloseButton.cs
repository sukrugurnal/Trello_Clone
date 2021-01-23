using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TabCloseButton : Button
    {
        public TabCloseButton()
        {

            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackColor = Color.Teal;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "TabCloseButton";
            this.Click += TabCloseButton_Click;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(30,10);
            this.Text = "X";

        }
        public void close()
        {
            MainForm mainForm = (MainForm)Application.OpenForms["MainForm"];
            TabControlPanelItem tabControlPanelItem = (TabControlPanelItem)this.Parent;
            tabControlPanelItem.Form.Close();
            mainForm.TabControlPanel.Controls.Remove(tabControlPanelItem);
            if (mainForm.TabControlPanel.Controls.Count > 0)
            {
                tabControlPanelItem = mainForm.TabControlPanel.Controls[mainForm.TabControlPanel.Controls.Count - 1] as TabControlPanelItem;
                tabControlPanelItem.TabButton.showForm();
            }
        }
        private void TabCloseButton_Click(object sender, EventArgs e)
        {

            close();
        }
    }
}
