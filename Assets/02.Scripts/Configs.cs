﻿
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;

public enum Data_Type
{
    item_info,
    player_info,
    character_info,
    stage_info,
    weapon_info,
    skill_info,
    content_info,
    pet_info,
    job_info,
    totem_info,
    coupon_info,
    post_info,
    game_info,
    quest_info
}

public enum Character_Lv
{
    lv_1 = 1,
    lv_10 = 10,
    lv_100 = 100
}

public enum Intro_State
{
    Service,
    Login,
    Touch
}

public enum Character_Contnet
{
    State,
    Skill,
    Upgrade,
    Limit,
}

public enum Weapon_Content
{
    Sword,
    Shield,
    Accessory,
    Costume,
}

public enum Weapon_Popup
{
    info,
    upgrade,
    mix,
    roon,
    decom
}

public enum Quest_Popup
{
    accumulate,
    daily
}

public enum Icon_Content
{
    Content,
    Character,
    Pet,
    Weapon,
    Job,
    Totem,
    Shop

}

public enum Shop_Content
{
    Event,
    Gacha,
    Goods,
    Mileage,
    Other
}

public enum Item_Type
{
    dia,
    coin,
    upgrade_stone,
    limit_stone,
    steel,
    soul_stone,
    black_stone,
    topaz,
    ruby,
    emerald,
    sapphire,
    weapon_box_d_c,
    weapon_box_d_b,
    weapon_box_d_a,
    weapon_box_d_s,
    shield_box_d_c,
    shield_box_d_b,
    shield_box_d_a,
    shield_box_d_s,
    accessory_box_d_c,
    accessory_box_d_b,
    accessory_box_d_a,
    accessory_box_d_s,
    upgrade_stone_box_1_100,
    upgrade_stone_box_100_500,
    upgrade_stone_box_500_1000,
    upgrade_stone_box_1000_3000,
    upgrade_stone_box_3000_5000,
    upgrade_stone_box_5000_10000,
    upgrade_stone_box_10000_20000,
    underground_ticket,
    upgrade_ticket,
    hell_ticket,
    yellow_key,
    red_key,
    blue_key,
    green_key,
    black_key,
    yellow_marble,
    red_marble,
    blue_marble,
    green_marble,
    black_marble,
    meat,
    heart,
    guild_coin,
    weapon_limit_stone_d,
    weapon_limit_stone_c,
    weapon_limit_stone_b,
    weapon_limit_stone_a,
    weapon_limit_stone_s,
    weapon_limit_stone_ss,
    item_gacha_ticket_1,
    transform_gacha_ticket_1,
    pet_gacha_ticket_1,
    item_gacha_ticket_5,
    transform_gacha_ticket_5,
    pet_gacha_ticket_5,
    item_gacha_ticket_10,
    transform_gacha_ticket_10,
    pet_gacha_ticket_10,
    roulette_gacha_ticket_1,
    guild_coin_box_1_100,
    guild_coin_box_100_500,
    guild_coin_box_500_1000,
    guild_coin_box_1000_3000,
    guild_coin_box_3000_5000,
    weapon_limit_stone_d_box_1_100,
    weapon_limit_stone_c_box_1_100,
    weapon_limit_stone_b_box_1_100,
    weapon_limit_stone_a_box_1_100,
    weapon_limit_stone_s_box_1_100,
    weapon_limit_stone_ss_box_1_100,
    weapon_shield_stone_d_box_1_100,
    weapon_shield_stone_c_box_1_100,
    weapon_shield_stone_b_box_1_100,
    weapon_shield_stone_a_box_1_100,
    weapon_shield_stone_s_box_1_100,
    weapon_shield_stone_ss_box_1_100,
    weapon_accessory_stone_d_box_1_100,
    weapon_accessory_stone_c_box_1_100,
    weapon_accessory_stone_b_box_1_100,
    weapon_accessory_stone_a_box_1_100,
    weapon_accessory_stone_s_box_1_100,
    weapon_accessory_stone_ss_box_1_100,
    jewelry_box_1,
    jewelry_box_1_5,
    jewelry_box_5_10,
    jewelry_box_10_15,
    jewelry_box_10_20,
    jewelry_box_10_50,
    relic,
    weapon_all_box_ss,
    weapon_box_ss,
    weapon_shield_box_ss,
    weapon_accessory_box_ss,
    weapon_all_box_s_ss,
    weapon_box_s_ss,
    weapon_shield_box_s_ss,
    weapon_accessory_box_s_ss,
    mileage


}

