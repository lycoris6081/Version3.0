using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    // �ŧi���s�ܼ�
    public Button resumeButton;

    // �}�l���
    void Start()
    {
        // �]�w���s���I���ƥ�
        resumeButton.onClick.AddListener(ResumeGame);
    }

    // ��_�C���ɶ������
    void ResumeGame()
    {
        // ��_�C���ɶ��A�N�ɶ��y�u�t�׳]�m��1
        Time.timeScale = 1;
    }
}
