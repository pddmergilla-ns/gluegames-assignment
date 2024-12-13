using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform background;
    [SerializeField] private RectTransform handle;
    [SerializeField] private float joystickRange = 100f;

    private Vector2 inputDirection = Vector2.zero;

    public Vector2 InputDirection => inputDirection;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out Vector2 localPoint);

        localPoint = Vector2.ClampMagnitude(localPoint, joystickRange);
        handle.anchoredPosition = localPoint;

        inputDirection = localPoint / joystickRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;
        inputDirection = Vector2.zero;
    }
}
