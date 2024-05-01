using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from
// https://www.sunnyvalleystudio.com/blog/unity-3d-selection-highlight-using-emission
public class Highlight : MonoBehaviour
{
    //we assign all the renderers here through the inspector
    [SerializeField]
    private List<Renderer> renderers;
    [SerializeField]
    private Color color = Color.HSVToRGB(0.2f, 0.7f, 0.1f, false);
    public bool On = false;

    //helper list to cache all the materials ofd this object
    private List<Material> materials;

    private void Update()
    {
        ToggleHighlight(On);
    }

    //Gets all the materials from each renderer
    private void Awake()
    {
        materials = new List<Material>();
        foreach (var renderer in renderers)
        {
            //A single child-object might have mutliple materials on it
            //that is why we need to all materials with "s"
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

    public void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach (var material in materials)
            {
                //We need to enable the EMISSION
                material.EnableKeyword("_EMISSION");
                //before we can set the color
                material.SetColor("_EmissionColor", color);
            }
        }
        else
        {
            foreach (var material in materials)
            {
                //we can just disable the EMISSION
                //if we don't use emission color anywhere else
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}
