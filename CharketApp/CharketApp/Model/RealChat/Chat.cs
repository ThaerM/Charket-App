using System;

namespace CharketApp.Model.RealChat
{
    public class Chat
    {
        public string UserName
        {
            get; set;
        }
        public string UserMessage
        {
            get; set;
        }
        public bool IsMain
        {
            get
            {
                if (DataInfo.UserDataInfo.UserName == UserName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool IsBorder
        {
            get
            {
                if (DataInfo.UserDataInfo.UserName == UserName)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
