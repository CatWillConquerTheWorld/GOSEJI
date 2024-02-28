using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class explore : MonoBehaviour
{
    public GameObject objectToScale;
    public GameObject buttonObject;
    public float scaleFactor = 1.5f; // Ȯ���� ����
    public float restoreDelay = 2f; // ���������� �ð� (��)

    private Vector3 originalScale;
    private bool isScaling = false;

    public GameObject catObject; // ����� ������Ʈ�� ������ ����
    public GameObject dontfound; //�ƹ��͵� �߰� �� ��
    public float catProbability = 0.5f; // ����̰� ��Ÿ�� Ȯ�� (0.0 ~ 1.0)

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


        float randomValue = Random.value; // 0.0 ~ 1.0 ������ ������ �� ����

        if (randomValue < catProbability)
        {
            StartCoroutine(SpawnCat()); // ����̸� �����ϴ� �Լ� ȣ��
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

        // Ȯ��
        Vector3 targetScale = originalScale * scaleFactor;

        float startTime = Time.time;
        while (Time.time < startTime + restoreDelay)
        {
            float t = (Time.time - startTime) / restoreDelay;
            objectToScale.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        // ���� �ð� �Ŀ� ���� ũ��� ����
        yield return new WaitForSeconds(restoreDelay);
        objectToScale.transform.localScale = originalScale;

        isScaling = false;
        buttonObject.gameObject.SetActive(true);
    }
    IEnumerator SpawnCat()
    {
        yield return new WaitForSeconds(restoreDelay);
        catObject.gameObject.SetActive(true); // ����� ������Ʈ�� �����ϰų� Ȱ��ȭ�ϴ� �ڵ带 ���⿡ �߰�
        //��� �ƿ�? ��ư ȭ�� ��İ� ���� ���� ���� ������ �Ѿ��
        yield return new WaitForSeconds(1.5f);
        catObject.gameObject.SetActive(false);
        //SceneManager.LoadScene("Exploration");
    }

    IEnumerator NoCat()
    {
        yield return new WaitForSeconds(restoreDelay);
        dontfound.gameObject.SetActive(true); // �ƹ��͵� ã�� ���� ��쿡 ���� ó���� ���⿡ �߰�
        Debug.Log("�ƹ��͵� ã�� ���߽��ϴ�.");
        yield return new WaitForSeconds(1.5f);
        dontfound.gameObject.SetActive(false);
    }
}
