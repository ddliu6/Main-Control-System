using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    [SerializeField] GameObject errMsg;
    [SerializeField] GameObject[] upgrade;
    [SerializeField] Sprite[] used;
    [SerializeField] InputField inputCode;
    [SerializeField] Text powerLevel;

    string[] sensorCodes = { "CAO19Y", "YIZ97H", "ZHE09C", "AOY02I", "EASY00" },
             enegryCodes = { "Y1U2E8", "R3V6B8", "EVT354", "EXS150", "JMP404" },
             weaponCodes = { "DD1IU6", "G12E4T", "134D55", "5H4M17", "L05E12" },
             sheildCodes = { "Y1IZHE", "YZ2HCA", "ZHE3YI", "ZHEC4Y", "CAOZH5" };
    string input = "";
    int curPower = 0, codeUsed = 0;
    bool sensorUpgraded = false, energyUpgraded = false, weaponUpgraded = false, shieldUpgraded = false;

    void Start()
    {
        Init();
        powerLevel.text = curPower.ToString();
        upgrade[0].SetActive(sensorUpgraded);
        upgrade[1].SetActive(energyUpgraded);
        upgrade[2].SetActive(weaponUpgraded);
        upgrade[3].SetActive(shieldUpgraded);
    }

    void Init()
    {
        codeUsed = SavedVariables.instance.upgradeCodes;
        curPower = SavedVariables.instance.curPower;
        sensorUpgraded = SavedVariables.instance.sensorUpgraded;
        energyUpgraded = SavedVariables.instance.energyUpgraded;
        weaponUpgraded = SavedVariables.instance.weaponUpgraded;
        shieldUpgraded = SavedVariables.instance.shieldUpgraded;
    }

    public void GetInput(string s)
    {
        input = s;
        Debug.Log(input);
    }

    public void CheckCodes(string typeIn)
    {
        bool isChecked = false;
        //check sensor
        for (int i = 0; i < sensorCodes.Length; ++i)
        {
            if (sensorCodes[i] == typeIn)
            {
                if (!sensorUpgraded)
                {
                    sensorUpgraded = true;
                    curPower += 200 * (5 - i);
                    SavedVariables.instance.SaveUpgrade(curPower, ++codeUsed, sensorUpgraded, energyUpgraded, weaponUpgraded, shieldUpgraded);
                    powerLevel.text = curPower.ToString();
                    upgrade[0].SetActive(true);
                }
                else
                {
                    errMsg.GetComponent<Image>().sprite = used[0];
                    errMsg.SetActive(true);
                }
                i = sensorCodes.Length;
                isChecked = true;
            }
        }

        if(!isChecked)
        {
            //check energy
            for (int i = 0; i < enegryCodes.Length; ++i)
            {
                if (enegryCodes[i] == typeIn)
                {
                    if (!energyUpgraded)
                    {
                        energyUpgraded = true;
                        curPower += 200 * (5 - i);
                        SavedVariables.instance.SaveUpgrade(curPower, ++codeUsed, sensorUpgraded, energyUpgraded, weaponUpgraded, shieldUpgraded);
                        powerLevel.text = curPower.ToString();
                        upgrade[1].SetActive(true);
                    }
                    else
                    {
                        errMsg.GetComponent<Image>().sprite = used[1];
                        errMsg.SetActive(true);
                    }
                    i = sensorCodes.Length;
                    isChecked = true;
                }
            }
        }

        if (!isChecked)
        {
            //check weapon
            for (int i = 0; i < weaponCodes.Length; ++i)
            {
                if (weaponCodes[i] == typeIn)
                {
                    if (!weaponUpgraded)
                    {
                        weaponUpgraded = true;
                        curPower += 200 * (5 - i);
                        SavedVariables.instance.SaveUpgrade(curPower, ++codeUsed, sensorUpgraded, energyUpgraded, weaponUpgraded, shieldUpgraded);
                        powerLevel.text = curPower.ToString();
                        upgrade[2].SetActive(true);
                    }
                    else
                    {
                        errMsg.GetComponent<Image>().sprite = used[2];
                        errMsg.SetActive(true);
                    }
                    i = sensorCodes.Length;
                    isChecked = true;
                }
            }
        }

        if (!isChecked)
        {
            //check sheild
            for (int i = 0; i < sheildCodes.Length; ++i)
            {
                if (sheildCodes[i] == typeIn)
                {
                    if (!shieldUpgraded)
                    {
                        shieldUpgraded = true;
                        curPower += 200 * (5 - i);
                        SavedVariables.instance.SaveUpgrade(curPower, ++codeUsed, sensorUpgraded, energyUpgraded, weaponUpgraded, shieldUpgraded);
                        powerLevel.text = curPower.ToString();
                        upgrade[3].SetActive(true);
                    }
                    else
                    {
                        errMsg.GetComponent<Image>().sprite = used[3];
                        errMsg.SetActive(true);
                    }
                    i = sensorCodes.Length;
                    isChecked = true;
                }
            }
        }

        if (!isChecked)
        {
            errMsg.GetComponent<Image>().sprite = used[4];
            errMsg.SetActive(true);
        }
    }

    public void Submit()
    {
        inputCode.text = "";
        CheckCodes(input);
    }
    
    public void GoBack()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseMsg()
    {
        errMsg.SetActive(false);
    }
}
