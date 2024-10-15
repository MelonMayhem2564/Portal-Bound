using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    float currentHealth;
    int maxHealth = 3;
    bool invincible = false;
    float invincibletimer;
    public GameObject enemy;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        invincible = false;
        invincibletimer = 0;
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        print("Health = " + player.GetComponent<SpriteScripts>().GetHealth());
    }
    
}
