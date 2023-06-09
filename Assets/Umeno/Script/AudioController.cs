﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : InstanceSystem<AudioController>
{
    [Header("0:選択音")]
    [Header("1:女1大満足")]
    [Header("2:女1満足")]
    [Header("3:女1不満")]
    [Header("4:女2大満足")]
    [Header("5:女2満足")]
    [Header("6:女2不満")]
    [Header("7:女3大満足")]
    [Header("8:女3満足")]
    [Header("9:女3不満")]
    [Header("10:外国人大満足")]
    [Header("11:外国人満足")]
    [Header("12:外国人不満")]
    [Header("13:チャラ男大満足")]
    [Header("14:チャラ男満足")]
    [Header("15:チャラ男不満")]
    [Header("16:オカマ大満足")]
    [Header("17:オカマ満足")]
    [Header("18:オカマ不満")]
    [Header("19:シャッター")]
    [SerializeField] AudioClip[] _clips;
    AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SePlay(SelectAudio seName)
    {
        int index = (int)seName;
        _audio.PlayOneShot(_clips[index]);
    }
}

public enum SelectAudio
{
    Select,
    Woman1VerryGood,
    Woman1Good,
    Woman1Miss,
    Woman2VerryGood,
    Woman2Good,
    Woman2Miss,
    Woman3VerryGood,
    Woman3Good,
    Woman3Miss,
    Man1VerryGood,
    Man1Good,
    Man1Miss,
    Man2VerryGood,
    Man2Good,
    Man2Miss,
    Man3VerryGood,
    Man3Good,
    Man3Miss,
    Shutter,
}
