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
    private bool _isCanMove = true;
    public bool IsCanMove
    {
        get => _isCanMove;
        set => _isCanMove = value;
    }
    private PlaneInfo _roleInfo ;
    private Quaternion _rotation; //记录战机出生时的四元数
    public 
    // Start is called before the first frame update
    void Start()
    {
        _rotation = this.transform.rotation;
        _roleInfo = DataMgr.Instance.PlaneInfoList[DataMgr.Instance.SelectRoleID];
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
        if (IsCanMove)
        {
            this.transform.Translate(Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            this.transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.up * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            //允许玩家战机可以有旋转效果
            this.transform.rotation = Quaternion.AngleAxis(30 * Input.GetAxisRaw("Horizontal"), Vector3.up) * _rotation;
        }
    }
}
