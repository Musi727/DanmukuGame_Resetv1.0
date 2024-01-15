using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public override void Init()
    {

    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnClose":
                //�Ƚ������״̬��ֵ�����ݹ�������
                //�ر�ʱ����Setting����
                DataMgr.Instance.MusicData.isOpenMusic = GetController<Toggle>("ToggleMusic").isOn;
                DataMgr.Instance.MusicData.isOpenSound = GetController<Toggle>("ToggleSound").isOn;
                DataMgr.Instance.MusicData.musicValue = GetController<Slider>("SliderMusic").value;
                DataMgr.Instance.MusicData.soundValue = GetController<Slider>("SliderSound").value;
                DataMgr.Instance.SaveSettingData();
                UIMgr.Instance.HidePanel<SettingPanel>("SettingPanel");
                break;
        }
    }
    protected override void OnValueChange(string name, bool value)
    {
        switch(name)
        {
            case "ToggleMusic":
                GetController<Toggle>("ToggleMusic").isOn = value;
                MusicMgr.Instance.BkMusic.mute = !value;
                break;
            case "ToggleSound":
                GetController<Toggle>("ToggleSound").isOn = value;
                break;
        }
    }
    protected override void OnValueChange(string name, float value)
    {
        switch(name)
        {
            case "SliderMusic":
                GetController<Slider>("SliderMusic").value = value;
                MusicMgr.Instance.BkMusic.volume = value;
                break;
            case "SliderSound":
                GetController<Slider>("SliderSound").value = value;
                break;
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        InitSettingInfo();
        
    }
    public void InitSettingInfo()
    {
        //�򿪸����ʱ��Ҫ��ȡ����
        GetController<Slider>("SliderMusic").value = DataMgr.Instance.MusicData.musicValue;
        GetController<Slider>("SliderSound").value = DataMgr.Instance.MusicData.soundValue;
        GetController<Toggle>("ToggleMusic").isOn = DataMgr.Instance.MusicData.isOpenMusic;
        GetController<Toggle>("ToggleSound").isOn = DataMgr.Instance.MusicData.isOpenSound;
    }

}
