using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class playerHP : MonoBehaviour
{
    public Image healthBar;
    public Image imagen;
    public Sprite cara;

    private PlayerMovement pm;
    public float health;

    public float StartHealth = 100;
  
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        health = StartHealth;
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float amount){
        health-= amount;
        healthBar.fillAmount = health/StartHealth;
       // rb.AddForce(transform.up*-10,ForceMode2D.Impulse);
        anim.SetTrigger("damage");


         if(health<= 0){
            Die();
        }
    }
    void Die(){
        anim.SetTrigger("die");
        pm.moveSpeed = 0;
        StartCoroutine(endles());
    }
    void end(){
        SceneManager.LoadScene("end");
    }
    IEnumerator endles(){
     yield return new WaitForSeconds(1f);
    SceneManager.LoadScene("end");
}
}
