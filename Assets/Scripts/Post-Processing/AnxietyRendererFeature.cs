using UnityEngine.Rendering.Universal;

public class AnxietyRendererFeature: ScriptableRendererFeature
{
    AnxietyRenderPass anxietyRenderPass;

    public override void Create() 
    {
        anxietyRenderPass = new AnxietyFilterRenderPass();
        name = "AnxietyFilter";
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (blurRenderPass.Setup(renderer)) {
            renderer.EnqueuePass(anxietyRenderPass);
        }
    }
}
