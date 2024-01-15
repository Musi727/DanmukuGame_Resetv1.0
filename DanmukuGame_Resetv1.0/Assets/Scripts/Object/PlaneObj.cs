using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObj : MonoBehaviour
{
    private bool _isSelectPanel;
    public bool IsSelectPanel
    {
        get { return _isSelectPanel; }
        set
        {
            _isSelectPanel = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�����ѡ���ɫ���
        if (IsSelectPanel)
        {
            //�����ƶ�
            this.transform.Translate(Vector3.up * Mathf.Cos(Time.time) * Time.deltaTime * 0.1f);
        }
    }
}