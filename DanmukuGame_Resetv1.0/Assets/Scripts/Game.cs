using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //调用UIMgr生成开始界面
        UIMgr.Instance.ShowPanel<BeginPanel>("BeginPanel",E_UI_Layer.mid,(panel)=>{});
        //初始化游戏数据
        DataMgr.Instance.Init();
        //播放音乐
        MusicMgr.Instance.PlayBkMusic("John Williams - The Imperial March");
        MusicMgr.Instance.BkMusic.volume = DataMgr.Instance.MusicData.musicValue;
        MusicMgr.Instance.BkMusic.mute = !DataMgr.Instance.MusicData.isOpenMusic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
