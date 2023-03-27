using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeChange : MonoBehaviour
{
    [SerializeField]
    [Header("���̕��̃C���f�b�N�X")]
    int _index;

    //�e�����̃p�����[�^�[�̕ϐ�
    [SerializeField]
    [Header("���킢���p�����[�^�[")]
    int _cuteParameter;
    [SerializeField]
    [Header("�����������p�����[�^�[")]
    int _coolParameter;
    [SerializeField]
    [Header("�ʔ����p�����[�^�[")]
    int _amuseingParameter;
    [SerializeField]
    [Header("�Z�N�V�[�p�����[�^�[")]
    int _sexyParameter;
    [SerializeField]
    [Header("���킢�p�����[�^�[")]
    int _ghostlyParameter;

    [SerializeField]
    [Header("�ߑ��̉摜")]
    GameObject _costumeImage;

    public int CuteParameter { get => _cuteParameter; }
    public int CoolParameter { get => _coolParameter; }
    public int AmuseingParameter { get => _amuseingParameter; }
    public int SexyParameter { get => _sexyParameter; }
    public int GhostlyParameter { get => _ghostlyParameter; }
    //�e��p�[�c�����Ă��邩�̔���
    bool _clotheAttached = false;
    bool _shoseAttached = false;
    bool _accessoryAttached = false;

    CustomerController _customerController;
    public void SetClothes()
    {
        _customerController = FindObjectOfType<CustomerController>();
        if (_clotheAttached == true)
        {
            for (int i = 0; i < _customerController.Dresses.Length; i++)
            {
                _customerController.Dresses[i].SetActive(false);
            }
        }
        else _clotheAttached = true;
        _customerController.Dresses[_index].SetActive(true);
        Decision.Instance.Clothes._cute = _cuteParameter;
        Decision.Instance.Clothes._cool = _coolParameter;
        Decision.Instance.Clothes._amuseing = _amuseingParameter;
        Decision.Instance.Clothes._sexy = _sexyParameter;
        Decision.Instance.Clothes._ghostly = _ghostlyParameter;
    }
    public void SetShoes()
    {
        _customerController = FindObjectOfType<CustomerController>();
        if (_shoseAttached == true)
        {
            for (int i = 0; i < _customerController.Shoes.Length; i++)
            {
                _customerController.Shoes[i].SetActive(false);
            }
        }
        else _shoseAttached = true;
        _customerController.Shoes[_index].SetActive(true);
        Decision.Instance.Shoes._cute = _cuteParameter;
        Decision.Instance.Shoes._cool = _coolParameter;
        Decision.Instance.Shoes._amuseing = _amuseingParameter;
        Decision.Instance.Shoes._sexy = _sexyParameter;
        Decision.Instance.Shoes._ghostly = _ghostlyParameter;
    }
    public void SetAccessory()
    {
        _customerController = FindObjectOfType<CustomerController>();
        if (_accessoryAttached == true)
        {
            for (int i = 0; i < _customerController.Accessories.Length; i++)
            {
                _customerController.Accessories[i].SetActive(false);
            }
        }
        else _accessoryAttached = true;
        _customerController.Accessories[_index].SetActive(true);
        Decision.Instance.Accessory._cute = _cuteParameter;
        Decision.Instance.Accessory._cool = _coolParameter;
        Decision.Instance.Accessory._amuseing = _amuseingParameter;
        Decision.Instance.Accessory._sexy = _sexyParameter;
        Decision.Instance.Accessory._ghostly = _ghostlyParameter;
    }
}
