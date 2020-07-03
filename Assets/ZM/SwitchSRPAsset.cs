using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SwitchSRPAsset : MonoBehaviour
{
    public RenderPipelineAsset A,B;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GraphicsSettings.renderPipelineAsset = A;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            GraphicsSettings.renderPipelineAsset = B;
        }
        
    }


}
