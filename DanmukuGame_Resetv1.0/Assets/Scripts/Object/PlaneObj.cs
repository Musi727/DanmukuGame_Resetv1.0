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
    private Quaternion _rotation; //��¼ս������ʱ����Ԫ��
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
        //�����ѡ���ɫ���
        if (IsSelectPanel)
        {
            //�����ƶ�
            this.transform.Translate(Vector3.up * Mathf.Cos(Time.time) * Time.deltaTime * 0.1f);
        }
        if (IsCanMove)
        {
            this.transform.Translate(Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            this.transform.Translate(Input.GetAxisRaw("Vertical") * Vector3.up * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            //�������ս����������תЧ��
            this.transform.rotation = Quaternion.AngleAxis(30 * Input.GetAxisRaw("Horizontal"), Vector3.up) * _rotation;
        }
    }
}
