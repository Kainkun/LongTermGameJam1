using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ImageEffectHolder : MonoBehaviour
{
	[SerializeField]
	bool renderInEditMode = true;

	[SerializeField]
  Material imageEffectMaterial;

  private void OnRenderImage(RenderTexture src, RenderTexture dst){
		if (imageEffectMaterial == null){
			Graphics.Blit(src, dst);
			return;
		}

		if (!UnityEditor.EditorApplication.isPlaying && !renderInEditMode){
			Graphics.Blit(src, dst);	
			return;
		}

			Graphics.Blit(src, dst, imageEffectMaterial);
  }
}
