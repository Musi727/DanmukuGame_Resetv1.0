using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : BasePanel
{
    public Transform Content;
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
    public override void ShowMe()
    {
        base.ShowMe();
        UpdateRankInfo(DataMgr.Instance.RankInfoList);
    }
    public void UpdateRankInfo(List<RankData> info)
    {
        for(int i = 0; i < info.Count; i++)
        {
            int index = i;
            //生成预制体
            PoolMgr.Instance.GetGameObject("UI/RankInfo", (obj) =>
            {
                obj.transform.SetParent(Content, false);
                obj.transform.localPosition = new Vector3(0, -100 * index, 0);
                obj.GetComponent<RankInfo>().UpdateInfo(DataMgr.Instance.RankInfoList[index]);
            });
        }
    }
}
