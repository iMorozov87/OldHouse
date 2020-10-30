using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class PauseButton : Menu
{   
    [SerializeField] private TMP_Text _startGameButtonText;
    [SerializeField] private GameObject _menuButtonsContainer;
    [SerializeField] private Button _continueButton;
    [SerializeField] private string _newLabelButtonText;

    private Button _pauseButton;
    private string _startLabelButton;

    private void Awake()
    {
        _pauseButton = GetComponent<Button>();
        _startLabelButton = _startGameButtonText.text;
    }

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _continueButton.onClick.AddListener(RenameNewGameButton);
    }

    private void RenameNewGameButton()
    {
        _startGameButtonText.text = _startLabelButton;
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick() 
    {       
        OpenPanel(_menuButtonsContainer);
        OpenPanel(_continueButton.gameObject);
        _startGameButtonText.text = _newLabelButtonText;
        StopTime();
    }
}
