using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class BackgroundCollider : MonoBehaviour 
{
	private GameManager _gameMng;

	void Start()
	{
		_gameMng = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void OnMouseUp()
	{
		//UIConsole.LogWithRandomColor("Background.");


	}
}
