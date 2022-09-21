using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class WebSpriteLoader : MonoBehaviour
{
    [Header("URL Settings")]
    public string _BasicUrl = "https://picsum.photos/";
    public int _SpriteWidth = 200;
    public int _SpriteHeight = 350;

    [Header("On Download Completion")]
    public UnityEvent OnDownloadCompletion;

    private List<Sprite> _DownloadedSprites = new List<Sprite>();
    IEnumerator _DownloadCoroutine;
    public void TryToRequestSprites(int numberOfSprites)
    {
        if (_DownloadCoroutine != null) {
            StopCoroutine(_DownloadCoroutine);
            _DownloadCoroutine = null;
        }
        _DownloadCoroutine = GetSpritesCoroutine(numberOfSprites);
        StartCoroutine(_DownloadCoroutine);
    }
    IEnumerator GetSpritesCoroutine(int numberOfSprites)
    {
        Debug.Log(string.Format("Trying to async download {0} sprites from \"{1}\"", numberOfSprites, TargetURL));
        _DownloadedSprites.Clear();
        for (int i = 0; i < numberOfSprites; i++)
        {
            yield return GetOneSpriteCoroutine();
        }
        OnDownloadCompletion.Invoke();
    }
    IEnumerator GetOneSpriteCoroutine()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(TargetURL);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Debug.Log(texture.GetRawTextureData().Length + " bytes recieved");
            Rect rect = new Rect(0.0f, 0.0f, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
            
            _DownloadedSprites.Add(sprite);
        }
    }
    public void ClearDownloadedSprites()
    {
        _DownloadedSprites.Clear();
    }
    private string TargetURL{ get => string.Format("{0}{1}/{2}", _BasicUrl, _SpriteWidth, _SpriteHeight); }
    public List<Sprite> DownloadedSprites { get => _DownloadedSprites; set => _DownloadedSprites = value; }
}
