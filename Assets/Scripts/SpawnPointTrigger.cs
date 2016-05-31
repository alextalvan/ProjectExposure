using UnityEngine;
using System.Collections.Generic;

public class SpawnPointTrigger : MonoBehaviour {


    List<Collider> colList = new List<Collider>();
    public bool Available { get { return colList.Count == 0; } }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col) 
	{
		UnitAI aiComp =  col.transform.GetComponent<UnitAI>();

		if(aiComp)
		{
        	colList.Add(col);
			aiComp.OnDestruction += () => { Remove(col); };
		}
    }

    void Remove(Collider col)
    {
        if (colList.Contains(col))
            colList.Remove(col);
    }

    void OnTriggerExit(Collider col)
    {
        colList.Remove(col);
    }
}
