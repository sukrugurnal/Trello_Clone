using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public class TbTitle : TextBox
    {
        public TbTitle()
        {
            this.BackColor = System.Drawing.Color.Teal;
            this.Dock = System.Windows.Forms.DockStyle.Left;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Multiline = true;
            this.Name = "TbTitle";
            this.Text = "Başlık";
            this.MaxLength = 13;
            this.Size = new System.Drawing.Size(180, 30);
            this.TabIndex = 0;
        }
    }
}
