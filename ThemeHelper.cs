using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class ThemeHelper
{
    public static void ModernizeInterface(Form form)
    {
        foreach (Control ctrl in form.Controls)
        {
            // If the control is a button, apply the style
            if (ctrl is Button btn)
            {
                ApplyModernStyle(btn);
            }
            // If the button is inside a Panel or GroupBox, we need to check those too
            else if (ctrl.HasChildren)
            {
                ApplyToChildren(ctrl);
            }
        }
    }

    private static void ApplyToChildren(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl is Button btn) ApplyModernStyle(btn);
            else if (ctrl.HasChildren) ApplyToChildren(ctrl);
        }
    }

    private static void ApplyModernStyle(Button btn)
    {
        // 1. Set Flat Style
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Cursor = Cursors.Hand; // Makes it feel interactive

        // 2. Set Modern Font if not already set
        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        // 3. Apply Rounded Corners (Radius 15)
        int radius = 15;
        Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
        GraphicsPath path = new GraphicsPath();
        path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
        path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
        path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90);
        path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
        path.CloseAllFigures();

        btn.Region = new Region(path);
    }
}