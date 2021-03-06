﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIConsole : MonoBehaviour 
{
	//hardcoded textsize and rectangle, i don't care.
	public int charSize = 16;
	public Rect containerInfo = new Rect(0,Screen.height - 256,768,256);

	string _mainText = "";
	GUIStyle _consoleStyle = new GUIStyle();


	//UIConsole is a singleton gameobject
	static UIConsole _instance = null;
	bool hide = false;

	static string[] randomColors = { "red", "blue", "green", "yellow", "white", "magenta", "cyan" };

	static UIConsole Instance
	{
		get 
		{ 
			if (_instance == null)
			{
				_instance = new GameObject ("UIConsole", typeof(UIConsole)).GetComponent<UIConsole> ();
				DontDestroyOnLoad(_instance.gameObject);
			}

			return _instance;
		}
	}


	static public void SetParams(int charSize, Rect boundingBox, bool enabled = true)
	{
		Instance.charSize = charSize;
		Instance.containerInfo = boundingBox;
		Instance.hide = !enabled;
	}

	static public void Log(object message)
	{
		Instance.PushDebugLine (message);
	}

	static public void LogWithRandomColor(object message)
	{
		Instance.PushDebugLine (message,randomColors[Random.Range(0,randomColors.GetLength(0))]);
	}

	public void PushDebugLine(object message, string colorName = null)
	{
		Debug.Log (message);

		if(colorName==null)
			_mainText += message.ToString();
		else
			_mainText += "<color=" + colorName + ">" + message.ToString() + "</color>";
		
		_mainText += "\n";
	}

	void OnGUI()
	{

		_consoleStyle = GUI.skin.box;
		_consoleStyle.alignment = TextAnchor.UpperLeft;
		_consoleStyle.fontSize = charSize;

		int lines = 0;
		foreach (char c in _mainText)
			if (c == '\n')
				lines++;

		int maxLines = (int)(containerInfo.height / _consoleStyle.lineHeight);


		if (lines > maxLines) 
		{
			string[] separateLines = _mainText.Split ('\n');
			string newMainText = "";

			for(int i= lines - maxLines; i < lines; ++i)
			{
				newMainText += separateLines[i];
				newMainText += "\n";
			}

			_mainText = newMainText;
		}

		//let the huge string get clamped to max lines before returning in case of hide being enabled
		if (hide)
			return;

		GUI.Box (containerInfo, _mainText, _consoleStyle);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
			_mainText = "";
	}

}