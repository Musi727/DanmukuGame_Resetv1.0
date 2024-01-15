using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : BaseManager<DataMgr>
{
    public int SelectRoleID;
    private MusicData _musicData = new MusicData();
    public MusicData MusicData => _musicData;
    private List<PlaneInfo> _planeInfoList = new List<PlaneInfo>();
    public List<PlaneInfo> PlaneInfoList => _planeInfoList;
    private List<TowerInfo> _towerInfoList = new List<TowerInfo>();
    public List<TowerInfo> TowerInfoList => _towerInfoList;
    private List<BulletInfo> _bulletInfoList = new List<BulletInfo>();
    public List<BulletInfo> BulletInfosList => _bulletInfoList;

    public void Init()
    {
        _musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        _planeInfoList = JsonMgr.Instance.LoadData<List<PlaneInfo>>("PlaneInfo");
        _towerInfoList = JsonMgr.Instance.LoadData<List<TowerInfo>>("TowerInfo");
        _bulletInfoList = JsonMgr.Instance.LoadData<List<BulletInfo>>("BulletInfo");
    } 
    public void SaveSettingData()
    {
        JsonMgr.Instance.SaveData(_musicData, ("MusicData"));
    }
}
