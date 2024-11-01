using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ApplyLUT : MonoBehaviour
{
    public Shader lutShader;
    public Texture2D lutTexture;
    [Range(0, 1)] public float contribution = 1.0f;

    private Material lutMaterial;

    void Start()
    {
        if (lutShader == null)
        {
            Debug.LogError("Please assign a shader in the inspector.");
            enabled = false;
            return;
        }

        lutMaterial = new Material(lutShader);
        if (!lutMaterial || !lutMaterial.shader.isSupported)
        {
            enabled = false;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (lutMaterial != null && lutTexture != null)
        {
            lutMaterial.SetTexture("_MainTex", source);
            lutMaterial.SetTexture("_LUT", lutTexture);
            lutMaterial.SetFloat("_Contribution", contribution);
            lutMaterial.SetVector("_LUT_TexelSize", new Vector4(1.0f / lutTexture.width, 1.0f / lutTexture.height, lutTexture.width, lutTexture.height));

            Graphics.Blit(source, destination, lutMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    void OnDisable()
    {
        if (lutMaterial)
        {
            DestroyImmediate(lutMaterial);
        }
    }
}
