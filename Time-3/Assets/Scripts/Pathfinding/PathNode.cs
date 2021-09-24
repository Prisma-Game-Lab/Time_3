using UnityEngine;

public class PathNode
{
	private const int DIAGONAL_COST = 14;
	private const int STRAIGHT_COST = 10;

	private int gCost, hCost;
	private PathNode prevNode;
	public PathNode PrevNode {
		get => prevNode;
		set => prevNode = value;
	}
	private PathNode[] neighbours;

	public int GCost {
		get => gCost;
		set => gCost = value;
	}
	public int HCost { get => hCost; }
	public int FCost { get => gCost + hCost; }
	public PathNode[] Neighbours { get => neighbours; }

	private Grid<PathNode> grid;
	private NavMeshNode navMeshNode;
	private NavMeshNode endNode;

	private Vector3 position;
	public Vector3 Position { get => position; }

	public PathNode(PathNode prevNode, int gCost, NavMeshNode navMeshNode, NavMeshNode endNode, Grid<PathNode> grid)
	{
		this.prevNode = prevNode;
		this.gCost = gCost;
		this.position = navMeshNode.Position;
		this.grid = grid;
		this.navMeshNode = navMeshNode;
		this.endNode = endNode;

		this.neighbours = new PathNode[8];


		hCost = DistanceCost(navMeshNode, endNode);
	}

	public void PopulateNeighbours()
	{
		Vector2Int gridPos = grid.WorldToLocalPosition(this.position);
		for (int i = 0; i < 8; ++i) {
			int dist = i % 2 == 0 ? STRAIGHT_COST : DIAGONAL_COST;
			NavMeshNode neighbour = navMeshNode.Neighbours[i];
			if (neighbour != null) {
				Vector3 dir = NavMeshNode.neighbour_directions[i];
				PathNode neighbourPathNode = grid.GetPosition(gridPos.x + Mathf.FloorToInt(dir.x), gridPos.y + Mathf.FloorToInt(dir.y));
				if (neighbourPathNode != null) {
					int newGCost = gCost + dist;
					neighbours[i] = neighbourPathNode;
					if (newGCost < neighbourPathNode.GCost) {
						neighbourPathNode.GCost = newGCost;
						neighbourPathNode.prevNode = this;
					}
				} else {
					neighbours[i] = new PathNode(this, gCost + dist, neighbour, endNode, grid);
					grid.SetPosition(neighbour.Position, neighbours[i]);
				}
			} else {
				neighbours[i] = null;
			}
		}
	}

	public static int DistanceCost(NavMeshNode a, NavMeshNode b)
	{
		int xDist = Mathf.Abs(Mathf.FloorToInt(a.Position.x - b.Position.x));
		int yDist = Mathf.Abs(Mathf.FloorToInt(a.Position.y - b.Position.y));
		int rest = Mathf.Abs(xDist - yDist);

		return DIAGONAL_COST * Mathf.Min(xDist, yDist) + STRAIGHT_COST * rest;

	}

	public static int DistanceCost(PathNode a, PathNode b)
	{
		int xDist = Mathf.Abs(Mathf.FloorToInt(a.Position.x - b.Position.x));
		int yDist = Mathf.Abs(Mathf.FloorToInt(a.Position.y - b.Position.y));
		int rest = Mathf.Abs(xDist - yDist);

		return DIAGONAL_COST * Mathf.Min(xDist, yDist) + STRAIGHT_COST * rest;

	}
}
