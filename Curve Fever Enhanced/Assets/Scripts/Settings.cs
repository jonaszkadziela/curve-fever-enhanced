using UnityEngine;

public class Settings : MonoBehaviour
{
	public static float BattlefieldWidth;
	public static float BattlefieldHeight;
	public static float GapSize;
	public static float GapTimeoutMin;
	public static float GapTimeoutMax;
	public static int NumberOfPlayers;

	public float startBattlefieldWidth = 7f;
	public float startBattlefieldHeight = 7f;
	public float startGapSize = 0.5f;
	public float startGapTimeoutMin = 0.5f;
	public float startGapTimeoutMax = 1.5f;
	public int startNumberOfPlayers = 2;

	void Start()
	{
		BattlefieldWidth = startBattlefieldWidth;
		BattlefieldHeight = startBattlefieldHeight;
		GapSize = startGapSize;
		GapTimeoutMin = startGapTimeoutMin;
		GapTimeoutMax = startGapTimeoutMax;
		NumberOfPlayers = startNumberOfPlayers;
	}
}
