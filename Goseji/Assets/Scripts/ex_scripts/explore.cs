using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explore : MonoBehaviour
{
    public GameObject objectToScale;
    public GameObject buttonObject;
    public float scaleFactor = 1.5f; // 확대할 비율
    public float restoreDelay = 2f; // 복구까지의 시간 (초)

    private Vector3 originalScale;
    private bool isScaling = false;

    public GameObject catObject; // 고양이 오브젝트를 연결할 변수
    public GameObject dontfound; //아무것도 발견 못 함
    public float catProbability = 0.5f; // 고양이가 나타날 확률 (0.0 ~ 1.0)

    void Start()
    {
        originalScale = objectToScale.transform.localScale;
    }

    public void ExploreClick()
    {
        if (!isScaling)
        {
            StartCoroutine(ScaleObject());
        }


        float randomValue = Random.value; // 0.0 ~ 1.0 사이의 랜덤한 값 생성

        if (randomValue < catProbability)
        {
            StartCoroutine(SpawnCat()); // 고양이를 생성하는 함수 호출
        }
        else
        {
            StartCoroutine(NoCat());
        }

    }

    IEnumerator ScaleObject()
    {
        isScaling = true;
        buttonObject.gameObject.SetActive(false);

        // 확대
        Vector3 targetScale = originalScale * scaleFactor;

        float startTime = Time.time;
        while (Time.time < startTime + restoreDelay)
        {
            float t = (Time.time - startTime) / restoreDelay;
            objectToScale.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        // 일정 시간 후에 원래 크기로 복구
        yield return new WaitForSeconds(restoreDelay);
        objectToScale.transform.localScale = originalScale;

        isScaling = false;
        buttonObject.gameObject.SetActive(true);
    }
    IEnumerator SpawnCat()
    {
        yield return new WaitForSeconds(restoreDelay);
        catObject.gameObject.SetActive(true); // 고양이 오브젝트를 생성하거나 활성화하는 코드를 여기에 추가
        //페드 아웃? 암튼 화면 까맣게 만든 이후 전투 씬으로 넘어가기
        yield return new WaitForSeconds(1.5f);
        catObject.gameObject.SetActive(false);
        //SceneManager.LoadScene("Exploration");
    }

    IEnumerator NoCat()
    {
        yield return new WaitForSeconds(restoreDelay);
        dontfound.gameObject.SetActive(true); // 아무것도 찾지 못한 경우에 대한 처리를 여기에 추가
        Debug.Log("아무것도 찾지 못했습니다.");
        yield return new WaitForSeconds(1.5f);
        dontfound.gameObject.SetActive(false);
    }
}
