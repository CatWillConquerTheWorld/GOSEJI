using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPop : MonoBehaviour
{
    public float scaleSpeed = 2.0f; // Ȯ�� �ӵ�

    void OnEnable()
    {
        // ���� ������Ʈ�� Ȱ��ȭ�� �� ȣ��Ǵ� �Լ�
        StartCoroutine(ScaleIn());
    }
    IEnumerator ScaleIn()
    {
        transform.localScale = Vector3.zero; // �ʱ� �������� 0���� ����

        while (transform.localScale.x < 1.0f)
        {
            // ���� �����ϰ� ��ǥ ������(1, 1, 1) ���̸� �����Ͽ� �ε巴�� Ȯ��
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * scaleSpeed);
            yield return null;
        }

        // ���������� �������� 1�� ���� (�ε巯�� ������ ����)
        transform.localScale = Vector3.one;
    }
}
