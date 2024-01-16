using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    private float _time;
    public override void Init()
    {
        UpdateHp();
    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnBack":
                UIMgr.Instance.ShowPanel<QuitPanel>("QuitPanel", E_UI_Layer.mid, (panel) => { });
                break;
        }
    }
    protected override void Update()
    {
        _time += Time.deltaTime;
        base.Update();
        //更新时间
        UpdateTime((int)_time);
    }
    public void UpdateTime(int time)
    {
        //时,分，秒
        string str = "";
        string hours = time / 3600 != 0 ? (time / 3600).ToString() + "h" : "";
        string minutes = time % 3600 / 60 != 0 ? (time % 3600 / 60).ToString() +"m" : "";
        string seconds = time % 60 != 0 ? (time % 60).ToString()+"s" : "";
        GetController<Text>("txtTimeNum").text = str + hours + minutes + seconds;
    }
    public void UpdateHp()
    {
        GetController<Text>("txtHpNum").text = PlaneObj.Player.Hp.ToString();
    }
}
