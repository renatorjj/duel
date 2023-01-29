using UnityEngine;

[RequireComponent(typeof (RectTransform))]
public class UIScreen : MonoBehaviour, IUIScreen
{
    public virtual void Init()
    {
      Hide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
