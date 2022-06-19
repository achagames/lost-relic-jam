using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _timesToRepeat = 2;

    [SerializeField]
    private CardUI _cardPrefab;

    [SerializeField]
    private Transform[] _cardPositions1;

    [SerializeField]
    private Transform[] _cardPositions2;

    [SerializeField]
    private Transform[] _cardPositions3;

    [SerializeField]
    private Transform[] _cardPositions4;

    [SerializeField]
    private List<Card> _allCards;


    private List<CardUI> _selectedCards = new List<CardUI>();

    private List<CardUI> _cardObjects = new List<CardUI>();

    private List<Card> _cardPool = new List<Card>();

    public List<Card> AllCards => _allCards;

    private void Start()
    {
        GenerateBoard();
    }

    public void GenerateBoard()
    {
        foreach (Card card in _allCards)
        {
            for (int i = 0; i < _timesToRepeat; i++)
            {
                _cardPool.Add(card);
            }
        }

        _cardPool = _cardPool.OrderBy(x => Guid.NewGuid()).ToList();

        for (int i = 0; i < _cardPositions1.Length; i++)
        {
            CardUI createdCard = Instantiate(_cardPrefab, _cardPositions1[i].transform);
            createdCard.CardSelected += OnCardSelected;
            createdCard.Initialize(_cardPool[i]);
        }

    }

    private void OnCardSelected(CardUI card)
    {
        if (_selectedCards.Count > 2)
            return;

        _selectedCards.Add(card);

        if (_selectedCards.Count == 2)
            EvaluateGuess();
    }

    private void EvaluateGuess()
    {
        for (int i = 0; i < _selectedCards.Count; i++)
        {
            if (i > 0 && _selectedCards[i] != _selectedCards[i - 1])
            {
                WrongGuess();
                return;
            }
        }

        RightGuess();
    }

    private void WrongGuess()
    {
        Debug.Log("Incorrect");
        foreach (CardUI card in _selectedCards)
        {
            card.FlipCard();
        }

        _selectedCards.Clear();
    }

    private void RightGuess()
    {
        Debug.Log("Correct");

        _selectedCards.Clear();
    }

    private void OnDisable()
    {
        foreach (CardUI card in _cardObjects)
        {
            card.CardSelected -= OnCardSelected;
        }
    }
}
