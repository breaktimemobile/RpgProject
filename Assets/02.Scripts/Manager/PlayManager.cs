using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State
{
    None,
    Run,
    Fight
}

public class PlayManager : MonoBehaviour
{
    public static PlayManager instance;

    Player_State player_State = Player_State.None;

    [SerializeField] List<GameObject> Characters;
    [SerializeField] List<GameObject> Monsters;

    Transform pos_Character;
    Transform pos_Monster;

    Player sc_Player;
    public Monster sc_Monster;

    GameObject obj_Monster;

    public Player_State Player_State { get => player_State; set => player_State = value; }

     
    public void Change_State(Player_State _State)
    {
        Player_State = _State;

        switch (Player_State)
        {
            case Player_State.None:
                break;
            case Player_State.Run:
                sc_Player.Stop_Atk();
                sc_Player.Start_Run();
                break;
            case Player_State.Fight:
                sc_Player.Start_Atk();
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        instance = this;

        pos_Character = UiManager.instance.obj_Stage.transform.Find("pos_Character");
        pos_Monster = UiManager.instance.obj_Stage.transform.Find("pos_Monster");
    }

    public void Play_Game()
    {
        Debug.Log("플레이 게임");
        UiManager.instance.Set_Ui();
        Set_Character();
        Set_Monster();

        Change_State(Player_State.Run);
        
    }

    public void Set_Character()
    {
        GameObject obj_Player = Instantiate(Characters[0], UiManager.instance.obj_Stage.transform);
        obj_Player.transform.position = pos_Character.position;
     
        sc_Player = obj_Player.GetComponent<Player>();
    }

    public void Set_Monster()
    {

        obj_Monster = Instantiate(Monsters[0], UiManager.instance.obj_Stage.transform);
        obj_Monster.transform.position = pos_Monster.position;

        sc_Monster = obj_Monster.GetComponent<Monster>();

        if (BackEndDataManager.instance.Stage_Data.int_step > 10)
        {
            sc_Monster.Set_Monster(Monster_Type.Boss, 500);

        }
        else
        {
            sc_Monster.Set_Monster(Monster_Type.Basic, 300);

        }
    }
}
