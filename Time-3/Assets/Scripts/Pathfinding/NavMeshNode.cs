using UnityEngine;

public class NavMeshNode
{
	public static readonly Vector3[] neighbour_directions = {
		Vector2.up,							// straight
		(Vector2.up + Vector2.right).normalized,
		Vector2.right,						// straight
		(Vector2.right + (-Vector2.up)).normalized,
		-Vector2.up,						// straight
		((-Vector2.up) + (-Vector2.right)).normalized,
		-Vector2.right,						// straight
		(-Vector2.right + Vector2.up).normalized
	};

	private NavMeshNode[] neighbours;
	private NavMesh parent;
	private Vector3 position;

	public Vector3 Position { get => position; }
	public NavMeshNode[] Neighbours { get => neighbours; }
	private float StraightDist { get => parent.NodeDistance; }
	private float DiagonalDist { get => parent.NodeDistance * Mathf.Sqrt(2); }

	public NavMeshNode(NavMesh parent, Vector3 position)
	{
		if (parent == null) return;
		this.parent = parent;
		this.position = position;
		this.neighbours = new NavMeshNode[8];

		for (uint i = 0; i < 8; ++i)
			this.neighbours[i] = null;

	}

	public void FindNeighbours()
	{
		for (int i = 0; i < neighbour_directions.Length; ++i) {
			float dist = i % 2 == 0 ? this.StraightDist : this.DiagonalDist;
			RaycastHit2D hit = Physics2D.Raycast(this.position, neighbour_directions[i], dist, parent.ObstaclesMask);
			if (hit.collider != null) continue;
			this.neighbours[i] = this.parent.GetNode(this.position + dist * neighbour_directions[i]);
		}

	}
}
