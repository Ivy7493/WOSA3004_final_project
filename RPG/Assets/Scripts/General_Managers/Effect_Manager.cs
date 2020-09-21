using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
      
    }


    public void ScreenShake(float duration)
    {
        StartCoroutine(Shake(duration));
    }


    IEnumerator Shake(float duration)
    {
        float counter = 0f;
        while(counter < duration)
        {
            float x = Random.Range(-1, 1f)*1;
            float y = Random.Range(-1, 1f)*1;
            Camera.main.gameObject.transform.localPosition = new Vector3(Player.transform.position.x + x, Player.transform.position.y + y, -10);
            counter += Time.deltaTime;
            yield return null;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
