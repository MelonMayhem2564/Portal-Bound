using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToDeathScript : MonoBehaviour
{
    public GameObject Teleport;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.position =  Teleport.transform.position;
        }
    }
}
