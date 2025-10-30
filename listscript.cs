using UnityEngine;

/// <summary>
/// 所有角色的基类
/// </summary>
public abstract class Character : MonoBehaviour
{
    [Header("角色基础信息")]
    public string characterName;
    public int health;
    public int shield;
    public string faction;
    public string abilityName;
    public string abilityDescription;
    [TextArea]
    public string background;

    [Header("状态标识")]
    public bool isAlive = true;

    /// <summary>
    /// 初始化角色（由 GameManager 调用）
    /// </summary>
    public virtual void Initialize()
    {
        isAlive = true;
        Debug.Log($"{characterName} 初始化完成。");
    }

    /// <summary>
    /// 角色受伤逻辑
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        int remainingDamage = damage;

        if (shield > 0)
        {
            int shieldAbsorb = Mathf.Min(shield, remainingDamage);
            shield -= shieldAbsorb;
            remainingDamage -= shieldAbsorb;
        }

        if (remainingDamage > 0)
        {
            health -= remainingDamage;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// 角色死亡逻辑
    /// </summary>
    protected virtual void Die()
    {
        if (!isAlive) return;
        isAlive = false;
        Debug.Log($"{characterName} 已阵亡。");
    }

    /// <summary>
    /// 子类必须实现的主动技能逻辑
    /// </summary>
    public abstract void UseAbility();
}
