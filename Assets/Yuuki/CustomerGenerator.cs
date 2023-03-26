using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> ���ɗ��X����q�𐶐�����N���X </summary>
public class CustomerGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�q�̃v���n�u(�O�������q�E�㔼���j�q)")] GameObject[] customers = new GameObject[6];
    [SerializeField, Tooltip("�I�[�_�[�̃{�[�_�[")] int _orderBorder = default;
    [SerializeField, Tooltip("�I�[�_�[�̃Z���t�e�L�X�g")] Text _orderText = default;
    [Header("�I�[�_�[�̃Z���t���e")]
    [SerializeField] String[] diaLogues = new string[Enum.GetNames(typeof(NextOrder)).Length];
    [SerializeField, Tooltip("�����̊���(������)")] int _womenRatio = default;

    /// <summary> ���̋q�𐶐�����BDecision����Ă΂�� </summary>
    public void Generate()
    {
        _order = DecideOrder(); //�I�[�_�[�����肷��
        _orderText.text = Dialogue(_order); //�Z���t��\������
        SetParameter(_order);
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

        CuteAndCool = 6,
        CuteAndAmusing = 7,
        CuteAndSexy = 8,
        CuteAndGhostly = 9,

        CoolAndAmusing = 10,
        CoolAndSexy = 11,
        CoolAndGhostly = 12,

        AmusingAndSexy = 13,
        AmusingAndGhostly = 14,

        SexyAndGhostly = 15,

    }
    NextOrder _order = NextOrder.Uncertainty;
    
    /// <summary> ���̃I�[�_�[�����肷�� </summary>
    /// <returns></returns>
    private NextOrder DecideOrder()
    {
        //�����_���ɃI�[�_�[�𐶐�����
        int orderIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(NextOrder)).Length);
        //Enum��int�ɕϊ�
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

            case NextOrder.CuteAndCool: Decision.Instance.Customer._cute = _orderBorder; Decision.Instance.Customer._cool = _orderBorder; break;
            case NextOrder.CuteAndAmusing:Decision.Instance.Customer._cute = _orderBorder; Decision.Instance.Customer._amuseing = _orderBorder; break;
            case NextOrder.CuteAndSexy: Decision.Instance.Customer._cute = _orderBorder; Decision.Instance.Customer._sexy = _orderBorder; break;
            case NextOrder.CuteAndGhostly: Decision.Instance.Customer._cute = _orderBorder; Decision.Instance.Customer._ghostly = _orderBorder; break;

            case NextOrder.CoolAndAmusing: Decision.Instance.Customer._cool = _orderBorder; Decision.Instance.Customer._amuseing = _orderBorder; break;
            case NextOrder.CoolAndSexy: Decision.Instance.Customer._cool = _orderBorder; Decision.Instance.Customer._sexy = _orderBorder; break;
            case NextOrder.CoolAndGhostly: Decision.Instance.Customer._cool = _orderBorder; Decision.Instance.Customer._ghostly = _orderBorder; break;

            case NextOrder.AmusingAndSexy: Decision.Instance.Customer._amuseing = _orderBorder; Decision.Instance.Customer._sexy= _orderBorder; break;
            case NextOrder.AmusingAndGhostly: Decision.Instance.Customer._amuseing = _orderBorder; Decision.Instance.Customer._ghostly = _orderBorder; break;

            case NextOrder.SexyAndGhostly: Decision.Instance.Customer._sexy = _orderBorder; Decision.Instance.Customer._ghostly = _orderBorder; break;


            default: break;
        }
    }

    /// <summary> �q�̃v���n�u�����肷�� </summary>
    private GameObject DecideCusttomer()
    {
        int lot = UnityEngine.Random.Range(0, 100);
        int customerIndex = default;
        if (lot < _womenRatio)
        {
            customerIndex = UnityEngine.Random.Range(0, 3);
        }
        else
        {
            customerIndex = UnityEngine.Random.Range(4, 6);
        }
        return customers[customerIndex];
    }

    /// <summary> �I�[�_�[�ɍ��킹�ăZ���t�����肷�� </summary>
    /// <param name="nextOrder"></param>
    /// <returns></returns>
    private string Dialogue(NextOrder nextOrder)
    {
        switch(nextOrder)
        {
            case NextOrder.Cute: return diaLogues[0];
            case NextOrder.Cool: return diaLogues[1];
            case NextOrder.Amusing: return diaLogues[2];
            case NextOrder.Sexy: return diaLogues[3];
            case NextOrder.Ghostly: return diaLogues[4];

            case NextOrder.CuteAndCool:return diaLogues[5];
            case NextOrder.CuteAndAmusing: return diaLogues[6];
            case NextOrder.CuteAndSexy: return diaLogues[7];
            case NextOrder.CuteAndGhostly: return diaLogues[8];

            case NextOrder.CoolAndAmusing: return diaLogues[9];
            case NextOrder.CoolAndSexy: return diaLogues[10];
            case NextOrder.CoolAndGhostly: return diaLogues[11];

            case NextOrder.AmusingAndSexy: return diaLogues[12];
            case NextOrder.AmusingAndGhostly: return diaLogues[13];

            case NextOrder.SexyAndGhostly: return diaLogues[14];

            default: return "";
        }
    }
}
