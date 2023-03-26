using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>ゲームの制限時間とスコアを管理します</summary>
public class GameManager : MonoBehaviour
{
    [Header("時間関係")]
    [SerializeField, Tooltip("制限時間(秒)")] private ReactiveProperty<float> _limitTime = new ReactiveProperty<float>();
    /// <summary>制限時間(秒)</summary>
    public ReactiveProperty<float> LimitTime { get => _limitTime; }

    [Header("スコア関係")]
    [SerializeField, Tooltip("今のスコア")] private ReactiveProperty<int> _score = new ReactiveProperty<int>();
    /// <summary>今のスコア</summary>
    public ReactiveProperty<int> Score { get => _score; }

    [SerializeField, Tooltip("ゲーム中かのフラグ")] private bool _isGame = false;
    /// <summary>ゲーム中かのフラグ</summary>
    public bool IsGame { get => _isGame; set => _isGame = value; }

    void Start()
    {
        _score.Value = 0;
        //カウントダウンしてisGameをオンにする
        _isGame = true;
    }

    void Update()
    {

        //ゲーム中だったら
        if(_isGame)
        {
            //時間減らしてる
            _limitTime.Value -= Time.deltaTime;

            //制限時間経ったらフラグを変える
            if(_limitTime.Value < 0)
            {
                _isGame = false;
            }

        }

    }

    public void AddScore(int score)
    {
        _score.Value += score;
    }

}
