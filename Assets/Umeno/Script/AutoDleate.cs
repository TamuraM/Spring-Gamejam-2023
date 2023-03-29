using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDleate : MonoBehaviour
{
    [SerializeField]float _destroyTime;
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }
}
