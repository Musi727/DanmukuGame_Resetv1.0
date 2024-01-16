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
    public E_TowerBulletType _towerType;
    private int _bullerCount;
    private float _fireOffset;//每颗子弹间的间隔时间
    private float _fireRoundOffset;//每轮子弹的间隔时间
    public bool isOpenFire = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOpenFire)
        {
            switch (_towerType)
            {
                case E_TowerBulletType.Singleshot:
                    //将炮台转向目标点
                    this.transform.LookAt(PlaneObj.Player.transform.position);
                    StartCoroutine(Fire());
                    isOpenFire = true;
                    break;
                case E_TowerBulletType.Scattering:
                    //将炮台转向目标点
                    this.transform.LookAt(Consts.Center);
                    StartCoroutine(ScatteringFire());
                    isOpenFire = true;
                    break;
            }
        }
    }
    IEnumerator Fire()
    {
        int bulletcount = _bullerCount;
        while (true)
        {
            BulletInfo info = DataMgr.Instance.BulletInfosList[Random.Range(0, 2)];
            if(info.id == 0)
                this.transform.LookAt(PlaneObj.Player.transform.position);
            else
            {
                this.transform.LookAt(Consts.Center);
            }
            while (bulletcount > 0)
            {
                BulletInfo info2 = info;
                //发射子弹
                PoolMgr.Instance.GetGameObject("Bullet/Bullet", (bullet) =>
                {
                    if (bullet.GetComponent<BulletObj>() == null)
                        bullet.AddComponent<BulletObj>();
                    BulletObj bulletObj = bullet.GetComponent<BulletObj>();
                    bulletObj.InitBullet(info2);
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
    /// <summary>
    /// 散射子弹
    /// </summary>
    /// <returns></returns>
    IEnumerator ScatteringFire()
    {
        int bulletcount = _bullerCount;
        while (true)
        {
            BulletInfo info = DataMgr.Instance.BulletInfosList[Random.Range(0, 2)];
            this.transform.LookAt(Consts.Center);
            Quaternion midAngle = Quaternion.LookRotation(Consts.Center - this.transform.position);
            //得到散射旋转角度
            float angle = 90.0f / bulletcount;
            int mid = bulletcount / 2;
            while (bulletcount > 0)
            {
                BulletInfo info2 = info;
                //发射子弹
                PoolMgr.Instance.GetGameObject("Bullet/Bullet", (bullet) =>
                {
                    if (bullet.GetComponent<BulletObj>() == null)
                        bullet.AddComponent<BulletObj>();
                    BulletObj bulletObj = bullet.GetComponent<BulletObj>();
                    bulletObj.InitBullet(info2);
                    bullet.transform.position = this.transform.position;
                    bullet.transform.rotation = Quaternion.AngleAxis(angle * (mid - bulletcount), Vector3.forward) * midAngle;
                });
                yield return new WaitForSeconds(_fireOffset);
                bulletcount--;
            }
            bulletcount = _bullerCount;
            yield return new WaitForSeconds(_fireRoundOffset);
        }
    }
    private void OnDestroy()
    {
        StopCoroutine(Fire());
        StopCoroutine(ScatteringFire());
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
