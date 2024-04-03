using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zil_Body : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField ]private Animator animator_builds;
    private Vector3 Start_postion;

    private void Start() => Start_postion = this.transform.position;
    
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);

        if (GameManager.Instance.is_learning_Mode)
            return;
        if(action_build.Use_Add_Action)
            GameManager.Instance.Status_Action.Add(action_build);

        switch (GameManager.Instance.Number_Span)
        {
            case 0:
                animator_builds.Play("Set_ramp_coastal_support_1");
               // GameManager.Instance.part_marm[0].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 1:
                animator_builds.Play("Set_span_support_1");
               // GameManager.Instance.part_marm[1].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 2:
                animator_builds.Play("Set_span_support_2");
               // GameManager.Instance.part_marm[2].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 3:
                animator_builds.Play("Set_span_support_3");
              //  GameManager.Instance.part_marm[3].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 4:
                animator_builds.Play("Set_span_support_4");
              //  GameManager.Instance.part_marm[4].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 5:
                animator_builds.Play("Set_span_support_5");
              //  GameManager.Instance.part_marm[5].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 6:
                animator_builds.Play("Set_span_support_6");
              //  GameManager.Instance.part_marm[6].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 7:
                animator_builds.Play("Set_span_support_7");
              //  GameManager.Instance.part_marm[7].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 8:
                animator_builds.Play("Set_span_support_8");
                GameManager.Instance.part_marm[8].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 9:
                animator_builds.Play("Set_ramp_coastal_support_2");
              //  GameManager.Instance.part_marm[9].GetComponent<Part_marm>().Show_Span(true);
                break;
        }
        GameManager.Instance.Number_Span++;

        Debug.Log("Number_Span:" + GameManager.Instance.Number_Span);
        
    }

    public void Set_Zil_to_End() => this.transform.position = Start_postion;
}
