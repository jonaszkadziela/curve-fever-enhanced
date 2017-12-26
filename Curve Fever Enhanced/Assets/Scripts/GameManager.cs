using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public static bool GameOverState = false;

	public Color[] tailColors;
	public bool[] usedColors;

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

	public Color getTailColor()
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

	private void ResetGame()
	{
		GameOverState = false;
		for (int i = 0; i < usedColors.Length; i++)
		{
			usedColors[i] = false;
		}
	}
}
