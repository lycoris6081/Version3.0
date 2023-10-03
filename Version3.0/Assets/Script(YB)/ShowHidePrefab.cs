using UnityEngine;

public class ShowHidePrefab : MonoBehaviour
{
    public GameObject[] prefabs; // �o�̩�J�A��15��Prefab
    private int currentIndex = 0;
    private float timer = 0f;
    public float interval = 1f; // 1����ܤ@��Prefab
    public bool repeat = true; // �O�_�ҥέ��ƴ`��
    public bool hideLastPrefab = true; // �O�_�n�N�̫�@��Prefab�]�m�����i��

    private void Start()
    {
        // �}�l�ɡA�N�Ҧ�Prefab�]�m�����i��
        foreach (var prefab in prefabs)
        {
            prefab.SetActive(false);
        }

        // �ҰʲĤ@��Prefab�����
        ShowNextPrefab();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;

            // ��ܤU�@��Prefab�A�p�G�w�g��ܧ��Ҧ���Prefab�A�h�ھ�repeat�ܼƨM�w�O�_���s�}�l�`��
            if (currentIndex < prefabs.Length)
            {
                ShowNextPrefab();
            }
            else
            {
                if (hideLastPrefab && prefabs.Length > 0)
                {
                    prefabs[prefabs.Length - 1].SetActive(false); // �N�̫�@��Prefab�]�m�����i��
                }

                if (repeat)
                {
                    currentIndex = 0; // ���]���ޡA���s�}�l�`��
                    ShowNextPrefab();
                }
                else
                {
                    // �����s�ΰ����L�������ާ@
                    enabled = false;
                }
            }
        }
    }

    private void ShowNextPrefab()
    {
        // �����W�@��Prefab
        if (currentIndex > 0)
        {
            prefabs[currentIndex - 1].SetActive(false);
        }

        // ��ܷ�ePrefab
        if (currentIndex < prefabs.Length)
        {
            prefabs[currentIndex].SetActive(true);
        }

        currentIndex++;
    }
}
