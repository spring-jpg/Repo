using UnityEngine;

/// <summary>
/// ������ɫ��
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

    // ��ѡ����ɫ״̬��ʶ
    public bool isAlive = true;

    // ? ��������ʼ���������ɱ�������д��
    public virtual void Initialize()
    {
        // �����ͨ�õĳ�ʼ���߼�
        isAlive = true;
        Debug.Log($"{characterName} ��ʼ����ɣ����� Character ���ࣩ");
    }

    // ͨ�÷���
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
        Debug.Log(characterName + " ��������");
    }

    // ����������д
    public abstract void UseAbility();
}
