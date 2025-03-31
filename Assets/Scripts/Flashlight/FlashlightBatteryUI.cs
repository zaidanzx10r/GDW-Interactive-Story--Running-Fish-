using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FlashlightBatteryUI : MonoBehaviour
{

    public Image BatteryBar;
    public FLController fLController;
    void Update()
    {
       // BatteryBar.fillAmount = fLController.batteryLife;
    }
}
