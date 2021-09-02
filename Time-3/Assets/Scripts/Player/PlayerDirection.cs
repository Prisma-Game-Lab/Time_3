using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDirection : MonoBehaviour
{

	public void LookAtMouse()
	{
		Vector3 mouse_point = Mouse.current.position.ReadValue();
		mouse_point = Camera.main.ScreenToWorldPoint(mouse_point);

		Vector3 look_direction = mouse_point - transform.position;

		float angle = Mathf.Atan2(look_direction.y, look_direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
