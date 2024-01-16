using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanel : BasePanel
{
    public override void Init()
    {

    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnSure":
                SceneMgr.Instance.LoadSceneAsync("StartScene", () =>
                {
                    UIMgr.Instance.HidePanel<GamePanel>("GamePanel");
                    UIMgr.Instance.HidePanel<QuitPanel>("QuitPanel");
                });
                break;
            case "btnCancel":
                UIMgr.Instance.HidePanel<QuitPanel>("QuitPanel");
                break;
        }
    }
}
