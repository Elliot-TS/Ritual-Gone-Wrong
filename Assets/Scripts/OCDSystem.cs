using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;


// using OCDTarget;
using UnityEngine;

public class OCD : MonoBehaviour
{
    float AnxietyLevel = 0.0f;
    float AnxietyReduceRate = 0.0f;
    float CompulsionTriggerStep = 0.01f;
    float TimeForCompulsion = 0.0f;

    OCDTarget[] CompulsionContainers;
    
    


    // Start is called before the first frame update
    void Start()
    {

        OCDTarget[] parentObjectsInScene = this.gameObject.scene.GetRootGameObjects().Select(
            x => x.GetComponentsInChildren<OCDTarget>()).Aggregate<OCDTarget[]>(
            (a, b) => a.Union<OCDTarget>(b).ToArray<OCDTarget>());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
