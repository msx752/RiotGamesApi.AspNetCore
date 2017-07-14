
clear
$firstCommit = $(git log --pretty=format:'%H' -n -1).Length;
$firstCommitHash = $(git log --pretty=format:'%H' -n -1)[$firstCommit-1];
Write-Host "First Commit Hash:" $firstCommitHash;
$firstCommitDate = (git show -s --format=%ci $firstCommitHash);
Write-Host "First Commit Date:" $firstCommitDate;
[datetime]$FCDateTime = $firstCommitDate;
#Write-Host $FCDateTime
$FCyear = $FCDateTime.ToString("y.").TrimEnd('.');
#Write-Host $FCyear
$timeZone0 = [TimeZoneInfo]::ConvertTimeBySystemTimeZoneId([DateTime]::UtcNow, "Turkey Standard Time");
$timeZone = $timeZone0;
[datetime]$DateTime = $timeZone;

$year = $DateTime.ToString("y.").TrimEnd('.');
$month = $DateTime.ToString("M.").TrimEnd('.');
$day = $DateTime.ToString("d.").TrimEnd('.');
$hourMinute = $DateTime.ToString(".hmm").TrimStart('.');
$buildYear = (($year - $FCyear) + 1);
#$buildTime = $DateTime.ToString("M.d.hmm");
$newBuildNumber = "$buildYear.$month.$day.$hourMinute";

Write-Host "New Nuget Package Version:" $newBuildNumber

dotnet clean -c Release
dotnet build -c Release  /p:Version=$newBuildNumber --framework netcoreapp1.1
.\nuget pack -version $newBuildNumber
