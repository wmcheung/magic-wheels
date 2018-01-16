using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Frost")]
public class FrostEffect : MonoBehaviour
{
    public float FrostAmount = 0.5f; //0-1 (0=minimum Frost, 1=maximum frost)
    public float EdgeSharpness = 1; //>=1
    public float minFrost = 0; //0-1
    public float maxFrost = 1; //0-1
    public float seethroughness = 0.2f; //blends between 2 ways of applying the frost effect: 0=normal blend mode, 1="overlay" blend mode
    public float distortion = 0.1f; //how much the original image is distorted through the frost (value depends on normal map)
    public Texture2D Frost; //RGBA
    public Texture2D FrostNormals; //normalmap
    public Shader Shader; //ImageBlendEffect.shader

	private Material material;
    private float _WaitTime = 0.5f;

	private void Awake()
	{
        material = new Material(Shader);
        material.SetTexture("_BlendTex", Frost);
        material.SetTexture("_BumpMap", FrostNormals);

        // material.SetFloat("_BlendAmount", Mathf.Clamp01(0.0f));


        // StartCoroutine(BlendIn());
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!Application.isPlaying)
        {
            material.SetTexture("_BlendTex", Frost);
            material.SetTexture("_BumpMap", FrostNormals);
            EdgeSharpness = Mathf.Max(1, EdgeSharpness);
        }
        StartCoroutine(BlendIn());

        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(FrostAmount) * (maxFrost - minFrost) + minFrost));
        material.SetFloat("_EdgeSharpness", EdgeSharpness);
        material.SetFloat("_SeeThroughness", seethroughness);
        material.SetFloat("_Distortion", distortion);
        //
		Graphics.Blit(source, destination, material);
	}

    public IEnumerator BlendIn() {
        material.SetFloat("_EdgeSharpness", EdgeSharpness);
        material.SetFloat("_SeeThroughness", seethroughness);
        material.SetFloat("_Distortion", distortion);

        // Graphics.Blit(source, destination, material);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.0f) * (maxFrost - minFrost) + minFrost));
        yield return new WaitForSeconds(_WaitTime);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.1f) * (maxFrost - minFrost) + minFrost));

        yield return new WaitForSeconds(_WaitTime);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.2f) * (maxFrost - minFrost) + minFrost));

        yield return new WaitForSeconds(_WaitTime);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.3f) * (maxFrost - minFrost) + minFrost));

        yield return new WaitForSeconds(_WaitTime);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.4f) * (maxFrost - minFrost) + minFrost));

        yield return new WaitForSeconds(_WaitTime);
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(0.5f) * (maxFrost - minFrost) + minFrost));
    }
}
