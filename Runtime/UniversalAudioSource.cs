using UnityEngine;
using UnityEditor;

namespace Quartzified.Audio
{
    public class UniversalAudioSource : MonoBehaviour
    {
        public static UniversalAudioSource instance;

        [Header("Audio Layers")]
        public AudioLayer musicLayer = new AudioLayer();
        public AudioLayer effectLayer = new AudioLayer();

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);

            DontDestroyOnLoad(gameObject);
        }

#if UNITY_EDITOR
        [MenuItem("GameObject/Audio/Universal Audio Manager", false, 0)]
        static void CreateAudioManager(MenuCommand menuCommand)
        {
            GameObject go = new GameObject("Universal Audio Manager", typeof(UniversalAudioSource));

            CreateEffectChild(go);
            CreateMusicChild(go);
        }

        static void CreateEffectChild(GameObject parentObj)
        {
            GameObject effectChild = new GameObject("Effect Audio Source", typeof(AudioSource));
            GameObjectUtility.SetParentAndAlign(effectChild, parentObj);
            parentObj.GetComponent<UniversalAudioSource>().effectLayer.SetSource(effectChild.GetComponent<AudioSource>());
        }

        static void CreateMusicChild(GameObject parentObj)
        {
            GameObject musicChild = new GameObject("Music Audio Source", typeof(AudioSource));
            GameObjectUtility.SetParentAndAlign(musicChild, parentObj);
            parentObj.GetComponent<UniversalAudioSource>().musicLayer.SetSource(musicChild.GetComponent<AudioSource>());
        }
#endif
    }

}

