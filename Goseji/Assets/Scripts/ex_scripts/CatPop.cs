using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPop : MonoBehaviour
{
    public float scaleSpeed = 2.0f; // 확대 속도

    void OnEnable()
    {
        // 게임 오브젝트가 활성화될 때 호출되는 함수
        StartCoroutine(ScaleIn());
    }
    IEnumerator ScaleIn()
    {
        transform.localScale = Vector3.zero; // 초기 스케일을 0으로 설정

        while (transform.localScale.x < 1.0f)
        {
            // 현재 스케일과 목표 스케일(1, 1, 1) 사이를 보간하여 부드럽게 확대
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);
            yield return null;
        }

        // 최종적으로 스케일을 1로 설정 (부드러운 보간을 위해)
        transform.localScale = Vector3.one;
    }
}
