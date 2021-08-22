using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderDebugHide : MonoBehaviour
{
	TilemapRenderer tilemapRenderer;

    void Awake()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    void Start()
    {
        tilemapRenderer.enabled = false;
    }
}
