// See https://aka.ms/new-console-template for more information
using System.Globalization;
Console.WriteLine("Hello, World!");


var linesPersonFile = new List<string>(){
    "123,Biptor,82-04-05",
    "456,ChinoChino,80-03-31"
};

var linesAddressFile = new List<string>(){
    "calle123,Cali",
    "calle456,San Agustin"
};

var outputLines = new List<string>();

for (var i = 0;  i < linesPersonFile.Count(); i++) {
    var newLine = string.Concat(linesPersonFile[i], ",", linesAddressFile[i]);

    outputLines.Add(newLine);
}

foreach (var output in outputLines) {
    Console.WriteLine(output);

    var lineContent = output.Split(',');

    Console.WriteLine(lineContent);

    DateTime fecha;
    bool exito = DateTime.TryParseExact(
    lineContent[2],
    "yy-MM-dd",
    CultureInfo.InvariantCulture,
    DateTimeStyles.None,
    out fecha);

    Console.WriteLine(fecha.ToString());

    foreach (var content in lineContent){
        var tmp = string.Concat(content, "|");
    }
}

