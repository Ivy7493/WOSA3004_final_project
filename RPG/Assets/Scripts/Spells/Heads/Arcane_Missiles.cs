using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcane_Missiles : MonoBehaviour
{
    // Start is called before the first frame update
    UI_Manager UIM;
    public float DamageScale;
    public float Speed;
    public float Range;
    public float Duration;
    public float TickRate;
    public GameObject Missile;
    float counter = 0f;
    Vector3 pos;
    Vector3 StartPos;
    Vector3 Direction;
    GameObject Player;
    public float KnockBack;
    float Damage;
    bool Channeling = true;
    Queue<GameObject> MissileList;
    void Start()
    {
        MissileList = new Queue<GameObject>();
        UIM = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<UI_Manager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0f);
        Damage = DamageScale * GameObject.FindGameObjectWithTag("Experience_Manager").GetComponent<Experience_Manager>().ReturnLevel();
        Direction = (pos - Player.transform.position).normalized;
        StartPos = transform.position;
        InvokeRepeating("Spell", 0f, TickRate);
        Debug.Log(GameObject.FindGameObjectsWithTag("Arcane_Missiles").Length + " : Active spells");
        if(GameObject.FindGameObjectsWithTag("Arcane_Missiles").Length > 1)
        {
            for(int i = 0; i < MissileList.Count; i++)
            {
                Destroy(MissileList.Dequeue());
            }
            Destroy(gameObject);
        }
    }

    void Spell()
    {


        float Xpos = 0;
        float Ypos = 0;
            GameObject CurrentMissile = Instantiate(Missile, new Vector3(Player.transform.position.x + Xpos, Player.transform.position.y + Ypos, 0f), Quaternion.identity);
            try
            {
                CurrentMissile.GetComponent<Missile>().SetValues(Damage / 2, Range, Speed);
                MissileList.Enqueue(CurrentMissile);
              }
            catch
            {
                Debug.Log("YPPPPPP:");
            }

    

        



    }

    void ChannelingCheck()
    {
        
        counter += Time.deltaTime;
        if(counter >= Duration)
        {
            Channeling = false;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        ChannelingCheck();
    }
}
