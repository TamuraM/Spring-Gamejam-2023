using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>リザルトを表示する</summary>
public class ShowResult : MonoBehaviour
{
    [Header("UI関係")]
    [SerializeField, Tooltip("リザルトのアニメーション")] private Animator _resultAnim = default;
    [SerializeField, Tooltip("スコアを表示するテキスト")] private Text _score = default;
    [SerializeField, Tooltip("「New Record」の文字")] private Image _newRecord = default;
    [SerializeField, Tooltip("")]

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Result(int score)
    {
        //アニメーション再生
        //_resultAnim.Play();

        //スコアによって表示する内容を変える
    }
}
