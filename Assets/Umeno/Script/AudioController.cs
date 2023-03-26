using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : InstanceSystem<AudioController>
{
    [Header("0:選択音")]
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
    VerryGoodWoman,
    GoodWoman,
    MissWoman,
    VerryGoodMan,
    GoodMan,
    MiaaMan,
    SheetChange,
    Shutter,
}
