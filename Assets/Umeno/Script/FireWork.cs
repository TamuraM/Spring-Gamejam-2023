using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    [SerializeField] Transform[] _fireWorkPoint;
    [SerializeField] GameObject[] _fireWork;
    int _positionIndex;
    int _fireWorkIndex;

    private void Update()
    {
        if(FindObjectsOfType<AutoDleate>().Length < 4)
        {
            _positionIndex = Random.Range(0, _fireWorkPoint.Length);
            _fireWorkIndex = Random.Range(0, _fireWork.Length);
            Instantiate(_fireWork[_fireWorkIndex], _fireWorkPoint[_positionIndex].position, transform.rotation);

        }
    }
}
