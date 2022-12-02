using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject HelixPlatformPrefab;

    public GameObject MenuPanel;
    public GameObject ScoreText;

    private bool _isStarted;

    private void OnEnable()
    {
        MoveController.Move += DisableMenuPanel;
    }

    private void OnDisable()
    {
        MoveController.Move -= DisableMenuPanel;
    }

    private void Start () {
        Time.timeScale = 1f;
        _isStarted = false;
        CreateHelix();
    }
	
    private void CreateHelix()
    {
        float yPos = 0;
        for (int i = 0; i < 3; i++)
        {
            GameObject helixPlatform = Instantiate(HelixPlatformPrefab);
            helixPlatform.transform.position = new Vector3(0, yPos, 0);
            yPos -= 3.5f;
        }
    }

    private void DisableMenuPanel()
    {
        if (!_isStarted)
        {
            _isStarted = true;
            MenuPanel.SetActive(false);
            ScoreText.SetActive(true);
        }
    }
}
