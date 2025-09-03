using UnityEngine;

namespace DefaultNamespace.UI.Base
{
    public interface IUIWindow
    {
    void Show();
    void Hide();
    void OpenAni();
    void CloseAni();
    }
    public class BaseWindow : MonoBehaviour,IUIWindow
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OpenAni()
        {
            
        }

        public void CloseAni()
        {
            
        }
    }

    
}