using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI points;
    public void setup(int score){
        points.text = score.ToString();
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Main(){
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton(){
        //for test in unity
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

        
        // Application.Quit();
        
    }
}
