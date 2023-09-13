using UnityEngine;
using System;

namespace Silverdale
{
    public class MobileDialogConfirm : MonoBehaviour
    {
        #region PUBLIC_VARIABLES

        public Action yesAction;
        public Action noAction;
        public string title;
        public string message;
        public string yes;
        public string no;
        public string urlString;

        #endregion

        #region PUBLIC_FUNCTIONS

        // Constructor
        public static MobileDialogConfirm Create(string title, string message, string yes, string no, Action yesAction, Action noAction)
        {
            MobileDialogConfirm dialog;
#if UNITY_ANDROID
	        dialog = new GameObject("AndroidDialogPopup").AddComponent<MobileDialogConfirm>();
#else
	        dialog = new GameObject("MobileDialogConfirm").AddComponent<MobileDialogConfirm>();
#endif
	        dialog.title = title;
            dialog.message = message;
            dialog.yes = yes;
            dialog.no = no;
            dialog.yesAction = yesAction;
            dialog.noAction = noAction;
            dialog.init();
            return dialog;
        }

        public void init()
        {
            MobileNative.showDialogConfirm(title, message, yes, no, yesAction, noAction);
        }

        #endregion

        public void OnDialogPopUpCallBack(string buttonIndex)
        {
	        int index = Convert.ToInt16(buttonIndex);

	        switch (index)
	        {
		        case 0:
			        OnYesCallBack("1");
			        break;
		        case 1:
			        OnNoCallBack("0");
			        break;
	        }
	        Destroy(gameObject);
        }
        
        #region IOS_EVENT_LISTENER
        public void OnYesCallBack(string message)
        {
            if (yesAction != null)
            {
                yesAction();
            }
            Destroy(gameObject);
        }
        public void OnNoCallBack(string message)
        {
            if (noAction != null)
            {
                noAction();
            }
            Destroy(gameObject);
        }
        #endregion
    }
}