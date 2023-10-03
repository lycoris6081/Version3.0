using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public Button button;
    public Sprite playSprite;
    public Sprite pauseSprite;

    private bool isPlaying = true;

    void Start()
    {
        // 设置初始的按钮图片
        button.image.sprite = isPlaying ? pauseSprite : playSprite;

        // 添加按钮点击事件监听器
        button.onClick.AddListener(ToggleMusic);
    }

    void ToggleMusic()
    {
        if (isPlaying)
        {
            // 停止音乐播放
            audioSource.Pause();
        }
        else
        {
            // 继续播放音乐
            audioSource.UnPause();
        }

        // 切换播放状态
        isPlaying = !isPlaying;

        // 更新按钮图片
        button.image.sprite = isPlaying ? pauseSprite : playSprite;
    }
}

