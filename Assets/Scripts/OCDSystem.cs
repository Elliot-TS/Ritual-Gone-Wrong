using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OCDSystem : MonoBehaviour
{
    private OCDTarget[] ocdTargets;
    private OCDTarget ocdTarget;
    private bool activeCompulsion = false;
    private float compulsionStartTime;
    private float compulsionDuration = 10f;
    private float compulsionAnxietyRate = 0.7f;
    private float normalAnxietyRate = 0.1f;
    private float anxietyDecayRate = 0.2f;
    private int numRepeats = 4;
    private int repeatCounter = 0;
    private double anxiety = 0;
    // Start is called before the first frame update
    void Start()
    {
        ocdTargets = FindObjectsOfType<OCDTarget>();        
        ActivateCompulsion();
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        double rand = rnd.NextDouble();
        bool compulse = rand <= CalculateCompulsionFrequency() * Time.deltaTime;
        if (!activeCompulsion && compulse) {
            Debug.Log("Activating");
            ActivateCompulsion();
        }

        AnxietyPolicy();
        Debug.Log("Anxiety: " + anxiety);
        Debug.Log("Compulsion Frequency: " + CalculateCompulsionFrequency());
    }

    private void AnxietyPolicy() {
        if (activeCompulsion) {
            if (Time.time - compulsionStartTime < compulsionDuration) {
                anxiety += compulsionAnxietyRate * Time.deltaTime;
            }
            else {
                anxiety -= anxietyDecayRate * Time.deltaTime;
            }
            if (anxiety <= 0)
                OvercomeCompulsion();
        }
        else {
            anxiety += normalAnxietyRate * Time.deltaTime;
        }
    }
    private double CalculateCompulsionFrequency() {
        return System.Math.Atan(anxiety / 20f) * 2.0/System.Math.PI;
    }
    public void ActivateCompulsion() {
        activeCompulsion = true;
        compulsionStartTime = Time.time;
        ocdTarget = getOCDTarget();
        ocdTarget.Enable();
    }
    public void ObeyCompulsion()
    {
        activeCompulsion = false;
    }
    public void OvercomeCompulsion()
    {
        activeCompulsion = false;
        anxiety = 0;
        ocdTarget.Disable();
    }

    private OCDTarget getOCDTarget() {
        System.Random rnd = new System.Random();
        int randIndex = rnd.Next(ocdTargets.Length);         
        return ocdTargets[randIndex];
    }
}
