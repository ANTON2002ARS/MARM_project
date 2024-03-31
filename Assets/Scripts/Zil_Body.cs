using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zil_Body : MonoBehaviour
{
    [SerializeField] private Action_build action_build;
    [SerializeField ]private Animator animator_builds;
    private void OnMouseUpAsButton()
    {
        Debug.Log("Choice object: " + this.name);
        GameManager.Instance.Status_Action.Add(action_build);

        switch (GameManager.Instance.Number_Span)
        {
            case 0:
                animator_builds.Play("Set_ramp_coastal_support_1");
                GameManager.Instance.part_marm[0].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 1:
                animator_builds.Play("Set_span_support_1");
                GameManager.Instance.part_marm[1].GetComponent<Part_marm>().Show_Span(true);
                break;
            case 2:
                animator_builds.Play("Set_span_support_2");
                break;
            case 3:
                animator_builds.Play("Set_span_support_3");
                break;
            case 4:
                animator_builds.Play("Set_span_support_4");
                break;
            case 5:
                animator_builds.Play("Set_span_support_5");
                break;
            case 6:
                animator_builds.Play("Set_span_support_6");
                break;
            case 7:
                animator_builds.Play("Set_span_support_7");
                break;
            case 8:
                animator_builds.Play("Set_span_support_8");
                break;
            case 9:
                animator_builds.Play("Set_ramp_coastal_support_2");
                break;
        }
        GameManager.Instance.Number_Span++;

        Debug.Log("Number_Span:" + GameManager.Instance.Number_Span);
        
    }
}
