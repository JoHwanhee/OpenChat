using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMe.Models;
using ChatMe.ViewModels;
using SuperSocket.SocketBase.Command;

namespace ChatMe.Data
{
    public class SampleMainWindowViewModel : ViewModelBase
    {
        private Room _currentRoom;
        
        private ObservableCollection<Participant> _participants = new ObservableCollection<Participant>();
        public ObservableCollection<Participant> Participants
        {
            get { return _participants; }
            set
            {
                _participants = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ChatMessage> ChatMessages { get; }

        public ICommand OpenImageCommand
        {
            get { throw new NotImplementedException(); }
        }


        public SampleMainWindowViewModel()
        {
            ObservableCollection<ChatMessage> someChatter = new ObservableCollection<ChatMessage>();
            someChatter.Add(new ChatMessage
            {
                Author = "Batman",
                Message = "What do you think about the Batmobile?",
                Time = DateTime.Now,
                IsOriginNative = true
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Batman",
                Message = "Coolest superhero ride?",
                Time = DateTime.Now,
                IsOriginNative = true
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Superman",
                Message = "Only if you don't have superpowers :P",
                Time = DateTime.Now
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Batman",
                Message = "I'm rich. That's my superpower.",
                Time = DateTime.Now,
                IsOriginNative = true
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Superman",
                Message = ":D Lorem Ipsum something blah blah blah blah blah blah blah blah. Lorem Ipsum something blah blah blah blah.",
                Time = DateTime.Now
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Batman",
                Message = "I have no feelings",
                Time = DateTime.Now,
                IsOriginNative = true
            });
            someChatter.Add(new ChatMessage
            {
                Author = "Batman",
                Message = "How's Martha?",
                Time = DateTime.Now,
                IsOriginNative = true
            });
            ChatMessages = someChatter;
            //Participants.Add(new Participant { Name = "Superman", Chatter = someChatter, IsTyping = true, IsLoggedIn = true });
            //Participants.Add(new Participant { Name = "Wonder Woman", Chatter = someChatter, IsLoggedIn = false });
            //Participants.Add(new Participant { Name = "Aquaman", Chatter = someChatter, HasSentNewMessage = true });
            //Participants.Add(new Participant { Name = "Captain Canada", Chatter = someChatter, HasSentNewMessage = true });
            //Participants.Add(new Participant { Name = "Iron Man", Chatter = someChatter, IsTyping = true });

        }
    }
}
