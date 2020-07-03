using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MyRPInstance : RenderPipeline
{
    public MySRPAsset Myasset;

    public MyRPInstance(MySRPAsset asset) {
        Myasset = asset;
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {     
        CommandBuffer command=new CommandBuffer();
        foreach (var camera in cameras)
        {
            //清除深度缓存和颜色缓存，输出纯颜色
            // context.SetupCameraProperties(camera);
            // command.ClearRenderTarget(true,true,Color.yellow);
            // context.ExecuteCommandBuffer(command);
            // context.Submit();

            //一定要设置这个，否则渲染不出任何东西
            context.SetupCameraProperties(camera);
            //渲染天空盒要在下面的代码之前，如果放到下面代码之后，则不能渲染出其他物体（应该是天空盒把后面的东西给覆盖了）
            context.DrawSkybox(camera);   
                       
            // Cull
            ScriptableCullingParameters cullParam = new ScriptableCullingParameters();
            camera.TryGetCullingParameters(out cullParam);
            cullParam.isOrthographic = false;
            CullingResults cullResults = context.Cull(ref cullParam);

            //render
            SortingSettings sortSet = new SortingSettings(camera)
            {
                criteria = SortingCriteria.CommonOpaque
            };
            DrawingSettings drawSet = new DrawingSettings(new ShaderTagId("Always"), sortSet);
            //filter
            FilteringSettings filtSet = new FilteringSettings(RenderQueueRange.opaque, -1);

            context.DrawRenderers(cullResults, ref drawSet, ref filtSet);                         
            context.Submit();                     
        }
      
    }
     
}
