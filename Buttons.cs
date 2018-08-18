using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons : MonoBehaviour {
    public TMP_Text ScoreText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ScoreText.text = (PlayerPrefs.GetInt("score")).ToString() ; //show the last score
    }

    public void ButtonQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    
    public void ButtonStart()
    {
        Debug.Log("Start");
        //charger la scene
        PlayerPrefs.SetInt("score",0);
        SceneManager.LoadScene("cinema");
    }

    public void TweetShare()
    {
        string tweet = "I placed " + PlayerPrefs.GetInt("score") + " child in @farfadet46 #LD42 game PLACE IT !";
        string URL = "http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(tweet);
        Application.OpenURL(URL);
        // tweet the score ?
    }
}
