using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    class Score
    {
        public int _score;
    }
    [SerializeField] Text _hightScoreText;
    Score _hightScore = new Score();
    GameManager _gameManager;

    void Start()
    {
        _hightScore = _hightScore.OnLoad();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (_hightScore._score < _gameManager.Score.Value)
        {
            _hightScore._score = _gameManager.Score.Value;
            _hightScore.OnSave();
        }
        _hightScoreText.text = $"HISCORE:{_hightScore._score}";
    }
}
