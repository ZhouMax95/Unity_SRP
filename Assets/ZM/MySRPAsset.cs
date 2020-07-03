using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


[CreateAssetMenu(menuName="Rendering/MyScriptPipelineAsset")]
public class MySRPAsset : RenderPipelineAsset
{  

    protected override RenderPipeline CreatePipeline()
    {
        return new MyRPInstance(this); 
    }
   
}