public enum Ability_Type
{
    character_level,
    skill_atk,
    skill_atk_speed,
    skill_speed,
    add_atk_speed,
    add_speed,
    add_critical_damege,
    add_critical_percent,
    level_up_decrease,
    quest_upgrede_decrease,
    quest_reward_increase,
    monster_coin_increase,
    monster_steel_increase,
    steel_increase,
    quset_time_decrease,
    treasure_monster_steel_increase,
    add_level,
    add_atk,
    boss_coin_increase,
    treasure_monster_coin_increase,
    under_boss_percent_increase,
    treasure_monster_percent_increase,
    critical_shield,
    buy_reward_increase,
    monster_coin_10_percent,
    under_boss_soul_stone_increase,
    boss_hp_decrease,
    monster_steel_10_percent,
    counter_cool_decrease,
    none,
    under_time_increase,
    counter_skill_increase,
    monster_spawn_decrease,
    double_atk_damege_increase,
    boss_steel_increase,
    monster_hp_decrease,
    boss_round_damege_increase,
    tournament_damege_increase,
    tournament_hp_increase,
    job_time_decrease,
    hp_increase,
    damege_double,
    critical_double,
    crirical_armer_10_increase,
    reflect,
    damege_decrease,
    faint,


}

public enum Calculate_Type
{
    plus,
    mius
}

public enum Popup_Type
{
    underground_dungeon,
    upgrade_dungeon,
    hell_dungeon

}

public enum Cupon_Type
{
    Sussece,
    fail,
    overlab
}

public enum Help_Type
{
    skill,
    weapom,
    job,
    costume,
    totem,
    roon,
    guild,
    dungeon,
    quest,
    pet
}

public enum Progress_Reward_Type
{
    monster,
    job_upgrade,
    weapon_gacha,
    weapon_upgrade,
    shield_gacha,
    shield_upgrade,
    accessory_gacha,
    accessory_upgrade,
    pet_upgrade,
    level_upgrade,
    stage_clear,
    skill_upgrade,
    totem_upgrade,
    weapon_mix,
    upgrade_upgrade
}

public enum Daily_Quest_Type
{
    daily_clear,
    monster,
    job_upgrade,
    wepon_get,
    weapon_upgrade,
    character_level,
    skill_upgrade,
    totem_upgrade,
    weapon_mix

}

public enum Accumulate_Quest_Type
{
    chearacter_lv,
    wepon_get,
    shield_get,
    accessory_get,
    weapon_upgrade,
    shield_upgrade,
    accessory_upgrade,
    weapon_mix,
    shield_mix,
    accessory_mix,
    monster,
    boss,
    upgrade_stone,
    limit_stone,
    black_stone,
    totem_upgrade,
    skill_upgrade,
    upderground_clear,
    upgrade_clear,
    hell_clear,
    pet_skill_upgrade,
    crystal,
    coin,
    steel,
    player_level

}

public enum Game_Info_Type
{
    join_time,
    charactet_lv,
    player_lv,
    monster,
    boss,
    daily_quest_clear,
    undergroind_join,
    undergroind_clear,
    upgrade_join,
    upgrade_clear,
    hell_join,
    hell_clear,
    skill_upgrade,
    upgrade_upgrade,
    pet_upgrade,
    weapon_get,
    weapon_upgrade,
    weapon_mix,
    weapon_roon,
    weapon_decom,
    shield_get,
    shield_upgrade,
    shield_mix,
    shield_roon,
    shield_decom,
    accessory_get,
    accessory_upgrade,
    accessory_mix,
    accessory_roon,
    accessory_decom,
    job_upgrade,
    totem_upgrade,
    dia_get,
    dia_use,
    coin_get,
    coin_use,
    upgrade_stone_get,
    upgrade_stone_use,
    limit_stone_get,
    limit_stone_use,
    steel_get,
    steel_use,
    soul_stone_get,
    soul_stone_use,
    black_stone_get,
    black_stone_use,
    roon_get,
    gold_goblin,
    gift_get,
    roulette_get,
    ads_get

}

