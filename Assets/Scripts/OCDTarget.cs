using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OCDTarget : MonoBehaviour, IPointerClickHandler
{
    public bool On = false;
    private bool onChange = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("---");
        Debug.Log(On);
        Debug.Log(onChange);
        if (onChange != On) {
            if (On) Enable();
            else Disable();
        }
        onChange = On;
    }

    public void Enable()
    {
        On = true;
        gameObject.GetComponent<Highlight>().On = true;
    }

    public void Disable()
    {
        On = false;
        gameObject.GetComponent<Highlight>().On = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Disable();
    }
}

