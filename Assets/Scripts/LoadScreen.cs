using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;

    private float _progress;


    public void Loading(int sceneId)
    {
        // LoadingScreen.SetActive(true);

        StartCoroutine(LoadAsync(sceneId));
    }

    IEnumerator LoadAsync(int sceneId)
    {
        Debug.Log(sceneId);
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneId);
        loadAsync.allowSceneActivation = false;
        
        while (!loadAsync.isDone)
        {
            var diff = loadAsync.progress - _progress;
            _progress += diff == 0 ? 0 : Math.Sign(diff) / 100f;
            scale.value = Math.Min(_progress, 0.9f);
            // Debug.Log($"{_progress}  {loadAsync.progress}");
            yield return null;
            
            if (_progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(0.3f);
                loadAsync.allowSceneActivation = true;
            }
        }
    }
    
    void Awake()
    {
        Debug.Log("Loading Awake");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading Start");
        StartCoroutine(LoadAsync(1));
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Update");
    }
}
