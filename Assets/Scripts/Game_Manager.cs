using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game_Manager : MonoBehaviour
{
    Animator anim_marm;
    [Header("MARM part")]
    [SerializeField] GameObject marm;
    [SerializeField] List<GameObject> shields;
    [SerializeField] List<GameObject> wheel_war;
    [SerializeField] GameObject folder_opors;
    [SerializeField] GameObject folder_block_span;
    [SerializeField] GameObject folder_aparels;
    [SerializeField] GameObject folder_pins;
        
    [Header("UI")]
    [SerializeField] Text report;
    [SerializeField] Text status_;
    
    private int[] sequence = {4,6,5,3,3,3,3,3,3,3,6,5};
    private int currentPos = 0;

    private bool call_wheel_war;
    private bool call_shield;

    private int number_wheel_war;
    private int number_shield;

    void Start() => anim_marm = marm.GetComponent<Animator>(); 

    public void Set_wheel_war()
    {
        Debug.Log("call_wheel_war: " + call_wheel_war);

        if (!call_wheel_war)
            Full_Test("колесоотбой установить неправильно");
        if (number_wheel_war  >= wheel_war.Count)
            number_wheel_war = 0;
        else
            wheel_war[number_wheel_war].SetActive(true);
        number_wheel_war++;
        call_wheel_war = false;
    }

    public void Set_shield()
    {
        Debug.Log("call_shield: " + call_shield);

        if (!call_shield)
            Full_Test("Деформационный щит установить неправильно");
        if (number_shield >= shields.Count)
            number_shield = 0;
        else
            shields[number_shield].SetActive(true);
        number_shield++;
        call_shield = false;
    }

    public void Check_Button_Sequence(int number_push)
    {
        if (call_shield || call_wheel_war)
            Full_Test("Машина упала в реку");

        Debug.Log("call_shield: " + call_shield + "  call_wheel_war: " + call_wheel_war);
        Debug.Log("number_push: " + number_push + " currentPos: " + currentPos);

        if(currentPos >= sequence.Length)
            Restart(false);            
       
        if (number_push == sequence[currentPos])
        {            
            switch (currentPos)            
            {
                case 0:
                    Reset(false);
                    status_.text = "";  
                    anim_marm.SetBool("bank_1", true);
                    anim_marm.SetBool("full_set", false);
                    break;
                case 1:
                    anim_marm.SetBool("aparels_1", true);                    
                    break;
                case 2:
                    anim_marm.SetBool("anchor_1", true);                    
                    break;
                case 3:
                    anim_marm.SetBool("opora_1", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 4:
                    anim_marm.SetBool("opora_2", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 5:
                    anim_marm.SetBool("opora_3", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 6:
                    anim_marm.SetBool("opora_4", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 7:
                    anim_marm.SetBool("opora_5", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 8:
                    anim_marm.SetBool("opora_6", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;
                case 9:
                    anim_marm.SetBool("opora_5_bank", true);
                    call_wheel_war = true;
                    call_shield = true;
                    break;                
                case 10:
                    anim_marm.SetBool("aparels_2", true);
                    call_shield = true;
                    break;
                case 11:
                    anim_marm.SetBool("ancher_2", true);
                    break;
            }
            currentPos++;
            if (currentPos >= sequence.Length)
                Pass_Test();
            return;
        }
        else
            Full_Test("Не правильная последовательность установки моста");        
    }

    private void Reset(bool set_active)
    {
        foreach (var w in wheel_war)
            w.SetActive(set_active);

        foreach (var s in shields)
            s.SetActive(set_active);
    }

    public void Restart(bool set_active)
    {
        Reset(set_active);

        currentPos = 0;
        call_shield = false;
        call_wheel_war = false;
        number_wheel_war = 0;
        number_shield = 0;        
        
        for (int i = 0; i < anim_marm.parameterCount; i++)
        {
            AnimatorControllerParameter parameter = anim_marm.GetParameter(i);
            if (parameter.type == AnimatorControllerParameterType.Bool)
                anim_marm.SetBool(parameter.name, false);           
        }
        anim_marm.SetBool("full_set", true);
    }

    private void Full_Test(string a)
    {       
        status_.text = a;
        report.text = "Тест провален ";
        report.color = Color.red;

        Restart(true);
    }

    private void Pass_Test()
    {
        status_.text = "<_TЕСТ ПРОЙДЕН_>";
        report.text = "Tecт пройден";
        report.color = Color.green;
    }
}
