﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{   
    [SerializeField]
    private Sprite bgImage;

    public Animator camShakeAnim;

    //bar
    public int maxHealthPlayer = 10;
    public int currentHealthPlayer;
    public PlayerHelathBar playerHealthBar;

    public int maxHealthEnemy = 10;
    public int currentHealthEnemy;
    public EnemyHelathBar enemyHealthBar;
    //akhir bar

    private AddButton addButton;
    public PlayerController playerController;
    public Enemy1Controller enemy1Controller;

    public GameObject finishedddd, puzzleField;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> buttonss = new List<Button>();

    public GameObject[] Enemies;

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCoreectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;

    void Awake()
    {
        addButton = this.GetComponent<AddButton>();
        puzzles = Resources.LoadAll<Sprite>("game ui");
    }
    void Start()
    {
        PuzzleInitialize();

        currentHealthEnemy = maxHealthEnemy;
        enemyHealthBar.setMaxHealth(maxHealthEnemy);

        currentHealthPlayer = maxHealthPlayer;
        playerHealthBar.setMaxHealth(maxHealthPlayer);
    }

    void PuzzleInitialize()
    {
        addButton.SpawnKartu();
        GetButtons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            buttonss.Add(objects[i].GetComponent<Button>());
            buttonss[i].image.sprite = bgImage;
        }
    }

    void AddGamePuzzles()
    {
        int looper = buttonss.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);

            index++;
        }
    }

    void AddListeners()
    {
        foreach (Button btn in buttonss)
        {
            btn.onClick.AddListener(() => pickPuzzle());
        }
    }

    public void pickPuzzle()
    {

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            buttonss[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            buttonss[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            StartCoroutine(CheckIfPuzzleMatch());
        }
    }

    IEnumerator CheckIfPuzzleMatch()
    {
        yield return new WaitForSeconds(1f);
        print(firstGuessPuzzle);
        print(secondGuessPuzzle);
        if ((buttonss[firstGuessIndex].name != buttonss[secondGuessIndex].name) && (firstGuessPuzzle == secondGuessPuzzle))
        {
            yield return new WaitForSeconds(.1f);

            buttonss[firstGuessIndex].interactable = false;
            buttonss[secondGuessIndex].interactable = false;

            buttonss[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            buttonss[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();            
        }
        else
        {
            yield return new WaitForSeconds(.1f);

            buttonss[firstGuessIndex].image.sprite = bgImage;
            buttonss[secondGuessIndex].image.sprite = bgImage;
        }

        yield return new WaitForSeconds(.1f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCoreectGuesses++;
        if (countCoreectGuesses == gameGuesses)
        {
            StartCoroutine(AnimasiPlayer());
            Debug.Log(countGuesses);
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
            
        }
    }

    IEnumerator RespawnKartu()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(puzzleField.transform.GetChild(i).gameObject);
        }
        buttonss.Clear();
        gamePuzzles.Clear();
        countGuesses = 0;
        countCoreectGuesses = 0;
        gameGuesses = 0;

        yield return null;
        
        PuzzleInitialize();
    }

    IEnumerator AnimasiPlayer()
    {
        playerController.animasiBasicAttack(true);

        yield return new WaitForSeconds(1.6f);

        take_BasicAttackDamage_Enemy1(2);
        camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        playerController.animasiBasicAttack(false);
        enemy1Controller.animasiBasicAttack(true);

        yield return new WaitForSeconds(1.6f);

        take_BasicAttackDamage_Player(2);
        camShakeAnim.SetTrigger("shake");

        yield return new WaitForSeconds(1f);

        enemy1Controller.animasiBasicAttack(false);

        StartCoroutine(RespawnKartu());
    }

    void take_BasicAttackDamage_Enemy1(int damage)
    {
        currentHealthEnemy -= damage;

        enemyHealthBar.setHealth(currentHealthEnemy);
    }

    void take_BasicAttackDamage_Player(int damage)
    {
        currentHealthPlayer -= damage;

        playerHealthBar.setHealth(currentHealthPlayer);
    }
}
