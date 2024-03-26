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


        /*// Получаем компонент Animation для объекта
        Animation anim = GetComponent<Animation>();

        // Начало временного диапазона
        float startTime = 0.15f;

        // Конец временного диапазона
        float endTime = 1f;

        // Имя анимации
        string animName = "Zip_wish_prolit";

        // Проигрываем часть анимации
        anim.Play(animName);
        anim[animName].time = startTime;
        anim[animName].speed = 1f / (endTime - startTime);*/
    }
}
