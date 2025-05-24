// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System;
using System.IO;

var linesPersonFile = new List<string>(){
    "123,Biptor,82-04-05",
    "456,ChinoChino,80-03-31"
};

var linesAddressFile = new List<string>(){
    "calle123,Cali",
    "calle456,San Agustin"
};


linesPersonFile = ReadFile("Persons.txt").ToList();
linesAddressFile = ReadFile("Addresses.txt").ToList();

var merged = MergeFilesContent(linesPersonFile, linesAddressFile);

var finalContent = GenerateFileContent(merged);


IEnumerable<string> MergeFilesContent(List<string> linesPersonFile,
List<string> linesAddressFile) {
    var outputLines = new List<string>();

    for (var i = 0;  i < linesPersonFile.Count(); i++) {
        var newLine = string.Concat(linesPersonFile[i], ",", linesAddressFile[i]);

        outputLines.Add(newLine);
    }

    return outputLines;
}

IEnumerable<string> GenerateFileContent(IEnumerable<string> linesMerged) {
    var outputLines = new List<string>();

    foreach (var output in linesMerged) {

        var lineContent = output.Split(',');

        DateTime dateOfBirth;

        if (DateTime.TryParseExact(
            lineContent[2],
            "yy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out dateOfBirth)
            ) {

            lineContent[2] = dateOfBirth.ToString();

            var finalLine = string.Join('|', lineContent);
            Console.WriteLine(finalLine);
            outputLines.Add(finalLine);
        }
    }

    return outputLines;
}

IEnumerable<string> ReadFile(string path) {
    var lines = new List<string>();

    try
    {
        foreach (var line in File.ReadLines(path))
        {
            Console.WriteLine(line);
            lines.Add(line);
        }

        return lines;
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        throw;
    }
}