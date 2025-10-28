using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// =====================================
// 钢腕
// =====================================
public class SteelArm : Character
{
    private bool canActivateShield = false;

    public override void Initialize()
    {
        base.Initialize();
        characterName = "钢腕";
        health = 5;
        shield = 2;
        faction = "地球联合国";
        abilityName = "魔力手盾";
        abilityDescription = "一回合未被攻击后可主动展开，抵挡一次伤害。";
        background = "第三代自主意识改造人...";
    }

    public override void UseAbility()
    {
        if (canActivateShield)
        {
            shield += 1;
            Debug.Log("钢腕展开魔力手盾！");
            canActivateShield = false;
        }
        else
        {
            Debug.Log("钢腕目前无法展开护盾。");
        }
    }
}

// =====================================
// 半魔游侠
// =====================================
public class HalfDemonRanger : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "半魔游侠";
        health = 3;
        shield = 0;
        faction = "无";
        abilityName = "迅捷";
        abilityDescription = "未受伤时移动距离+1。";
        background = "一个爱管闲事的人罢了。";
    }

    public override void UseAbility()
    {
        Debug.Log("迅捷：移动距离+1");
    }
}

// =====================================
// 弓箭手
// =====================================
public class Archer : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "弓箭手";
        health = 3;
        shield = 0;
        faction = "地球联合国";
        abilityName = "远视";
        abilityDescription = "攻击距离+1（无法穿墙）。";
        background = "实验录音：弓箭形态的压缩魔能弹药威力更大。";
    }

    public override void UseAbility()
    {
        Debug.Log("远视：攻击距离+1");
    }
}

// =====================================
// 暗夜猎手
// =====================================
public class NightHunter : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "暗夜猎手";
        health = 3;
        shield = 0;
        faction = "未知";
        abilityName = "突袭 / 灵动";
        abilityDescription = "突袭：斩杀血量≤2的敌人。灵动：若被墙包围，穿墙移动。";
        background = "他们没有正邪之分，只做该做的事。";
    }

    public override void UseAbility()
    {
        Debug.Log("暗夜猎手发动突袭或灵动。");
    }
}

// =====================================
// 工程师
// =====================================
public class Engineer : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "工程师";
        health = 3;
        shield = 1;
        faction = "地球联合国";
        abilityName = "机械臂";
        abilityDescription = "3x3范围内移动单位；敌方则使其下回合无法行动。";
        background = "老去的技术人员们，为了后方的孩子再次上战场。";
    }

    public override void UseAbility()
    {
        Debug.Log("机械臂发动：操控目标移动！");
    }
}

// =====================================
// 投弹手
// =====================================
public class Bomber : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "投弹手";
        health = 3;
        shield = 0;
        faction = "地球联合国";
        abilityName = "艺术就是爆炸";
        abilityDescription = "摧毁3x3范围内所有角色与障碍（包括自己）。";
        background = "被植入芯片的边缘人，用爆炸结束生命。";
    }

    public override void UseAbility()
    {
        Debug.Log("艺术就是爆炸——BOOM！");
        Die(); // 自爆
    }
}

// =====================================
// 圣光卫士
// =====================================
public class HolyGuardian : Character
{
    private bool usedHolyShield = false;

    public override void Initialize()
    {
        base.Initialize();
        characterName = "圣光卫士";
        health = 4;
        shield = 1;
        faction = "莱特第三共和国";
        abilityName = "破敌 / 光之圣卫";
        abilityDescription = "破敌：对有护盾敌人额外+1伤害；光之圣卫：免疫致命伤一次。";
        background = "禁军档案，机密资料。";
        usedHolyShield = false;
    }

    public override void UseAbility()
    {
        Debug.Log("破敌：对护盾目标造成额外伤害。");
    }

    protected override void Die()
    {
        if (!usedHolyShield)
        {
            usedHolyShield = true;
            health = 1;
            isAlive = true;
            Debug.Log("光之圣卫：发动，被致命伤免疫一次！");
        }
        else
        {
            base.Die();
        }
    }
}

// =====================================
// 荆棘战士
// =====================================
public class ThornWarrior : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "荆棘战士";
        health = 4;
        shield = 1;
        faction = "赫斯合众国 & 宙斯帝国";
        abilityName = "能量压缩装甲";
        abilityDescription = "血量<50%时，伤害+2。";
        background = "能量压缩装甲吸收能量并释放，增强战斗力。";
    }

    public override void UseAbility()
    {
        Debug.Log("能量压缩装甲激活，伤害提升！");
    }
}

// =====================================
// 至忠圣卫
// =====================================
public class LoyalGuardian : Character
{
    public override void Initialize()
    {
        base.Initialize();
        characterName = "至忠圣卫";
        health = 4;
        shield = 1;
        faction = "宙斯帝国";
        abilityName = "忠诚守护";
        abilityDescription = "己方半场时，移动+1且可在范围内任意点复活。";
        background = "如神话中的军团，对帝国永远忠诚。";
    }

    public override void UseAbility()
    {
        Debug.Log("忠诚守护：获得移动力与复活能力。");
    }
}

