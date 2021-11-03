using UnityEngine;

public class CharStats : MonoBehaviour
{
	[SerializeField] protected CharacterBase charBase; //Referencia ao SO do personagem.

	[SerializeField] private SkillBase[] skills; //Array contendo as habilidades dos personagens. -Arthur
	[SerializeField] private SkillBase basicAttack;
	[SerializeField] private int maxHp;
	[SerializeField] private int defense;
	[SerializeField] private float speed;
	[SerializeField] private int damage;
	[SerializeField] private int skillDmg;
	[SerializeField] private Sprite current_sprite;
	[SerializeField] private Sprite current_head;
	[SerializeField] private Vector3 headoffset;

	private int currHp;


	// Start is called before the first frame update
	protected virtual void Awake()
	{
		//Status definidos a partir do SO. -Arthur
		basicAttack = charBase.basicAttack;
		maxHp = charBase.baseHp;
		defense = charBase.baseDefense;
		speed = charBase.baseSpeed;
		damage = charBase.baseDamage;
		skillDmg = charBase.baseSkillDmg;
		skills = charBase.Skills;
		current_sprite = charBase.sprite;
		current_head = charBase.head;
		currHp = maxHp; //Vida atual deve ser inicializada como a vida maxima. -Arthur
		headoffset = charBase.headOffset;
	}

	//Funcoes para obter os valores das variaveis
	public int GetMaxHp() => maxHp;
	public int GetCurrHp() => currHp;
	public int GetDefense() => defense;
	public float GetSpeed() => speed;
	public int GetDamage() => damage;
	public int GetSkillDmg() => skillDmg;
	public CharacterBase GetCharacterBase() => charBase;
	public SkillBase GetCombatSkill() => skills[0];
	public SkillBase GetExplorationSkill() => skills[1];

	public SkillBase GetBasicAttack() => basicAttack;
	public Vector3 GetHeadOffset() => headoffset;


	//Funcoes para redefinir os valores das variaveis
	public void SetCurrHp(int currHp)
	{
		if (currHp < 0)
			this.currHp = 0;
		else {
			if (currHp > maxHp)
				this.currHp = maxHp;
			else
				this.currHp = currHp;
		}
	}

	public void SetMaxHp(int maxHp) => this.maxHp = maxHp < 0 ? 0 : maxHp;
	public void SetDefense(int defense) => this.defense = defense < 0 ? 0 : defense;
	public void SetSpeed(int speed) => this.speed = speed < 0 ? 0 : speed;
	public void SetDamage(int damage) => this.damage = damage < 0 ? 0 : damage;
	public void SetSkillDmg(int skillDmg) => this.skillDmg = skillDmg < 0 ? 0 : skillDmg;


	//Funcoes para manipular os valores das variaveis
	public void IncMaxHp(int maxHp)
	{
		this.maxHp += maxHp;
		if (this.maxHp < 0)
			this.maxHp = 0;

		if (currHp > this.maxHp)
			currHp = this.maxHp;
	}

	public void IncCurrHp(int currHp)
	{
		this.currHp += currHp;

		if (this.currHp < 0)
			this.currHp = 0;
		else if (this.currHp > maxHp)
			this.currHp = maxHp;
	}

	public void IncDefense(int defense)
	{
		this.defense += defense;

		if (this.defense < 0)
			this.defense = 0;
	}

	public void IncSpeed(int speed)
	{
		this.speed += speed;

		if (this.speed < 0)
			this.speed = 0;
	}

	public void IncDamage(int damage)
	{
		this.damage += damage;

		if (this.damage < 0)
			this.damage = 0;
	}

	public void IncSkillDmg(int skillDmg)
	{
		this.skillDmg += skillDmg;

		if (this.skillDmg < 0)
			this.skillDmg = 0;
	}


	public void SetCharbase(CharacterBase cd)
	{
		charBase = cd;
		maxHp = charBase.baseHp;
		defense = charBase.baseDefense;
		speed = charBase.baseSpeed;
		damage = charBase.baseDamage;
		skillDmg = charBase.baseSkillDmg;
		current_sprite = charBase.sprite;
		skills = charBase.Skills;
		basicAttack = charBase.basicAttack;
		headoffset = charBase.headOffset;
		currHp = maxHp;
	}

}
