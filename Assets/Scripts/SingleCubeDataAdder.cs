using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;
using Input = UnityEngine.Windows.Input;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class SingleCubeDataAdder : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image plane;

    private Heritage thisHeritage = new Heritage();

    public async void InitialiseCube(Heritage thisHeritageData)
    {
        thisHeritage = thisHeritageData;
        title.text = thisHeritage.name;
        text.text = thisHeritage.title;
        Sprite mat = await GetRemoteTexture(thisHeritage.image);
        plane.GetComponent<Image>().sprite = mat;
        
        
    }
    private async Task<Sprite> GetRemoteTexture(string url)
    {
        using var www = UnityWebRequestTexture.GetTexture(url);
        // begin request:
        var asyncOp = www.SendWebRequest();

        while (asyncOp.isDone == false)
            await Task.Delay(1000 / 30);//30 hertz

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            // log error:
#if DEBUG
            Debug.Log($"{www.error}, URL:{www.url}");
#endif

            // nothing to return on error:
            return null;
        }

        var image = DownloadHandlerTexture.GetContent(www);
        return Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(image.width / 2, image.height / 2));
    }

    public void DisplaySingle()
    {
        GameManager.Instance.DisplaySingle(thisHeritage);
    }


}
