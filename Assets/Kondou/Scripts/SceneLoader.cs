using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    [Header("ロードするシーンの名前")]
    string _loadSceneName;

    public void SceneLoad()
    {
        SceneManager.LoadScene(_loadSceneName);
    }
}
