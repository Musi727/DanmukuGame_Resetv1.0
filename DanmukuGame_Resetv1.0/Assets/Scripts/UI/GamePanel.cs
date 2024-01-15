using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel
{
    public override void Init()
    {
       
       
    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnBack":
                SceneMgr.Instance.LoadSceneAsync("StartScene", () =>
                {
                    UIMgr.Instance.HidePanel<GamePanel>("GamePanel");
                });
                break;
        }
    }
}
