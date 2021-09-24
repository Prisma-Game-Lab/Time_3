using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
	[SerializeField] NavMesh navMesh;

	public static Pathfinding Instance {get; private set;}

	private void Awake()
	{
		if (Instance != null && Instance != this)
			Destroy(this);
		else
			Instance = this;

		DontDestroyOnLoad(this);
	}

	public Stack<Vector3> MakePath(Vector3 start, Vector3 end)
	{
		List<PathNode> unvisited = new List<PathNode>();
		List<PathNode> visited = new List<PathNode>();

		Grid<PathNode> pathGrid = new Grid<PathNode>(navMesh.Width, navMesh.Height, navMesh.NodeDistance, navMesh.Origin);

		PathNode startPathNode = new PathNode(null, 0, navMesh.GetNode(start), navMesh.GetNode(end), pathGrid);
		startPathNode.PopulateNeighbours();
		pathGrid.SetPosition(start, startPathNode);
		unvisited.Add(startPathNode);

		while(unvisited.Count > 0) {
			PathNode curr = GetLowestFCostNode(unvisited);
			unvisited.Remove(curr);
			if (curr == null) continue;
			visited.Add(curr);

			if (Vector3.Distance(end, curr.Position) < 0.5)
				return BuildPath(curr);

			for (int i = 0; i < 8; ++i) {
				PathNode neighbour = curr.Neighbours[i];
				if (neighbour == null || visited.Contains(neighbour)) continue;
				neighbour.PopulateNeighbours();
				int newGCost = curr.GCost + PathNode.DistanceCost(curr, neighbour);
				if (newGCost < neighbour.GCost) {
					neighbour.GCost = newGCost;
					neighbour.PrevNode = curr;
				}

				if (!unvisited.Contains(neighbour))
					unvisited.Add(neighbour);

			}

		}

		return null;
	}

	private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
	{
		PathNode lowestFCostNode = pathNodeList[0];

		for (int i = 1; i < pathNodeList.Count; ++i) {
			if (pathNodeList[i].FCost < lowestFCostNode.FCost)
				lowestFCostNode = pathNodeList[i];
		}

		return lowestFCostNode;
	}

	private Stack<Vector3> BuildPath(PathNode node)
	{
		Stack<Vector3> movStack = new Stack<Vector3>();
		PathNode curr = node;
		while (curr != null) {
			movStack.Push(curr.Position);
			Debug.Log(curr.Position);
			curr = curr.PrevNode;
		}

		return movStack;

	}

}
