using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankInfo : MonoBehaviour
{
    public Text txtRanking;
    public Text txtName;
    public Text txtTime;
    private void OnEnable()
    {
        
    }
    public void UpdateInfo(RankData info)
    {
        txtRanking.text = info.id.ToString();
        txtName.text = info.name;
        txtTime.text = info.time;
    }
}
