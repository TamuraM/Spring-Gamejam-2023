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
    [SerializeField, Tooltip("�ߋ��̃n�C�X�R�A��\��")] Text _hightScoreText;
    [SerializeField, Tooltip("����̃X�R�A��\��")] Text _scoreText;
    [SerializeField, Tooltip("����̃����N��\��")] Text _rank;
    [SerializeField, Tooltip("�����N�ɉ������̍�")] Text _comment;
    [Header("�e�����N�̏̍�")]
    [SerializeField, Tooltip("S�����N�̏̍�")] string _rankS;
    [SerializeField, Tooltip("A�����N�̏̍�")] string _rankA;
    [SerializeField, Tooltip("B�����N�̏̍�")] string _rankB;
    [SerializeField, Tooltip("C�����N�̏̍�")] string _rankC;
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
            _rank.text = "S";
            _comment.text = _rankS;
        }
        else if (_gameManager.Score.Value > 50000)
        {
            _rank.text = "A";
            _comment.text = _rankA;
        }
        else if (_gameManager.Score.Value > 20000)
        {
            _rank.text = "B";
            _comment.text = _rankB;
        }
        else
        {
            _rank.text = "C";
            _comment.text = _rankC;
        }
    }
}
