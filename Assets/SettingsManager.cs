using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
   

   
    public GameObject infoWindow;  // 作品简介弹窗
    public Button openInfoButton;  // 打开简介的按钮
    public Button closeInfoButton; // 关闭简介的按钮

    void Start()
    {
        // 为按钮添加点击事件
        openInfoButton.onClick.AddListener(OpenInfoWindow);
        closeInfoButton.onClick.AddListener(CloseInfoWindow);

        // 确保初始状态下弹窗是隐藏的
        infoWindow.SetActive(false);
    }

    // 打开简介弹窗
    void OpenInfoWindow()
    {
        infoWindow.SetActive(true);
    }

    // 关闭简介弹窗
    void CloseInfoWindow()
    {
        infoWindow.SetActive(false);
    }
}


