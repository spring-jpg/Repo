using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // 设置界面（在 Inspector 里拖进去）
    public GameObject settingsCanvas;

    // 点击“Settings”按钮时调用
    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
    }

    // 点击“关闭”按钮时调用
    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);
    }
}

    

