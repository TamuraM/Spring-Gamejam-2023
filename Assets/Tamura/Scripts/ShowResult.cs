using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>���U���g��\������</summary>
public class ShowResult : MonoBehaviour
{
    [Header("UI�֌W")]
    [SerializeField, Tooltip("���U���g�̃A�j���[�V����")] private Animator _resultAnim = default;
    [SerializeField, Tooltip("�X�R�A��\������e�L�X�g")] private Text _score = default;
    [SerializeField, Tooltip("�uNew Record�v�̕���")] private Image _newRecord = default;
    [SerializeField, Tooltip("")]

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Result(int score)
    {
        //�A�j���[�V�����Đ�
        //_resultAnim.Play();

        //�X�R�A�ɂ���ĕ\��������e��ς���
    }
}
