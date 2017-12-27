using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public static bool GameOverState = false;
	public static int PlayersAlive = 0;

	public GameObject playerPrefab;
	public float spawnMargin;
	public Color[] tailColors;
	public bool[] usedColors;

	[SerializeField]
	private List<GameObject> players;

	void Start()
	{
		GameOver();
	}

	void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		usedColors = new bool[tailColors.Length];
		spawnMargin = Mathf.Max(Settings.BattlefieldWidth / 10f, Settings.BattlefieldHeight / 10f);
		for (int i = 0; i < Mathf.Min(Settings.NumberOfPlayers, 4); i++)
		{
			GameObject newPlayer = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
			Transform newPlayerHeadTransform = newPlayer.GetComponentInChildren<Head>().gameObject.transform;
			newPlayerHeadTransform.position = GetRandomPosition();
			newPlayerHeadTransform.eulerAngles = new Vector3(0f, 0f, Random.Range(0f, 360f));
			players.Add(newPlayer);
			PlayersAlive++;
			newPlayer.GetComponentInChildren<Head>().inputAxis = "Horizontal" + PlayersAlive.ToString();
		}
	}

	public void GameOver()
	{
		if (GameOverState)
		{
			return;
		}
		GameOverState = true;
		StartCoroutine(BeginGameEnd());
	}

	IEnumerator BeginGameEnd()
	{
		yield return new WaitForSeconds(1f);

		ResetGame();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public Color GetTailColor()
	{
		int randomIndex = 0;
		bool colorSelected = false;
		Color tailColor = Color.white;
		while (!colorSelected)
		{
			randomIndex = Random.Range(0, tailColors.Length);
			if (usedColors[randomIndex] == false)
			{
				tailColor = tailColors[randomIndex];
				colorSelected = true;
				usedColors[randomIndex] = true;
			}
		}
		return tailColor;
	}

	Vector3 GetRandomPosition()
	{
		Vector3 randomPosition = new Vector3(
			                         Random.Range(-(Settings.BattlefieldWidth - spawnMargin), Settings.BattlefieldWidth - spawnMargin),
			                         Random.Range(-(Settings.BattlefieldHeight - spawnMargin), Settings.BattlefieldHeight - spawnMargin),
			                         0f
		                         );
		return randomPosition;
	}

	private void ResetGame()
	{
		GameOverState = false;
		PlayersAlive = 0;
		for (int i = 0; i < usedColors.Length; i++)
		{
			usedColors[i] = false;
		}
	}
}
