using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zil_Body : MonoBehaviour
{
    Animator anim;

    private void OnMouseUpAsButton()
    {
        Debug.Log("zip");

        anim = this.GetComponent<Animator>();
        anim.SetBool("zip_active", true);


        /*// �������� ��������� Animation ��� �������
        Animation anim = GetComponent<Animation>();

        // ������ ���������� ���������
        float startTime = 0.15f;

        // ����� ���������� ���������
        float endTime = 1f;

        // ��� ��������
        string animName = "Zip_wish_prolit";

        // ����������� ����� ��������
        anim.Play(animName);
        anim[animName].time = startTime;
        anim[animName].speed = 1f / (endTime - startTime);*/
    }
}
