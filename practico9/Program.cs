﻿using System;
using System.IO;
using System.Net;
using System.Text.Json;
using EspacioMoneda;

 
 
  Cambio moneda = GetMoneda();

    Console.WriteLine("----------- Precios Disponibles -----------");
    Console.WriteLine($"USD: ${moneda.bpi.USD.rate_float:F2}");
    Console.WriteLine($"EUR: ${moneda.bpi.EUR.rate_float:F2}");
    Console.WriteLine($"GBP: ${moneda.bpi.GBP.rate_float:F2}");
    Console.WriteLine("");
    
 Console.WriteLine("Si desea conocer mas sobre la moneda ingrese el codigo:(USD),(EUR),(GBP)");
 string seleccion = Console.ReadLine();
 switch (seleccion)
 {
    case "USD":
    Console.WriteLine($"Codigo: {moneda.bpi.USD.code}");
    Console.WriteLine($"Descripcion: {moneda.bpi.USD.description}");
    Console.WriteLine($"Simbolo: {moneda.bpi.USD.symbol}");
    break;
    case "EUR":
    Console.WriteLine($"Codigo: {moneda.bpi.EUR.code}");
    Console.WriteLine($"Descripcion: {moneda.bpi.EUR.description}");
    Console.WriteLine($"Simbolo: {moneda.bpi.EUR.symbol}");
    break;
    case "GBP":
    Console.WriteLine($"Codigo: {moneda.bpi.GBP.code}");
    Console.WriteLine($"Descripcion: {moneda.bpi.GBP.description}");
    Console.WriteLine($"Simbolo: {moneda.bpi.GBP.symbol}");
    break;


    default:
    Console.WriteLine("Moneda no encontrada, ingrese un codigo valido");
    break;
 } 
 
 
 static Cambio GetMoneda()
    {
        var url = "https://api.coindesk.com/v1/bpi/currentprice.json";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";

        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    return JsonSerializer.Deserialize<Cambio>(responseBody);
                }
            }
        }
    }
