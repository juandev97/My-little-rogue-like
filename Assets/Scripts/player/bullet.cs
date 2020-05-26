using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D other) {
      if(other.gameObject.tag == "enemy" || other.gameObject.tag == "boss"){
      
     Destroy(gameObject);
      }
 }
void Update() {
   StartCoroutine(bye());
}
 IEnumerator bye(){
   yield return new WaitForSeconds(3);
   Destroy(gameObject);
 }
}
