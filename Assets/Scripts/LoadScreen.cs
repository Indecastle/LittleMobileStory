using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public GameObject LoadingScreen;

    public Slider scale;


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
            scale.value = loadAsync.progress;
            yield return null;
            
            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
        
            
        }
        
        var plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (plane.Raycast(ray, out float position))
        {
            Vector3 worldPosition = ray.GetPoint(position);
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
