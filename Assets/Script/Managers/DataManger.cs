using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Category
{

}

public enum AvatarType
{

}

[System.Serializable]
public struct Item
{
    public string name, description;
    public Category category;
    public int timestamp;
    public int price;
    public string filepath;

};

[System.Serializable]
public struct ItemStandData
{
   public Vector3 location;
    public string sellerUsername;
    public List<Item> items;
};

[System.Serializable]
public struct UserData
{
    public string username;
    public int AvatarType;
    public string Gu;
    public string Dong;
};

[System.Serializable]
public static class DataManager
{
    static public UserData userdata = new UserData();
    static public List<ItemStandData> itemstands =  new List<ItemStandData>();

    public static void Awake()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Data/ItemStandList/standlist.json");
        itemstands  = JsonUtility.FromJson<List<ItemStandData>>(textAsset.text);
    }

}
