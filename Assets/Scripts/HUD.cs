using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthUI;
    public int currentHealth;
    public int maxHealth = 3;
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
        healthUI.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        print("Health = " + player.GetComponent<SpriteScripts>().GetHealth());
        healthUI.text = "Health : " + player.GetComponent<SpriteScripts>().GetHealth();
    }
}