using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Email : MonoBehaviour
{
    [SerializeField] GameObject[] mailBtn;
    [SerializeField] Sprite[] mailBody;

    bool isOpened = false;

    public void ReadEmail()
    {
        HideInbox();
        int n = int.Parse(EventSystem.current.currentSelectedGameObject.name[EventSystem.current.currentSelectedGameObject.name.Length - 1].ToString());
        GetComponent<Image>().sprite = mailBody[n];
    }

    public void GoBack()
    {
        if(isOpened)
            ShowInbox();
        else
            SceneManager.LoadScene(1);
    }

    void ShowInbox()
    {
        for (int i = 0; i < mailBtn.Length; ++i)
            mailBtn[i].SetActive(true);
        GetComponent<Image>().sprite = mailBody[0];
        isOpened = false;
    }

    void HideInbox()
    {
        for(int i = 0; i < mailBtn.Length; ++i)
            mailBtn[i].SetActive(false);
        isOpened = true;
    }    
}
