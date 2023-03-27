using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>�������ԂƃX�R�A��UI���Ǘ�����</summary>
public class TimeScoreUI : MonoBehaviour
{
    [SerializeField, Tooltip("�Q�[���}�l�[�W���[")] private GameManager _gameManager = default;

    [Header("UI�֌W")]
    [SerializeField, Tooltip("�������Ԃ�\������Text")] private Text _timeText = default;
    [SerializeField, Tooltip("�������Ԃ̌��ɂ���Q�[�W")] Image _timerGauge;
    [SerializeField, Tooltip("�������Ԃ����Ȃ��Ȃ������A�t�H���g���ǂ��܂ő傫���Ȃ邩")] private int _fontSizeMax = 40;
    [SerializeField, Tooltip("�X�R�A��\������Text")] private Text _scoreText = default;
    [Tooltip("�O��̃X�R�A")] private int _oldScore = default;
    [SerializeField, Tooltip("�X�R�A�v���X�\��")] private Text _plusScoreText = default;

    void Start()
    {
        //���l���ύX���ꂽ��A�e�L�X�g���ύX����
        _gameManager.LimitTime.Subscribe(time => ChangeTimeText(time));
        _gameManager.Score.Subscribe(score => ChangeScoreText(score));
        _oldScore = 0;
        _plusScoreText.enabled = false;
    }

    /// <summary>�������Ԃ����������Ƀe�L�X�g��ς����肷��</summary>
    /// <param name="time"></param>
    private void ChangeTimeText(float time)
    {
        
        //�c�莞�ԂȂ��Ȃ����炨���
        if(time < 0)
        {
            _timeText.text = "0";
            return;
        }

        _timeText.text = time.ToString(); //�^�C�}�[�e�L�X�g��ύX
        _timerGauge.fillAmount -= 0.0167f; //�Q�[�W�����炷

        if (time <= 10) //10�b�ȉ��ɂȂ�����Ԃ��_�ł�����
        {
            //�Ԃ��_��
            _timeText.DOColor(Color.red, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill();
            //�t�H���g�T�C�Y���傫���Ȃ��ď������Ȃ�
            DOTween.To(() => _timeText.fontSize, //�t�H���g�T�C�Y��
                x => _timeText.fontSize = x, //x�̒l�܂ŕύX����
                _fontSizeMax, //x�̒l��40�܂ŕω�����
                0.3f)
                .SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill(); //0.3�b�����ĕω�����
        }
        
    }

    /// <summary>�X�R�A���������炾�񂾂񑝂��Ă��悤�Ɍ�����</summary>
    /// <param name="score"></param>
    private void ChangeScoreText(int score)
    {
        int tempScore = _oldScore;
        _oldScore = score;
        //�X�R�A�\��
        DOTween.To(() => tempScore, //�X�R�A�e�L�X�g��
                x => _scoreText.text = x.ToString("D7"), //x�̒l�܂ŕύX����
                score, //x��score�܂ŕω�����
                0.7f ) //0.3�b�����ĕω�����
                .SetEase(Ease.Linear)
                .OnComplete(() => _scoreText.text = score.ToString("D7")).SetAutoKill();
        //���_���������\��
        _plusScoreText.text = $"+{score - tempScore}";
        _plusScoreText.enabled = true;
        _plusScoreText.DOFade(0.3f, 0.7f).SetEase(Ease.Linear)
            .OnComplete(() => { _plusScoreText.enabled = false; _plusScoreText.color = Color.white; })
            .SetAutoKill();
    }

}
