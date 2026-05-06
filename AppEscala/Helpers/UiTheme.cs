using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppEscala.Helpers;

internal static class UiTheme
{
    public static readonly Color Background = Color.FromArgb(246, 248, 251);
    public static readonly Color Surface = Color.White;
    public static readonly Color SurfaceMuted = Color.FromArgb(238, 243, 247);
    public static readonly Color Text = Color.FromArgb(30, 41, 59);
    public static readonly Color MutedText = Color.FromArgb(100, 116, 139);
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
    public static readonly Color Danger = Color.FromArgb(220, 38, 38);
    public static readonly Color Sidebar = Color.FromArgb(15, 23, 42);
    public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);
    public static readonly Color Border = Color.FromArgb(226, 232, 240);

    private static readonly Font DefaultFont = new("Segoe UI", 10F, FontStyle.Regular);
    private static readonly Font HeadingFont = new("Segoe UI Semibold", 18F, FontStyle.Bold);
    private static readonly Font LabelFont = new("Segoe UI Semibold", 9.5F, FontStyle.Bold);

    public static void Apply(Control root)
    {
        root.BackColor = Background;
        root.Font = DefaultFont;
        root.ForeColor = Text;
        ApplyRecursive(root);
    }

    public static void StyleSidebarButton(Button button, bool active = false)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = active ? SidebarHover : Sidebar;
        button.ForeColor = Color.White;
        button.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.ImageAlign = ContentAlignment.MiddleLeft;
    }

    public static void StyleTitle(Label label)
    {
        label.Font = HeadingFont;
        label.ForeColor = Text;
    }

    public static void StylePanelSurface(Panel panel)
    {
        panel.BackColor = Surface;
        panel.Paint -= PaintSurface;
        panel.Paint += PaintSurface;
    }

    private static void ApplyRecursive(Control control)
    {
        foreach (Control child in control.Controls)
        {
            switch (child)
            {
                case Button button:
                    StyleButton(button);
                    break;
                case TextBox textBox:
                    StyleTextBox(textBox);
                    break;
                case ComboBox comboBox:
                    StyleComboBox(comboBox);
                    break;
                case DateTimePicker picker:
                    StylePicker(picker);
                    break;
                case DataGridView grid:
                    StyleGrid(grid);
                    break;
                case ListBox listBox:
                    StyleListBox(listBox);
                    break;
                case ListView listView:
                    StyleListView(listView);
                    break;
                case RichTextBox richTextBox:
                    StyleRichTextBox(richTextBox);
                    break;
                case Label label:
                    StyleLabel(label);
                    break;
                case CheckBox checkBox:
                    checkBox.ForeColor = Text;
                    checkBox.Font = DefaultFont;
                    break;
            }

            if (child.HasChildren)
                ApplyRecursive(child);
        }
    }

    private static void StyleButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = Primary;
        button.ForeColor = Color.White;
        button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
        button.MinimumSize = new Size(36, 32);

        if (button.Text.Contains("Excluir", StringComparison.OrdinalIgnoreCase))
            button.BackColor = Danger;
    }

    private static void StyleTextBox(TextBox textBox)
    {
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Surface;
        textBox.ForeColor = Text;
        textBox.Font = DefaultFont;
        textBox.Height = Math.Max(textBox.Height, 30);
    }

    private static void StyleComboBox(ComboBox comboBox)
    {
        comboBox.FlatStyle = FlatStyle.Flat;
        comboBox.BackColor = Surface;
        comboBox.ForeColor = Text;
        comboBox.Font = DefaultFont;
        comboBox.Height = Math.Max(comboBox.Height, 30);
    }

    private static void StylePicker(DateTimePicker picker)
    {
        picker.CalendarForeColor = Text;
        picker.CalendarTitleBackColor = Primary;
        picker.CalendarTitleForeColor = Color.White;
        picker.Font = DefaultFont;
        picker.Height = Math.Max(picker.Height, 30);
    }

    private static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Surface;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.EnableHeadersVisualStyles = false;
        grid.GridColor = Border;
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.DefaultCellStyle.BackColor = Surface;
        grid.DefaultCellStyle.ForeColor = Text;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
        grid.DefaultCellStyle.SelectionForeColor = Text;
        grid.DefaultCellStyle.Padding = new Padding(6);
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
        grid.ColumnHeadersDefaultCellStyle.BackColor = SurfaceMuted;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Text;
        grid.ColumnHeadersDefaultCellStyle.Font = LabelFont;
        grid.ColumnHeadersHeight = 38;
        grid.RowTemplate.Height = 34;
    }

    private static void StyleListBox(ListBox listBox)
    {
        listBox.BorderStyle = BorderStyle.FixedSingle;
        listBox.BackColor = Surface;
        listBox.ForeColor = Text;
        listBox.Font = DefaultFont;
    }

    private static void StyleListView(ListView listView)
    {
        listView.BorderStyle = BorderStyle.FixedSingle;
        listView.BackColor = Surface;
        listView.ForeColor = Text;
        listView.Font = DefaultFont;
    }

    private static void StyleRichTextBox(RichTextBox richTextBox)
    {
        richTextBox.BorderStyle = BorderStyle.FixedSingle;
        richTextBox.BackColor = Surface;
        richTextBox.ForeColor = Text;
        richTextBox.Font = DefaultFont;
    }

    private static void StyleLabel(Label label)
    {
        label.ForeColor = MutedText;
        label.Font = label.Font.Bold ? LabelFont : DefaultFont;
    }

    private static void PaintSurface(object? sender, PaintEventArgs e)
    {
        if (sender is not Panel panel)
            return;

        using Pen pen = new(Border);
        Rectangle bounds = new(0, 0, panel.Width - 1, panel.Height - 1);
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.DrawRectangle(pen, bounds);
    }
}
