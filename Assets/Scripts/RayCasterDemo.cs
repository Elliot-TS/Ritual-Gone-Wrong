/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OCDTarget : MonoBehaviour, IPointerClickHandler
{
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        Enable();
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
        gameObject.GetComponent<Highlight>().On = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Highlight>().On = false;
    }
}
*/