using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
   

   
    public GameObject infoWindow;  // ��Ʒ��鵯��
    public Button openInfoButton;  // �򿪼��İ�ť
    public Button closeInfoButton; // �رռ��İ�ť

    void Start()
    {
        // Ϊ��ť��ӵ���¼�
        openInfoButton.onClick.AddListener(OpenInfoWindow);
        closeInfoButton.onClick.AddListener(CloseInfoWindow);

        // ȷ����ʼ״̬�µ��������ص�
        infoWindow.SetActive(false);
    }

    // �򿪼�鵯��
    void OpenInfoWindow()
    {
        infoWindow.SetActive(true);
    }

    // �رռ�鵯��
    void CloseInfoWindow()
    {
        infoWindow.SetActive(false);
    }
}


