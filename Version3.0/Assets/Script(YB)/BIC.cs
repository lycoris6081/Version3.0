using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BIC : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage; 
    public Sprite imageOne; 
    public Sprite imageTwo; 

    private void Start()
    {
        buttonImage.sprite = imageOne; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = imageTwo; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = imageOne; 
    }
}

