using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    CharacterSelection,
    Battle,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState = GameState.CharacterSelection;

    [Header("Managers")]
    public UIManager uiManager;
    public GridManager gridManager;

    [Header("角色数据")]
    public List<Character> allCharacters = new List<Character>();  // 所有可选角色
    public List<Character> player1Team = new List<Character>();
    public List<Character> player2Team = new List<Character>();

    [Header("战斗控制")]
    public Transform player1SpawnPoint1;
    public Transform player1SpawnPoint2;
    public Transform player2SpawnPoint1;
    public Transform player2SpawnPoint2;

    private int currentRound = 0;
    private bool isPlayer1Turn;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        uiManager.ShowCharacterSelectionUI(allCharacters);
        currentState = GameState.CharacterSelection;
    }

    public void OnCharactersSelected(List<Character> team1, List<Character> team2)
    {
        player1Team = team1;
        player2Team = team2;

        // 进入战斗阶段
        StartBattle();
    }

    void StartBattle()
    {
        currentState = GameState.Battle;

        // 生成地图
        gridManager.GenerateGrid();

        // 生成角色
        SpawnCharacter(player1Team[0], player1SpawnPoint1.position);
        SpawnCharacter(player1Team[1], player1SpawnPoint2.position);
        SpawnCharacter(player2Team[0], player2SpawnPoint1.position);
        SpawnCharacter(player2Team[1], player2SpawnPoint2.position);

        uiManager.HideCharacterSelectionUI();
        uiManager.ShowBattleUI();

        StartCoroutine(BattleRoutine());
    }

    void SpawnCharacter(Character prefab, Vector3 spawnPos)
    {
        Character newChar = Instantiate(prefab, spawnPos, Quaternion.identity);
        newChar.Initialize();
    }

    IEnumerator BattleRoutine()
    {
        Debug.Log("开始战斗回合顺序控制");
        yield return null;
    }

    public void EndGame(string winner)
    {
        currentState = GameState.GameOver;
        uiManager.ShowGameOver(winner);
    }
}
