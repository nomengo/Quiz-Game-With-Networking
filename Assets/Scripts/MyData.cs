using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

[System.Serializable]
public class QuestionData
{
    public string Question;
    public string A;
    public string B;
    public string C;
    public string D;
    public int CevapId;
}

public class MyData : MonoBehaviour
{
    public static System.Action<QuestionData> questionData;
    public void GetDataJson()
    {
        StartCoroutine("GetText");
    }


    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/Unity/QuestionData.php");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            var json = JSON.Parse(www.downloadHandler.text);
            var data = new QuestionData();
            data.Question = json["Question"].Value;
            data.A = json["A"].Value;
            data.B = json["B"].Value;
            data.C = json["C"].Value;
            data.D = json["D"].Value;
            data.CevapId = json["Cevap_ID"].AsInt;

            questionData.Invoke(data);
        }
    }
}
