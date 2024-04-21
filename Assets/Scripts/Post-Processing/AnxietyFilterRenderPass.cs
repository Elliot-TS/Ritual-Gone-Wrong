using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// Credit to https://youtu.be/AlCuc58z7E8?si=MYIsWWn_DejDJZDm for most of the code here :)
public class AnxietyFilterRenderPass : ScriptableRenderPass 
{
    private Material material;
    private AnxietyFilterSettings settings;
    private RenderTargetIdentifier source;
    private RenderTargetHandle filterTex;
    private int filterTexID;

    public bool Setup(ScriptableRenderer renderer) {
        source = renderer.cameraColorTarget;
        settings = VolumeManager.instance.stack.GetComponent<AnxietyFilterSettings>();
        renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;

        if (blurSettings != null && settings.IsActive()) {
            material = new Material(Shader.Find("PostProcessing/AnxietyFilter"));
            return true;
        }
        return false;
    }

    // Implement COnfigure, Exectute, and FrameCleanup
    public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
    {
        if (settings == null || material == null) return;

        filterTexID = Shader.PropertyToID("_FilterTex");
        filterTex = new RenderTargetHandle();
        filterTex.id = filterTexID;
        cmd.GetTemporaryRT(filterTex.id, cameraTextureDescriptor);
        
        base.Configure(cmd, cameraTextureDescriptor);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        if (settings == null || material == null) return;

        CommandBuffer cmd = CommandBufferPool.Get("Blur Post Process");

        // Set BLuf effect properties
        // TODO: Change this to anxiety filter settings
        int gridSize = Mathf.CeilToInt(settings.strength.value * 6.0f);
        if (gridSize % 2 == 0) gridSize++;

        material.SetInteger("_GridSize", gridSize);
        material.SetFloat("_Spread", settings.strength.value);

        // Execute effect using effect material with two passes
        cmd.Blit(source, filterTex.id, material, 0);
        cmd.Blit(filterTex.id, source, material, 1);
        context.ExecuteCommandBuffer(cmd);

        cmd.Clear();
        CommandBufferPool.Release(cmd);
    }

    public override void FrameCleanup(CommandBuffer cmd)
    {
        cmd.ReleaseTemporaryRT(filterTex.id);
        base.FrameCleanup(cmd);
    }
}
