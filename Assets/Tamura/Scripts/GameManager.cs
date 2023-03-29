using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

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

    [Header("���̑�")]
    [SerializeField, Tooltip("�Q�[�������̃t���O")] private bool _isGame = false;
    /// <summary>�Q�[�������̃t���O</summary>
    public bool IsGame { get => _isGame; }
    [SerializeField, Tooltip("���U���g")] private GameObject _result;
    [SerializeField, Tooltip("�J�E���g�_�E��")] private GameObject _countDown = default;
    /// <summary>�Q�[�����X�^�[�g�����Ƃ��ɌĂ΂�郁�\�b�h</summary>
    public event System.Action OnGameStart;
    /// <summary>�Q�[�����I��������ɌĂ΂�郁�\�b�h</summary>
    public event System.Action OnGameEnd;

    void Start()
    {
        OnGameStart += () => _isGame = true;
        OnGameEnd += () => _isGame = false;
        //�J�E���g�_�E������isGame���I���ɂ���
        StartCoroutine(CountDown());
    }

    void Update()
    {

        //�Q�[������������
        if(_isGame)
        {
            //���Ԍ��炵�Ă�
            _second -= Time.deltaTime;

            if(_second < 0)
            {
                _limitTime.Value--;
                _second = 1;
            }
            

            //�������Ԍo������t���O��ς���
            //���U���g����
            if(_limitTime.Value < 0)
            {
                OnGameEnd();
                _result.SetActive(true);
            }

        }

    }

    /// <summary>�����Ɏw�肵�����l���X�R�A�����Z�����</summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        _score.Value += score;
    }

    /// <summary>�J�E���g�_�E������</summary>
    /// <returns></returns>
    private IEnumerator CountDown()
    {
        _countDown.SetActive(true);
        yield return new WaitForSeconds(5);
        _countDown.SetActive(false);
        OnGameStart();
    }
}
