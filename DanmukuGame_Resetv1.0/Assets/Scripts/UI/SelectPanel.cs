using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPanel : BasePanel
{
    public override void Init()
    {
    
    }
    protected override void OnClick(string name)
    {
        switch(name)
        {
            case "btnBack":
                UIMgr.Instance.HidePanel<SelectPanel>("SelectPanel");
                UIMgr.Instance.ShowPanel<BeginPanel>("BeginPanel",E_UI_Layer.mid,(panel)=>{});
                break;
        }
    }

}
