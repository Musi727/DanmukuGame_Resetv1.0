using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : BasePanel
{
    private Transform _planePos;
    private int _index; //��ǰѡ��ɻ�������
    private List<PlaneInfo> _infoList;
    private GameObject _nowPrefab;
    private RaycastHit _hitInfo;
    public override void Init()
    {
        _index = 0;
        _infoList = DataMgr.Instance.PlaneInfoList;
    }
    protected override void OnClick(string name)
    {
        switch (name)
        {
            case "btnBack":
                UIMgr.Instance.HidePanel<SelectPanel>("SelectPanel");
                UIMgr.Instance.ShowPanel<BeginPanel>("BeginPanel",E_UI_Layer.mid,(panel)=>{});
                ClearPrefab();
                break;
            case "btnLeft":
                _index--;
                if (_index < 0)
                    _index = _infoList.Count - 1;
                InitPlaneInfo(_infoList[_index]);
                break;
            case "btnRight":
                _index++;
                if (_index >= _infoList.Count)
                    _index = 0;
                InitPlaneInfo(_infoList[_index]);
                break;
            case "btnStart":
                //��¼�ɻ�����
                DataMgr.Instance.SelectRoleID = _index;
                UIMgr.Instance.HidePanel<SelectPanel>("SelectPanel");
                SceneMgr.Instance.LoadScene("GameScene", () =>
                {
                    PoolMgr.Instance.Clear();
                    UIMgr.Instance.ShowPanel<GamePanel>("GamePanel", E_UI_Layer.mid, (panel) =>
                    {

                    });
                });
                break;
        }
    }
    public override void ShowMe()
    {
        base.ShowMe();
        //������Ԥ�������ɵ�λ��
        _planePos = GameObject.Find("planePos").transform;
        //�򿪸ý���ʱ����ʼ���ɻ�ģ����Ϣ
        InitPlaneInfo(DataMgr.Instance.PlaneInfoList[_index]);
    }
    protected override void Update()
    {
        base.Update();
        //ͨ�����߼���ж��Ƿ������˽�ɫģ��
        if (Input.GetMouseButton(0))
        {
            //������߼�ⲻΪ��
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hitInfo, 1000, 1 << LayerMask.NameToLayer("UI")))
            {
                //������ת
                _hitInfo.transform.Rotate(Vector3.up, -Input.GetAxisRaw("Mouse X") * Time.deltaTime * 1000);
            }
        }
    }
    /// <summary>
    /// ��ʼ����ɫ��Ϣ
    /// </summary>
    /// <param name="info">��������</param>
    public void InitPlaneInfo(PlaneInfo info)
    {
        //���������һ�ε�ģ��
        ClearPrefab();
        //���ȼ���ģ��
        PoolMgr.Instance.GetGameObject("Airplane/" + info.modelRes, (plane) =>
        {
            plane.transform.position = _planePos.position;
            plane.transform.rotation = _planePos.rotation;
            plane.transform.localScale = info.scale * Vector3.one;
            plane.AddComponent<PlaneObj>().IsSelectPanel = true;
            //��¼��ǰԤ����
            _nowPrefab = plane;
        });
        //���ö�Ӧ����
        GetController<Text>("txtHpNum").text = info.hp.ToString();
        GetController<Text>("txtSpeedNum").text = info.speed.ToString();
        GetController<Text>("txtVolumeNum").text = info.volume.ToString();
    }
    public void ClearPrefab()
    {
        if (_nowPrefab != null)
        {
            PoolMgr.Instance.PushGameObject(_nowPrefab.gameObject.name, _nowPrefab.gameObject);
            _nowPrefab.GetComponent<PlaneObj>().IsSelectPanel = false;
            _nowPrefab = null;
        }
    }
}
