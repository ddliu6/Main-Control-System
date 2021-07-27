using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launch : MonoBehaviour
{
    [SerializeField] GameObject warnMsg;
    int totalPower = 0;
    bool isChecked = false;

    void Start()
    {
        totalPower = SavedVariables.instance.curPower;
    }

    public void GoLaunch()
    {
        if (!isChecked)
            warnMsg.SetActive(true);
        else
        {
            //video shows up
            Debug.Log("Total Power: " + totalPower);
            Debug.Log("Show Video!");
        }
        isChecked = true;
    }

    public void GoBack()
    {
        if(!isChecked)
            SceneManager.LoadScene(1);
        else
        {
            warnMsg.SetActive(false);
            isChecked = false;
        }
    }
}
