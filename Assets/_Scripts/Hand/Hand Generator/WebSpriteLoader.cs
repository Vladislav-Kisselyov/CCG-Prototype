namespace CCG.Hand.SpriteLoader
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.Networking;

    public class WebSpriteLoader : MonoBehaviour
    {
        [Header("URL Settings")]
        [SerializeField] private string _targetUrl = "https://api.lorem.space/image/movie?w=350&h=350";
        //[SerializeField] private string _targetUrl = "https://picsum.photos/350/350";

        [Header("On Download Completion")]
        [SerializeField] private UnityEvent _onDownloadCompletion;

        private List<Sprite> _downloadedSprites = new List<Sprite>();
        IEnumerator _downloadCoroutine;
        public void TryToRequestSprites(int numberOfSprites)
        {
            if (_downloadCoroutine != null)
            {
                StopCoroutine(_downloadCoroutine);
                _downloadCoroutine = null;
            }
            _downloadCoroutine = GetSpritesCoroutine(numberOfSprites);
            StartCoroutine(_downloadCoroutine);
        }
        IEnumerator GetSpritesCoroutine(int numberOfSprites)
        {
            Debug.Log(string.Format("Trying to async download {0} sprites from \"{1}\"", numberOfSprites, _targetUrl));
            DownloadedSprites.Clear();
            for (int i = 0; i < numberOfSprites; i++)
            {
                yield return GetOneSpriteCoroutine();
            }
            _onDownloadCompletion.Invoke();
        }
        IEnumerator GetOneSpriteCoroutine()
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(_targetUrl);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
                Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

                DownloadedSprites.Add(sprite);
            }
        }
        public void ClearDownloadedSprites()
        {
            DownloadedSprites.Clear();
        }
        public List<Sprite> DownloadedSprites { get => _downloadedSprites; private set => _downloadedSprites = value; }
    }
}
