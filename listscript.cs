using UnityEngine;

/// <summary>
/// ���н�ɫ�Ļ���
/// </summary>
public abstract class Character : MonoBehaviour
{
    [Header("��ɫ������Ϣ")]
    public string characterName;
    public int health;
    public int shield;
    public string faction;
    public string abilityName;
    public string abilityDescription;
    [TextArea]
    public string background;

    [Header("״̬��ʶ")]
    public bool isAlive = true;

    /// <summary>
    /// ��ʼ����ɫ���� GameManager ���ã�
    /// </summary>
    public virtual void Initialize()
    {
        isAlive = true;
        Debug.Log($"{characterName} ��ʼ����ɡ�");
    }

    /// <summary>
    /// ��ɫ�����߼�
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
    /// ��ɫ�����߼�
    /// </summary>
    protected virtual void Die()
    {
        if (!isAlive) return;
        isAlive = false;
        Debug.Log($"{characterName} ��������");
    }

    /// <summary>
    /// �������ʵ�ֵ����������߼�
    /// </summary>
    public abstract void UseAbility();
}
