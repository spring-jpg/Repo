using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public List<Character> playerTeam = new List<Character>();
    public List<Character> enemyTeam = new List<Character>();

    private List<Character> turnOrder = new List<Character>();
    private int currentTurnIndex = 0;
    private bool battleActive = false;

    private Character currentCharacter;
    private string firstFaction; // “Player” or “Enemy”

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // 🟢 初始化战斗（由 GameManager 调用）
    public void StartBattle(List<Character> playerChars, List<Character> enemyChars)
    {
        playerTeam = playerChars;
        enemyTeam = enemyChars;

        bool playerFirst = Random.value > 0.5f;
        firstFaction = playerFirst ? "Player" : "Enemy";
        Debug.Log($"先手方：{firstFaction}");

        BuildTurnOrder(playerFirst);

        foreach (var c in playerTeam) c.Initialize();
        foreach (var c in enemyTeam) c.Initialize();

        battleActive = true;
        currentTurnIndex = 0;

        StartCoroutine(TurnLoop());
    }

    // 🧮 构建行动顺序
    private void BuildTurnOrder(bool playerFirst)
    {
        turnOrder.Clear();
        if (playerFirst)
        {
            turnOrder.Add(playerTeam[0]);
            turnOrder.Add(enemyTeam[0]);
            turnOrder.Add(enemyTeam[1]);
            turnOrder.Add(playerTeam[1]);
        }
        else
        {
            turnOrder.Add(enemyTeam[0]);
            turnOrder.Add(playerTeam[0]);
            turnOrder.Add(playerTeam[1]);
            turnOrder.Add(enemyTeam[1]);
        }
    }

    // 🔁 主循环
    private IEnumerator TurnLoop()
    {
        while (battleActive)
        {
            if (CheckVictoryCondition()) yield break;

            currentCharacter = turnOrder[currentTurnIndex];

            if (currentCharacter == null || !currentCharacter.isAlive)
            {
                NextTurn();
                continue;
            }

            Debug.Log($"轮到 {currentCharacter.characterName} 行动");

            if (currentCharacter.faction == "Player")
            {
                yield return StartCoroutine(PlayerTurn(currentCharacter));
            }
            else
            {
                yield return StartCoroutine(EnemyTurn(currentCharacter));
            }

            NextTurn();
        }
    }

    // 👤 玩家行动
    private IEnumerator PlayerTurn(Character character)
    {
        Debug.Log($"等待玩家操作：{character.characterName}");
        UIManager.Instance.ShowActionMenu(character);

        // 等待玩家选择
        while (!UIManager.Instance.HasMadeChoice)
        {
            yield return null;
        }

        string choice = UIManager.Instance.GetPlayerChoice();
        UIManager.Instance.ResetChoice();

        switch (choice)
        {
            case "Attack":
                Debug.Log($"{character.characterName} 发动攻击！");
                yield return new WaitForSeconds(1f);
                // TODO: 攻击逻辑
                break;

            case "Move":
                Debug.Log($"{character.characterName} 选择移动。");

                // 获取鼠标位置并转换为格子坐标
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                int targetX = Mathf.FloorToInt(mousePos.x / GridManager.Instance.cellSize);
                int targetY = Mathf.FloorToInt(mousePos.y / GridManager.Instance.cellSize);

                // 调用 GridManager 移动角色
                if (GridManager.Instance.MoveCharacter(character, targetX, targetY))
                {
                    Debug.Log($"{character.characterName} 成功移动到 {targetX}, {targetY}");
                }
                else
                {
                    Debug.Log("目标位置不可达！");
                }
                yield return new WaitForSeconds(1f);
                break;

            case "Skill":
                Debug.Log($"{character.characterName} 使用技能！");
                character.UseAbility();
                yield return new WaitForSeconds(1f);
                break;

            case "Shield":
                Debug.Log($"{character.characterName} 恢复护盾！");
                character.shield += 10; // 示例
                yield return new WaitForSeconds(1f);
                break;
        }

        Debug.Log($"{character.characterName} 行动结束。");
    }

    // 🤖 敌人自动行动
    private IEnumerator EnemyTurn(Character character)
    {
        Debug.Log($"{character.characterName}（AI）思考中...");

        // 选择目标角色（攻击第一个存活的玩家）
        Character target = playerTeam.Find(c => c.isAlive);
        if (target != null)
        {
            Debug.Log($"{character.characterName} 攻击 {target.characterName}！");
            target.TakeDamage(10); // 敌人对玩家造成10点伤害
        }

        // 如果敌人需要移动，则可以在这里添加敌人移动的逻辑
        // 例如：
        if (character != null)
        {
            Vector3 targetPos = GridManager.Instance.GetWorldPosition(3, 3); // 假设敌人移动到 (3,3)
            int targetX = Mathf.FloorToInt(targetPos.x / GridManager.Instance.cellSize);
            int targetY = Mathf.FloorToInt(targetPos.y / GridManager.Instance.cellSize);

            // 使用 GridManager 处理移动
            if (GridManager.Instance.MoveCharacter(character, targetX, targetY))
            {
                Debug.Log($"{character.characterName} 移动到 {targetX}, {targetY}");
            }
        }

        yield return new WaitForSeconds(1f);
    }

    // ⏭️ 下一个角色
    private void NextTurn()
    {
        currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
    }

    // 🏁 胜负判定
    private bool CheckVictoryCondition()
    {
        bool playerAllDead = playerTeam.TrueForAll(c => !c.isAlive);
        bool enemyAllDead = enemyTeam.TrueForAll(c => !c.isAlive);

        if (playerAllDead)
        {
            Debug.Log("敌方胜利！");
            battleActive = false;
            return true;
        }

        if (enemyAllDead)
        {
            Debug.Log("玩家胜利！");
            battleActive = false;
            return true;
        }

        return false;
    }
}
