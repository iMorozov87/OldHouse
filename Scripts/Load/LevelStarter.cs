using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private GameObject _menuDisplay;

    private bool _isMenuActive = false;
    private void Start()
    {
        GetMenuStatus();
    }

    private bool GetMenuStatus()
    {
        bool isMenuActive;
        
        if (PlayerPrefs.GetInt("MenuActive") == 1)
            isMenuActive = true;
        else
            isMenuActive = false;        
        return isMenuActive;
    }
}
