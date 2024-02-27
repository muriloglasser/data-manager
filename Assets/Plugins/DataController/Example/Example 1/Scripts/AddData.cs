using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Script to test adding data to the DataManager.
/// </summary>
public class AddData : MonoBehaviour
{
    public TMP_InputField idInputField;
    public TMP_InputField distanceInputField;
    public TMP_InputField nameInputField;
    public Button cacheDataButton;

    private void Start()
    {
        // Load GetData scene if it is not loaded.
        if (!SceneManager.GetSceneByName("GetData").isLoaded)
            SceneManager.LoadScene("GetData", LoadSceneMode.Additive);

        // Add listener to save button.
        cacheDataButton.onClick.AddListener(() =>
        {
            CheckDataToAdd();
        });
    }

    // Check for the key press to add data.
    private void CheckDataToAdd()
    {
        // Check if id is a number.
        if (!float.TryParse(idInputField.text, out float resultInt))
        {
            Debug.Log("ID is not an integer!");
            return;
        }

        // Check if distance is a number.
        if (!float.TryParse(distanceInputField.text, out float resultFloat))
        {
            Debug.Log("Distance is not an float!");
            return;
        }

        // Create an instance of DataManagerExampleStruct and add it to the DataManager.
        Add(new DataManagerExampleStruct
        {
            id = int.Parse(idInputField.text),
            distance = float.Parse(distanceInputField.text),
            name = nameInputField.text
        });
    }

    // Add data to the DataManager.
    private void Add(DataManagerExampleStruct data)
    {
        // Retrieve any existing data of the same type.
        DataManagerExampleStruct loadedData = DataManager.GetData<DataManagerExampleStruct>();

        // Check if data of the specified type already exists in the cache.
        if (!DataManager.DataExists<DataManagerExampleStruct>())
            Debug.Log("Data has not been created. \n Created new data cache.");
        else
            Debug.Log("Cached data already exists. \n Save data cache.");

        // Add the new data to the cache.
        DataManager.AddData<DataManagerExampleStruct>(data);

        // Display information about the saved data.
        Debug.Log("Saved data: \n" +
                  "ID: " + data.id +
                  ", Distance: " + data.distance +
                  ", Name: " + data.name);
    }
}

