
using UnityEngine;

namespace TK.Ch02
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ConUI : MonoBehaviour
    {
        CanvasGroup m_CanvasGroup;

        protected virtual void Awake()
        {
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }

        public void SetActivePanel(bool active)
        {
            if(active == true)
            {
                m_CanvasGroup.alpha = 1f;
                m_CanvasGroup.interactable = true;
                m_CanvasGroup.blocksRaycasts = true;
            }
            else
            {
                m_CanvasGroup.alpha = 0f;
                m_CanvasGroup.interactable = false;
                m_CanvasGroup.blocksRaycasts = false;
            }
        }
    }
}
