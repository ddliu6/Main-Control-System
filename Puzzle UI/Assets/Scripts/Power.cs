using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Power : MonoBehaviour
{
    [SerializeField] Sprite[] code;
    [SerializeField] Sprite[] invalid;
    [SerializeField] GameObject errMsg;
    [SerializeField] InputField inputCode;
    [SerializeField] Image powerCode;
    [SerializeField] Text powerLevel;

    string[] powerCodes = { "553-EDX", "327", "Ursa Major", "Cypher", "Overheating", "Defense" };
    string input = "";
    int curPower = 0, codeUsed = 0;

    void Start()
    {
        Init();
        powerLevel.text = curPower.ToString();
        if (codeUsed < 6)
            powerCode.sprite = code[codeUsed];
        else
        {
            errMsg.GetComponent<Image>().sprite = invalid[0];
            errMsg.SetActive(true);
        }
    }

    void Init()
    {
        codeUsed = SavedVariables.instance.powerCodes;
        curPower = SavedVariables.instance.curPower;
    }

    public void GetInput(string s)
    {
        input = s;
        Debug.Log(input);
    }

    public void CheckPowerCodes(string typeIn)
    {
        if (powerCodes[codeUsed] == typeIn)
        {
            curPower += 50 * ++codeUsed;
            SavedVariables.instance.SavePower(curPower, codeUsed);
            powerLevel.text = curPower.ToString();
            if(codeUsed < 6)
                powerCode.sprite = code[codeUsed];
            else
            {
                errMsg.GetComponent<Image>().sprite = invalid[0];
                errMsg.SetActive(true);
            }
        }
        else
        {
            errMsg.GetComponent<Image>().sprite = invalid[1];
            errMsg.SetActive(true);
        }
    }

    public void Submit()
    {
        inputCode.text = "";
        if(codeUsed < 6)
            CheckPowerCodes(input);
    }

    public void GoBack()
    {
        if (codeUsed < 6)
            SceneManager.LoadScene(1);
    }

    public void CloseMsg()
    {
        if (codeUsed < 6)
            errMsg.SetActive(false);
        else
            SceneManager.LoadScene(1);
    }
}
