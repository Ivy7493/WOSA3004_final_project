using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LoadingBar;
    void Start()
    {

        StartCoroutine(StartAsyncLoad());
    }

    IEnumerator StartAsyncLoad()
    {
        AsyncOperation Loading = SceneManager.LoadSceneAsync(2);
        while (Loading.progress < 1)
        {
            LoadingBar.GetComponent<Slider>().value = Loading.progress;
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
