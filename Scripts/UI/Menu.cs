using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _mainMenu;

    private int _gameSceneIndex = 1;

    private void OnEnable()
    {
        _player.Died += OpenMainMenu;
    }

    private void OnDisable()
    {
        _player.Died -= OpenMainMenu;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_gameSceneIndex);
    }

    private void OpenMainMenu()
    {
        OpenPanel(_mainMenu);
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}

