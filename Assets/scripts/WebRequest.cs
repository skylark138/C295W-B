using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{
    private string apiUrl = "https://avwx.rest/api/station/LYBT?";
    private string apiToken = "gM9Dby02yNjeF-erj0RrNgbx0c3WveuwFbyD-vDE-QI";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetAirportData()
    {
        StartCoroutine(AirportData());
    }
    IEnumerator AirportData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + apiToken);
            yield return webRequest.SendWebRequest();
            if(webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: "+ webRequest.error);
            }
            else
            {
                Debug.Log("Success");
                string jsonData = webRequest.downloadHandler.text;
            }

        }
    }
}
