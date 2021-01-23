using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace YZM_3105
{
    public class EventTabTopMenu : Panel
    {
        public TbTitle TbTitle = new TbTitle();
        public ListDeleteButton BtnListDelete = new ListDeleteButton();
        public EventTabTopMenu()
        {
            this.Controls.Add(BtnListDelete);
            this.Controls.Add(TbTitle);
            this.Dock = DockStyle.Top;
            this.Name = "EventTabTopMenu";
            this.Size = new System.Drawing.Size(240, 30);
            this.TabIndex = 3;
        }
    }
}
