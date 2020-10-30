using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttacker : MonoBehaviour
{   
    private float _attackDelay= 1.0F;
    private bool _isReadyAttack = true;

    private void OnEnable()
    {
        _isReadyAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isReadyAttack && collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDemage();
            _isReadyAttack = false;
            StartCoroutine(ActivateAttack());
        }
    }

    private IEnumerator ActivateAttack()
    {
        WaitForSeconds delay = new WaitForSeconds(_attackDelay);
        yield return delay;
        _isReadyAttack = true;
    }
}
