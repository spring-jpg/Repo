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

    [Header("��ɫ����")]
    public List<Character> allCharacters = new List<Character>();  // ���п�ѡ��ɫ
    public List<Character> player1Team = new List<Character>();
    public List<Character> player2Team = new List<Character>();

    [Header("ս������")]
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

        // ����ս���׶�
        StartBattle();
    }

    void StartBattle()
    {
        currentState = GameState.Battle;

        // ���ɵ�ͼ
        gridManager.GenerateGrid();

        // ���ɽ�ɫ
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
        Debug.Log("��ʼս���غ�˳�����");
        yield return null;
    }

    public void EndGame(string winner)
    {
        currentState = GameState.GameOver;
        uiManager.ShowGameOver(winner);
    }
}
