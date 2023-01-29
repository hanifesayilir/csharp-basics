using UpSchool.Console.Domain;
using UpSchool.Console.Enums;
using UpSchool.Console.FirstExample;

/*Student student = new Student();

student.FirstName = "Alper";

student.LastName = "Tunga";

student.TCID = "33377788999111";

Console.WriteLine(student.FullName);

student.FullName = "Alper Tunga";

Teacher teacher = new Teacher();

teacher.FirstName = "Arman";

teacher.LastName = "Tunga";

Console.WriteLine(student.FullName);

var alper = "";
var colour = Colour.Blue;

if (colour == Colour.Red)
{
    Console.WriteLine("Red");
}

//Console.WriteLine(student.FinalNotes);

Console.WriteLine(student.FullName);

Console.ReadLine();*/

const string filePath = $@"C:\Users\hanif\OneDrive\Masaüstü\\Access_Control_Logs.txt";

var logsText = File.ReadAllText(filePath);


var splitLines = logsText.Split('\n',StringSplitOptions.RemoveEmptyEntries);

splitLines.ToList().ForEach(line => Console.WriteLine(line));

var logs = new List<AccessControlLog>();

foreach (var line in splitLines.Skip(1))
{
    var logFields = line.Replace(" ",string.Empty)
        .Replace("\r",string.Empty)
        .Split("---",StringSplitOptions.RemoveEmptyEntries);
    var accessControlLog = new AccessControlLog()
    {
        UserId = Convert.ToInt32(logFields[0]),
        DeviceSerialNo = logFields[1],
        AccessType = AccessControlLog.ConvertToAccessType(logFields[2]),
        Date = Convert.ToDateTime(logFields[3]),
    };
    logs.Add(accessControlLog);
}
var cardLogs = logs.Where(x => x.AccessType == AccessType.CARD)
    .Where(x => x.DeviceSerialNo == "X01X2500S")
    .ToList();

cardLogs.Count();

cardLogs.ForEach(log => Console.WriteLine($"{log.UserId} - {log.DeviceSerialNo} - {log.AccessType} - {log.Date}"));

Console.ReadLine();