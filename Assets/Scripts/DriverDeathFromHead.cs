
using UnityEngine;

public class DriverDeathFromHead : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Collision){
        if(Collision.gameObject.CompareTag("Ground")){
            GameManager.instance.GameOver();
        }
    
    }
   
}
