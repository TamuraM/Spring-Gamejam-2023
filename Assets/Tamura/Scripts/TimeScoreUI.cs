using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

/// <summary>制限時間とスコアのUIを管理する</summary>
public class TimeScoreUI : MonoBehaviour
{
    [SerializeField, Tooltip("ゲームマネージャー")] private GameManager _gameManager = default;

    [Header("UI関係")]
    [SerializeField, Tooltip("制限時間を表示するText")] private Text _timeText = default;
    [SerializeField, Tooltip("スコアを表示するText")] private Text _scoreText = default;

    void Start()
    {
        _gameManager.LimitTime.Subscribe();
        _gameManager.Score.Subscribe();
    }

    void Update()
    {
        
    }
}
