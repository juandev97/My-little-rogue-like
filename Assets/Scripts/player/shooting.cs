using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public static float MIN_BULLET_DAMAGE = 1f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public int inventoryBullets = 30;
    public float bulletForce = 10f;
    //private new AudioSource audio;

    //private Animator anim;

    void Start() {
        //anim = GetComponent<Animator>();
        //anim.SetInteger("bullets",inventoryBullets);
        //audio = bulletPrefab.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(inventoryBullets > 0){
            shoot();
            //audio.Play();
            //anim.SetTrigger("shooting");
            inventoryBullets-=1;
            //anim.SetInteger("bullets",inventoryBullets);
            }
        }
    }

    void shoot(){
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();  
    rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    float damage = CalculateBulletDamage();
    bullet.GetComponent<bullet>().Setup(damage);
    }

    float CalculateBulletDamage()
    {
        float bulletDamage = 0;
        PlayerEquip playerEquip = gameObject.GetComponent<PlayerEquip>();
        foreach(var equipment in playerEquip.equipObjects)
        {
            if (equipment != null)
            {
                foreach(var buff in equipment.buffs)
                {
                    if (buff.type == Buff.Type.Attack)
                    {
                        bulletDamage += buff.value;
                    }
                }
            }
        }
        
        return Mathf.Max(bulletDamage,MIN_BULLET_DAMAGE);
    }
}
