using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedVariables : MonoBehaviour
{
    public static SavedVariables instance;
    public int curPower = 0, upgradeCodes = 0, powerCodes = 0;
    public bool sensorUpgraded = false, energyUpgraded = false, weaponUpgraded = false, shieldUpgraded = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveUpgrade(int power, int code, bool sensor, bool energy, bool weapon, bool shield)
    {
        curPower = power;
        upgradeCodes = code;
        sensorUpgraded = sensor;
        energyUpgraded = energy;
        weaponUpgraded = weapon;
        shieldUpgraded = shield;
        Debug.Log("curPower: " + curPower + " upgradeCodes: " + upgradeCodes + " sensorUpgraded: " + sensor + " energyUpgraded: " + energy + " weaponUpgraded: " + weapon + " shieldUpgraded: " + shield);
    }

    public void SavePower(int power, int code)
    {
        curPower = power;
        powerCodes = code;
        Debug.Log("curPower: " + curPower + " powerCodes: " + powerCodes);
    }
}
