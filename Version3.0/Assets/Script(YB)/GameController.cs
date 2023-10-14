using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject panel; // 面板
    public Button continueButton; // 继续游戏的按钮

    private bool isGamePaused = false;

    void Start()
    {
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }

    void Update()
    {
        // 游戏时间继续进行的逻辑
        if (!isGamePaused)
        {
            // 在这里添加游戏时间继续的逻辑
        }
    }

    void OnContinueButtonClicked()
    {
        // 恢复游戏时间的逻辑
        isGamePaused = false;

        // 设置面板为不可见
        panel.SetActive(false);
    }
}

