using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusWindow : MonoBehaviour
{
    [Header("�e�p�����[�^�[�̃X�e�[�^�X")]
    [SerializeField, Tooltip("cute��slider")] Slider _cuteStatus;
    [SerializeField, Tooltip("cool��slider")] Slider _coolStatus;
    [SerializeField, Tooltip("amuseing��slider")] Slider _amuseingStatus;
    [SerializeField, Tooltip("sexy��slider")] Slider _sexyStatus;
    [SerializeField, Tooltip("ghostly��slider")] Slider _ghostlyStatus;
    public void StatusGet()
    {
        CostumeChange parameter = GetComponent<CostumeChange>();
        _cuteStatus.value = parameter.CuteParameter;
        _coolStatus.value = parameter.CoolParameter;
        _amuseingStatus.value = parameter.AmuseingParameter;
        _sexyStatus.value = parameter.SexyParameter;
        _ghostlyStatus.value = parameter.GhostlyParameter;
    }
}
