using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        Debug.Log("pointer down");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("pointer up");
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("pointer clicked");
        Debug.Log(eventData.pointerClick);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer entered something");
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exited something");
    }


  

    // Update is called once per frame
    void Update()
    {
        
    }
}
