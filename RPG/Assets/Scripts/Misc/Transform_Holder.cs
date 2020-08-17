using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform_Holder : MonoBehaviour
{
    // Start is called before the first frame update
    //Unity work around with Destorying the game object
    GameObject Enemy;
    bool Startcheck = false;
    void Start()
    {
        
    }

    public void SetEnemy(GameObject _enemy)
    {
        Enemy = _enemy;
        Startcheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Startcheck == true)
        {
            if(Enemy == null)
            {
                Destroy(gameObject);
            }
        }
    }
}
