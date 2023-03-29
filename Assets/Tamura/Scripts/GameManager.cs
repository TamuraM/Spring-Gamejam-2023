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

    [Header("その他")]
    [SerializeField, Tooltip("ゲーム中かのフラグ")] private bool _isGame = false;
    /// <summary>ゲーム中かのフラグ</summary>
    public bool IsGame { get => _isGame; }
    [SerializeField, Tooltip("リザルト")] private GameObject _result;
    [SerializeField, Tooltip("カウントダウン")] private GameObject _countDown = default;
    /// <summary>ゲームがスタートしたときに呼ばれるメソッド</summary>
    public event System.Action OnGameStart;
    /// <summary>ゲームが終わった時に呼ばれるメソッド</summary>
    public event System.Action OnGameEnd;

    void Start()
    {
        OnGameStart += () => _isGame = true;
        OnGameEnd += () => _isGame = false;
        //カウントダウンしてisGameをオンにする
        StartCoroutine(CountDown());
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
                OnGameEnd();
                _result.SetActive(true);
            }

        }

    }

    /// <summary>引数に指定した数値分スコアが加算される</summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score.Value += score;
    }

    /// <summary>カウントダウンする</summary>
    /// <returns></returns>
    private IEnumerator CountDown()
    {
        _countDown.SetActive(true);
        yield return new WaitForSeconds(5);
        _countDown.SetActive(false);
        OnGameStart();
    }
}
