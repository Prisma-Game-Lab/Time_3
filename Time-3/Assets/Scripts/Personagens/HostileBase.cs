using UnityEngine;

[CreateAssetMenu(fileName = "Novo hostil", menuName = "Hostil")]
public class HostileBase : CharacterBase
{
	[Header("Atributos do Inimigo")]
	public int dropValue;
}
