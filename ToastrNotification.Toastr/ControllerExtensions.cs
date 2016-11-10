using System.Web.Mvc;
using ToastrNotification.Toastr.Enum;

namespace ToastrNotification.Toastr
{
    public static class ControllerExtensions
    {
        /// <summary>
        /// Extension for an asp net mvc controller, applying the message functionality toastrs
        /// </summary>
        /// <param name="controller">The controller to which the extension occurs does not have to be referenced</param>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="toastType"></param>
        /// <param name="toastPosition"></param>
        /// <param name="showCloseButton"></param>
        /// <param name="newestOnTop"></param>
        /// <returns></returns>
        public static ToastMessage AddToastMessage(this Controller controller,
           string title,
           string message,
           ToastType toastType,
           ToastPosition toastPosition = ToastPosition.TopRight,
           bool showCloseButton = false,
           bool newestOnTop = false)
        {
            var toast = (Toastr)controller.TempData["toastr"] ?? new Toastr();

            toast.ShowCloseButton = showCloseButton;
            toast.ShowNewestOnTop = newestOnTop;
            toast.Position = PositionToastr(toastPosition);

            var toastMessage = toast.AddToastMessage(title, message, toastType);
            controller.TempData["toastr"] = toast;

            return toastMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toastPosition"></param>
        /// <returns></returns>
        private static string PositionToastr(ToastPosition toastPosition)
        {
            string positionToastr;
            switch (toastPosition)
            {
                case ToastPosition.TopRight:
                    positionToastr = "toast-top-right";
                    break;
                case ToastPosition.TopLeft:
                    positionToastr = "toast-top-left";
                    break;
                case ToastPosition.BottomRight:
                    positionToastr = "toast-bottom-right";
                    break;
                case ToastPosition.BottomLeft:
                    positionToastr = "toast-bottom-left";
                    break;
                case ToastPosition.TopFullWidth:
                    positionToastr = "toast-top-full-width";
                    break;
                case ToastPosition.BottomFullWidth:
                    positionToastr = "toast-bottom-full-width";
                    break;
                case ToastPosition.TopCenter:
                    positionToastr = "toast-top-center";
                    break;
                case ToastPosition.BottomCenter:
                    positionToastr = "toast-bottom-center";
                    break;
                default:
                    positionToastr = "toast-top-right";
                    break;
            }
            return positionToastr;
        }
    }
}