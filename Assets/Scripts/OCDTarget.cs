using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OCDTarget : MonoBehaviour, IPointerClickHandler
{
    public bool On = false;
    private bool onChange = false;
    private OCDSystem parentOCDSystem;
    // Start is called before the first frame update
    void Start()
    {
        parentOCDSystem = FindObjectsOfType<OCDSystem>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (onChange != On) {
            if (On) Enable();
            else Disable();
        }
        onChange = On;
    }

    public void Enable()
    {
        On = true;
        onChange = On;
        Debug.Log(gameObject);
        gameObject.GetComponent<Highlight>().On = true;
    }

    public void Disable()
    {
        On = false;
        onChange = On;
        gameObject.GetComponent<Highlight>().On = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (On) parentOCDSystem.ObeyCompulsion();
    }
}

