using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>制限時間とスコアのUIを管理する</summary>
public class TimeScoreUI : MonoBehaviour
{
    [SerializeField, Tooltip("ゲームマネージャー")] private GameManager _gameManager = default;

    [Header("UI関係")]
    [SerializeField, Tooltip("制限時間を表示するText")] private Text _timeText = default;
    [SerializeField, Tooltip("スコアを表示するText")] private Text _scoreText = default;

    void Start()
    {
        //数値が変更されたら、テキストも変更する
        _gameManager.LimitTime.Subscribe(time => ChangeTimeText(time));
        _gameManager.Score.Subscribe(score => ChangeScoreText(score));
    }

    void Update()
    {
        
    }

    /// <summary>制限時間が減った時にテキストを変えたりする</summary>
    /// <param name="time"></param>
    private void ChangeTimeText(float time)
    {
        
        //残り時間によってかわったりする
        if(time < 0)
        {
            _timeText.text = "00";
        }
        else if(time < 10) //10秒以下になったら赤く点滅しだす
        {
            _timeText.DOColor(Color.red, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill();
            //フォントサイズも変えたい
            DOTween.To(() => _timeText.fontSize, //フォントサイズを
                x => _timeText.fontSize = x, //xの値まで変更する
                40, //xの値は40まで変化する
                0.3f); //0.3秒かけて変化する
        }
        else
        {
            _timeText.text = time.ToString("00");
        }
        
    }

    /// <summary>スコアが増えたらだんだん増えてくように見せる</summary>
    /// <param name="score"></param>
    private void ChangeScoreText(int score)
    {
        _scoreText.text = score.ToString("D7");
    }

}
