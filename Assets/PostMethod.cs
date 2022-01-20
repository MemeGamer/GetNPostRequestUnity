using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class PostMethod : MonoBehaviour
{
    [SerializeField] Text uiHealthText ;
    void Start()
    {
        //GameObject.Find("PostButton").GetComponent<Button>().
        PostData();
    }
 
    void PostData() => StartCoroutine(PostData_Coroutine());
 
    IEnumerator PostData_Coroutine()
    {
        uiHealthText.text = "Loading...";
        string uri = "https://my-json-server.typicode.com/MemeGamer/MockData/UnityData";
        WWWForm form = new WWWForm();
        form.AddField("Health", "110");
        using(UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error");
            }
            else
            {
                Data data = JsonUtility.FromJson<Data> (request.downloadHandler.text) ;
                uiHealthText.text = "Health: "+data.Health ;
            }
        }
    }
}
