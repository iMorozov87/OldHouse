using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyDisplay : ScoreDisplay
{
    private void OnEnable()
    {
        _player.MoneyChanged += SetValue;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= SetValue;
    }
}
