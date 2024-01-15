using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPanel : BasePanel
{
    public override void Init()
    {
        
    }
    //通过脚本添加控件
    protected override void OnClick(string name)
    {
        switch(name)
        {
            case "btnStart":
                //跳转到游戏面板
                //关闭当前面板
                UIMgr.Instance.HidePanel<BeginPanel>("BeginPanel");
                UIMgr.Instance.ShowPanel<SelectPanel>("SelectPanel",E_UI_Layer.mid,(panel)=>{});
                break;
            case "btnRank":
                UIMgr.Instance.ShowPanel<RankPanel>("RankPanel",E_UI_Layer.mid,(panel)=>{});
                break;
            case "btnSetting":
                UIMgr.Instance.ShowPanel<SettingPanel>("SettingPanel", E_UI_Layer.mid, (panel) => { });
                break;
            case "btnQuit":
                Application.Quit();
                break;
        }
    }
}
