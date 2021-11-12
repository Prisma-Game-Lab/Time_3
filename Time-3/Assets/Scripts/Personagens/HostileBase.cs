using UnityEngine;

[CreateAssetMenu(fileName = "Novo hostil", menuName = "Hostil")]
public class HostileBase : CharacterBase
{
	[Header("Atributos do Inimigo")]
	public float dropValue;
	public float fov;
	public float viewDistance;
	public float hearingDistance;
}
