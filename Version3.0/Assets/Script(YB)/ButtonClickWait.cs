using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonClickWait : MonoBehaviour
{
    [SerializeField]
    private Button yourButton;

    [SerializeField]
    private float waitTime = 2f;

    // 定义一个UnityEvent
    public UnityEvent onClickEvent;

    void Start()
    {
        // 获取按钮组件
        if (yourButton == null)
        {
            yourButton = GetComponent<Button>();
        }

        // 注册按钮点击事件
        yourButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        // 启动协程等待
        StartCoroutine(WaitForSecondsCoroutine(waitTime));
    }

    IEnumerator WaitForSecondsCoroutine(float seconds)
    {
        // 等待指定的时间
        yield return new WaitForSeconds(seconds);

        // 触发UnityEvent，执行相关代码
        onClickEvent.Invoke();
    }
}

