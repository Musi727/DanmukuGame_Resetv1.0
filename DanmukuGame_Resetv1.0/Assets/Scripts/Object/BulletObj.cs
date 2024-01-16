using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_BulletType 
{
    /// <summary>
    /// 直线子弹
    /// </summary>
    Straight,
    /// <summary>
    /// 曲线子弹
    /// </summary>
    Curve,
}

public class BulletObj : MonoBehaviour
{
    public float moveSpeed;
    public E_BulletType Type;
    public Vector3 LeftDownBullet;
    public Vector3 RightUpBullet;
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
        LeftDownBullet = Consts.LeftDown + new Vector3(-100, -100);
        RightUpBullet = Consts.RightUp + new Vector3(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        switch (Type) 
        {
            case E_BulletType.Straight:
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                break;
            case E_BulletType.Curve:
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                this.transform.Translate(Vector3.up * Mathf.Cos(_time) , Space.World);
                break;
        }
        //如果子弹出界则将子弹放入对象池
        if (transform.position.x < LeftDownBullet.x || transform.position.x > RightUpBullet.x)
            this.Destroy();
        if (transform.position.y < LeftDownBullet.y || transform.position.y > RightUpBullet.y)
            this.Destroy();
    }
    public void InitBullet(BulletInfo info)
    {
        this.moveSpeed = info.moveSpeed;
        this.Type = (E_BulletType)info.id;
    }
    public void Destroy()
    {
        PoolMgr.Instance.PushGameObject("Bullet/Bullet", this.gameObject);
        _time = 0;
    }

}
