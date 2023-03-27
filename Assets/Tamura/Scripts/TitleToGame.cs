using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TitleToGame : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader = default;
    private PlayableDirector _titleTimeline = default;
    private bool _isDone = false;

    void Start()
    {
        _titleTimeline = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        
        if(!_isDone && _titleTimeline.time >= _titleTimeline.duration)
        {
            _sceneLoader.SceneLoad();
            _isDone = true;
        }

    }
}
