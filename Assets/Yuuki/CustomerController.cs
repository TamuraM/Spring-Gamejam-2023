using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �q�̃N���X�B���̔z��������Ă��� </summary>
public class CustomerController : MonoBehaviour
{
    [SerializeField, Header("�����s�[�X")] GameObject[] dresses = new GameObject[5];
    [SerializeField, Header("�C")] GameObject[] shoes = new GameObject[5];
    [SerializeField, Header("�A�N�Z�T���[")] GameObject[] accessories= new GameObject[5];
    public GameObject[] Dresses { get => dresses; }
    public GameObject[] Shoes { get => shoes; }
    public GameObject[] Accessories { get => accessories; }
}
