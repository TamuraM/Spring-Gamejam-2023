using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary> 客のクラス。服の配列を持っている </summary>
public class CustomerController : MonoBehaviour
{
    [SerializeField, Header("ワンピース")] GameObject[] dresses = new GameObject[5];
    [SerializeField, Header("靴")] GameObject[] shoes = new GameObject[5];
    [SerializeField, Header("アクセサリー")] GameObject[] accessories= new GameObject[5];
    [Header("客毎のSE")]
    [SerializeField, Tooltip("大満足時のSE")] SelectAudio _verryGoodAudio;
    [SerializeField, Tooltip("満足時のSE")] SelectAudio _goodAudio;
    [SerializeField, Tooltip("不満時のSE")] SelectAudio _missAudio;
    [SerializeField, Tooltip("髪ありのイラストと髪なしのイラスト")] Sprite[] _images;
    public GameObject[] Dresses { get => dresses; }
    public GameObject[] Shoes { get => shoes; }
    public GameObject[] Accessories { get => accessories; }
    SpriteRenderer _customImage;
    private void Awake()
    {
        _customImage = GetComponent<SpriteRenderer>();
    }

    public void ImageChange(bool isAmuseing)
    {
        if(!isAmuseing)
        {
            _customImage.sprite = _images[0];
        }
        else
        {
            _customImage.sprite = _images[1];
        }
    }
    //大満足時のSEを再生
    public void VerryGoodPlay()
    {
        AudioController.Instance.SePlay(_verryGoodAudio);
    }

    //満足時のSEを再生
    public void GoodPlay()
    {
        AudioController.Instance.SePlay(_goodAudio);
    }

    //不満時のSEを再生
    public void MissPlay()
    {
        AudioController.Instance.SePlay(_missAudio);
    }
}
