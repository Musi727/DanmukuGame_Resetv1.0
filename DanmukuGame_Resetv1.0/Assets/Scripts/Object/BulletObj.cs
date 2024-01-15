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
    /// <summary>
    /// 追踪子弹
    /// </summary>
    Trace,
}

public class BulletObj : MonoBehaviour
{
    public float moveSpeed;
    private E_BulletType type;
    public Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (type) 
        {
            case E_BulletType.Straight:
                this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                break;
            case E_BulletType.Curve:
                this.transform.Translate(new Vector3(1,1,0) * moveSpeed * Time.deltaTime);
                break;
            case E_BulletType.Trace:
                this.transform.position = Vector3.Lerp(targetPos, this.transform.position, Time.deltaTime / Vector3.Distance(this.transform.position,targetPos));
                break;
        }
    }
    public void InitBullet(BulletInfo info,Vector3 pos)
    {
        this.moveSpeed = info.moveSpeed;
        this.type = (E_BulletType)info.id;
        targetPos = pos;
    }
}
