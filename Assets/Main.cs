using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Main : MonoBehaviour {

    public Button btnAlert;
    public Button btnCustomPage;
    public Button btnGetDummyStr;

    [DllImport("__Internal")]
    private static extern void showAlert(string msg);
    [DllImport("__Internal")]
    private static extern void toCustomPage();
    [DllImport("__Internal")]
    private static extern string getDummyStr();


    private void Awake()
    {
#if UNITY_IOS && !UNITY_EDITOR

        btnAlert.onClick.AddListener(()=>{
            showAlert("msg from unity");
        });

        btnCustomPage.onClick.AddListener(() => {
            toCustomPage();
        });

        btnGetDummyStr.onClick.AddListener(() => {
            print(getDummyStr());
        });

#endif

    }

}