public enum Quest_Type
{
    daily,
    accumulate
}

public class Skill_s
{
    public static Character_Lv skill_lv = Character_Lv.lv_1;

    public static List<Skill> skills = new List<Skill>();

    public static Skill Get_Skill(Ability_Type skill_num)
    {
        Skill skill = skills.Find(x => x.ability_type.Equals((int)skill_num));

        return skill;
    }

    public static float Get_Skill_Val(Ability_Type skill_num)
    {

        Skill skill = skills.Find(x => x.ability_type.Equals((int)skill_num));

        return skill == null ? 0 : skill.f_total;
    }

    public static void Set_Skill_Val(int skill_num, int lv)
    {
        Skill skill = skills.Find(x => x.num.Equals(skill_num));

        int per = Ability_.Get_Ability_Type(skill.ability_type).Equals(0) ? 100 : 1;

        skill.f_total = (skill.base_ability * per) + (skill.ability_add * per) * (lv - 1);

    }

}

public class Calculate
{
    public static BigInteger Percent(int base_price, float percent, int lv, int end_lv)
    {
        BigInteger total = 0;

        int m_percent = (int)Math.Ceiling(base_price * percent);

        for (int i = lv; i < lv + end_lv; i++)
        {
            total += base_price + m_percent * i;
        }

        return total;
    }

    public static BigInteger Price(BigInteger base_price, int percent, int lv, int end_lv)
    {
        BigInteger total = 0;

        for (int i = lv; i < lv + end_lv; i++)
        {
            total += base_price + (base_price * percent / 100) * i;
            // Debug.Log(base_price * percent / 100 + " " +total);
        }

        return total;
    }

    public static BigInteger Reward(BigInteger base_price, int percent, int lv)
    {
        BigInteger total = base_price;
        BigInteger pow = 1;

        for (int i = 0; i < lv; i++)
        {
            pow = pow * 100;

            total = (total * percent);
        }

        total /= pow;

        return total;
    }
}

public class Skill
{
    public int num;
    public string name;
    public int max_lv;
    public int price_type;
    public int price_val;
    public float price_percent;
    public int ability_type;
    public float base_ability;
    public float ability_add;
    public int skill_time;
    public int cool_time;
    public float f_total;

}

public class Index
{
    public int num;
    public int val;

}

public class Item_s
{
    public static float total;
    public static float gift_total;
    public static float gobiln_total;

    public static Item selet_item;

    public static List<Item> items = new List<Item>();
    public static List<Item> gift_items = new List<Item>();
    public static List<Item> goblin_items = new List<Item>();

    public static int Get_Random_Item()
    {
        float selet = 0;
        float weight = 0;

        selet = total * Random.Range(0.0f, total);

        for (int i = 0; i < items.Count; i++)
        {
            weight += items[i].percent;

            if (selet <= weight)
            {
                Debug.Log("이거다 " + items[i].name);
                return items[i].num;
            }
        }

        return 0;
    }

    public static void Get_Random_Gift_Item()
    {
        float selet = 0;
        float weight = 0;

        selet = Random.Range(0.0f, gift_total);
        Debug.Log("SELEECT " + selet);

        for (int i = 0; i < gift_items.Count; i++)
        {
            weight += gift_items[i].percent;

            if (selet <= weight)
            {
                Debug.Log("이거다 " + gift_items[i].name);
                selet_item = gift_items[i];
                break;
            }
        }
    }

    public static Item Get_Random_Goblin_Item()
    {
        float selet = 0;
        float weight = 0;

        selet = Random.Range(0.0f, gift_total);
        Debug.Log("SELEECT " + selet);

        for (int i = 0; i < goblin_items.Count; i++)
        {
            weight += goblin_items[i].percent;

            if (selet <= weight)
            {
                Debug.Log("이거다 " + goblin_items[i].name);
                selet_item = goblin_items[i];
                return items[i];
            }
        }

        return null;

    }

}

public class Item
{
    public int num;
    public string name;
    public int item_num;
    public int val;
    public float percent;
}

public class Underground_
{

    public static int Underground_Lv = 0;

