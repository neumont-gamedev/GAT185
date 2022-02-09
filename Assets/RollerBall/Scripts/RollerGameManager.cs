using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RollerGameManager : Singleton<RollerGameManager>
{
	enum State
	{
		TITLE,
		PLAYER_START,
		GAME,
		PLAYER_DEAD,
		GAME_OVER
	}

	[SerializeField] GameObject playerPrefab;
	[SerializeField] Transform playerSpawn;

	[SerializeField] GameObject titleScreen;
	[SerializeField] GameObject gameoverScreen;
	[SerializeField] TMP_Text scoreUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] Slider healthBarUI;

	public float playerHealth { set { healthBarUI.value = value; } }

	public delegate void GameEvent();

	public event GameEvent startGameEvent;
	public event GameEvent stopGameEvent;

	int score = 0;
	int lives = 0;
	State state = State.TITLE;
	float stateTimer;
	float gameTimer = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			scoreUI.text = score.ToString("D2");
		}
	}

	public int Lives
	{
		get { return lives; }
		set
		{
			lives = value;
			livesUI.text = "LIVES: " + lives.ToString();
		}
	}

	private void Update()
	{
		stateTimer -= Time.deltaTime;

		switch (state)
		{
			case State.TITLE:
				break;
			case State.PLAYER_START:
				DestroyAllEnemies();
				//Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation);
				startGameEvent?.Invoke();

				state = State.GAME;
				break;
			case State.GAME:
				gameTimer += Time.deltaTime;
				if (gameTimer > 5)
				{
					gameTimer = 0;
				}
				break;
			case State.PLAYER_DEAD:
				if (stateTimer <= 0)
				{
					state = State.PLAYER_START;
				}
				break;
			case State.GAME_OVER:
				if (stateTimer <= 0)
				{
					state = State.TITLE;
					gameoverScreen.SetActive(false);
					titleScreen.SetActive(true);
				}
				break;
			default:
				break;
		}
	}


	public void OnStartGame()
	{
		state = State.PLAYER_START;
		Score = 0;
		Lives = 3;
		gameTimer = 0;

		titleScreen.SetActive(false);
	}

	public void OnStartTitle()
	{
		state = State.TITLE;
		titleScreen.SetActive(true);
		stopGameEvent?.Invoke();
	}

	public void OnPlayerDead()
	{
		Lives -= 1;
		if (lives == 0)
		{
			state = State.GAME_OVER;
			stateTimer = 5;

			gameoverScreen.SetActive(true);
		}
		else 
		{
			state = State.PLAYER_DEAD;
			stateTimer = 3;
		}
		stopGameEvent?.Invoke();
	}

	private void DestroyAllEnemies()
	{
		// destroy all enemies

		//GameObject.FindGameObjectsWithTag("Enemy");
/*		SpaceEnemy[] spaceEnemies = FindObjectsOfType<SpaceEnemy>();
		foreach (var spaceEnemy in spaceEnemies)
		{
			Destroy(spaceEnemy.gameObject);
		}*/
	}
}
