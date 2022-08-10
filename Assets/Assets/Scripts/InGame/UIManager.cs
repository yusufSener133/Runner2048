using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText, _maxPointText, _missionText, _levelNameText;
    [SerializeField] Button _restartButton, _nextButton, _settingButton;
    [SerializeField] GameObject _startPanel, _theEndPanel;

    int _scale = 1;

    void Start()
    {
        _levelNameText.text = "Level\n" + PlayerPrefs.GetInt("SceneCount");
        _missionText.text = "Mission\n" + GameManager.Instance.Mission;
        StartCoroutine(Starting());
    }

    void Update()
    {
        TheEnd();
    }

    void TheEnd()
    {

        _scoreText.text = "Score : " + GameManager.Instance.EndPoint.Score;
        _maxPointText.text = "MaxPoint : " + GameManager.Instance.EndPoint.MaxValue;
        if (GameManager.Instance.EndPoint.TheEnd)
        {
            _theEndPanel.SetActive(true);
            Time.timeScale = 0;

            if (GameManager.Instance.MissionCheck)
            {
                _maxPointText.color = Color.green;
                _restartButton.gameObject.SetActive(false);
                _nextButton.gameObject.SetActive(true);
            }
            else
            {
                _maxPointText.color = Color.red;
                _restartButton.gameObject.SetActive(true);
                _nextButton.gameObject.SetActive(false);
            }
        }
        else
        {
            _theEndPanel.SetActive(false);
            Time.timeScale = _scale;
        }
    }
    IEnumerator Starting()
    {
        GameManager.Instance.CollectController.IsRunning = false;
        for (int i = 0; i < 3; i++)
        {
            _startPanel.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _startPanel.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
        GameManager.Instance.CollectController.IsRunning = true;
    }

    public void Setting(GameObject settingPanel)
    {
        Time.timeScale = _scale;
        if (!settingPanel.activeInHierarchy)
        {
            _scale = 0;
            settingPanel.SetActive(true);
        }
        else
        {
            _scale = 1;
            settingPanel.SetActive(false);
        }
    }
}
