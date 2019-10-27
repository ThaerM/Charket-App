namespace CharketApp.Model.RealChat
{
    public class UserChat
    {
        private static string _uid;
        public static string UserName
        {
            get { return _uid; }
            set { _uid = value; }
        }
        private UserChat() { }
    }
}
