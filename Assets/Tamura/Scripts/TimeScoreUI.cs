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
    [SerializeField, Tooltip("�X�R�A��\������Text")] private Text _scoreText = default;

    void Start()
    {
        //���l���ύX���ꂽ��A�e�L�X�g���ύX����
        _gameManager.LimitTime.Subscribe(time => ChangeTimeText(time));
        _gameManager.Score.Subscribe(score => ChangeScoreText(score));
    }

    void Update()
    {
        
    }

    /// <summary>�������Ԃ����������Ƀe�L�X�g��ς����肷��</summary>
    /// <param name="time"></param>
    private void ChangeTimeText(float time)
    {
        
        //�c�莞�Ԃɂ���Ă�������肷��
        if(time < 0)
        {
            _timeText.text = "00";
        }
        else if(time < 10) //10�b�ȉ��ɂȂ�����Ԃ��_�ł�����
        {
            _timeText.DOColor(Color.red, 0.3f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo).SetAutoKill();
            //�t�H���g�T�C�Y���ς�����
            DOTween.To(() => _timeText.fontSize, //�t�H���g�T�C�Y��
                x => _timeText.fontSize = x, //x�̒l�܂ŕύX����
                40, //x�̒l��40�܂ŕω�����
                0.3f); //0.3�b�����ĕω�����
        }
        else
        {
            _timeText.text = time.ToString("00");
        }
        
    }

    /// <summary>�X�R�A���������炾�񂾂񑝂��Ă��悤�Ɍ�����</summary>
    /// <param name="score"></param>
    private void ChangeScoreText(int score)
    {
        _scoreText.text = score.ToString("D7");
    }

}
