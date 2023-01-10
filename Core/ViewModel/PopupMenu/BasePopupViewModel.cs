namespace wpf_advance.Core
{
    public class BasePopupViewModel : BaseViewModel
    {
        public string BubbleBackground { get; set; } = "ffffff";
        public ElementHorizontalAlignment ArrowAlignment { get; set; } = ElementHorizontalAlignment.Left;
        public BaseViewModel Content { get; set; }
    }
}
