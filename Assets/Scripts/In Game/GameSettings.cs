using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{ 
	Story,
	Endless
}

public static class GameSettings
{
	public static GameMode mode = GameMode.Story;
}
