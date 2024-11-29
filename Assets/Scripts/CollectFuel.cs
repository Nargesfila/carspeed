using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    


  public AudioSource audioSource;

   private void Awake(){
    audioSource=GetComponent<AudioSource>();
   }

   private void OnTriggerEnter2D(Collider2D collision){
    if (collision.gameObject.CompareTag("Player")){

        if (gameObject.CompareTag("RedFuel")){
            FuelController.instance.AddFuel(20f);
        }
        else if 
        (gameObject.CompareTag("BlueFuel")){
        FuelController.instance.AddFuel(50f);
        }
        else if 
        (gameObject.CompareTag("GreenFuel")){
         FuelController.instance.FillFuel();

        }
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length !=null ? 0.2f :0f);
        }
        else
        {
            Destroy(gameObject);
        }

            }
        }
        }