    public static int Boss_Percent = 0;

    public static Underground_info underground_Info = new Underground_info();

    public static List<Index> Underground_Item = new List<Index>();

    public static BigInteger Get_Reward_0()
    {
        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_val_0"].ToString());

        return big * underground_Info.int_Max_Monster + (big * underground_Info.int_Max_Boss) * 2;
    }

    public static BigInteger Get_Reward_1()
    {

        BigInteger big = BigInteger.Parse(BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_val_1"].ToString());

        return big * underground_Info.int_Max_Monster + (big * underground_Info.int_Max_Boss) * 2;
    }

    public static Item_Type Get_Reward_0_Type()
    {
        return (Item_Type)(int)BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_0"];
    }

    public static Item_Type Get_Reward_1_Type()
    {
        return (Item_Type)(int)BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_1"];
    }

    public static Sprite Get_Img_Reward_0()
    {
        return Utill.Get_Item_Sp((Item_Type)BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_0"]);
    }

    public static Sprite Get_Img_Reward_1()
    {
        return Utill.Get_Item_Sp((Item_Type)BackEndDataManager.instance.underground_dungeon_csv_data[Underground_Lv]["reward_1"]);
    }

    public static void Get_Sweep(int val)
    {

        Game_info_.Set_Game_Info(Game_Info_Type.undergroind_clear, val);
        Game_info_.Set_Game_Info(Game_Info_Type.undergroind_join, val);

        Underground_info Db_Info = BackEndDataManager.instance.Content_Data.underground_info
       .Find(x => x.int_num.Equals(Underground_Lv));

        underground_Info = Db_Info;

        BackEndDataManager.instance.Set_Item(Item_Type.underground_ticket, val, Calculate_Type.mius);
        BackEndDataManager.instance.Set_Item(Get_Reward_0_Type(), Get_Reward_0() * val, Calculate_Type.plus);
        BackEndDataManager.instance.Set_Item(Get_Reward_1_Type(), Get_Reward_1() * val, Calculate_Type.plus);


        Underground_Item.Clear();

        Get_Underground_Random_Item();

        Set_Underground_Random_Item();

        UiManager.instance.Set_Underground_Reward_Txt(val);


    }

    public static void Get_Underground_Random_Item()
    {
        int total_ = 1;

        switch (PlayManager.instance.Stage_State)
        {
            case Stage_State.stage:
                total_ = underground_Info.int_Max_Monster + underground_Info.int_Max_Boss;
                UiManager.instance.Reset_Underground_Item();

                break;
            default:
                break;
        }

        for (int i = 0; i < total_; i++)
        {

            if (Random.Range(0, 1000) <= 50)
            {
                Debug.Log("아이템 획득");
                int item = Item_s.Get_Random_Item();

                Index index = Underground_Item.Find(x => x.num.Equals(item));

                if (index == null)
                {
                    index = new Index { num = item, val = 1 };

                    Underground_Item.Add(index);


                }
                else
                    index.val += 1;


                UiManager.instance.Set_Underground_Val((Item_Type)Item_s.items.Find(x => x.num.Equals(index.num)).item_num, index.val);

            }

        }

    }

    public static void Set_Underground_Random_Item()
    {
        Debug.Log(Underground_Item.Count);

        foreach (var item in Underground_Item)
        {
            Debug.Log(item.num);

            BackEndDataManager.instance.Set_Item((Item_Type)Item_s.items.Find(x => x.num.Equals(item.num)).item_num
                , item.val, Calculate_Type.plus);
        }

    }

}

public class Upgrade_
{

    public static int Upgrade_Lv = 0;

    public static BigInteger Get_Reward_0()
    {
        BigInteger big = Calculate.Reward((int)BackEndDataManager.instance.upgrade_dungeon_csv_data[0]["reward_val_0"], 120, Upgrade_Lv);

        return big;
    }

    public static BigInteger Get_Reward_1()
    {

        BigInteger big = Calculate.Reward((int)BackEndDataManager.instance.upgrade_dungeon_csv_data[0]["reward_val_1"], 240, Upgrade_Lv);

        return big;
    }

    public static Item_Type Get_Reward_0_Type()
    {
        return (Item_Type)BackEndDataManager.instance.upgrade_dungeon_csv_data[Upgrade_Lv]["reward_0"];
    }

    public static Item_Type Get_Reward_1_Type()
    {
        return (Item_Type)BackEndDataManager.instance.upgrade_dungeon_csv_data[Upgrade_Lv]["reward_1"];
    }

    public static Sprite Get_Img_Reward_0()
    {
        return Utill.Get_Item_Sp(Get_Reward_0_Type());
    }

    public static Sprite Get_Img_Reward_1()
    {
        return Utill.Get_Item_Sp(Get_Reward_1_Type());
    }

}

public class Hell_
{

    public static int Hell_Lv = 0;

    public static int int_Max_Monster = 0;


    public static BigInteger Get_Reward_0()
    {
        BigInteger big = Calculate.Reward((int)BackEndDataManager.instance.hell_dungeon_csv_data[0]["reward_val_0"], 120, Hell_Lv);

        return big * int_Max_Monster;
    }

    public static BigInteger Get_Reward_1()
    {

        BigInteger big = (int)BackEndDataManager.instance.hell_dungeon_csv_data[0]["reward_val_1"] * (Hell_Lv + 1);

        return big * int_Max_Monster;
    }

    public static Item_Type Get_Reward_0_Type()
    {
        return (Item_Type)BackEndDataManager.instance.hell_dungeon_csv_data[Hell_Lv]["reward_0"];
    }

    public static Item_Type Get_Reward_1_Type()
    {
        return (Item_Type)BackEndDataManager.instance.hell_dungeon_csv_data[Hell_Lv]["reward_1"];
    }

    public static Sprite Get_Img_Reward_0()
    {
        return Utill.Get_Item_Sp(Get_Reward_0_Type());
    }

    public static Sprite Get_Img_Reward_1()
    {
        return Utill.Get_Item_Sp(Get_Reward_1_Type());
    }

}

public class Ability_
{
    public static int Get_Ability_Type(int type)
    {
        return (int)BackEndDataManager.instance.ability_csv_data[type]["type"];
    }

    public static string Ability_Type_Sign(int type)
    {
        return Get_Ability_Type(type).Equals(0) ? "%" : "";
    }

    public static string Get_Ability_Nmae(int type)
    {
        if (type == -1)
            return "";

        return BackEndDataManager.instance.ability_csv_data[type]["ability_kr"].ToString();
    }
}

public class Pet_
{
    public static int int_pet = 0;

    public static string Pet_Name()
    {
        return (string)BackEndDataManager.instance.pet_csv_data[int_pet]["name"];
    }

    public static int Pet_Ability_type_0()
    {
        return (int)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_type_0"];
    }

    public static int Pet_Ability_type_1()
    {
        return (int)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_type_1"];
    }

    public static float Pet_Ability_type_0_Val()
    {
        Pet_info pet_Info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(int_pet));

        int mix = Ability_.Get_Ability_Type(Pet_Ability_type_0()).Equals(0) ? 100 : 1;
        float val = (float)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_val_0"] * mix;
        float percent = (float)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_percent_0"] * mix;

        Debug.Log("0 type " + val + "   " + percent);
        return val + percent * (pet_Info != null ? (pet_Info.int_lv - 1) : 0);
    }

    public static float Pet_Ability_type_1_Val()
    {
        Pet_info pet_Info = BackEndDataManager.instance.Pet_Data.pet_info.Find(x => x.int_num.Equals(int_pet));

        int mix = Ability_.Get_Ability_Type(Pet_Ability_type_1()).Equals(0) ? 100 : 1;
        float val = (float)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_val_1"] * mix;
        float percent = (float)BackEndDataManager.instance.pet_csv_data[int_pet]["ability_percent_1"] * mix;

        Debug.Log("1 type " + int_pet + "   " + Pet_Ability_type_0());

        return val + percent * (pet_Info != null ? (pet_Info.int_lv - 1) : 0); ;
    }

    public static int Pet_Max_lv()
    {
        return (int)BackEndDataManager.instance.pet_csv_data[int_pet]["max_lavel"];
    }

    public static Item_Type Pet_Price_Type()
    {
        return (Item_Type)BackEndDataManager.instance.pet_csv_data[int_pet]["price_type"];
    }

    public static BigInteger Price(int my_lv, int add_lv)
    {
        int price_val = (int)BackEndDataManager.instance.pet_csv_data[int_pet]["price_val"];
        float price_percent = (float)BackEndDataManager.instance.pet_csv_data[int_pet]["price_percent"] * 100;

        return Calculate.Price(price_val, (int)price_percent, my_lv, add_lv);
    }
}

public class Weapon_
{
    public static int Select_Weapon = 0;

