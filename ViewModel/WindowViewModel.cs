using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace wpf_advance
{
    public class WindowViewModel : BaseViewModel
    {
        private Window window;
        private int outerMarginSize = 10;
        private int windowRadius = 10;

        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMinimumHeight { get; set; } = 400;
        public int ResizeBorder { get; set; } = 6;
        public Thickness ResizeBorderThickness
        {
            get { return new Thickness(ResizeBorder + OuterMarginSize); }
        }
        public Thickness InnerContentPadding
        {
            get { return new Thickness(ResizeBorder); }
        }
        public int OuterMarginSize
        {
            get { return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize; }
            set { outerMarginSize = value; }
        }
        public Thickness OuterMarginSizeThickness
        {
            get { return new Thickness(OuterMarginSize); }
        }
        public int WindowRadius
        {
            get { return window.WindowState == WindowState.Maximized ? 0 : windowRadius; }
            set { windowRadius = value; }
        }
        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(WindowRadius); }
        }
        public int TitleHeight { get; set; } = 42;
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }
        public WindowViewModel(Window window)
        {
            this.window = window;

            window.StateChanged += (sender, e) => 
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
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
        public ICommand MinimizeCommand => new RelayCommand(() => window.WindowState = WindowState.Minimized);
        public ICommand MaximizeCommand => new RelayCommand(() => window.WindowState ^= WindowState.Maximized);
        public ICommand CloseCommand => new RelayCommand(() => window.Close());
        public ICommand MenuCommand => new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));
    }
}
