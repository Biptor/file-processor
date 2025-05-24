// See https://aka.ms/new-console-template for more information
using System.Globalization;

var linesPersonFile = new List<string>(){
    "123,Biptor,82-04-05",
    "456,ChinoChino,80-03-31"
};

var linesAddressFile = new List<string>(){
    "calle123,Cali",
    "calle456,San Agustin"
};

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

            outputLines.Add(finalLine);
        }
    }

    return outputLines;
}