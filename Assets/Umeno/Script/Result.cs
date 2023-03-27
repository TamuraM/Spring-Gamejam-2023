using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

public class Result : MonoBehaviour
{
    class Score
    {
        public int _score;
    }
    [SerializeField, Tooltip("過去のハイスコアを表示")] Text _hightScoreText;
    [SerializeField, Tooltip("今回のスコアを表示")] Text _scoreText;
    [SerializeField, Tooltip("今回のランクを表示")] Image _rank;
    [SerializeField] Sprite[] _ranks;
    [SerializeField, Tooltip("ランクに応じた称号")] Text _comment;
    [Header("各ランクの称号")]
    [SerializeField, Tooltip("Sランクの称号")] string _rankS;
    [SerializeField, Tooltip("Aランクの称号")] string _rankA;
    [SerializeField, Tooltip("Bランクの称号")] string _rankB;
    [SerializeField, Tooltip("Cランクの称号")] string _rankC;
    Score _hightScore = new Score();
    GameManager _gameManager;

    void Start()
    {
        _hightScore = _hightScore.OnLoad();
        _gameManager = FindObjectOfType<GameManager>();
        if (_hightScore._score < _gameManager.Score.Value)
        {
            _hightScore._score = _gameManager.Score.Value;
            _hightScore.OnSave();
        }
        _hightScoreText.DOCounter(0, _hightScore._score, 5f);
        _scoreText.DOCounter(0, _gameManager.Score.Value, 5f);
        if (_gameManager.Score.Value >= 100000)
        {
            _rank.sprite = _ranks[0];
            _comment.text = _rankS;
        }
        else if (_gameManager.Score.Value > 50000)
        {
            _rank.sprite = _ranks[1];
            _comment.text = _rankA;
        }
        else if (_gameManager.Score.Value > 20000)
        {
            _rank.sprite = _ranks[2];
            _comment.text = _rankB;
        }
        else
        {
            _rank.sprite = _ranks[3];
            _comment.text = _rankC;
        }
    }
}
