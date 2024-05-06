using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    public GameObject pickUpText;

    public bool inReach;
    public bool picked;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player")
        {
            GameVariables.keyCount += 2;
            Destroy(gameObject);
        }
    }


    void Update()
    {
        
    }
}
