using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField]
    private Image _currentTexture;

    [SerializeField]
    private Card _cardDetails;

    public event Action<CardUI> CardSelected;

    public void Initialize(Card cardDetails)
    {
        _cardDetails = cardDetails;
        _currentTexture.sprite = _cardDetails.BackTexture;
        _currentTexture.preserveAspect = true;

    }


    public void OnPointerClick()
    {
        Debug.Log("Selected");
        CardSelected?.Invoke(this);
    }

    public void FlipCard()
    {
        if (_currentTexture.sprite == _cardDetails.BackTexture)
            _currentTexture.sprite = _cardDetails.FrontTexture;
        else
            _currentTexture.sprite = _cardDetails.BackTexture;

    }
}
