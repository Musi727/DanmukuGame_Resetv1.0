using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr : BaseManager<DataMgr>
{
    private MusicData _musicData = new MusicData();
    public MusicData MusicData => _musicData;

    public void Init()
    {
        _musicData = JsonMgr.Instance.LoadData<MusicData>("MusicData");
    } 
}
