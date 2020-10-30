using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    public event UnityAction<Player> PlayerDiscovered;
    public event UnityAction<Player> PlayerGone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {          
            PlayerDiscovered?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {         
            PlayerGone?.Invoke(player);
        }

    }
}
