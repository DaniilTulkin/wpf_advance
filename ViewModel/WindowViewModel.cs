using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using wpf_advance.Core;

namespace wpf_advance
{
    public class WindowViewModel : BaseViewModel
    {
        private Window window;
        private int outerMarginSize = 10;
        private int windowRadius = 10;
        private WindowDockPosition dockPosition = WindowDockPosition.Undocked;

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 500;
        public bool Borderless => window.WindowState == WindowState.Maximized || dockPosition != WindowDockPosition.Undocked;
        public int ResizeBorder => Borderless ? 0 : 6;
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);
        public int OuterMarginSize
        {
            get => Borderless ? 0 : outerMarginSize;
            set => outerMarginSize = value;
        }
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);
        public int WindowRadius
        {
            get => Borderless ? 0 : windowRadius;
            set => windowRadius = value;
        }
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        public WindowViewModel(Window window)
        {
            this.window = window;
            window.StateChanged += (sender, e) =>
            {
                WindowResized();
            };

            WindowResizer resizer = new WindowResizer(window);
            resizer.WindowDockChanged += (dock) =>
            {
                dockPosition = dock;
                WindowResized();
            };
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(ref Win32Point pt);
        [StructLayout(LayoutKind.Sequential)]
        private struct Win32Point
        {
            public int X;
            public int Y;
        }
        private static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
        private void WindowResized()
        {
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }
        public ICommand MinimizeCommand => new RelayCommand(() => window.WindowState = WindowState.Minimized);
        public ICommand MaximizeCommand => new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
        public ICommand CloseCommand => new RelayCommand(() => window.Close());
        public ICommand MenuCommand => new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));
    }
}
