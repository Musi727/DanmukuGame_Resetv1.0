using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : BasePanel
{
    private Transform _planePos;
    private int _index; //当前选择飞机的索引
    private List<PlaneInfo> _infoList;
    private GameObject _nowPrefab;
    public override void Init()
    {
        _index = 0;
        _infoList = DataMgr.Instance.PlaneInfoList;
    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnBack":
                UIMgr.Instance.HidePanel<SelectPanel>("SelectPanel");
                UIMgr.Instance.ShowPanel<BeginPanel>("BeginPanel",E_UI_Layer.mid,(panel)=>{});
                ClearPrefab();
                break;
            case "btnLeft":
                _index--;
                if (_index < 0)
                    _index = _infoList.Count - 1;
                InitPlaneInfo(_infoList[_index]);
                break;
            case "btnRight":
                _index++;
                if (_index >= _infoList.Count)
                    _index = 0;
                InitPlaneInfo(_infoList[_index]);
                break;
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //获得玩家预制体生成的位置
        _planePos = this.transform.Find("planePos");
        //打开该界面时，初始化飞机模型信息
        InitPlaneInfo(DataMgr.Instance.PlaneInfoList[_index]);
    }
    public void InitPlaneInfo(PlaneInfo info)
    {
        //首先清除上一次的模型
        ClearPrefab();
        //首先加载模型
        PoolMgr.Instance.GetGameObject("Airplane/" + info.modelRes, (plane) =>
        {
            plane.transform.position = _planePos.position;
            plane.transform.rotation = _planePos.rotation;
            plane.transform.localScale = info.scale * Vector3.one;
            //记录当前预制体
            _nowPrefab = plane;
        });
        //配置对应数据
        GetController<Text>("txtHpNum").text = info.hp.ToString();
        GetController<Text>("txtSpeedNum").text = info.speed.ToString();
        GetController<Text>("txtVolumeNum").text = info.volume.ToString();
    }
    public void ClearPrefab()
    {
        if (_nowPrefab != null)
        {
            PoolMgr.Instance.PushGameObject(_nowPrefab.gameObject.name, _nowPrefab.gameObject);
            _nowPrefab = null;
        }
    }
}
