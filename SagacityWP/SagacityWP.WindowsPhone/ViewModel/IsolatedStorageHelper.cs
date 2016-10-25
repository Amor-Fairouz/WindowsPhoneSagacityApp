using System.IO;
//using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using System.Text;
public static class IsolatedStorageHelper 
{

    // silver light WP 7.0 , 7.5 , 8
    // winRT c# 5, 6.0 ; WP >8

    public static T GetObject<T>(string key)
    {
         var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;    
        if (localSettings.Values.ContainsKey(key))
        {
            string serializedObject = localSettings.Values[key].ToString();
            return Deserialize<T>(serializedObject);
        }
        return default(T);
    }



    public static void SaveObject<T>(string key, T objectToSave)
    {
        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        string serializedObject = Serialize(objectToSave);
        localSettings.Values[key] = serializedObject;
    }



    public static void DeleteObject(string key)
    {
        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        localSettings.Values.Remove(key);
    }



    private static string Serialize(object objectToSerialize) // convertir en binaire
    {
        using (MemoryStream ms = new MemoryStream())
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(objectToSerialize.GetType());
            serializer.WriteObject(ms, objectToSerialize);
            ms.Position = 0;

            using (StreamReader reader = new StreamReader(ms))
            {
                return reader.ReadToEnd();
            }
        }
    }


    private static T Deserialize<T>(string jsonString) // convertir de binaire vers objet (un ou plusieurs)
    {
        using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonString)))
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(ms);
        }
    }
}

// IsolatedStorage: - notions des clés limité ; + taux de réponse assez vite(ms)
// SQLite : 
// Channel 9 : chaines pr microsoft (documentation officiel)

// SQLitePCL // Portable Class Library : 
//SQLite.Net 
// WPF ; design pattern : model View 

// CONTROLS : one page xaml with components
 
/*
Flders :
 - Views : xaml's
 - Model : classe (.cs) 
 - ViewModel : Helper ; SharedInformation .... (utiles) ; parsing ; SQLiteHelper (PCL ); 
*/

/*
Mécanisme :

    - Binding 
    - Converter
    - 
*/
