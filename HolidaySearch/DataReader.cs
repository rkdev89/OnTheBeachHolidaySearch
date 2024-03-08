﻿using Newtonsoft.Json;
using System.Reflection;

namespace HolidaySearch;
public class DataReader
{
    private readonly string _flightsFilePath;
    private readonly string _hotelsFilePath;

    public DataReader()
    {
        var assemblyDirectory = GetFileDirectoryInfo();
        _flightsFilePath = Path.Combine(assemblyDirectory, "Data", "Flights.json");
        _hotelsFilePath = Path.Combine(assemblyDirectory, "Data", "Hotels.json");
    }

    public List<Flight> ReadFlightData()
    {
        return ReadJsonFile<List<Flight>>(_flightsFilePath);
    }

    public List<Hotel> ReadHotelData()
    {
        return ReadJsonFile<List<Hotel>>(_hotelsFilePath);
    }

    private static T ReadJsonFile<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }

    private static string GetFileDirectoryInfo()
    {
        var directory = Assembly.GetExecutingAssembly().Location;
        return Path.GetDirectoryName(directory);
    }
}
