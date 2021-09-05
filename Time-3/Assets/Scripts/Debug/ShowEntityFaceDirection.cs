using UnityEngine;

public class ShowEntityFaceDirection : MonoBehaviour
{
	void Update()
	{
		Debug.DrawLine(transform.position, transform.position + transform.right.normalized * 2.0f, Color.cyan);
	}
}
