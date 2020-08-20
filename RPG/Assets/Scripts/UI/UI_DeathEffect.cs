using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeathEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DeathText;
    public GameObject FadeBlackEffect;
    public AudioSource AS;
    float counter = 0f;
    float Switch = 0;
    void Start()
    {
       
    }

    private void OnEnable()
    {
        counter = 0f;
        float select = Random.Range(0, 2);
        AS.Play();

        switch (select)
        {
            case 0:
                DeathText.GetComponent<Text>().text = "You can't die now....Not yet At least";
                break;
            case 1:
                DeathText.GetComponent<Text>().text = "The only way to escape is to keep moving forward";
                break;
        }
    }
    void Effect()
    {
        counter += Time.deltaTime;
        switch (Switch)
        {
            case 0:
                counter *= 1.5f;
                FadeBlackEffect.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, counter);
                if(counter >= 1)
                {
                    Switch = 1;
                    counter = 0;
                }
                break;
            case 1:
                if(counter >= 1)
                {
                    counter = 0;
                    Switch = 2;
                }
                break;
            case 2:
                FadeBlackEffect.GetComponent<Image>().color = Color.Lerp(Color.black, Color.clear, counter);
                if (counter >= 1)
                {
                    counter = 0;
                    gameObject.SetActive(false);
                    Switch = 0;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Effect();
    }
}
