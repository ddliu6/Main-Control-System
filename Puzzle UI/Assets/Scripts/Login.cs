using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] GameObject pwdPanel;
    [SerializeField] GameObject errMsg;
    [SerializeField] Sprite invalid;
    [SerializeField] InputField inputCode;

    string loginPwd = "OPHEL", input;

    public void GetInput(string s)
    {
        input = s;
        Debug.Log(input);
    }

    public void CheckPwd(string typeIn)
    {
        if (loginPwd == typeIn)
            SceneManager.LoadScene(1);
        else
        {
            errMsg.GetComponent<Image>().sprite = invalid;
            errMsg.SetActive(true);
        }
    }

    public void GoLogin()
    {
        gameObject.SetActive(false);
        pwdPanel.SetActive(true);
    }

    public void Submit()
    {
        CheckPwd(input);
        inputCode.text = "";
    }

    public void GoBack()
    {
        pwdPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public void CloseMsg()
    {
        errMsg.SetActive(false);
    }
}
