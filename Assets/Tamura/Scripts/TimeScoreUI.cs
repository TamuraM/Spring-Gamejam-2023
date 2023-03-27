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
    [SerializeField, Tooltip("制限時間の後ろにあるゲージ")] Image _timerGauge;
    [SerializeField, Tooltip("制限時間が少なくなった時、フォントがどこまで大きくなるか")] private int _fontSizeMax = 40;
    [SerializeField, Tooltip("スコアを表示するText")] private Text _scoreText = default;
    [Tooltip("前回のスコア")] private int _oldScore = default;
    [SerializeField, Tooltip("スコアプラス表示")] private Text _plusScoreText = default;

    void Start()
    {
        //数値が変更されたら、テキストも変更する
        _gameManager.LimitTime.Subscribe(time => ChangeTimeText(time));
        _gameManager.Score.Subscribe(score => ChangeScoreText(score));
        _oldScore = 0;
        _plusScoreText.enabled = false;
    }

    /// <summary>制限時間が減った時にテキストを変えたりする</summary>
    /// <param name="time"></param>
    private void ChangeTimeText(float time)
    {
        
        //残り時間なくなったらおわり
        if(time < 0)
        {
            _timeText.text = "0";
            return;
        }

        _timeText.text = time.ToString(); //タイマーテキストを変更
        _timerGauge.fillAmount -= 0.0167f; //ゲージも減らす

        if (time <= 10) //10秒以下になったら赤く点滅しだす
        {
            //赤く点滅
            _timeText.DOColor(Color.red, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill();
            //フォントサイズが大きくなって小さくなる
            DOTween.To(() => _timeText.fontSize, //フォントサイズを
                x => _timeText.fontSize = x, //xの値まで変更する
                _fontSizeMax, //xの値は40まで変化する
                0.3f)
                .SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill(); //0.3秒かけて変化する
        }
        
    }

    /// <summary>スコアが増えたらだんだん増えてくように見せる</summary>
    /// <param name="score"></param>
    private void ChangeScoreText(int score)
    {
        int tempScore = _oldScore;
        _oldScore = score;
        //スコア表示
        DOTween.To(() => tempScore, //スコアテキストを
                x => _scoreText.text = x.ToString("D7"), //xの値まで変更する
                score, //xはscoreまで変化する
                0.7f ) //0.3秒かけて変化する
                .SetEase(Ease.Linear)
                .OnComplete(() => _scoreText.text = score.ToString("D7")).SetAutoKill();
        //何点増えたか表示
        _plusScoreText.text = $"+{score - tempScore}";
        _plusScoreText.enabled = true;
        _plusScoreText.DOFade(0.3f, 0.7f).SetEase(Ease.Linear)
            .OnComplete(() => { _plusScoreText.enabled = false; _plusScoreText.color = Color.white; })
            .SetAutoKill();
    }

}
