echo OFF

if not exist GameSense2D\ goto :ERROR

rem -------------------------------------
rem Try Replacing Launcher
rem -------------------------------------
powershell write-host Trying to Replace Launcher
echo.
:REPLACELAUNCHER
timeout /t 1 > NUL
copy "GameSense2D\Launcher\Launcher.exe" "Launcher.exe" /Y
if %ERRORLEVEL% GEQ 1 goto :REPLACELAUNCHER

rem -------------------------------------
rem Update Launcher Version
rem -------------------------------------
powershell write-host Updating Launcher Version
echo.
copy "GameSense2D\Launcher\LauncherVersion.log" "LauncherVersion.log" /Y
if %ERRORLEVEL% GEQ 1 goto :ERROR

rem -------------------------------------
rem Deleting Launcher Folder
rem -------------------------------------
powershell write-host Deleting Launcher Folder
echo.
rmdir "GameSense2D\Launcher" /S /Q
if %ERRORLEVEL% GEQ 1 goto :ERROR

rem -------------------------------------
rem Restarting Launcher...
rem -------------------------------------
powershell write-host Restarting Launcher...
echo.
Launcher.exe

goto :DONE

:ERROR
powershell write-host -fore Red UPDATE LAUNCHER - ERROR!!
exit -1

:DONE
powershell write-host -fore White UPDATE LAUNCHER - DONE!!
exit 0