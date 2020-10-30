using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _enemyDemage;
    [SerializeField] private AudioClip _selectionCoint;
    [SerializeField] private Player _player;

    private PlayerAttacker _playerAttacker;
    private AudioSource _audioSource;

    private void Awake()
    {
        _playerAttacker = _player.GetComponent<PlayerAttacker>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _player.MoneyChanged += PlaySelectionCountSound;
        _playerAttacker.Attaked += PlayAttackSound;        
    }

    private void OnDisable()
    {
        _player.MoneyChanged += PlaySelectionCountSound;
        _playerAttacker.Attaked -= PlayAttackSound;       
    }

    private void PlayAttackSound(int score)
    {
        _audioSource.PlayOneShot(_enemyDemage);
    }

    private void PlaySelectionCountSound(int money)
    {
        _audioSource.PlayOneShot(_selectionCoint);
    }
}
