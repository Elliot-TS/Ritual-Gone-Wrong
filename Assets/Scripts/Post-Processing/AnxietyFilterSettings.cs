using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[System.Serializable, VolumeComponentMenu("Post-processing/AnxietyFilter")]
public class AnxietyFilterSettings: VolumeComponent, IPostProcessComponent 
{
    [Tooltip("The intensity of the effect.")]
    public ClampedFloatParameter strength = new ClampedFloatParameter(0f,0f,15f);

    public bool IsActive() {
        return strength.value > 0f;
     }
    public bool IsTileCompable() {
        return false;
    }
}
