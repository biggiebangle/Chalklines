using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioProgressBar : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    
    public AudioSource source;

    private Image progress;
    
    private void Awake()
    {
        progress = GetComponent<Image>();
    }

    private void Update()
    {
        if (source.clip.length > 0)
            progress.fillAmount = (float)source.time / (float)source.clip.length;
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var time = source.clip.length * pct;
        source.time = (long)time;
    }
}