﻿using Core;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace wpf_advance.Core
{
    public class ChatListItemViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictureRGB { get; set; }
        public bool NewContentAvailable { get; set; }
        public bool IsSelected { get; set; }
        public ICommand OpenMessage => new RelayCommand(() =>
        {
            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                Items = new List<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody else",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody else",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody else",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "Another message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Somebody else",
                        SentByMe = false
                    }
                }
            });
        });
    }
}
