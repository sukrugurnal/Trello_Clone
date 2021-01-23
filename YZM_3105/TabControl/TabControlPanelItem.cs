using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YZM_3105
{
    public class TabControlPanelItem : Panel
    {
        public TabCloseButton CloseButton = new TabCloseButton();
        public Form Form;
        public TabButton TabButton;
        public TabControlPanelItem(string projectTitle)
        {
            TabButton = new TabButton(projectTitle);
            this.Controls.Add(TabButton);
            this.Controls.Add(CloseButton);
            this.Controls.SetChildIndex(CloseButton, 0);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Dock = DockStyle.Left;
            this.Name = "TabControlPanel";
            this.AutoSize = true;
        }

    }
}
