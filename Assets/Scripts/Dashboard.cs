using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dashboard : MonoBehaviour
{
    [SerializeField] GameObject powerBtn;
    [SerializeField] Sprite powerUp;
    bool hasPower = false;

    void Start()
    {
        if (SavedVariables.instance != null)
            if (SavedVariables.instance.upgradeCodes >= 2)
            {
                powerBtn.GetComponent<Image>().sprite = powerUp;
                hasPower = true;
            } 
    }

    public void GoEmail()
    {
        SceneManager.LoadScene(2);
    }
    
    public void GoUpgrade()
    {
        SceneManager.LoadScene(3);
    }
    
    public void GoPower()
    {
        if(hasPower)
            SceneManager.LoadScene(4);
    }
    
    public void GoLaunch()
    {
        SceneManager.LoadScene(5);
    }
}
