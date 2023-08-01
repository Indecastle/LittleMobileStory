using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void Loading(int sceneId)
    {
        StartCoroutine(LoadSilentAsync(sceneId));
    }
    
    public IEnumerator LoadSilentAsync(int sceneId)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneId);
        while (!loadAsync.isDone)
            yield return null;
    }
}
