using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PropertiesView : MonoBehaviour
{
    [SerializeField] private Button _buyButton;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;

    private PlayerPropertiesInt _playerProperties;

    public event UnityAction<PlayerPropertiesInt> BuyTried;

    private void OnEnable()
    {
        _buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnDisable()
    {
        _buyButton.onClick.RemoveListener(OnBuyButtonClick);
    }

    private void OnBuyButtonClick()
    {
        BuyTried?.Invoke(_playerProperties);
    }

    public void Init(PlayerPropertiesInt playerProperties)
    {        
        _price.text = playerProperties.NextPrice.ToString();
        _label.text = playerProperties.Name;
        _playerProperties = playerProperties;
    }   

}
