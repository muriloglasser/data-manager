# DataManager Class

`DataManager` is a utility class for managing and caching structured data of various types in Unity. It provides methods to store, retrieve, and remove data items, as well as to check the existence of data of a specific type.

## Table of Contents

- [Usage](#usage)
- [Example](#example)

## Usage

### Adding Data
Adds an item of type T to the data cache. If data of the same type already exists, it is first removed.
```csharp
// Add an item to the data cache
DataManager.AddData<T>(data);
```

### Retrieving Data
Retrieves cached data of the specified type T. Returns default value if no data is found.
```csharp
// Retrieve cached data of type T
T data = DataManager.GetData<T>();
```

### Removing Data
Removes cached data of the specified type T.
```csharp
// Remove cached data of type T
DataManager.RemoveData<T>();
```

### Checking Data Existence
Returns true if data of the specified type T exists in the cache; otherwise, returns false.
```csharp
// Check if data of type T exists in the cache
bool exists = DataManager.DataExists<T>();
```

## Example

Note: This example is available in the Example1 scene. Be sure to check out that scene to see the code in action.

### Struct
```csharp
// Example struct to represent data
public struct DataManagerExampleStruct
{
    public int id;
    public float distance;
    public string name;
}

```

### Adding
```csharp
// Add data to the DataManager
private void Add(DataManagerExampleStruct data)
{
    // Retrieve any existing data of the same type
    DataManagerExampleStruct loadedData = DataManager.GetData<DataManagerExampleStruct>();

    // Check if data of the specified type already exists in the cache
    if (!DataManager.DataExists<DataManagerExampleStruct>())
        Debug.Log("Data has not been created. \n Created new data cache.");
    else
        Debug.Log("Cached data already exists. \n Save data cache.");

    // Add the new data to the cache
    DataManager.AddData<DataManagerExampleStruct>(data);

    // Display information about the saved data
    Debug.Log("Saved data: \n" +
              "ID: " + data.id +
              ", Distance: " + data.distance +
              ", Name: " + data.name);
}
```

### Retrieving
```csharp
// Retrieve data from the DataManager
private void Get()
{
    // Retrieve data of the specified type from the DataManager
    data = DataManager.GetData<DataManagerExampleStruct>();

    // Check if data of the specified type exists in the cache
    if (!DataManager.DataExists<DataManagerExampleStruct>())
        Debug.Log("Data has not been created!");
    else
    {
        // Display information about the loaded data
        Debug.Log("Cached Data Loaded!");
        Debug.Log("Loaded data: \n" +
                  "ID: " + data.id +
                  ", Distance: " + data.distance +
                  ", Name: " + data.name);
    }
}
```

# Thank You

I sincerely appreciate you taking the time to explore this project. I hope you enjoyed the experience and found valuable information. If you have any questions or suggestions, feel free to share them.



