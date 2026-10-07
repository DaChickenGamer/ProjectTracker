using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ProjectTracker;

public partial class MainWindow : Window
{
    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
    private const uint SWP_NOSIZE = 0x0001;
    private const uint SWP_NOMOVE = 0x0002;
    private const uint SWP_NOACTIVATE = 0x0010;

    public MainWindow()
    {
        InitializeComponent();
        
        ShowActivated = false;
        ShowInTaskbar = false;

        SourceInitialized += MainWindow_SourceInitialized;

        Width = Config.Instance.Window.Width;
        Height = Config.Instance.Window.Height;
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        
        IntPtr hwnd = new WindowInteropHelper(this).Handle;
        SetWindowPos(hwnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
    }

    private void MainWindow_SourceInitialized(object sender, EventArgs e)
    {
        var workArea = SystemParameters.WorkArea;
        
        Left = workArea.Right - Width - Config.Instance.Window.MarginLeft;
        Top = workArea.Top + Config.Instance.Window.MarginTop;

        IntPtr hwnd = new WindowInteropHelper(this).Handle;
        SetWindowPos(hwnd, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
    }
}