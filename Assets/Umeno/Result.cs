using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Result : MonoBehaviour
{
    class Score
    {
        public int _hightScore;
    }
    Score _hightScore = new Score();
    GameManager _gameManager;

    void Start()
    {
        _hightScore = _hightScore.OnLoad();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        //if (_hiScore._hiScore > _gameManager.Score)
        //{

        //}
    }
}
