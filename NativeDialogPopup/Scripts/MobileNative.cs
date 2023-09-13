using System;
using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Silverdale
{
	public class MobileNative
    {

#if UNITY_IOS
        [DllImport("__Internal")]
        private static extern void _TAG_ShowDialogConfirm(string title, string message, string yes, string no);

        [DllImport("__Internal")]
        private static extern void _TAG_ShowDialogInfo(string title, string message, string ok);
#endif

        /// <summary>
        /// Calls a Native Confirm Dialog on iOS and Android
        /// </summary>
        /// <param name="title">Dialog title text</param>
        /// <param name="message">Dialog message text</param>
        /// <param name="yes">Accept Button text</param>
        /// <param name="no">Cancel Button text</param>
        /// <param name="cancelable">Android only. Allows setting the cancelable property of the dialog</param>
        public static void showDialogConfirm(string title, string message, string yes, string no, Action yesAction = null, Action noAction = null, bool cancelable = true)
        {
#if UNITY_EDITOR
			var result = EditorUtility.DisplayDialog(title, message, yes, no);
			if (result) yesAction?.Invoke();
			else noAction?.Invoke();
#elif UNITY_IOS
            _TAG_ShowDialogConfirm(title, message, yes, no);
#elif UNITY_ANDROID
           AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.tag.nativepopup.PopupManager");
            javaUnityClass.CallStatic("ShowDialogPopup", title, message, yes, no);
#endif
        }

        public static void showInfoPopup(string title, string message, string ok, Action yesAction = null)
        {
#if UNITY_EDITOR
	        var result = EditorUtility.DisplayDialog(title, message, ok);
	        if (result) yesAction?.Invoke();
#elif UNITY_IOS
            _TAG_ShowDialogInfo(title, message, ok);
#elif UNITY_ANDROID
            AndroidJavaClass javaUnityClass = new AndroidJavaClass("com.tag.nativepopup.PopupManager");
            javaUnityClass.CallStatic("ShowMessagePopup", title, message, ok);
#endif
        }
    }
}