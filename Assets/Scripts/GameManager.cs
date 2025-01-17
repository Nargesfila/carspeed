
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour


{
    public static GameManager instance;
    [SerializeField] private GameObject _gamrOverCanvas;

    private void Awake (){
        if(instance == null){
            instance = this ;

        }
        Time.timeScale = 1f;
    }

    public void GameOver (){
        _gamrOverCanvas.SetActive (true);
        Time.timeScale = 0f;

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}
