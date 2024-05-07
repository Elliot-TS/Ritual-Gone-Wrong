using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OCDSystem : MonoBehaviour
{
    private OCDTarget[] ocdTargets;
    private OCDTarget ocdTarget;

    private VolumeProfile anxietyEffect;
    private ColorAdjustments colorAdjustments;
    private ChromaticAberration chromaticAberration;
    private Vignette vignette;
    private FilmGrain filmGrain;
    private LensDistortion lensDistortion;

    private bool activeCompulsion = false;
    private float compulsionStartTime;
    private float compulsionDuration = 10f;
    private float compulsionAnxietyRate = 0.7f;
    private float normalAnxietyRate = 0.1f;
    private float anxietyDecayRate = 0.2f;
    private double numRepeats = 4;
    private int repeatCounter = 0;
    private double anxiety = 0;
    private double baseAnxiety = 0;
    // Start is called before the first frame update
    void Start()
    {
        ocdTargets = FindObjectsOfType<OCDTarget>();        
        ActivateCompulsion();
        anxietyEffect = GameObject.Find("AnxietyEffect").GetComponent<Volume>().profile;
        if (!anxietyEffect.TryGet(out vignette)) {
            throw new System.Exception("Vignette not found");
        }
        if (!anxietyEffect.TryGet(out colorAdjustments)) {
            throw new System.Exception("ColorAdjustments not found");
        }
        if (!anxietyEffect.TryGet(out chromaticAberration)) {
            throw new System.Exception("ChromaticAberration not found");
        }
        if (!anxietyEffect.TryGet(out filmGrain)) {
            throw new System.Exception("FilmGrain not found");
        }
        if (!anxietyEffect.TryGet(out lensDistortion)) {
            throw new System.Exception("LensDistortion not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        System.Random rnd = new System.Random();
        double rand = rnd.NextDouble();
        bool compulse = rand <= CalculateCompulsionFrequency() * Time.deltaTime;
        if (!activeCompulsion && compulse) {
            ActivateCompulsion();
        }

        AnxietyPolicy();
        UpdateFilters();
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
        ocdTarget.Disable();

        // Consequence of Obeying compulsions: repeats
        if (repeatCounter < numRepeats) {
            repeatCounter++;
            ActivateCompulsion();
        }
        else {
            repeatCounter = 0;
            anxiety = baseAnxiety;
        }

        // Consequence of Obeying compulsions: increase in base anxiety and anxiety rates
        baseAnxiety += 0.3f;
        normalAnxietyRate += 0.1f;
        compulsionAnxietyRate += 0.05f;
        numRepeats += 0.3;
    }
    public void OvercomeCompulsion()
    {
        activeCompulsion = false;
        anxiety = 0;
        ocdTarget.Disable();

        baseAnxiety -= 0.1f;
        normalAnxietyRate -= 0.1f;
        compulsionAnxietyRate -= 0.05f;
        numRepeats -= 0.1;
    }

    private OCDTarget getOCDTarget() {
        System.Random rnd = new System.Random();
        int randIndex = rnd.Next(ocdTargets.Length);         
        return ocdTargets[randIndex];
    }

    private void UpdateFilters() {
        float anxietyEffectStrength = Mathf.Atan((float)anxiety / 5f) * 2f / Mathf.PI;
        Debug.Log(anxietyEffectStrength);
        vignette.intensity.value = anxietyEffectStrength * 0.5f;
        filmGrain.intensity.value = anxietyEffectStrength * 4;
        colorAdjustments.hueShift.value = -anxietyEffectStrength * 190;
        if (anxietyEffectStrength > 0.5) {
            chromaticAberration.intensity.value = (anxietyEffectStrength*2f - 1f) * 0.9f;
            lensDistortion.intensity.value = (anxietyEffectStrength*2f - 1f) * 0.95f;
            lensDistortion.xMultiplier.value = Mathf.Sin(Time.time) * 0.4f + 0.5f;
            lensDistortion.yMultiplier.value = Mathf.Cos(Time.time) * 0.4f + 0.5f;
        }
        else {
            chromaticAberration.intensity.value = 0;
            lensDistortion.intensity.value = 0;
            lensDistortion.xMultiplier.value = 1;
            lensDistortion.yMultiplier.value = 1;
        }

        if (anxietyEffectStrength > 0.8) {
            lensDistortion.scale.value = 1f - (anxietyEffectStrength-0.8f)*4f;
        }
    }
}
