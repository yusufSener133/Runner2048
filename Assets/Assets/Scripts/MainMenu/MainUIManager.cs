using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    void Start()
    {
        //PlayerPrefs.SetInt("Coin", 0);
        _scoreText.text = "Coin : " + PlayerPrefs.GetInt("Coin");
    }
    public void PlayButton()
    {
        //Debug.Log(PlayerPrefs.GetInt("SceneCount")); 
        if (PlayerPrefs.GetInt("SceneCount") != 0)
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneCount"));
        else
            SceneManager.LoadScene(1);
    }
}
