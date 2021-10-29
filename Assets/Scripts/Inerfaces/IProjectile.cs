using UnityEngine;

namespace Assets.Scripts.Inerfaces
{
    public interface IProjectile
    {
        void ChangeColor(Color color);
        void SetParent(GameObject parent);
    }
}
