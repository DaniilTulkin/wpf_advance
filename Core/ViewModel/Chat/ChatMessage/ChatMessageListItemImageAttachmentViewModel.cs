using System.Threading.Tasks;

namespace wpf_advance.Core
{
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        private string thumbnailUrl;
        public string Title { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ThumbnailUrl
        {
            get => thumbnailUrl;
            set
            {
                if (value != thumbnailUrl)
                {
                    thumbnailUrl = value;
                    Task.Delay(2000).ContinueWith(t => LocalFilePath = "/Resources/Samples/dog.jpg");
                }
            }
        }
        public string LocalFilePath { get; set; }
    }
}
