using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 次に来店する客を生成するクラス </summary>
public class CustomerGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("客のプレハブ")] GameObject[] customers = new GameObject[6];
    [SerializeField, Tooltip("オーダーのボーダー")] int _orderBorder = default;
    [SerializeField, Tooltip("オーダーのセリフテキスト")] Text _orderText = default;
    [Header("オーダーのセリフ内容")]
    [SerializeField, Tooltip("可愛い")] string _cuteLogue = default;
    [SerializeField, Tooltip("かっこいい")] string _coolLogue = default;
    [SerializeField, Tooltip("面白い")] string _amusingLogue = default;
    [SerializeField, Tooltip("セクシー")] string _sexyLogue = default;
    [SerializeField, Tooltip("怖い")] string _ghostlyLogue = default;

    /// <summary> 次の客を生成する。Decisionから呼ばれる </summary>
    public void Generate()
    {
        _order = DecideOrder(); //オーダーを決定する
        _orderText.text = Dialogue(_order); //セリフを表示する
        DecideCusttomer().SetActive(true);  //客を表示する
    }

    /// <summary> 次のオーダーの内容を管理する列挙型 </summary>
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
    
    /// <summary> 次のオーダーを決定する </summary>
    /// <returns></returns>
    private NextOrder DecideOrder()
    {
        int orderIndex = UnityEngine.Random.Range(0, 4);
        //ランダムにオーダーを生成するために、Enumをintに変換
        NextOrder next = (NextOrder)Enum.ToObject(typeof(NextOrder), orderIndex);
        return next;
    }

    /// <summary> オーダーに合わせて、スコアのボーダーを設定する </summary>
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

    /// <summary> 客のプレハブを決定する </summary>
    private GameObject DecideCusttomer()
    {
        int customerIndex = UnityEngine.Random.Range(0, 5);
        return customers[customerIndex];
    }

    /// <summary> オーダーに合わせてセリフを決定する </summary>
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
