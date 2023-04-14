using System;
using UnityEngine;


namespace MyTanks2D
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _storedScreenSaveArea;
        private int _storedScreenWidth;
        private int _storedScreenHeight;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (Screen.width != _storedScreenWidth || Screen.height != _storedScreenHeight || Screen.safeArea != _storedScreenSaveArea)
            {
                UpdateSaveArea();
            }
        }

        private void UpdateSaveArea()
        {
            Rect safeArea = Screen.safeArea;
            float offsetLeft = safeArea.x;
            float offsetRight = Screen.width - safeArea.width - offsetLeft;
            float offsetTop = safeArea.y;
            float offsetBottom = Screen.height - safeArea.height - offsetTop;

            _rectTransform.SetLeftOffset(offsetLeft);
            _rectTransform.setRighttOffset(offsetRight);
            _rectTransform.setTopOffset(offsetTop);
            _rectTransform.setBottomOffset(offsetBottom);

            _storedScreenWidth = Screen.width;
            _storedScreenHeight = Screen.height;
            _storedScreenSaveArea = Screen.safeArea;
        }
    }
}
