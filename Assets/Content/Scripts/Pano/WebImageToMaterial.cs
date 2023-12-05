using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WebImageToMaterial : MonoBehaviour
{
    public string imageUrl = "http://example.com/image.png"; // URL of the image
    public Texture2D localImage; // Drag and drop the local image here
    public bool useLocalImage = false; // Flag to choose between local or web image
    public Renderer targetRenderer; // The renderer of the GameObject

    void Start()
    {
        
    }

    public void LoadPano()
    {
        if (useLocalImage)
        {
            LoadLocalTexture();
        }
        else
        {
            StartCoroutine(LoadTextureFromWeb());
        }
    }

    IEnumerator LoadTextureFromWeb()
    {
        if (string.IsNullOrEmpty(imageUrl))
        {
            Debug.LogError("Image URL is not set.");
            yield break;
        }

        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer is not assigned.");
            yield break;
        }

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageUrl))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error while downloading the image: " + uwr.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                targetRenderer.material.SetTexture("_BaseMap", texture);
            }
        }
    }

    void LoadLocalTexture()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer is not assigned.");
            return;
        }

        if (localImage == null)
        {
            Debug.LogError("Local image is not assigned.");
            return;
        }

        targetRenderer.material.SetTexture("_BaseMap", localImage);
    }
}
