using UnityEngine;
using System;

namespace Silverdale
{
    public class MobileDialogInfo : MonoBehaviour
    {

        #region PUBLIC_VARIABLES

        public Action okAction;
        public string title;
        public string message;
        public string ok;

        #endregion

        #region PUBLIC_FUNCTIONS

        public static MobileDialogInfo Create(string title, string message, string ok, Action okAction)
        {
            MobileDialogInfo dialog;
            
#if UNITY_ANDROID
	        dialog = new GameObject("AndroidMessagePopup").AddComponent<MobileDialogInfo>();
#else
            dialog = new GameObject("MobileDialogInfo").AddComponent<MobileDialogInfo>();
#endif
            dialog.title = title;
            dialog.message = message;
            dialog.ok = ok;
            dialog.okAction = okAction;

            dialog.init();
            return dialog;
        }

        public void init()
        {
            MobileNative.showInfoPopup(title, message, ok, okAction);
        }

        #endregion

        public void OnDialogPopUpCallBack(string buttonIndex)
        {
            int index = Convert.ToInt16(buttonIndex);

            switch (index)
            {
                case 0:
                    OnOkCallBack("0");
                    break;
                case 1:
                    OnOkCallBack("0");
                    break;
            }
            Destroy(gameObject);
        }
        
        #region IOS_EVENT_LISTENER
        public void OnOkCallBack(string message)
        {
            if (okAction != null)
            {
                okAction();
            }
            Destroy(gameObject);
        }

        #endregion
    }
}