using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public HealthBehaviour health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health.isDead())
        {
            Debug.Log("PLAYER MORREU");
            this.gameObject.SetActive(false);
        }
    }
}
