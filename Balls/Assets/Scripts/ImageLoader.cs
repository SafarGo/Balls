using UnityEngine;
using System.IO;
using SFB;
using System.Collections; // StandaloneFileBrowser

public class ImageLoader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;
    public SpriteRenderer spriteRenderer3;
    public SpriteRenderer spriteRenderer4;
    public GameObject but1;
    public GameObject but2;
    public bool isStarted = false;
    public static ImageLoader instance;

    private void Awake()
    {
        instance = this;
    }
    public void LoadImageForSprite1()
    {
        OpenFileAndSetSprite(spriteRenderer1);
    }

    public void LoadImageForSprite2()
    {
        OpenFileAndSetSprite(spriteRenderer2);
    }

    public void LoadImageForSprite3()
    {
        OpenFileAndSetSprite(spriteRenderer3);
    }

    public void LoadImageForSprite4()
    {
        OpenFileAndSetSprite(spriteRenderer4);
    }

    private void OpenFileAndSetSprite(SpriteRenderer targetRenderer)
    {
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
        };
        StandaloneFileBrowser.OpenFilePanelAsync("Open Image", "", extensions, false, (string[] paths) =>
        {
            if (paths.Length > 0 && File.Exists(paths[0]))
            {
                StartCoroutine(LoadSprite(paths[0], targetRenderer));
            }
        });
    }

    private System.Collections.IEnumerator LoadSprite(string path, SpriteRenderer targetRenderer)
    {
        var url = "file:///" + path.Replace("\\", "/");
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                Texture2D loadedTexture = www.texture;

                // Создаём спрайт из всей текстуры
                Sprite sprite = Sprite.Create(
                    loadedTexture,
                    new Rect(0, 0, loadedTexture.width, loadedTexture.height),
                    new Vector2(0.5f, 0.5f)
                );
                targetRenderer.sprite = sprite;
            }
            else
            {
                Debug.LogError("Ошибка загрузки: " + www.error);
            }
        }
    }

}