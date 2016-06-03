using UnityEngine;
using System.Collections;

//a simple class that incorporates fast access for the game manager to avoid code duplication
public abstract class GameManagerSearcher : MonoBehaviour 
{
	private GameManager _gameManager;
	protected GameManager gameManager { get { return _gameManager; } }

    protected virtual void Awake()
	{
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
		
}
