using System.Collections.Generic;
using UnityEngine;

public class NavMesh : MonoBehaviour
{
	[SerializeField] private List<LayerMask> obstaclesMaskList;
	[SerializeField] private Transform origin, end;
	[SerializeField] private float nodeDistance;
	private Grid<NavMeshNode> navMeshGrid;

	public int Width { get => navMeshGrid.Width; }
	public int Height { get => navMeshGrid.Height; }
	public Vector3 Origin { get => navMeshGrid.Origin; }

	private void Awake()
	{
		CreateGrid();
		GenerateMesh();
	}

	public void Update()
	{
		for (int i = 0; i < navMeshGrid.Width; ++i) {
			for (int j = 0; j < navMeshGrid.Height; ++j) {
				NavMeshNode node = navMeshGrid.GetPosition(i, j);
				for (int k = 0; k < 8; ++k) {
					if (node.Neighbours[k] != null) {
						Debug.DrawLine(node.Position, node.Neighbours[k].Position, Color.cyan);
					}
				}
			}
		}

	}

	public LayerMask ObstaclesMask {
		get {
			LayerMask obstaclesMask = 0;
			foreach (LayerMask mask in obstaclesMaskList)
				obstaclesMask |= mask;

			return obstaclesMask;
		}
	}

	public float NodeDistance { get => nodeDistance; }

	public void CreateGrid()
	{
		this.navMeshGrid = new Grid<NavMeshNode>(nodeDistance, origin.position, end.position);
		for (int i = 0; i < navMeshGrid.Width; ++i) {
			for (int j = 0; j < navMeshGrid.Height; ++j) {
				Vector3 worldPosition = navMeshGrid.LocalToWorldPosition(i, j);
				navMeshGrid.SetPosition(i, j, new NavMeshNode(this, worldPosition));
			}
		}
	}

	public void GenerateMesh()
	{
		for (int i = 0; i < navMeshGrid.Width; ++i) {
			for (int j = 0; j < navMeshGrid.Height; ++j) {
				NavMeshNode node = navMeshGrid.GetPosition(i, j);
				node.FindNeighbours();
			}
		}
	}

	public NavMeshNode GetNode(Vector2Int position)
	{
		return this.navMeshGrid.GetPosition(position.x, position.y);
	}

	public NavMeshNode GetNode(Vector3 position)
	{
		return this.navMeshGrid.GetPosition(position);
	}

}
