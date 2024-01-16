using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Transform _rolePos;
    private List<Vector3> _TowerPos = new List<Vector3>();
    private Camera _camera;
    // Start is called before the first frame update
    void Awake()
    {
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        _rolePos = GameObject.Find("RolePos").transform;
        //�����������ؽ�ɫ
        PoolMgr.Instance.GetGameObject("Airplane/" + DataMgr.Instance.PlaneInfoList[DataMgr.Instance.SelectRoleID].modelRes, (plane) =>
        {
            plane.transform.SetParent(_rolePos, false);
            if (plane.GetComponent<PlaneObj>() == null)
                plane.AddComponent<PlaneObj>();
        });
        //�����Ļ����ת���������4���߽�
        //�ӿ���������Ϊ0,0 ������Ϊ1,1
        Vector3 p0 = new Vector3(0, 0, 300);
        Vector3 p1 = new Vector3(1, 1, 300);
        Vector3 p2 = new Vector3(0, 1, 300);
        Vector3 p3 = new Vector3(1, 0, 300);
        //ʹ��Camera�ķ������ӿ����꣨Viewport Coordinates��ת��Ϊ�������꣨World Coordinates
        _TowerPos.Add(_camera.ViewportToWorldPoint(p0));
        _TowerPos.Add(_camera.ViewportToWorldPoint(p1));
        _TowerPos.Add(_camera.ViewportToWorldPoint(p2));
        _TowerPos.Add(_camera.ViewportToWorldPoint(p3));
        for(int i = 0; i < _TowerPos.Count; i++)
        {
            int index = i;
            PoolMgr.Instance.GetGameObject("Tower", (tower) =>
            {
                if (tower.GetComponent<Tower>() == null)
                    tower.AddComponent<Tower>().InitTowerInfo(DataMgr.Instance.TowerInfoList[index], _TowerPos[index]);
            });
        }
        Consts.Center = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 300));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
