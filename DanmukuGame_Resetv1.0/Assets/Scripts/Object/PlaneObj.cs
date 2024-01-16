using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlaneObj : MonoBehaviour
{
    public static PlaneObj Player;
    private int _hp;
    private bool _isSelectPanel;
    public bool IsSelectPanel
    {
        get { return _isSelectPanel; }
        set
        {
            _isSelectPanel = value;
        }
    }
    public int Hp => _hp;
    private bool _isCanMove = true;
    public bool IsCanMove
    {
        get => _isCanMove;
        set => _isCanMove = value;
    }
    private PlaneInfo _roleInfo ;
    private Quaternion _rotation; //记录战机出生时的四元数
    private float _horizontalValue;
    private float _verticalValue;
    private Camera _camera;
    private Vector3 _lastPosition; //记录上一帧玩家的位置
    // Start is called before the first frame update
    void Start()
    {
        Player = this;
        _rotation = this.transform.rotation;
        _roleInfo = DataMgr.Instance.PlaneInfoList[DataMgr.Instance.SelectRoleID];
        _hp = _roleInfo.hp;
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        //获得屏幕坐标转世界坐标的4个边界
        //视口坐标左下为0,0 ，右上为1,1
        Vector3 p1 = new Vector3(0, 0, 300);
        Vector3 p2 = new Vector3(1, 1, 300);
        //使用Camera的方法将视口坐标（Viewport Coordinates）转换为世界坐标（World Coordinates
        Consts.LeftDown = Camera.main.ViewportToWorldPoint(p1);
        Consts.RightUp = Camera.main.ViewportToWorldPoint(p2);
    }

    // Update is called once per frame
    void Update()
    {
        _lastPosition = this.transform.position;
        _horizontalValue = Input.GetAxisRaw("Horizontal");
        _verticalValue = Input.GetAxisRaw("Vertical");
        //如果在选择角色面板
        if (IsSelectPanel)
        {
            //上下移动
            this.transform.Translate(Vector3.up * Mathf.Cos(Time.time) * Time.deltaTime * 0.1f);
        }
        if (IsCanMove)
        {
            this.transform.Translate(_horizontalValue * Vector3.right * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            this.transform.Translate(_verticalValue * Vector3.up * Time.deltaTime * _roleInfo.moveSpeed, Space.World);
            //允许玩家战机可以有旋转效果
            this.transform.rotation = Quaternion.AngleAxis(30 * -_horizontalValue, Vector3.up) * _rotation;
            this.transform.rotation *= Quaternion.AngleAxis(15 * _verticalValue, Vector3.right);
        }
        if(transform.position.x < Consts.LeftDown.x || transform.position.x> Consts.RightUp.x)
        {
            Vector3 pos = transform.position;
            pos.x = _lastPosition.x;
            transform.position = pos;
        }
        if (transform.position.y < Consts.LeftDown.y || transform.position.y > Consts.RightUp.y)
        {
            Vector3 pos = transform.position;
            pos.y = _lastPosition.y;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //调用Bullet脚本
            other.GetComponent<BulletObj>().Destroy();
            ChangeHp(1);
            UIMgr.Instance.GetPanel<GamePanel>().UpdateHp();
        }
    }
    public void ChangeHp(int damage) 
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
            UIMgr.Instance.ShowPanel<GameOverPanel>("GameOverPanel", E_UI_Layer.mid, (panel) => { });
        }
    }
}
