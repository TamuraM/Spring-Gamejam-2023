using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusWindow : MonoBehaviour
{
    [Header("各パラメーターのステータス")]
    [SerializeField, Tooltip("cuteのslider")] Slider _cuteStatus;
    [SerializeField, Tooltip("coolのslider")] Slider _coolStatus;
    [SerializeField, Tooltip("amuseingのslider")] Slider _amuseingStatus;
    [SerializeField, Tooltip("sexyのslider")] Slider _sexyStatus;
    [SerializeField, Tooltip("ghostlyのslider")] Slider _ghostlyStatus;
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
