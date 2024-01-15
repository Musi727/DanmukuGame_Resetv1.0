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

    public void Init()
    {
        _musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
        _planeInfoList = JsonMgr.Instance.LoadData<List<PlaneInfo>>("PlaneInfo");
    } 
    public void SaveSettingData()
    {
        JsonMgr.Instance.SaveData(_musicData, ("MusicData"));
    }
}
