using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =====================================
// ����
// =====================================
public class SteelArm : Character
{
    private bool canActivateShield = false;

    public override void Initialize()
    {
        base.Initialize();
        characterName = "����";
        health = 5;
        shield = 2;
        faction = "�������Ϲ�";
        abilityName = "ħ���ֶ�";
        abilityDescription = "һ�غ�δ�������������չ�����ֵ�һ���˺���";
        background = "������������ʶ������...";
    }

    public override void UseAbility()
    {
        if (canActivateShield)
        {
            shield += 1;
            Debug.Log("����չ��ħ���ֶܣ�");
            canActivateShield = false;
        }
        else
        {
            Debug.Log("����Ŀǰ�޷�չ�����ܡ�");
        }
    }
}

// =====================================
// ��ħ����
// =====================================
public class HalfDemonRanger : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "��ħ����";
        health = 3;
        shield = 0;
        faction = "��";
        abilityName = "Ѹ��";
        abilityDescription = "δ����ʱ�ƶ�����+1��";
        background = "һ���������µ��˰��ˡ�";
    }

    public override void UseAbility()
    {
        Debug.Log("Ѹ�ݣ��ƶ�����+1");
    }
}

// =====================================
// ������
// =====================================
public class Archer : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "������";
        health = 3;
        shield = 0;
        faction = "�������Ϲ�";
        abilityName = "Զ��";
        abilityDescription = "��������+1���޷���ǽ����";
        background = "ʵ��¼����������̬��ѹ��ħ�ܵ�ҩ��������";
    }

    public override void UseAbility()
    {
        Debug.Log("Զ�ӣ���������+1");
    }
}

// =====================================
// ��ҹ����
// =====================================
public class NightHunter : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "��ҹ����";
        health = 3;
        shield = 0;
        faction = "δ֪";
        abilityName = "ͻϮ / �鶯";
        abilityDescription = "ͻϮ��նɱѪ����2�ĵ��ˡ��鶯������ǽ��Χ����ǽ�ƶ���";
        background = "����û����а֮�֣�ֻ���������¡�";
    }

    public override void UseAbility()
    {
        Debug.Log("��ҹ���ַ���ͻϮ���鶯��");
    }
}

// =====================================
// ����ʦ
// =====================================
public class Engineer : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "����ʦ";
        health = 3;
        shield = 1;
        faction = "�������Ϲ�";
        abilityName = "��е��";
        abilityDescription = "3x3��Χ���ƶ���λ���з���ʹ���»غ��޷��ж���";
        background = "��ȥ�ļ�����Ա�ǣ�Ϊ�˺󷽵ĺ����ٴ���ս����";
    }

    public override void UseAbility()
    {
        Debug.Log("��е�۷������ٿ�Ŀ���ƶ���");
    }
}

// =====================================
// Ͷ����
// =====================================
public class Bomber : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "Ͷ����";
        health = 3;
        shield = 0;
        faction = "�������Ϲ�";
        abilityName = "�������Ǳ�ը";
        abilityDescription = "�ݻ�3x3��Χ�����н�ɫ���ϰ��������Լ�����";
        background = "��ֲ��оƬ�ı�Ե�ˣ��ñ�ը����������";
    }

    public override void UseAbility()
    {
        Debug.Log("�������Ǳ�ը����BOOM��");
        Die(); // �Ա�
    }
}

// =====================================
// ʥ����ʿ
// =====================================
public class HolyGuardian : Character
{
    private bool usedHolyShield = false;

    public override void Initialize()
    {
        base.Initialize();
        characterName = "ʥ����ʿ";
        health = 4;
        shield = 1;
        faction = "���ص������͹�";
        abilityName = "�Ƶ� / ��֮ʥ��";
        abilityDescription = "�ƵУ����л��ܵ��˶���+1�˺�����֮ʥ��������������һ�Ρ�";
        background = "�����������������ϡ�";
        usedHolyShield = false;
    }

    public override void UseAbility()
    {
        Debug.Log("�ƵУ��Ի���Ŀ����ɶ����˺���");
    }

    protected override void Die()
    {
        if (!usedHolyShield)
        {
            usedHolyShield = true;
            health = 1;
            isAlive = true;
            Debug.Log("��֮ʥ����������������������һ�Σ�");
        }
        else
        {
            base.Die();
        }
    }
}

// =====================================
// ����սʿ
// =====================================
public class ThornWarrior : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "����սʿ";
        health = 4;
        shield = 1;
        faction = "��˹���ڹ� & ��˹�۹�";
        abilityName = "����ѹ��װ��";
        abilityDescription = "Ѫ��<50%ʱ���˺�+2��";
        background = "����ѹ��װ�������������ͷţ���ǿս������";
    }

    public override void UseAbility()
    {
        Debug.Log("����ѹ��װ�׼���˺�������");
    }
}

// =====================================
// ����ʥ��
// =====================================
public class LoyalGuardian : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "����ʥ��";
        health = 4;
        shield = 1;
        faction = "��˹�۹�";
        abilityName = "�ҳ��ػ�";
        abilityDescription = "�����볡ʱ���ƶ�+1�ҿ��ڷ�Χ������㸴�";
        background = "�����еľ��ţ��Ե۹���Զ�ҳϡ�";
    }

    public override void UseAbility()
    {
        Debug.Log("�ҳ��ػ�������ƶ����븴��������");
    }
}

