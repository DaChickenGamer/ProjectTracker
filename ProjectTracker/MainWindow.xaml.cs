using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTracker;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        SourceInitialized += MainWindow_SourceInitialized;
        
        ShowInTaskbar = false;
        
        Width = Config.Instance.Window.Width;
        Height = Config.Instance.Window.Height;
    }

    private void MainWindow_SourceInitialized(object sender, EventArgs e)
    {
        var workArea = SystemParameters.WorkArea;
        
        Left = workArea.Right - Width - Config.Instance.Window.MarginLeft;
        Top = workArea.Top + Config.Instance.Window.MarginTop;
    }
}