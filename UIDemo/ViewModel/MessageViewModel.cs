using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;
using static UIDemo.Model.MessageModel;

namespace UIDemo.ViewModel
{
    class MessageViewModel : ViewModelBase
    {
        public override IModel Model { get; } = new MessageModel();

        private List<Message> messages;
        public List<Message> Messages
        {
            get
            {
                if (messages is null || messages.Count == 0)
                {
                    return new List<Message>() { new Message("Нет сообщений", "", DateTime.Now) };
                }
                else { return messages; }
            }
            private set
            {
                messages = value;
                OnPropertyChanged();
            }
        }
        public MessageViewModel()
        {
            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            Messages = await (Model as MessageModel).GetRandomQuotesAsMessages();
        }
    }
}