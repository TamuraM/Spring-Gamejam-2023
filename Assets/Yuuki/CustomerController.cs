using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 客のクラス。服の配列を持っている </summary>
public class CustomerController : MonoBehaviour
{
    [SerializeField, Header("ワンピース")] GameObject[] dresses = new GameObject[5];
    [SerializeField, Header("靴")] GameObject[] shoes = new GameObject[5];
    [SerializeField, Header("アクセサリー")] GameObject[] accessories= new GameObject[5];

}
