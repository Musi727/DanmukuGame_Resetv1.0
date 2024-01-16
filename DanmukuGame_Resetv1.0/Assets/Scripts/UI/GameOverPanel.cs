using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public override void Init()
    {
        
    }
    protected override void OnValueChange(string name, string value)
    {
        switch(name)
        {
            case "inputFiled":
                GetController<InputField>("inputFiled").text = value;
                break;
        }
    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnSure":
                //提交给排行榜
                //GetController<InputField>("inputFiled").text;
                break;
        }
    }
}
