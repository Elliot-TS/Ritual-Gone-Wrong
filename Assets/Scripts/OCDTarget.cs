using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OCDTarget : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
        Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enable()
    {
        gameObject.GetComponent<Highlight>().ToggleHighlight(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Highlight>().ToggleHighlight(false);
    }
}

