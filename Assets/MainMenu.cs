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

   
    // ���ý��棨�� Inspector ���Ͻ�ȥ��
    public GameObject settingsCanvas;

    // �����Settings����ťʱ����
    public void OpenSettings()
    {
        settingsCanvas.SetActive(true);
    }

    // ������رա���ťʱ����
    public void CloseSettings()
    {
        settingsCanvas.SetActive(false);
    }
}

    