    public static Weapon_Content Weapon_Content = Weapon_Content.Sword;

    public static int Mix_Count = 0;

    public static int Decom_Count = 0;

    public static Roon_Slot roon_Slot;

    public static Roon_Info roon_Info;

}

public class Job_
{
    public static Character_Lv Job_Lv = Character_Lv.lv_1;

    public static string Get_Time(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.job_csv_data[num];

        int d_time = (int)data["job_time"];

        return string.Format("{0:00}:{1:00}:{2:00}"
            , d_time / 3600, (d_time % 3600) / 60, (d_time % 3600) % 60);

    }

    public static BigInteger Get_Reward(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.job_csv_data[num];

        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals(num));


        if (job_ != null)
        {
            BigInteger big = BigInteger.Parse(data["reward_val_0"].ToString(), System.Globalization.NumberStyles.Float);

            float percnet = (float)data["reward_add"] * 100;

            BigInteger total = big;

            for (int i = 0; i < job_.int_lv - 1; i++)
            {
                BigInteger add = (total * (int)percnet / 100);
                total = total + add;

            }

            return total;

        }
        else
        {
            return 0;

        }


    }

    public static BigInteger Get_Add_Reward(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.job_csv_data[num];

        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals((int)data["num"]));

        BigInteger big = BigInteger.Parse(data["reward_val_0"].ToString(), System.Globalization.NumberStyles.Float);

