using CharketApp.Model;
using CharketApp.Services;
using System;

using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CharketApp.ViewModel
{
    public class CharityHomeViewModel : BaseViewModel
    {
        private ObservableCollection<UserData> _UserCollcetion;
        public ObservableCollection<UserData> UserCollcetion { get { return _UserCollcetion; } set { SetProperty(ref _UserCollcetion, value); } }
        DBFirebase firebase;
        public CharityHomeViewModel()
        {
            firebase = new DBFirebase();
            LoadUsers();
        }

        public async void LoadUsers()
        {
            var result = await firebase.GetAllUser();
            
            if (result != null)
            {
                result = result.Where(x => x.UserName != DataInfo.UserDataInfo.UserName).ToList();
                UserCollcetion = new ObservableCollection<UserData>(result);
            }
        }

    }
}
