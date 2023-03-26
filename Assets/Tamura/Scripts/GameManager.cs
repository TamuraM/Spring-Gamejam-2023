using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI; 

/// <summary>�Q�[���̐������ԂƃX�R�A���Ǘ����܂�</summary>
public class GameManager : MonoBehaviour
{
    [Header("���Ԋ֌W")]
    [SerializeField, Tooltip("��������(�b)")] private ReactiveProperty<int> _limitTime = new ReactiveProperty<int>();
    /// <summary>��������(�b)</summary>
    public ReactiveProperty<int> LimitTime { get => _limitTime; }
    private float _second = 1;

    [Header("�X�R�A�֌W")]
    [SerializeField, Tooltip("���̃X�R�A")] private ReactiveProperty<int> _score = new ReactiveProperty<int>(0);
    /// <summary>���̃X�R�A</summary>
    public ReactiveProperty<int> Score { get => _score; }

    [SerializeField, Tooltip("�Q�[�������̃t���O")] private bool _isGame = false;
    /// <summary>�Q�[�������̃t���O</summary>
    public bool IsGame { get => _isGame; }
    [SerializeField] Image _timerGauge;
    [SerializeField] GameObject _result;
    float _timer;
    void Start()
    {
        //�J�E���g�_�E������isGame���I���ɂ���
        _isGame = true;
    }

    void Update()
    {

        //�Q�[������������
        if(_isGame)
        {
            //���Ԍ��炵�Ă�
            _second -= Time.deltaTime;
            _timer += Time.deltaTime;
            if(_timer > 1)
            {
                _timerGauge.fillAmount -= 0.0167f;
                _timer = 0;
            }
            if(_second < 0)
            {
                _limitTime.Value--;
                _second = 1;
            }
            

            //�������Ԍo������t���O��ς���
            //���U���g����
            if(_limitTime.Value < 0)
            {
                _isGame = false;
            }

        }
        else
        {
            _result.SetActive(true);
        }

    }

    public void AddScore(int score)
    {
        _score.Value += score;
    }

}
