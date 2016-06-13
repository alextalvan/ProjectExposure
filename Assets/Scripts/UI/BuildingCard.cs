using UnityEngine;
using System.Collections;


public class BuildingCard : Card 
{
	//keep track if card was playable last frame
	bool wasPlayable = false;

	[SerializeField]
	EnergyBuildingType _buildingType;

	public EnergyBuildingType BuildingType { get { return _buildingType; } }

	Animator _anim;

	bool resetAnimVars = false;

	[SerializeField]
	float useCooldown = 5.0f;
	float currentCooldown;// = -1.0f;

    protected override void DoCardEffect ()
	{
		
		PlayerGameData pdata = gameManager.playerData[this.Owner];
		pdata.currentSelectedCard = this;
		gameManager.StartEnergyBuildingTileSelection(this);

		gameManager.raycastedOn2DObject = true;
	}

	protected override bool CalculatePlayCondition ()
	{
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		if(pdata.currentInputState != INPUT_STATES.FREE)
			return false;

		return CalculateNonInputPlayCondition();
	}

	bool CalculateNonInputPlayCondition()
	{
		if(!enabled)
			return false;

		if(!CheckMoneyCost())
			return false;

		bool oneFreeTile = false;
		PlayerGameData pdata = gameManager.playerData[this.Owner];

		foreach(HexagonTile t in pdata.tiles)
			if(t.AllowBuild)
			{
				oneFreeTile = true;
				break;
			}

		if(!oneFreeTile)
			return false;

		return true;
	}


	protected override void Update ()
	{
		bool isPlayable = CalculateNonInputPlayCondition() && (currentCooldown <= 0.0f);


		//_anim.SetBool("slide_out",false);

		//if(Input.GetKeyDown(KeyCode.Space))
		if(isPlayable && !wasPlayable)
		{
			_anim.SetBool("slide_out",false);
			_anim.SetBool("slide_in",true);//do slide in animation
			highlight.SetActive(true);
		}

		if(!isPlayable && wasPlayable)
		{
			_anim.SetBool("slide_in",false);
			_anim.SetBool("slide_out",true);//do slide out animation
			highlight.SetActive(false);
		}

		wasPlayable = isPlayable;

		currentCooldown -= Time.deltaTime;
	}


	protected override void Start ()
	{
		base.Start ();
		_anim = GetComponent<Animator>();
		currentCooldown = -1.0f;
	}

	public void StartCooldown()
	{
		currentCooldown = useCooldown;
	}
}
