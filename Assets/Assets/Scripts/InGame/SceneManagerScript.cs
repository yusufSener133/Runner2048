using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    Scene _scene;
    void Awake()
    {
        _scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetInt("SceneCount",_scene.buildIndex);
        Debug.Log(SceneManager.sceneCountInBuildSettings);

    }

    public void MainMenuButton()
    {
        GameManager.Instance.EndPoint.TheEnd = false;
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        GameManager.Instance.EndPoint.TheEnd = false;
        SceneManager.LoadScene(_scene.buildIndex);
    }
    public void NextButton()
    {
        GameManager.Instance.EndPoint.TheEnd = false;
        if (SceneManager.sceneCountInBuildSettings > _scene.buildIndex + 1)
            SceneManager.LoadScene(_scene.buildIndex + 1);
        else
        {
            Debug.Log("Add New Scene");
            SceneManager.LoadScene(0);
        }
    }
}
