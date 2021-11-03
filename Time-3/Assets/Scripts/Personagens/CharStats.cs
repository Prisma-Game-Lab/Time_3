using UnityEngine;

public class CharStats : MonoBehaviour
{
	[SerializeField] protected CharacterBase charBase; //Referencia ao SO do personagem.

	[SerializeField] private SkillBase[] skills; //Array contendo as habilidades dos personagens. -Arthur
	[SerializeField] private SkillBase basicAttack;
	[SerializeField] private int maxHp;
	[SerializeField] private float defense;
	[SerializeField] private float speed;
	[SerializeField] private int damage;
	[SerializeField] private int skillDmg;
	[SerializeField] private Sprite current_sprite;
	[SerializeField] private Sprite current_head;
	[SerializeField] private Vector3 headoffset;
	[SerializeField] private RuntimeAnimatorController AnimatorController;

	private int currHp;


	// Start is called before the first frame update
	protected virtual void Awake()
	{
		UpdateStats();
	}

	public void SetCharbase(CharacterBase cd)
	{
		charBase = cd;
		UpdateStats();
	}

	public void ChangeCharbase(CharacterBase cd)
	{
		charBase = cd;
		UpdateStats(false);
	}

	private void UpdateStats() {
		UpdateStats(true);
	}

	private void UpdateStats(bool heal)
	{
		//Status definidos a partir do SO. -Arthur
		basicAttack = charBase.basicAttack;
		skills = charBase.Skills;
		current_sprite = charBase.sprite;
		current_head = charBase.head;
		currHp = maxHp; //Vida atual deve ser inicializada como a vida maxima. -Arthur
		headoffset = charBase.headOffset;
		AnimatorController = charBase.animatorController;
		SetMaxHp(charBase.baseHp);
		SetDefense(charBase.baseDefense);
		SetSpeed(charBase.baseSpeed);
		SetDamage(charBase.baseDamage);
		SetSkillDmg(charBase.baseSkillDmg);

		if (heal)
			SetCurrHp(maxHp); //Vida atual deve ser inicializada como a vida maxima. -Arthur
	}

	//Funcoes para obter os valores das variaveis
	public int GetMaxHp() => maxHp;
	public int GetCurrHp() => currHp;
	public float GetDefense() => defense;
	public float GetSpeed() => speed;
	public int GetDamage() => damage;
	public int GetSkillDmg() => skillDmg;
	public CharacterBase GetCharacterBase() => charBase;
	public SkillBase GetCombatSkill() => skills[0];
	public SkillBase GetExplorationSkill() => skills[1];

	public SkillBase GetBasicAttack() => basicAttack;
	public Vector3 GetHeadOffset() => headoffset;
	public RuntimeAnimatorController GetRuntimeAnimatorController() => AnimatorController;


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

	public void SetMaxHp(int maxHp)
	{
		if (maxHp < 0)
			return;
		this.maxHp = maxHp;
	}

	public void SetDefense(float defense)
	{
		if (defense < 0.0f || defense > 0.0f)
			return;
		this.defense = defense;
	}

	public void SetSpeed(float speed)
	{
		if (speed < 0.0f)
			return;
		this.speed = speed;
	}

	public void SetDamage(int damage)
	{
		if (damage < 0)
			return;
		this.damage = damage;
	}

	public void SetSkillDmg(int skillDmg)
	{
		if (skillDmg < 0)
			return;
		this.skillDmg = skillDmg;
	}


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

	public void IncDefense(float defense)
	{
		this.defense += defense;

		if (this.defense < 0.0f)
			this.defense = 0.0f;
		else if (this.defense > 1.0f)
			this.defense = 0.0f;
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
		AnimatorController = charBase.animatorController;
	}

}
