using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class Script : MonoBehaviour
{

    [SerializeField] private TextMeshPro texto;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando la solicitud HTTP...");
        string urlapi = "https://www.omdbapi.com/?t=glory&apikey=c12bd3cb";
        StartCoroutine(Get(urlapi));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Get(string url)
    {
        Debug.Log("Enviando la solicitud HTTP...");
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError("ERROR");
            }
            else
            {
                Debug.Log("Respuesta recibida: " + unityWebRequest.downloadHandler.text);
                texto.text = unityWebRequest.downloadHandler.text;
            }
        }
        Debug.Log("Solicitud HTTP completada.");
    }

    
    
}

