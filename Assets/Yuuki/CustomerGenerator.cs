using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> ���ɗ��X����q�𐶐�����N���X </summary>
public class CustomerGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�q�̃v���n�u")] GameObject[] customers = new GameObject[6];
    [SerializeField, Tooltip("�I�[�_�[�̃{�[�_�[")] int _orderBorder = default;
    [SerializeField, Tooltip("�I�[�_�[�̃Z���t�e�L�X�g")] Text _orderText = default;
    [Header("�I�[�_�[�̃Z���t���e")]
    [SerializeField, Tooltip("����")] string _cuteLogue = default;
    [SerializeField, Tooltip("����������")] string _coolLogue = default;
    [SerializeField, Tooltip("�ʔ���")] string _amusingLogue = default;
    [SerializeField, Tooltip("�Z�N�V�[")] string _sexyLogue = default;
    [SerializeField, Tooltip("�|��")] string _ghostlyLogue = default;

    /// <summary> ���̋q�𐶐�����BDecision����Ă΂�� </summary>
    public void Generate()
    {
        _order = DecideOrder(); //�I�[�_�[�����肷��
        _orderText.text = Dialogue(_order); //�Z���t��\������
        DecideCusttomer().SetActive(true);  //�q��\������
    }

    /// <summary> ���̃I�[�_�[�̓��e���Ǘ�����񋓌^ </summary>
    enum NextOrder
    {
        Uncertainty = 0,
        Cute = 1,
        Cool = 2,
        Amusing = 3,
        Sexy = 4,
        Ghostly = 5,
    }
    NextOrder _order = NextOrder.Uncertainty;
    
    /// <summary> ���̃I�[�_�[�����肷�� </summary>
    /// <returns></returns>
    private NextOrder DecideOrder()
    {
        int orderIndex = UnityEngine.Random.Range(0, 4);
        //�����_���ɃI�[�_�[�𐶐����邽�߂ɁAEnum��int�ɕϊ�
        NextOrder next = (NextOrder)Enum.ToObject(typeof(NextOrder), orderIndex);
        return next;
    }

    /// <summary> �I�[�_�[�ɍ��킹�āA�X�R�A�̃{�[�_�[��ݒ肷�� </summary>
    /// <param name="nextOrder"></param>
    private void SetParameter(NextOrder nextOrder)
    {
        switch (nextOrder)
        {
            case NextOrder.Cute: Decision.Instance.Customer._cute = _orderBorder; break;
            case NextOrder.Cool: Decision.Instance.Customer._cool = _orderBorder; break;
            case NextOrder.Amusing: Decision.Instance.Customer._amuseing = _orderBorder; break;
            case NextOrder.Sexy: Decision.Instance.Customer._sexy = _orderBorder; break;
            case NextOrder.Ghostly: Decision.Instance.Customer._ghostly = _orderBorder; break;
            default: break;
        }

    }

    /// <summary> �q�̃v���n�u�����肷�� </summary>
    private GameObject DecideCusttomer()
    {
        int customerIndex = UnityEngine.Random.Range(0, 5);
        return customers[customerIndex];
    }

    /// <summary> �I�[�_�[�ɍ��킹�ăZ���t�����肷�� </summary>
    /// <param name="nextOrder"></param>
    /// <returns></returns>
    private string Dialogue(NextOrder nextOrder)
    {
        switch(nextOrder)
        {
            case NextOrder.Cute: return _cuteLogue;
            case NextOrder.Cool: return _coolLogue;
            case NextOrder.Amusing: return _amusingLogue;
            case NextOrder.Sexy: return _sexyLogue;
            case NextOrder.Ghostly: return _ghostlyLogue;
            default: return "";
        }
    }
}
