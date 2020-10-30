using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class VisualEffector : MonoBehaviour
{
    [SerializeField] private ParticleSystem _demageEffect;
    [SerializeField] private GameObject _floatingScore;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _spriteRenderer;
    private Coroutine _blink;
    private bool _isBlink = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void PlayDamageEffects()
    {
    _demageEffect.Play();
        if (_isBlink == false)         
            _blink = StartCoroutine(Blink());
    }

    public void PlayDamageEffects(Vector3 mousePosition)
    {
        _demageEffect.transform.position = mousePosition;
        _demageEffect.Play();

        float offsetVertical = 1.74F;
        float lifetime = 0.3F;
        GameObject floatingScore = Instantiate(_floatingScore, new Vector3(transform.position.x, transform.position.y + offsetVertical, transform.position.z), Quaternion.identity);
        Destroy(floatingScore, lifetime);
    }

    private IEnumerator Blink()
    {
        Color startColor = _spriteRenderer.color;
        Color invisible = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
        float delay = 0.15F;
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
        int numberFlashing = 5;
        _isBlink = true;

        for (int i = 0; i < numberFlashing; i++)
        {
            _spriteRenderer.color = invisible;        
            yield return waitForSeconds;
            _spriteRenderer.color = startColor;           
            yield return waitForSeconds;
        }
        _isBlink = false;
    }

    public void PlayDiedEffects()
    {        
        _animator.SetTrigger("Died");
    }

    private void OnInvisible()
    {
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 0);
    }
}
