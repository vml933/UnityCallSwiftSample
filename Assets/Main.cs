using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Main : MonoBehaviour {

    public Button btnOpen;

    [DllImport("__Internal")]
    private static extern void myFunc();

    private void Awake()
    {
        btnOpen.onClick.AddListener(()=>{
            myFunc();
        });
    }
}
