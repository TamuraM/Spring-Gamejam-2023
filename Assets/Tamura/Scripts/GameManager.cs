using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>ゲームの制限時間とスコアを管理します</summary>
public class GameManager : MonoBehaviour
{
    [Header("時間関係")]
    [SerializeField, Tooltip("制限時間(秒)")] private ReactiveProperty<int> _limitTime = new ReactiveProperty<int>();
    /// <summary>制限時間(秒)</summary>
    public ReactiveProperty<int> LimitTime { get => _limitTime; }
    private float _second = 1;

    [Header("スコア関係")]
    [SerializeField, Tooltip("今のスコア")] private ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
    /// <summary>今のスコア</summary>
    public ReactiveProperty<int> Score { get => _score; }

    [SerializeField, Tooltip("ゲーム中かのフラグ")] private bool _isGame = false;
    /// <summary>ゲーム中かのフラグ</summary>
    public bool IsGame { get => _isGame; }

    void Start()
    {
        //カウントダウンしてisGameをオンにする
        _isGame = true;
    }

    void Update()
    {

        //ゲーム中だったら
        if(_isGame)
        {
            //時間減らしてる
            _second -= Time.deltaTime;

            if(_second < 0)
            {
                _limitTime.Value--;
                _second = 1;
            }
            

            //制限時間経ったらフラグを変える
            //リザルト流す
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
