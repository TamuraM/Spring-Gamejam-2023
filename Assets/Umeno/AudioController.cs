using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [Header("0:‘I‘ð‰¹")]
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

    public enum SelectAudio
    {
        select,
    }
}
