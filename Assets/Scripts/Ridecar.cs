using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ridecar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _fronttireRB;
    [SerializeField] private Rigidbody2D _backtireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;
    [SerializeField] private AudioSource hornSound ;

    private float _moveInput;

    private void Update() {
       _moveInput = Input.GetAxisRaw("Horizontal");

       if (_moveInput == 0 && Input.touchCount > 0 ) {

         Touch touch = Input.GetTouch(0);

        if (touch.position.x < Screen.width /2) {
            _moveInput = -1;

        } else
        {
            _moveInput=1;
        }
       }



        if(Input.GetKeyDown(KeyCode.H)){
            hornSound.Play();

        }

    }

   
    private void FixedUpdate() { 
     _fronttireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
     _backtireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
     _carRB.AddTorque(-_moveInput * _rotationSpeed * Time.fixedDeltaTime);


    }




}
