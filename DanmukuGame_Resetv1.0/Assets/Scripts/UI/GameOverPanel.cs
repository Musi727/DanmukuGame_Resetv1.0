using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public override void Init()
    {
        UpdateTime((int)Consts.Time);
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
                DataMgr.Instance.AddRankData(new RankData(GetController<InputField>("inputFiled").text, Consts.Time.ToString() + "s"));
                SceneMgr.Instance.LoadScene("StartScene", () =>
                {
                    UIMgr.Instance.HidePanel<GamePanel>("GamePanel");
                    UIMgr.Instance.HidePanel<GameOverPanel>("GameOverPanel");
                });
                break;
        }
    }
    public void UpdateTime(int time)
    {
        //时,分，秒
        string str = "";
        string hours = time / 3600 != 0 ? (time / 3600).ToString() + "h" : "";
        string minutes = time % 3600 / 60 != 0 ? (time % 3600 / 60).ToString() + "m" : "";
        string seconds = time % 60 != 0 ? (time % 60).ToString() + "s" : "";
        GetController<Text>("txtTime").text = str + hours + minutes + seconds;
    }
}
