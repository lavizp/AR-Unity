using System.Collections.Generic;

[System.Serializable]
public class LocationsDTO
{
    public string status;
    public LocationDTO[] result;

}

[System.Serializable]
public class LocationDTO
{
    public string location;
    public Heritage[] heritages;
}

[System.Serializable]
public class Heritage
{
    public string name;
    public string image;
    public string title;
    public string description;
    public string mapsLink;


}