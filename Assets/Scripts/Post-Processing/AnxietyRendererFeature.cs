using UnityEngine.Rendering.Universal;

public class AnxietyRendererFeature : ScriptableRendererFeature
{
    AnxietyFilterRenderPass anxietyFilterRenderPass;

    public override void Create()
    {
        anxietyFilterRenderPass = new AnxietyFilterRenderPass();
        name = "AnxietyFilter";
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if(anxietyFilterRenderPass.Setup(renderer))
        {
            renderer.EnqueuePass(anxietyFilterRenderPass);
        }
    }
}