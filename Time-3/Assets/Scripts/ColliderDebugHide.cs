using UnityEngine;
using UnityEngine.Tilemaps;

public class ColliderDebugHide : MonoBehaviour
{
	public bool showColliderDebug = false;

	private TilemapRenderer tilemapRenderer;

	void Awake()
	{
		tilemapRenderer = GetComponent<TilemapRenderer>();
	}

	void Update()
	{
		tilemapRenderer.enabled = showColliderDebug;
	}
}
