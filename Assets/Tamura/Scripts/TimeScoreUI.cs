using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

/// <summary>�������ԂƃX�R�A��UI���Ǘ�����</summary>
public class TimeScoreUI : MonoBehaviour
{
    [SerializeField, Tooltip("�Q�[���}�l�[�W���[")] private GameManager _gameManager = default;

    [Header("UI�֌W")]
    [SerializeField, Tooltip("�������Ԃ�\������Text")] private Text _timeText = default;
    [SerializeField, Tooltip("�X�R�A��\������Text")] private Text _scoreText = default;

    void Start()
    {
        _gameManager.LimitTime.Subscribe();
        _gameManager.Score.Subscribe();
    }

    void Update()
    {
        
    }
}
