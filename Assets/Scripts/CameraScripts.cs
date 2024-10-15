using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    public GameObject player;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0, 1, -10);
    }
}
