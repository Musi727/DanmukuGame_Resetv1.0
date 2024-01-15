using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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
    private float _horizontalValue;
    private float _verticalValue;
    private Vector3 _leftDown;
    private Vector3 _rightUp;
    private Camera _camera;
    private Vector3 _lastPosition; //��¼��һ֡��ҵ�λ��
    // Start is called before the first frame update
    void Start()
    {
        _rotation = this.transform.rotation;
        _roleInfo = DataMgr.Instance.PlaneInfoList[DataMgr.Instance.SelectRoleID];
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        //�����Ļ����ת���������4���߽�
        //�ӿ���������Ϊ0,0 ������Ϊ1,1
        Vector3 p1 = new Vector3(0, 0, 300);
        Vector3 p2 = new Vector3(1, 1, 300);
        //ʹ��Camera�ķ������ӿ����꣨Viewport Coordinates��ת��Ϊ�������꣨World Coordinates
        _leftDown = Camera.main.ViewportToWorldPoint(p1);
        _rightUp = Camera.main.ViewportToWorldPoint(p2);
        Debug.Log(_leftDown);
        Debug.Log(_rightUp);
    }

    // Update is called once per frame
    void Update()
    {
        _lastPosition = this.transform.position;
        _horizontalValue = Input.GetAxisRaw("Horizontal");
        _verticalValue = Input.GetAxisRaw("Vertical");
        //�����ѡ���ɫ���
        if (IsSelectPanel)
        {
            //�����ƶ�
            this.transform.Translate(Vector3.up * Mathf.Cos(Time.time) * Time.deltaTime * 0.1f);
        }
        if (IsCanMove)
        {
            this.transform.Translate(_horizontalValue * Vector3.right * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            this.transform.Translate(_verticalValue * Vector3.up * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            //�������ս����������תЧ��
            this.transform.rotation = Quaternion.AngleAxis(30 * -_horizontalValue, Vector3.up) * _rotation;
            this.transform.rotation *= Quaternion.AngleAxis(15 * _verticalValue, Vector3.right);
        }
        if(transform.position.x < _leftDown.x || transform.position.x> _rightUp.x)
        {
            Vector3 pos = transform.position;
            pos.x = _lastPosition.x;
            transform.position = pos;
        }
        if (transform.position.y < _leftDown.y || transform.position.y > _rightUp.y)
        {
            Vector3 pos = transform.position;
            pos.y = _lastPosition.y;
            transform.position = pos;
        }

    }
}
