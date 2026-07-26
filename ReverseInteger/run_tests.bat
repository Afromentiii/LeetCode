@echo off
setlocal EnableDelayedExpansion

if not exist "Solution.cs" (
    echo Plik Solution.cs nie istnieje.
    exit /b 1
)
if not exist "SolutionWithString.cs" (
    echo Plik SolutionWithString.cs nie istnieje.
    exit /b 1
)
if not exist "payload.txt" (
    echo Plik payload.txt nie istnieje.
    exit /b 1
)

set CSC=
for /d %%D in ("%WINDIR%\Microsoft.NET\Framework64\v4.*") do (
    if exist "%%D\csc.exe" set CSC="%%D\csc.exe"
)
if not defined CSC (
    for /d %%D in ("%WINDIR%\Microsoft.NET\Framework\v4.*") do (
        if exist "%%D\csc.exe" set CSC="%%D\csc.exe"
    )
)

if not defined CSC (
    echo Nie znaleziono kompilatora csc.exe.
    exit /b 1
)

echo Kompilowanie kodow...
%CSC% /nologo /out:Solution.exe Solution.cs
%CSC% /nologo /out:SolutionWithString.exe SolutionWithString.cs
echo.

echo ==============================================
echo Testowanie Solution.exe (zbiorczo)
echo ==============================================
powershell -NoProfile -Command "$sw = [System.Diagnostics.Stopwatch]::StartNew(); .\Solution.exe payload.txt; $sw.Stop(); Write-Host 'Calkowity czas zewnetrzny (z uruchomieniem):' $sw.Elapsed.TotalMilliseconds 'ms'"
echo.

echo ==============================================
echo Testowanie SolutionWithString.exe (zbiorczo)
echo ==============================================
powershell -NoProfile -Command "$sw = [System.Diagnostics.Stopwatch]::StartNew(); .\SolutionWithString.exe payload.txt; $sw.Stop(); Write-Host 'Calkowity czas zewnetrzny (z uruchomieniem):' $sw.Elapsed.TotalMilliseconds 'ms'"
echo.
echo Gotowe!
pause
