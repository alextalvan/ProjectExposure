using UnityEngine;
using System.Collections;


public class BuildingCard : ActionCard 
{
	//for now use mouse input for testing

	[SerializeField]
	EnergyBuildingType _buildingType;

	public EnergyBuildingType BuildingType { get { return _buildingType; } }


	private GameManager _gameMng;

	void Start()
	{
		_gameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void OnMouseUp()
	{
		
	}
}
