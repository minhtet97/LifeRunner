using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerbullet : MonoBehaviour
{
    public float shootSpeed, shootTimer;
    public bool isShooting;
    public int maxAmmo;
    private int currentAmmo;
    
    public Transform shootPos;
    public GameObject bullet;

    public TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isShooting && currentAmmo > 0)
        {
            StartCoroutine(Shoot());
            currentAmmo--;
            UpdateAmmo(-1);
        }
    }

    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else
            {
                return +1;
            }
        }
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direction() *  Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
    }

    public void UpdateAmmo(int ammo)
    {
        currentAmmo += ammo;
        if(currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        ammoText.text = currentAmmo.ToString();
    }
}
