using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public override void Init()
    {

    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnClose":
                UIMgr.Instance.HidePanel<SettingPanel>("SettingPanel");
                break;
        }
    }
    protected override void OnValueChange(string name, bool value)
    {
        switch(name)
        {
            case "ToggleMusic":
                GetController<Toggle>("ToggleMusic").isOn = value;
                break;
            case "ToggleSound":
                GetController<Toggle>("ToggleSound").isOn = value;
                break;
        }
    }
    protected override void OnValueChange(string name, float value)
    {
        switch(name)
        {
            case "SliderMusic":
                GetController<Slider>("SliderMusic").value = value;
                break;
            case "SliderSound":
                GetController<Slider>("SliderSound").value = value;
                break;
        }
    }
}
