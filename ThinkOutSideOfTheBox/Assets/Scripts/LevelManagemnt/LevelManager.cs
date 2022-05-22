using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour, IDataPersistance
{
    public static LevelManager Instance;

    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Slider progressBar;
    private float target;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public async void LoadScene(string SceneName)
    {
        target = 0;
        progressBar.value = 0f;
        var scene = SceneManager.LoadSceneAsync(SceneName);
        scene.allowSceneActivation = false;
        
        loaderCanvas.SetActive(true);

        do
        {
            await System.Threading.Tasks.Task.Delay(100);
            target = scene.progress;
        } while (scene.progress < 0.9f);
        
        await System.Threading.Tasks.Task.Delay(1000);
        scene.allowSceneActivation = true;
       
        loaderCanvas.SetActive(false);
        Time.timeScale = 1f;
       

    }

    private void Update()
    {
        progressBar.value = Mathf.MoveTowards(progressBar.value, target, 3 * Time.deltaTime);
    }

    public void LoadData(GameData data)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadScene(data.CurrentSceneName);

        }
    }

    public void SaveData(ref GameData data)
    {
        data.CurrentSceneName = SceneManager.GetActiveScene().name;
    }
}
