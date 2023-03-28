using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 次に来店する客を生成するクラス </summary>
public class CustomerGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("客のプレハブ(前半が女子・後半が男子)")] GameObject[] customers = new GameObject[6];
    [SerializeField, Tooltip("オーダーのボーダー")] int _orderBorder = default;
    [SerializeField, Tooltip("オーダーのセリフテキスト")] Text _orderText = default;
    [Header("オーダーのセリフ内容")]
    [SerializeField] String[] diaLogues = new string[Enum.GetNames(typeof(NextOrder)).Length];
    [SerializeField, Tooltip("女性の割合(％)")] float _womenRatio = default;

    /// <summary> 次の客を生成する。Decisionから呼ばれる </summary>
    public void Generate()
    {
        _order = DecideOrder(); //オーダーを決定する
        _orderText.text = Dialogue(_order); //セリフを表示する
        SetParameter(_order);
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

        Chara1 = 16,
        Chara2 = 17,
        Chara3 = 18,
        Chara4 = 19,
        Chara5 = 20,
        Chara6 = 21,
    }
    NextOrder _order = NextOrder.Uncertainty;

    /// <summary> 次のオーダーを決定する </summary>
    /// <returns></returns>
    private NextOrder DecideOrder()
    {
        //ランダムにオーダーを生成する
        int orderIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(NextOrder)).Length);
        //Enumをintに変換
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

            case NextOrder.CuteAndCool: Decision.Instance.Customer._cute = _orderBorder - 20; Decision.Instance.Customer._cool = _orderBorder - 40; break;
            case NextOrder.CuteAndAmusing: Decision.Instance.Customer._cute = _orderBorder - 20; Decision.Instance.Customer._amuseing = _orderBorder - 40; break;
            case NextOrder.CuteAndSexy: Decision.Instance.Customer._cute = _orderBorder - 20; Decision.Instance.Customer._sexy = _orderBorder - 40; break;
            case NextOrder.CuteAndGhostly: Decision.Instance.Customer._cute = _orderBorder - 20; Decision.Instance.Customer._ghostly = _orderBorder - 40; break;

            case NextOrder.CoolAndAmusing: Decision.Instance.Customer._cool = _orderBorder - 20; Decision.Instance.Customer._amuseing = _orderBorder - 40; break;
            case NextOrder.CoolAndSexy: Decision.Instance.Customer._cool = _orderBorder - 20; Decision.Instance.Customer._sexy = _orderBorder - 40; break;
            case NextOrder.CoolAndGhostly: Decision.Instance.Customer._cool = _orderBorder - 20; Decision.Instance.Customer._ghostly = _orderBorder - 40; break;

            case NextOrder.AmusingAndSexy: Decision.Instance.Customer._amuseing = _orderBorder - 20; Decision.Instance.Customer._sexy = _orderBorder - 40; break;
            case NextOrder.AmusingAndGhostly: Decision.Instance.Customer._amuseing = _orderBorder - 20; Decision.Instance.Customer._ghostly = _orderBorder - 40; break;

            case NextOrder.SexyAndGhostly: Decision.Instance.Customer._sexy = _orderBorder - 20; Decision.Instance.Customer._ghostly = _orderBorder - 40; break;

            case NextOrder.Chara1: /*Chara1のキャラ設定に合わせてパラメーターを変える*/; break;
            case NextOrder.Chara2: /*Chara2のキャラ設定に合わせてパラメーターを変える*/; break;
            case NextOrder.Chara3: /*Chara3のキャラ設定に合わせてパラメーターを変える*/; break;
            case NextOrder.Chara4: /*Chara4のキャラ設定に合わせてパラメーターを変える*/; break;
            case NextOrder.Chara5: /*Chara5のキャラ設定に合わせてパラメーターを変える*/; break;
            case NextOrder.Chara6: /*Chara6のキャラ設定に合わせてパラメーターを変える*/; break;

            default: break;
        }
    }

    /// <summary> 客のプレハブを決定する </summary>
    private GameObject DecideCusttomer()
    {
        switch (_order)
        {
            //「好み」で注文されたときは、キャラが確定している
            case NextOrder.Chara1: return customers[0];
            case NextOrder.Chara2: return customers[2];
            case NextOrder.Chara3: return customers[4];
            case NextOrder.Chara4: return customers[6];
            case NextOrder.Chara5: return customers[7];
            case NextOrder.Chara6: return customers[8];

            default:
                //「好み」以外で注文されたときは、キャラはランダムに決まる
                float lot = UnityEngine.Random.Range(0, 100);
                int customerIndex = default;
                float tempRatio = (7.0f / 5.0f) * _womenRatio - 4.0f;
                if (lot < tempRatio)
                {
                    customerIndex = UnityEngine.Random.Range(0, 6);
                }
                else
                {
                    customerIndex = UnityEngine.Random.Range(6, 9);
                }
                return customers[customerIndex];
        }
    }

    /// <summary> オーダーに合わせてセリフを決定する </summary>
    /// <param name="nextOrder"></param>
    /// <returns></returns>
    private string Dialogue(NextOrder nextOrder)
    {
        switch (nextOrder)
        {
            case NextOrder.Cute: return diaLogues[0];
            case NextOrder.Cool: return diaLogues[1];
            case NextOrder.Amusing: return diaLogues[2];
            case NextOrder.Sexy: return diaLogues[3];
            case NextOrder.Ghostly: return diaLogues[4];

            case NextOrder.CuteAndCool: return diaLogues[5];
            case NextOrder.CuteAndAmusing: return diaLogues[6];
            case NextOrder.CuteAndSexy: return diaLogues[7];
            case NextOrder.CuteAndGhostly: return diaLogues[8];

            case NextOrder.CoolAndAmusing: return diaLogues[9];
            case NextOrder.CoolAndSexy: return diaLogues[10];
            case NextOrder.CoolAndGhostly: return diaLogues[11];

            case NextOrder.AmusingAndSexy: return diaLogues[12];
            case NextOrder.AmusingAndGhostly: return diaLogues[13];

            case NextOrder.SexyAndGhostly: return diaLogues[14];

            default: return diaLogues[15];
        }
    }
}
