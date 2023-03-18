using UnityEngine;

namespace Gameplay
{
    public class AntiBomb : MonoBehaviour
    {
        [SerializeField] private MyBomb bomb;

        private void Start()
        {
            bomb.OnExplosionScream += LogStringExplosion;
        }

        private void OnDestroy()
        {
            bomb.OnExplosionScream -= LogStringExplosion;
        }

        private void LogStringExplosion(string str)
        {
            Debug.Log(str);
        }


        public void LogExplosion()
        {
            Debug.Log("the bomb explode");
        }
    }
}