        float percnet = (float)data["reward_add"] * 100;

        BigInteger total = Get_Reward(num);

        BigInteger add = (total * (int)percnet / 100);

        if (job_ != null)
        {
            for (int i = 0; i < (int)Job_Lv - 1; i++)
            {
                total = total + (total * (int)percnet / 100);
                add += (total * (int)percnet / 100);

            }

            return add;

        }
        else
        {
            return big;

        }


    }

    public static BigInteger Get_Price(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.job_csv_data[num];

        Job_info job_ = BackEndDataManager.instance.Job_Data.job_info.Find(x => x.int_num.Equals(num));

        BigInteger price = BigInteger.Parse(data["price_val"].ToString(), System.Globalization.NumberStyles.Float);

        float percnet = (float)data["price_percent"] * 100;

        BigInteger total = job_ == null ? price : Calculate.Price(price, (int)percnet, job_.int_lv - 1, (int)Job_Lv);

        return total;
    }
}

public class Totem_
{
    public static Character_Lv totem_Lv = Character_Lv.lv_1;


    public static float Get_Reward(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.totem_csv_data[num];

        Totem_info info_ = BackEndDataManager.instance.Totem_Data.totem_info.Find(x => x.int_num.Equals(num));

        int ability_type = (int)data["ability_type"];

        int _type = Ability_.Get_Ability_Type(ability_type);

        float val = (float)data["base_ability"] * (_type.Equals(0) ? 100 : 1);

        float add = (float)data["ability_add"] * (_type.Equals(0) ? 100 : 1);

        decimal add_result = (decimal)add * (info_ == null ? 0 : info_.int_lv - 1);

        float resultValue = val + (float)add_result;

        return resultValue;

    }

    public static float Get_Add_Reward(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.totem_csv_data[num];

        int ability_type = (int)data["ability_type"];

        int _type = Ability_.Get_Ability_Type(ability_type);

        float add = (float)data["ability_add"] * (_type.Equals(0) ? 100 : 1);

        return add * (int)totem_Lv;

    }

