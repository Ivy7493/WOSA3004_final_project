using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnPrefab;
    void Start()
    {
        
    }

    public void PlaySound(AudioClip _clip)
    {
        GameObject temp = Instantiate(SpawnPrefab, transform.position, Quaternion.identity);
        temp.GetComponent<Sound_spawn>().SetSound(_clip);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
