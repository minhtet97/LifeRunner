using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrent : MonoBehaviour
{
    public float Range;

    public Transform Target;

    bool Detected = false;

    public GameObject AlarmLight;

    public GameObject Gun;
    

    Vector2 Direction;

    public GameObject Bullet;

    public float FireRate;

    float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
            else
            {
                 if(Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
        if(Detected)
        {
            Gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time+1/FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force );
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
