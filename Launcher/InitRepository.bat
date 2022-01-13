echo OFF

if exist GameSense2D\ rmdir "GameSense2D" /S /Q

rem -------------------------------------
rem Create RepoFolder
rem -------------------------------------
powershell write-host Creating Folder for GIT Repository...
echo.
mkdir "GameSense2D"
cd "GameSense2D"
if %ERRORLEVEL% GEQ 1 goto :ERROR


rem -------------------------------------
rem Initialize Folder as GIT Repository
rem -------------------------------------
powershell write-host Initializing Folder as GIT Repository...
echo.
git init
if %ERRORLEVEL% GEQ 1 goto :ERROR

rem -------------------------------------
rem Add remote at URL
rem -------------------------------------
powershell write-host Adding Git URL to Repository...
echo.
git remote add origin https://github.com/mingzss/GameSense-Editor.git
if %ERRORLEVEL% GEQ 1 goto :ERROR

goto :DONE

:ERROR
powershell write-host -fore Red INIT REPOSITORY - ERROR!!
if exist .git (
    rmdir ".git" /S /Q
)
exit -1

:DONE
powershell write-host -fore White INIT REPOSITORY - DONE!!
exit 0