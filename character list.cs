using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelArm : Character
{
    private bool canActivateShield = false;

    void Start()
    {
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
    }
  

    // ��� Initialize ����
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//��ħ����
public class HalfDemonRanger : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//������
public class Archer : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}


//��ҹ����
public class NightHunter : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//����ʦ
public class Engineer : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//Ͷ����
public class Bomber : Character
{
    void Start()
    {
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
        Die(); 
    }
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//ʥ����ʿ
public class HolyGuardian : Character
{
    void Start()
    {
        characterName = "ʥ����ʿ";
        health = 4;
        shield = 1;
        faction = "���ص������͹�";
        abilityName = "�Ƶ� / ��֮ʥ��";
        abilityDescription = "�ƵУ����л��ܵ��˶���+1�˺�����֮ʥ�������������ˡ�";
        background = "�����������������ϡ�";
    }

    public override void UseAbility()
    {
        Debug.Log("�ƵУ��Ի���Ŀ����ɶ����˺���");
    }

    protected override void Die()
    {
        if (isAlive)
        {
            Debug.Log("��֮ʥ����������������������һ�Σ�");
            isAlive = true;
            
        }
        else
        {
            base.Die();
        }
    }
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//����սʿ
public class ThornWarrior : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

//����ʥ��
public class LoyalGuardian : Character
{
    void Start()
    {
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
    public void Initialize()
    {
        // ��������г�ʼ������
        Debug.Log($"{characterName} �ѳ�ʼ��");
    }
}

