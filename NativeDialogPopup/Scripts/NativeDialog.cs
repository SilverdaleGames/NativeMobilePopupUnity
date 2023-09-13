using System;

namespace Silverdale
{
    public class NativeDialog
    {
        public NativeDialog() { }

        public static void OpenDialog(string title, string message, string ok = "Ok", Action okAction = null)
        {
            MobileDialogInfo.Create(title, message, ok, okAction);
        }
        public static void OpenDialog(string title, string message, string yes, string no, Action yesAction = null, Action noAction = null)
        {
            MobileDialogConfirm.Create(title, message, yes, no, yesAction, noAction);
        }
    }
}