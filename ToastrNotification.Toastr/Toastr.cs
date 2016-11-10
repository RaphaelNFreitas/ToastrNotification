using System;
using System.Collections.Generic;
using ToastrNotification.Toastr.Enum;

namespace ToastrNotification.Toastr
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Toastr
    {
        public Toastr()
        {
            ToastMessages = new List<ToastMessage>();
        }

        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public IList<ToastMessage> ToastMessages { get; set; }
        public string Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="toastType"></param>
        /// <returns></returns>
        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            var toast = new ToastMessage
            {
                Title = title,
                Message = message,
                ToastType = toastType
            };

            ToastMessages.Add(toast);
            return toast;
        }
    }
}