    public static BigInteger Get_Price(int num)
    {
        Dictionary<string, object> data = BackEndDataManager.instance.totem_csv_data[num];

        Totem_info info_ = BackEndDataManager.instance.Totem_Data.totem_info.Find(x => x.int_num.Equals(num));

        BigInteger price = BigInteger.Parse(data["price_val"].ToString(), System.Globalization.NumberStyles.Float);

        float percnet = (float)data["price_percent"] * 100;

        BigInteger total = info_ == null ? price : Calculate.Price(price, (int)percnet, info_.int_lv - 1, (int)totem_Lv);

        return total;
    }
}

public class Utill
{
    public static Sprite Get_Character_Sp(int num)
    {
        return Resources.Load<Sprite>("Character/char_" + num.ToString());
    }

    public static Sprite Get_Skill_Sp(int num)
    {
        return Resources.Load<Sprite>("Skill/S_skill_" + num);
    }

    public static Sprite Get_Item_Sp(Item_Type num)
    {
        return Resources.Load<Sprite>("Item/item_" + (int)num);
    }

    public static Sprite Get_Pet_Sp(int num)
    {
        return Resources.Load<Sprite>("Pet/pet_" + num.ToString());
    }

    public static Sprite Get_Sword_Sp(int num)
    {
        return Resources.Load<Sprite>("Weapon/Weapon_" + num.ToString());
    }

    public static Sprite Get_Shield_Sp(int num)
    {
        return Resources.Load<Sprite>("Shield/Shield_" + num.ToString());
    }

    public static Sprite Get_Accessory_Sp(int num)
    {
        return Resources.Load<Sprite>("Accessory/Accessory_" + num.ToString());
    }


    public static Sprite Get_Roon_Sp(int num)
    {
        return Resources.Load<Sprite>("Roon/roon_" + num.ToString());
    }

    public static Sprite Get_Job_Sp(int num)
    {
        return Resources.Load<Sprite>("Job/job_" + num.ToString());
    }

    public static Sprite Get_Totem_Sp(int num)
    {
        return Resources.Load<Sprite>("Totem/totem_" + num.ToString());
    }
}

public class Quest_
{
    public static void Check_Daily_Quest(Daily_Quest_Type daily_Quest_Type, int val)
    {

        Quest_info quest_Info = BackEndDataManager.instance.Quest_Data.quest_Info
            .Find(x => x.int_num.Equals((int)daily_Quest_Type) && x.type.Equals(Quest_Type.daily));

        if (quest_Info == null)
        {
            quest_Info = new Quest_info
            {
                int_num = (int)daily_Quest_Type,
                type = Quest_Type.daily,
                int_clear = 0,
                int_val = 0
            };

            BackEndDataManager.instance.Quest_Data.quest_Info.Add(quest_Info);
            BackEndDataManager.instance.Save_Quest_Data();
        }

        quest_Info.int_val += val;
        BackEndDataManager.instance.Save_Quest_Data();

        UiManager.instance.Set_Quest_(Quest_Type.daily, (int)daily_Quest_Type);
    }

}

public class Game_info_
{
    public static void Set_Game_Info(Game_Info_Type _Info_Type, BigInteger val)
    {

        Game_info _Info = BackEndDataManager.instance.Game_Data.game_Info.Find(x => x.int_num.Equals((int)_Info_Type));
        if (_Info == null)
        {
            _Info = new Game_info
            {
                int_num = (int)_Info_Type,
                str_val = val.ToString()
            };

            BackEndDataManager.instance.Game_Data.game_Info.Add(_Info);
        }
        else
        {
            BigInteger total = BigInteger.Parse(_Info.str_val);
            total += val;

            _Info.str_val = total.ToString();

        }

        UiManager.instance.Set_Quest_(Quest_Type.accumulate, (int)_Info_Type);


        BackEndDataManager.instance.Save_Game_Data();
    }


    public static BigInteger Get_Game_info(Game_Info_Type _Info_Type)
    {
        if (_Info_Type.Equals(Game_Info_Type.charactet_lv))
        {
            return BackEndDataManager.instance.Character_Data.int_character_Lv;
        }else if (_Info_Type.Equals(Game_Info_Type.player_lv))
        {
            return BackEndDataManager.instance.Player_Data.int_lv;
        }

        Game_info _Info = BackEndDataManager.instance.Game_Data.game_Info.Find(x => x.int_num.Equals((int)_Info_Type));

        return _Info == null ? 0 : BigInteger.Parse(_Info.str_val);

    }
}