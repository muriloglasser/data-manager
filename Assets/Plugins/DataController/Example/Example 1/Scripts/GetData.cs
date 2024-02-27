using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script to test retrieving data from the DataManager.
/// </summary>
public class GetData : MonoBehaviour
{
    private DataManagerExampleStruct data;
    public Button loadCacheDataButton;

    private void Start()
    {
        // Load GetData scene if it is not loaded.
        if (!SceneManager.GetSceneByName("AddData").isLoaded)
            SceneManager.LoadScene("AddData", LoadSceneMode.Additive);


        // Add listener to load button.
        loadCacheDataButton.onClick.AddListener(() =>
        {
            CheckDataToGet();
        });
    }

    /// <summary>
    /// Check for the key press to get data.
    /// </summary>
    private void CheckDataToGet()
    {
        // Retrieve and display the data.
        Get();
    }

    /// <summary>
    /// Retrieve data from the DataManager.
    /// </summary>
    private void Get()
    {
        // Retrieve data of the specified type from the DataManager.
        data = DataManager.GetData<DataManagerExampleStruct>();

        // Check if data of the specified type exists in the cache.
        if (!DataManager.DataExists<DataManagerExampleStruct>())
            Debug.Log("Data has not been created!");
        else
        {
            // Display information about the loaded data.
            Debug.Log("Cached Data Loaded!");
            Debug.Log("Loaded data: \n" +
                      "ID: " + data.id +
                      ", Distance: " + data.distance +
                      ", Name: " + data.name);
        }
    }
}
