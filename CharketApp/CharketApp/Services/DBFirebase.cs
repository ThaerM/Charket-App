using CharketApp.Model;
using CharketApp.Model.RealChat;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CharketApp.Services
{
    public class DBFirebase
    {
        //Use to integration with database on firebase
        FirebaseClient _firebaseClient;
        //Use to integration with folder image on firebase
        FirebaseStorage _firebaseStorage;

        //Constructor
        public DBFirebase()
        {
            //Set the url of database
            _firebaseClient = new FirebaseClient(AppConstant.URLData);
            //Set the url of storage 
            _firebaseStorage = new FirebaseStorage(AppConstant.StorageURLData);
        }

        #region ChatSystem
        //Retrun all rooms avalibale 
        public async Task<List<RoomChat>> GetRoomList()
        {

            return (await _firebaseClient
                .Child("ChatApp")
                .OnceAsync<RoomChat>())
                .Select((item) =>
                new RoomChat
                {
                    Key = item.Key,
                    FromChat = item.Object.FromChat,
                    ToChat = item.Object.ToChat
                }).ToList();
        }
        //Retrun all rooms avalibale 
        public async Task<RoomChat> GetRoomList(string from, string to)
        {

            var result = (await _firebaseClient
                .Child("ChatApp")
                .OnceAsync<RoomChat>());
            var valueResult = result.Where(
                x =>(
                (x.Object.FromChat == from && x.Object.ToChat == to) ||
                (x.Object.FromChat == to && x.Object.ToChat == from)) 
            ).ToList();
            var resultx = valueResult.Select((item) =>
                               new RoomChat()
                               {
                                   ToChat = item.Object.ToChat,
                                   FromChat = item.Object.FromChat,
                                   Key = item.Key
                               }
            ).FirstOrDefault();

            return resultx;


        }
        //Save room/ chat between pepole
        public async Task SaveRoom(RoomChat _roomName)
        {
            await _firebaseClient
                .Child("ChatApp")
                .PostAsync(_roomName);
        }
        //save the chat on firebase
        public async Task SaveMessage(Chat _chat, string _room)
        {
            await _firebaseClient
                .Child("ChatApp/" + _room + "/Message")
                .PostAsync(_chat);
        }
        //Check if recive any message by message center
        public ObservableCollection<Chat> SubscriberChat(string _roomKey)
        {
            return _firebaseClient
                .Child("ChatApp/" + _roomKey + "/Message")
                .AsObservable<Chat>()
                .AsObservableCollection<Chat>();
        }
        #endregion

        #region Login 
        //Check the username and password for verfication 
        public async Task<UserData> LoginUser(string _userName, string _password)
        {
            var userData = (await _firebaseClient
                .Child("Users")
                .OnceAsync<UserData>()).
                Where(item => item.Object.UserName == _userName
                && item.Object.Password == _password)
                .FirstOrDefault();
            //Check if the user return with data or not
            if (userData == null)
            {
                //return empty when the userdata is null
                return null;
            }
            //Return the object if it not null
            return userData.Object;
        }
        #endregion

        #region Get,Add,Retive,Update,Delete
        //Get Data user by username
        public async Task<UserData> GetUser(string userName)
        {
            var userData = (await _firebaseClient
                .Child("Users")
                .OnceAsync<UserData>()).
                Where(item => item.Object.UserName == userName).FirstOrDefault();
            //Check if the user return with data or not
            if (userData == null)
            {
                //return empty when the userdata is null 
                return null;
            }
            //Return the object if it not null
            return userData.Object;
        }
        //Get All Data user  
        public async Task<List<UserData>> GetAllUser()
        {
            var userData = (await _firebaseClient
                .Child("Users")
                .OnceAsync<UserData>());
            //Check if the user return with data or not
            if (userData == null)
            {
                //return empty when the userdata is null 
                return null;
            }
            //Return the object if it not null
            return userData.Select(item => new UserData
            {
                FirstName = item.Object.FirstName,
                UserName = item.Object.UserName,
                CharityModel = item.Object.CharityModel,
                Email = item.Object.Email,
                HouseHoldModel = item.Object.HouseHoldModel,
                LastName = item.Object.LastName,
                Location = item.Object.Location,
                Password = item.Object.Password,
                PickUpTime = item.Object.PickUpTime,
                SuperMarket = item.Object.SuperMarket,
                UserType = item.Object.UserType,
                ImageName = string.IsNullOrEmpty(item.Object.ImageName) ? "Avatar1" : item.Object.ImageName

            }).ToList();
        }
        //Sign-up new user 
        public async Task OnSignUp(UserData userData)
        {
            await _firebaseClient.Child("Users")
                .PostAsync(userData);
        }
        //Update user data from firebase
        public async Task OnUpdateUser(UserData userData)
        {
            var toUpdateUser = (await _firebaseClient
                .Child("Users")
                .OnceAsync<UserData>()
                ).Where(item => item.Object.UserName == userData.UserName).FirstOrDefault();
            await _firebaseClient
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(userData);
        }
        //Remove user data from firebase
        public async Task OnDeleteUser(UserData userData)
        {
            var toDeleteUser = (await _firebaseClient
                .Child("Users")
                .OnceAsync<UserData>()
                ).Where(item => item.Object.UserName == userData.UserName).FirstOrDefault();

            await _firebaseClient
                .Child("Users")
                .Child(toDeleteUser.Key)
                .DeleteAsync();
        }

        #endregion

        #region Upload And Download And Delete File
        //On Request to upload file from firebase storage
        public async void OnUploadFile(Image imageController = null)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });

                if (file == null)
                    return;
                if (imageController != null)
                {
                    imageController.Source = ImageSource.FromStream(() =>
                    {
                        var imageStream = file.GetStream();
                        return imageStream;
                    });
                }
                await UploadFile(file.GetStream(), Path.GetFileName(file.Path));

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error " + ex.Message);
            }
        }
        //Uplaod image on the firebase storage
        async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageURL = await _firebaseStorage
                .Child("CharketAppStorage")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageURL;

        }
        //On Request to download file from firebase storage
        public async void OnDowndloadFile(string fileName)
        {
            string path = await DownloadFile(fileName);
            if (path != null)
            {
                Debug.WriteLine("Successfully");
            }
        }
        //Download file from firebase storage
        async Task<string> DownloadFile(string fileName)
        {
            return await _firebaseStorage
                .Child("CharketAppStorage")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        //On Request to remove the file from firebase
        public async void OnDeleteFile(string fileName)
        {
            await DeleteFile(fileName);
            Debug.WriteLine("Succesfully");
        }
        //Delete file from firebase storage
        async Task DeleteFile(string fileName)
        {
            await _firebaseStorage
                .Child("CharketAppStorage")
                .Child(fileName)
                .DeleteAsync();
        }
        #endregion
    }
}