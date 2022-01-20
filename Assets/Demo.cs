using UnityEngine ;
using UnityEngine.Networking ;
using UnityEngine.UI ;
using System.Collections ;

// Json data format
/*
      {
        "Name"     : "..." ,
        "Health"     : "..." ,
        "Personality"     : "..." ,
        "Charm"     : "..." ,
        "Behavior"     : "..." ,
        "managment"     : "..." ,
        "ImageURL" : "..."
      }
*/
public struct Data {
   public string Name ;
   public string Health ;
   public string Personality;
   public string Charm;
   public string Behavior ;
   public string managment;
   public string ImageURL ;
}

public class Demo : MonoBehaviour {
   [SerializeField] Text uiNameText ;
   [SerializeField] Text uiHealthText ;
   [SerializeField] Text uiPersonalityText ;
   [SerializeField] Text uiCharmText ;
   [SerializeField] Text uiBehaviorText ;
   [SerializeField] Text uimanagmentText ;
   [SerializeField] RawImage uiRawImage ;

   string jsonURL = "https://my-json-server.typicode.com/MemeGamer/MockData/UnityData" ;

   void Start () {
      StartCoroutine (GetData (jsonURL)) ;
   }

   IEnumerator GetData (string url) {
      UnityWebRequest request = UnityWebRequest.Get (url) ;

      yield return request.SendWebRequest() ;

      if (request.isNetworkError || request.isHttpError) {
         // error ...

      } else {
         // success...
         Data data = JsonUtility.FromJson<Data> (request.downloadHandler.text) ;

         // print data in UI
         uiNameText.text = "Name: "+data.Name ;
         uiHealthText.text = "Health: "+data.Health ;
         uiPersonalityText.text = "Personality: "+data.Personality ;
         uiCharmText.text = "Charm"+data.Charm ;
         uiBehaviorText.text = "Behavior"+data.Behavior ;
         uimanagmentText.text = "Managment"+data.managment ;
         // Load image:
         StartCoroutine (GetImage (data.ImageURL)) ;
      }
      
      // Clean up any resources it is using.
      request.Dispose () ;
   }

   IEnumerator GetImage (string url) {
      UnityWebRequest request = UnityWebRequestTexture.GetTexture (url) ;

      yield return request.SendWebRequest() ;

      if (request.isNetworkError || request.isHttpError) {
         // error ...

      } else {
         //success...
         uiRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture ;
      }

      // Clean up any resources it is using.
      request.Dispose () ;
   }

}
