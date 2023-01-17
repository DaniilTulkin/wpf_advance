using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using wpf_advance.Core;

namespace wpf_advance
{
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        public ChatPage() : base()
        {
            InitializeComponent();
        }
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        protected override void OnViewModelChanged()
        {
            if (ChatMessageList != null)
            {
                var storyboard = new Storyboard();
                storyboard.AddFadeIn(1);
                storyboard.Begin(ChatMessageList);
            }

            if (MessageText != null) MessageText.Focus();
        }

        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
                {
                    var index = textBox.CaretIndex;
                    textBox.Text = textBox.Text.Insert(index, Environment.NewLine);
                    textBox.CaretIndex = index + Environment.NewLine.Length;
                    e.Handled = true;
                }
                else ViewModel.SendCommand.Execute(null);

                e.Handled = true;
            }
        }
    }
}
