using UnityEngine;

/// <summary>
/// 基础角色类
/// </summary>
public abstract class Character : MonoBehaviour
{
    public string characterName;
    public int health;
    public int shield;
    public string faction;
    public string abilityName;
    public string abilityDescription;
    public string background;

    // 可选：角色状态标识
    public bool isAlive = true;

    // 通用方法
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

    protected virtual void Die()
    {
        isAlive = false;
        Debug.Log(characterName + " 已阵亡。");
    }

    // 用于子类重写
    public abstract void UseAbility();
}
