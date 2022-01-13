echo OFF

if not exist GameSense2D\ goto :ERROR

rem -------------------------------------
rem Set Directory
rem -------------------------------------
cd "GameSense2D"

rem -------------------------------------
rem Delete all local commits
rem -------------------------------------
powershell write-host Removing all local commits
echo.
git reset --hard
if %ERRORLEVEL% GEQ 1 goto :ERROR


rem -------------------------------------
rem Fetch entire remote from url
rem -------------------------------------
powershell write-host Fetching Remote Git Repository...
echo.
git fetch --all
if %ERRORLEVEL% GEQ 1 goto :ERROR

rem -------------------------------------
rem Retrieving editor from main branch
rem -------------------------------------
powershell write-host Retrieving Version Log File...
echo.
git checkout -f origin/main
if %ERRORLEVEL% GEQ 1 goto :ERROR

goto :DONE

:ERROR
powershell write-host -fore Red FETCH VERSION - ERROR!!
exit -1

:DONE
powershell write-host -fore White FETCH VERSION - DONE!!
exit 0