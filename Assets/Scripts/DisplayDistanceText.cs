
using UnityEngine;
using TMPro;

public class DisplayDistanceText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceTexr ;
    [SerializeField] private Transform _playerTrans;


    private Vector2 _StartPosition;

    private void Start (){
        _StartPosition= _playerTrans.position ;
    }
        private void Update (){
            Vector2 distance = (Vector2)_playerTrans.position-_StartPosition ;
            distance.y = 0;
            if (distance.x<0){
                distance.x=0;
            }
            _distanceTexr.text=distance.x.ToString("0");

        }
    
}
