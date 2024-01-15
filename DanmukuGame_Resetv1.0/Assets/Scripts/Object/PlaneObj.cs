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
        //如果在选择角色面板
        if (IsSelectPanel)
        {
            //上下移动
            this.transform.Translate(Vector3.up * Mathf.Cos(Time.time) * Time.deltaTime * 0.1f);
        }
        this.transform.Translate(Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * 20);
        this.transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.forward * Time.deltaTime * 20);
    }
}
