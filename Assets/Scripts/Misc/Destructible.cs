using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;
    public  Sprite memeImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
       if( other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
        {
            GetComponent<PickUpSpawner>().DropItems();
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

           // StartCoroutine(GetMemeAndDisplay());
        }

    }
  /*  private IEnumerator GetMemeAndDisplay()
    {
        string url = "https://memegen.link/api/image";
        string text = "Object bị phá hủy!";
        url += "?text=" + text;

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.LogError("Lỗi khi lấy meme: " + request.error);
                yield break;
            }

            string json = request.downloadHandler.text;
            MemeResponse response = JsonUtility.FromJson<MemeResponse>(json);

            using (UnityWebRequest imageRequest = UnityWebRequestTexture.GetTexture(response.imageUrl))
            {
                yield return imageRequest.SendWebRequest();

                if (imageRequest.isNetworkError || imageRequest.isHttpError)
                {
                    Debug.LogError("Lỗi khi tải xuống hình ảnh meme: " + imageRequest.error);
                    yield break;
                }

                Sprite memeSprite = Sprite.Create((imageRequest.downloadHandler as DownloadHandlerTexture), new Rect(0, 0, imageRequest..texture.width, imageRequest.downloadHandlerTexture.texture.height), new Vector2(0.5f, 0.5f));
                memeImage.sprite = memeSprite;
                memeImage.gameObject.SetActive(true);
            }
        }
    }
}

public class MemeResponse
{
    public string imageUrl { get; set; } */
}
