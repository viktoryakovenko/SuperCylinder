using UnityEngine;

public static class PickupMessage
{
    public static Canvas MessageCanvas => _messageCanvas;
    private static Canvas _messageCanvas;

    public static void Init(Canvas canvas)
    {
        _messageCanvas = canvas;
    }
    
    public static void Show(Transform pickableObject)
    {
        var messagePosition = pickableObject.position;
        var scaleY = pickableObject.localScale.y;
        messagePosition.y += scaleY/2f + 0.2f;

        _messageCanvas.gameObject.transform.position = messagePosition;
        _messageCanvas.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        _messageCanvas.gameObject.SetActive(false);
    }
}
