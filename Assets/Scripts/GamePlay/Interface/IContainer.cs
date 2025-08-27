using UnityEngine;

namespace DefaultNamespace
{
    public interface IContainer
    {
        public Transform GetContiner();
        public void SetParentWithContiner(Transform child);
    }
}