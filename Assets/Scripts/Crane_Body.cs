using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane_Body : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField] private Animator animation_builds;
    private Vector3 Start_postion;
    private void Start() 
    {
        Start_postion = this.transform.position;
        animation_builds.enabled = false; 
    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        if (GameManager.Instance.Is_Open_Menu)
            return;
        if (GameManager.Instance.is_learning_Mode)
            return;             
        if (Zil_Body.Instance_Zil.Crane_in_position)
            return;
        if (GameManager.Instance.end_animation_test)
            return;
        /*if (action_build.Use_Add_Action)
            GameManager.Instance.Status_Action.Add(action_build);*/

        switch (GameManager.Instance.Number_Span)
        {
            case 0:
                animation_builds.enabled = true;
                animation_builds.Play("Set_Manipulator_coastal_support_1");
                break;
            case 1:
                animation_builds.Play("Set_Manipulator_pos1");
                break;
            case 2:
                animation_builds.Play("Set_Manipulator_pos2");
                break;
            case 3:
                animation_builds.Play("Set_Manipulator_pos3");
                break;
            case 4:
                animation_builds.Play("Set_Manipulator_pos4");
                break;
            case 5:
                animation_builds.Play("Set_Manipulator_pos5");
                break;
            case 6:
                animation_builds.Play("Set_Manipulator_pos6");
                break;
            case 7:
                animation_builds.Play("Set_Manipulator_pos7");
                break;
            case 8:
                animation_builds.Play("Set_Manipulator_pos8");
                break;
            case 9:
                animation_builds.Play("Set_Manipulator_coastal_support_2");
                break;
        }
        Zil_Body.Instance_Zil.Crane_in_position = true;        
    }

    public void Set_Crane_to_End() => this.transform.position = Start_postion;
    public void Enable_Animation(bool is_enable) 
    {
        animation_builds.StopPlayback();
        Debug.Log("Enable_Animation: " + is_enable);
        animation_builds.enabled = is_enable;
      
    }
}
