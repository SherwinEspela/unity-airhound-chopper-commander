using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

[AddComponentMenu("UI/Effects/Gradient")]
public class Gradient : BaseMeshEffect
{
    //[SerializeField]
    //public Color32 topColor;
    //[SerializeField]
    //public Color32 bottomColor;

    //Assets/Scripts/UnityUI/Gradient.cs(7,14): error CS0534: `Gradient' does not implement inherited abstract member `UnityEngine.UI.BaseMeshEffect.ModifyMesh(UnityEngine.UI.VertexHelper)'

	public Color colorTop; 
	public Color colorBot;

    public override void ModifyMesh(Mesh mesh)
    {
        base.ModifyMesh(mesh);
    }

    public override void ModifyMesh(VertexHelper vh)
    {
        throw new NotImplementedException();
    }

    public void ModifyVertices(List<UIVertex> vertexList) {
		if (!IsActive()) {
			return;
		}
		
		int count = vertexList.Count;
		float bottomY = vertexList[0].position.y;
		float topY = vertexList[0].position.y;
		
		for (int i = 1; i < count; i++) {
			float y = vertexList[i].position.y;
			if (y > topY) {
				topY = y;
			}
			else if (y < bottomY) {
				bottomY = y;
			}
		}

		float uiElementHeight = topY - bottomY;
		
		for (int i = 0; i < count; i++) {
			UIVertex uiVertex = vertexList[i];
			//uiVertex.color = Color32.Lerp(bottomColor, topColor, (uiVertex.position.y - bottomY) / uiElementHeight);
			uiVertex.color = Color.Lerp(colorBot, colorTop, (uiVertex.position.y - bottomY) / uiElementHeight);
			vertexList[i] = uiVertex;
		}
	}
}