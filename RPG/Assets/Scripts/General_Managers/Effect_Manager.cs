using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Effect_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    GameObject Post;
    public Volume _Profile;
    VolumeProfile _pro;
    UI_Manager UIM;
    Sound_Manager SM;
    public GameObject LevelEffect;
    
    
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Post = GameObject.FindGameObjectWithTag("PostProcessing");
        SM = GameObject.FindGameObjectWithTag("Sound_Manager").GetComponent<Sound_Manager>();
        _pro = _Profile.profile;
        Debug.Log(_pro.components[1]);
        VolumeComponent CA = _pro.components[1];
        
    
        
    }

    public void DamageEffect(float Duration)
    {
       
        ScreenShake(Duration);
        ScreenFlare();
        UIM.DamageEffectUI();
        
    }

    public void NoManaEffect()
    {
        AudioClip Clip = Resources.Load("No Mana", typeof(AudioClip)) as AudioClip;
        try
        {
            SM.PlaySound(Clip);
        }
        catch
        {

        }


    }
    //Level up effect
    public void LevelUpEffect()
    {
        UIM.SetLevelUp();
        Instantiate(LevelEffect, Player.transform.position, Quaternion.identity);
       // Time.timeScale = 0.3f;
       // StartCoroutine(SpeedUpTime(1f));
    }

    IEnumerator SpeedUpTime(float time)
    {
        float temp = Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Lerp(1, 0.5f, temp);
        yield return new WaitForSeconds(time);
        Time.timeScale = 1f;
    }

    public void ScreenShake(float duration)
    {
        StartCoroutine(Shake(duration));
    }

    public void ScreenFlare()
    {
        StartCoroutine(Flare(0));
    }

    IEnumerator Flare(float Duration)
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
           // CA.intensity.Override(ft);
            yield return null;
        }
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
