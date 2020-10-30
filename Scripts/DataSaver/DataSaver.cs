using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSaver : MonoBehaviour
{   
    [SerializeField] private Player _player;

    private int _money;
    private int _score;
    public int Money => _money;
    public int Score => _score;

    private void Awake()
    {
        LoadGame();
        _player.SetSaveData(this);
    }
    private void OnEnable()
    {
        _player.Died += SaveGame;
    }

    private void OnDisable()
    {
        _player.Died -= SaveGame;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetInt("Money", _player.Money);
        PlayerPrefs.SetInt("Score", _player.Score);
    }

    private void LoadGame()
    {
        _money = PlayerPrefs.GetInt("Money", 0);
        _score = PlayerPrefs.GetInt("Score", 0);
    }
}

