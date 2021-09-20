using System;
using System.IO;
using System.Text;

public class LocalStorageDataProvider
{
    private string _fullPath;
    public LocalStorageDataProvider(string fullPath)
    {
        _fullPath = fullPath;
    }

    public void WriteAllText(string content)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(_fullPath))
            {
                outputFile.Write(content);
            }
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogException(e);
        }
    }

    public string ReadAllText()
    {
        StringBuilder sb = new StringBuilder();

        try
        {
            using (StreamReader inputFile = new StreamReader(_fullPath))
            {
                string line;
                while ((line = inputFile.ReadLine()) != null)
                {
                    sb.Append(line);
                }
            }

        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogException(e);
            return string.Empty;
        }

        return sb.ToString();
    }
}
