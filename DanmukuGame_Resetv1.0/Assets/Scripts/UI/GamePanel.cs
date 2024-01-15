using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel
{
    private Transform _rolePos;
    public override void Init()
    {
        _rolePos = GameObject.Find("Pos").transform;
        //根据索引加载角色
        PoolMgr.Instance.GetGameObject("Airplane/" + DataMgr.Instance.PlaneInfoList[DataMgr.Instance.SelectRoleID].modelRes, (plane) =>
        {
            plane.transform.SetParent(_rolePos, false);
            if (plane.GetComponent<PlaneObj>() == null)
                plane.AddComponent<PlaneObj>();
        });
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
