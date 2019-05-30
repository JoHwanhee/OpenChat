using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMe.Enums;
using ChatMe.Models;
using ChatMe.Utils;

namespace ChatMe.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Room _currentRoom;

        private WindowModes _userMode;
        public WindowModes UserMode
        {
            get => _userMode;
        }

        public ObservableCollection<Participant> Participants { get; }
        public ObservableCollection<ChatMessage> ChatMessages { get; }

        public MainWindowViewModel(Room currentRoom)
        {
            _currentRoom = currentRoom;
            _userMode = WindowModes.Chat;
            Participants = _currentRoom.Participants.ToObservableCollection();
            ChatMessages = _currentRoom.ChatMessages.ToObservableCollection();
        }
    }
}
