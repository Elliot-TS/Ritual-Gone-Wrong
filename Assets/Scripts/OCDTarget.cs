using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OCDTarget : MonoBehaviour, IPointerClickHandler
{
    public bool On = false;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (once) {
            Enable();
            once = false;
        }
    }

    public void Enable()
    {
        On = true;
        gameObject.GetComponent<Highlight>().On = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        On = false;
        gameObject.GetComponent<Highlight>().On = false;
    }
}

