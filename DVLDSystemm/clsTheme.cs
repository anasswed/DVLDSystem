using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Color.FromArgb(240, 244, 248);
        public override Color MenuStripGradientEnd => Color.FromArgb(240, 244, 248);
        public override Color MenuItemSelected => Color.FromArgb(220, 225, 230);
        public override Color MenuItemBorder => Color.FromArgb(200, 205, 210);
        public override Color MenuBorder => Color.FromArgb(200, 205, 210);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(220, 225, 230);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(220, 225, 230);
        public override Color ButtonSelectedHighlight => Color.FromArgb(220, 225, 230);
    }
}
