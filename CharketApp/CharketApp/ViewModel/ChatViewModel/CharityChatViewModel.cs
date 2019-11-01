using CharketApp.Model;
using CharketApp.Model.RealChat;
using CharketApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CharketApp.ViewModel.ChatViewModel
{
   public class CharityChatViewModel : BaseViewModel
    {
        DBFirebase firebase;
        private ObservableCollection<Chat> _ChatCollection;
        public ObservableCollection<Chat> ChatCollection { get { return _ChatCollection; } set { SetProperty(ref _ChatCollection, value); } }
        private string _KeyRoom;
        public string KeyRoom
        {
            get { return _KeyRoom; }
            set { SetProperty(ref _KeyRoom, value); }
        }
        public CharityChatViewModel()
        {
            firebase = new DBFirebase();
            ChatCollection = new ObservableCollection<Chat>();
        }

        public async void GetRoomChat(string to)
        {
            var restult = await firebase.GetRoomList(DataInfo.UserDataInfo.UserName, to);
            if (restult != null)
            {
                KeyRoom = restult.Key;
                ChatCollection = firebase.SubscriberChat(restult.Key);
            }
            else
            {
                await firebase.SaveRoom(new RoomChat() { FromChat = DataInfo.UserDataInfo.UserName, ToChat = to });
                GetRoomChatAgain(to);
            }
        }

        public async void GetRoomChatAgain(string to)
        {
            var restult = await firebase.GetRoomList(DataInfo.UserDataInfo.UserName, to);
            if (restult != null)
            {
                KeyRoom = restult.Key;
                ChatCollection = firebase.SubscriberChat(restult.Key);
            }
        }

        public async Task SaveMessage(Chat chatOBJ)
        {
            await firebase.SaveMessage(chatOBJ, KeyRoom);
        }
    }
}
