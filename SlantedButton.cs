using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class SlantedButton : Button
{
    public void MakeSlanted(Button btn)
    {
        int slant = 30; // adjust angle here

        GraphicsPath path = new GraphicsPath();
        path.AddPolygon(new Point[]
        {
        new Point(0, 0),                        // top-left (normal)
        new Point(btn.Width, 0),               // top-right (normal)
        new Point(btn.Width, btn.Height),      // bottom-right (normal)
        new Point(slant, btn.Height),          // bottom slant point
        new Point(0, btn.Height - slant)       // left slant point
        });

        btn.Region = new Region(path);
    }
}