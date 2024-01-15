using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum E_TowerBulletType
{
    /// <summary>
    /// 单发
    /// </summary>
    Singleshot,
    /// <summary>
    /// 散射
    /// </summary>
    Scattering,
}

public class Tower : MonoBehaviour
{
    private E_TowerBulletType _towerType;
    private int _bullerCount;
    private float _fireOffset;//每颗子弹间的间隔时间
    private float _fireRoundOffset;//每轮子弹的间隔时间
    // Start is called before the first frame update
    void Start()
    {
        switch (_towerType)
        {
            case E_TowerBulletType.Singleshot:
                //将炮台转向目标点
                this.transform.LookAt(PlaneObj.Player.transform.position);
                StartCoroutine(Fire());
                break;
            case E_TowerBulletType.Scattering:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Fire()
    {
        //调整炮台朝向
        int bulletcount = _bullerCount;
        while (true)
        {
            this.transform.LookAt(PlaneObj.Player.transform.position);
            while (bulletcount > 0)
            {
                //发射子弹
                PoolMgr.Instance.GetGameObject("Bullet/Bullet", (bullet) =>
                {
                    if (bullet.GetComponent<BulletObj>() == null)
                        bullet.AddComponent<BulletObj>();
                    BulletObj bulletObj = bullet.GetComponent<BulletObj>();
                    bulletObj.InitBullet(DataMgr.Instance.BulletInfosList[0], PlaneObj.Player.transform.position);
                    bullet.transform.position = this.transform.position;
                    bullet.transform.rotation = this.transform.rotation;
                });
                yield return new WaitForSeconds(_fireOffset);
                bulletcount--;
            }
            bulletcount = _bullerCount;
            yield return new WaitForSeconds(_fireRoundOffset);
        }
    }
    public void InitTowerInfo(TowerInfo info,Vector3 pos)
    {
        this.transform.position = pos;
        this._towerType = (E_TowerBulletType)info.towerType;
        string[] strs = info.bulletCount.Split(",");
        this._bullerCount = Random.Range(int.Parse(strs[0]), int.Parse(strs[1]));
        this._fireOffset = info.fireOffset;
        this._fireRoundOffset = info.fireRoundOffset;
    }
}
