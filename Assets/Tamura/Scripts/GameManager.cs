using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>�Q�[���̐������ԂƃX�R�A���Ǘ����܂�</summary>
public class GameManager : MonoBehaviour
{
    [Header("���Ԋ֌W")]
    [SerializeField, Tooltip("��������(�b)")] private ReactiveProperty<float> _limitTime = new ReactiveProperty<float>();
    /// <summary>��������(�b)</summary>
    public ReactiveProperty<float> LimitTime { get => _limitTime; }

    [Header("�X�R�A�֌W")]
    [SerializeField, Tooltip("���̃X�R�A")] private ReactiveProperty<int> _score = new ReactiveProperty<int>();
    /// <summary>���̃X�R�A</summary>
    public ReactiveProperty<int> Score { get => _score; }

    [SerializeField, Tooltip("�Q�[�������̃t���O")] private bool _isGame = false;
    /// <summary>�Q�[�������̃t���O</summary>
    public bool IsGame { get => _isGame; set => _isGame = value; }

    void Start()
    {
        _score.Value = 0;
        //�J�E���g�_�E������isGame���I���ɂ���
        _isGame = true;
    }

    void Update()
    {

        //�Q�[������������
        if(_isGame)
        {
            //���Ԍ��炵�Ă�
            _limitTime.Value -= Time.deltaTime;

            //�������Ԍo������t���O��ς���
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
