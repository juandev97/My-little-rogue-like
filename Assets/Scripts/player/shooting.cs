using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
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
    
    }
}
