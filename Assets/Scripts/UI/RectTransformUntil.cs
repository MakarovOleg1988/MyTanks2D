using UnityEngine;

namespace MyTanks2D
{
    public static class RectTransformUntil
    {
        public static void SetLeftOffset(this RectTransform rt, float offset)
        {
            rt.offsetMin = new Vector2(offset, rt.offsetMin.y);
        }

        public static void setRighttOffset(this RectTransform rt, float offset)
        {
            rt.offsetMax = new Vector2(-offset, rt.offsetMax.y);
        }

        public static void setTopOffset(this RectTransform rt, float offset)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, offset);
        }

        public static void setBottomOffset(this RectTransform rt, float offset)
        {
            rt.offsetMax = new Vector2(rt.offsetMax.x, -offset);
        }
    }
}
