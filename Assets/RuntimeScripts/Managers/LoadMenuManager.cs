using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMenuManager : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;

    [SerializeField] public Button button3;

    [SerializeField] public Button button4;

    [SerializeField] public Button button5;

    [SerializeField] public Button button6;

    [SerializeField] public Button trash1;
    [SerializeField] public Button trash2;

    [SerializeField] public Button trash3;

    [SerializeField] public Button trash4;

    [SerializeField] public Button trash5;

    [SerializeField] public Button trash6;

    [SerializeField] public Button fuckgoback;

    [SerializeField] public Image img1;
    [SerializeField] public Image img2;
    [SerializeField] public Image img3;
    [SerializeField] public Image img4;
    [SerializeField] public Image img5;
    [SerializeField] public Image img6;

    static string json;
    dynamic jsonObj;

    
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => ManageButtons(0));
        button2.onClick.AddListener(() => ManageButtons(1));
        button3.onClick.AddListener(() => ManageButtons(2));
        button4.onClick.AddListener(() => ManageButtons(3));
        button5.onClick.AddListener(() => ManageButtons(4));
        button6.onClick.AddListener(() => ManageButtons(5));
        trash1.onClick.AddListener(() => TrashButtons(0));
        trash2.onClick.AddListener(() => TrashButtons(1));
        trash3.onClick.AddListener(() => TrashButtons(2));
        trash4.onClick.AddListener(() => TrashButtons(3));
        trash5.onClick.AddListener(() => TrashButtons(4));
        trash6.onClick.AddListener(() => TrashButtons(5));
        fuckgoback.onClick.AddListener(() => GoToPreviousScene());
    }

    void Update(){
        json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "data.json"));
        jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        if(jsonObj["loaders"][0]["image"]!="" && img1.sprite == null){
            img1.sprite = LoadImages("image0.png");
        }
        if(jsonObj["loaders"][1]["image"]!="" && img2.sprite == null){
            img2.sprite = LoadImages("image1.png");
        }
        if(jsonObj["loaders"][2]["image"]!="" && img3.sprite == null){
            img3.sprite = LoadImages("image2.png");;
        }
        if(jsonObj["loaders"][3]["image"]!="" && img4.sprite == null){
            img4.sprite = LoadImages("image3.png");;
        }
        if(jsonObj["loaders"][4]["image"]!="" && img5.sprite == null){
            img5.sprite = LoadImages("image4.png");
        }
        if(jsonObj["loaders"][5]["image"]!="" && img6.sprite == null){
            img6.sprite = LoadImages("image5.png");
        }
    }

    // Update is called once per frame
    public void ManageButtons(int i){
        // string json = File.ReadAllText("Assets/RuntimeScripts/SaveLoadSystem/data.json");
        // dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        jsonObj["active"]= i;
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "data.json"), output);
        SceneManager.LoadScene(1);
    }

    public void TrashButtons(int i){
        string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "data.json"));
        dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        jsonObj["loaders"][i]["node"] = 0;
        jsonObj["loaders"][i]["image"] = "";
        jsonObj["loaders"][i]["kenScore"] = 0;
        jsonObj["loaders"][i]["allenScore"] = 0;
        if(i == 0){
            img1.sprite = null;
        }
        else if(i == 1){
            img2.sprite = null;
        }
        else if(i == 2){
            img3.sprite = null;
        }
        else if(i == 3){
            img4.sprite = null;
        }
        else if(i == 4){
            img5.sprite = null;
        }
        else if(i == 5){
            img6.sprite = null;
        }
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "data.json"), output);
    }

    public Sprite LoadImages(string img){
        var imgData6 = File.ReadAllBytes(Path.Combine(Application.streamingAssetsPath, img));
        Texture2D tex = new Texture2D(2, 2);
        Vector2 pivot = new Vector2(0.5f, 0.5f);
        tex.LoadImage(imgData6);
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), pivot, 100.0f);
        return sprite;
    }

    public void GoToPreviousScene(){
        SceneManager.LoadScene(PlayerPrefs.GetInt("Previous Scene"));
    }
}
