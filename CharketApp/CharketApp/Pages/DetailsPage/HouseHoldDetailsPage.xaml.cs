using CharketApp.Model;
using CharketApp.Model.RealChat;
using CharketApp.ViewModel.ChatViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CharketApp.Pages.DetailsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseHoldDetailsPage : ContentPage
    {
        SupermarketChatViewModel superViewModel;
        public HouseHoldDetailsPage(Model.UserData item)
        {
            InitializeComponent();
            superViewModel = new SupermarketChatViewModel();
            superViewModel.GetRoomChat(item.UserName);
            this.BindingContext = superViewModel;
            this.Title = item.UserName;
            if (superViewModel.ChatCollection.Count > 0)
            {
                _lstChat.ScrollTo(superViewModel.ChatCollection[superViewModel.ChatCollection.Count - 1], ScrollToPosition.End, false);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (superViewModel.ChatCollection.Count > 0)
            {
                _lstChat.ScrollTo(superViewModel.ChatCollection[superViewModel.ChatCollection.Count - 1], ScrollToPosition.End, false);
            }
        }
      

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(_etMessage.Text))
            {
                var chatOBJ = new Chat { UserMessage = _etMessage.Text, UserName = DataInfo.UserDataInfo.UserName };
                await superViewModel.SaveMessage(chatOBJ);
                _etMessage.Text = "";
                _lstChat.ScrollTo(superViewModel.ChatCollection[superViewModel.ChatCollection.Count - 1], ScrollToPosition.End, false);
            }
        }
    }
}