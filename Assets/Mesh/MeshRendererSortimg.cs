using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshRendererSortimg : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = "middleground";
        meshRenderer.sortingOrder = 3;
    }

}
