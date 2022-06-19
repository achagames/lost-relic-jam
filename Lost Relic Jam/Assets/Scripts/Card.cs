using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string _cardName;

    [SerializeField]
    private Sprite _frontTexture;

    [SerializeField]
    private Sprite _backTexture;

    public string CardName => _cardName;

    public Sprite FrontTexture => _frontTexture;

    public Sprite BackTexture => _backTexture;

    
}
