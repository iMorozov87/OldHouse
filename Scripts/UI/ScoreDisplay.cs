using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] protected TMP_Text _textMeshPro;
    [SerializeField] protected Player _player;

    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.ScoreChanged += SetValue;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= SetValue;
    }

    protected void SetValue(int score)
    {        
        _animator.SetTrigger("AddValue");
        _textMeshPro.text = score.ToString();
    }
}
