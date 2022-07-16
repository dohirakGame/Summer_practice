using System.Security.Cryptography;
using UnityEngine;

[RequireComponent( typeof( BoxCollider ) )]
public class Initialization : MonoBehaviour
{
    [SerializeField] private GameObject WeatherRain;

    private GameObject _weather;
    private Vector3 _transformWeather;

    public void InitializationWeather()
    {
            //_weather = Instantiate(WeatherRain) as GameObject;
            //_weather.transform.position = new Vector3(0, 15, 1);
            if (GameObject.FindGameObjectWithTag("Weather") == null)
            {
                Instantiate(WeatherRain, transform.position = new Vector3(0,15,1), Quaternion.identity);
            }
    }

    public void DestroyWeather()
    {
            Destroy(GameObject.FindGameObjectWithTag("Weather"));
    }
}
