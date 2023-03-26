using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    [SerializeField, Header("ワンピース")] GameObject[] dresses = new GameObject[5];
    [SerializeField, Header("靴")] GameObject[] shoes = new GameObject[5];
    [SerializeField, Header("アクセサリー")] GameObject[] accessories= new GameObject[5];

}
