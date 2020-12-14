param ($projectName)
$dayNumber = $projectName.SubString($projectName.Length -2, 2)
$puzzleClass =
@"
namespace AOC2020.$projectName
{
    using System.Collections.Generic;
    using AOC2020.Utilities;
    using Microsoft.Extensions.Logging;

    public class Puzzle : IPuzzle
    {
        private readonly ILogger _logger;

        private List<string> _input = null;

        public Puzzle(ILogger<Puzzle> logger)
        {
            _logger = logger;
        }

        public string Day => "$dayNumber";

        public List<string> Input => _input;

        public string Part1
        {
            get
            {
                string answer = string.Empty;
                _logger.LogInformation("{Day}/Part1: Found {answer}", Day, answer);
                return answer;
            }
        }

        public string Part2
        {
            get
            {
                string answer = string.Empty;
                _logger.LogInformation("{Day}/Part2: Found {answer}", Day, answer);
                return answer;
            }
        }

        public void ProcessPuzzleInput(List<string> input)
        {
            _input = input;
        }
    }
}
"@

dotnet new classlib --name $projectName
dotnet sln add $projectName\$projectName.csproj
dotnet add Driver\Driver.csproj reference $projectName\$projectName.csproj
dotnet add $projectName\$projectName.csproj package Microsoft.Extensions.Logging.Abstractions
dotnet add $projectName\$projectName.csproj package StyleCop.Analyzers
dotnet add $projectName\$projectName.csproj reference Utilities\Utilities.csproj

Remove-Item -Path "$projectName\Class1.cs"
$puzzleClass | Set-Content -Encoding UTF8 -Path "$projectName\Puzzle.cs"
Write-Output "inputData" | Set-Content -Encoding UTF8 -Path $("Utilities\Resources\$projectName" + "_PuzzleInput.txt")

$xml=New-Object XML
$xml.Load(".\$projectName\$projectName.csproj")
$rootNameSpaceNode = $xml.CreateElement("RootNamespace")
$xml.Project.PropertyGroup.AppendChild($rootNameSpaceNode)
$xml.Project.PropertyGroup.RootNameSpace = "AOC2020.$projectName"
$xml.Save(".\$projectName\$projectName.csproj")