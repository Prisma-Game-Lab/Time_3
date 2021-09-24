using UnityEngine;

public class Grid<TGObject>
{
	private int height, width;
	private float vertDistance;
	private Vector3 origin;
	private TGObject[,] gridArray;

	public int Width { get => width; }
	public int Height { get => height; }
	public Vector3 Origin { get => origin; }

	public Grid(int width, int height, float vertDistance, Vector3 origin)
	{
		Debug.Log(width + ", " + height);
		this.width = width;
		this.height = height;
		this.vertDistance = vertDistance;
		this.origin = origin;

		gridArray = new TGObject[width, height];

		for (int i = 0; i < width; ++i) {
			for (int j = 0; j < height; ++j) {
				gridArray[i, j] = default(TGObject);
			}
		}

	}

	public Grid(float vertDistance, Vector3 origin, Vector3 end)
		: this( Mathf.FloorToInt((end.x - origin.x) / vertDistance) + 1,
				Mathf.FloorToInt((end.y - origin.y) / vertDistance) + 1,
				vertDistance, origin)
	{ }

	public Vector2Int WorldToLocalPosition(Vector3 worldPosition)
	{
		int x = Mathf.FloorToInt((worldPosition - origin).x / vertDistance);
		int y = Mathf.FloorToInt((worldPosition - origin).y / vertDistance);
		return new Vector2Int(x, y);
	}

	public Vector3 LocalToWorldPosition(int x, int y)
	{
		return new Vector3(x, y) * vertDistance + origin;
	}

	public void SetPosition(int x, int y, TGObject obj)
	{
		if (x >= 0 && x < width && y >= 0 && y < height) {
			this.gridArray[x, y] = obj;
		} else {
			Debug.LogError("GRID ERROR: Tried to set invalid position: (" + x +", " + y + ")");
		}
	}

	public void SetPosition(Vector3 position, TGObject obj)
	{
		Vector2Int lPosition = WorldToLocalPosition(position);
		SetPosition(lPosition.x, lPosition.y, obj);
	}

	public TGObject GetPosition(int x, int y)
	{
		if (x >= 0 && x < width && y >= 0 && y < height) {
			return this.gridArray[x, y];
		} else {
			return default(TGObject);
		}
	}

	public TGObject GetPosition(Vector3 worldPosition)
	{
		Vector2Int lPosition = WorldToLocalPosition(worldPosition);
		return GetPosition(lPosition.x, lPosition.y);
	}

}
