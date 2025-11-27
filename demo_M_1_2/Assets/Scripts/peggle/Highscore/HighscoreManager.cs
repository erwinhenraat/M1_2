using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class HighscoreManager : MonoBehaviour
{
    private const string GETSCOREURL = "https://hers.hosts1.ma-cloud.nl/gamehighscore/getHighscores.php";
    private const string ADDSCOREURL = "https://hers.hosts1.ma-cloud.nl/gamehighscore/addHighscore.php";
    public IEnumerator GetScores()
    {
        var request = new UnityWebRequest(GETSCOREURL, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
            string json = request.downloadHandler.text;
            string wrappedJson = "{\"items\":" + json + "}";
            HighscoreList scores = JsonUtility.FromJson<HighscoreList>(wrappedJson);
            Debug.Log(scores.items[0]);

        }
    }

    public IEnumerator AddScore(int score, string name)
    {
        string json = $"{{\"score\": {score}, \"name\": \"{name}\", \"source\": \"testenv\"}}";

        var request = new UnityWebRequest(ADDSCOREURL, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(AddScore((int)(Random.value * 2000), "Silvan"));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(GetScores());
        }
    }
}
