using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel
{
    public override void Init()
    {
        
    }
    protected override void OnClick(string name)
    {
        switch(name)
        {
            case "btnClose":
                UIMgr.Instance.HidePanel<RankPanel>("RankPanel");
                break;
        }
    }
}
