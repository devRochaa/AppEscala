@echo off
setlocal

set "SOURCE=%~dp0AppEscala"
set "TARGET=%LOCALAPPDATA%\Programs\App Escala"
set "DESKTOP=%USERPROFILE%\Desktop\App Escala.lnk"
set "STARTMENU=%APPDATA%\Microsoft\Windows\Start Menu\Programs\App Escala.lnk"

if not exist "%SOURCE%\AppEscala.exe" (
  echo Nao foi encontrada a pasta AppEscala ao lado deste instalador.
  echo Mantenha o arquivo Instalar_App_Escala.cmd junto da pasta AppEscala.
  pause
  exit /b 1
)

echo Instalando App Escala...

if not exist "%LOCALAPPDATA%\Programs" mkdir "%LOCALAPPDATA%\Programs"
if exist "%TARGET%" rmdir /s /q "%TARGET%"
mkdir "%TARGET%"
xcopy "%SOURCE%\*" "%TARGET%\" /E /I /Y >nul

powershell -NoProfile -ExecutionPolicy Bypass -Command ^
  "$shell = New-Object -ComObject WScript.Shell; " ^
  "$desktop = $shell.CreateShortcut('%DESKTOP%'); " ^
  "$desktop.TargetPath = '%TARGET%\AppEscala.exe'; " ^
  "$desktop.WorkingDirectory = '%TARGET%'; " ^
  "$desktop.IconLocation = '%TARGET%\AppEscala.exe,0'; " ^
  "$desktop.Save(); " ^
  "$start = $shell.CreateShortcut('%STARTMENU%'); " ^
  "$start.TargetPath = '%TARGET%\AppEscala.exe'; " ^
  "$start.WorkingDirectory = '%TARGET%'; " ^
  "$start.IconLocation = '%TARGET%\AppEscala.exe,0'; " ^
  "$start.Save();"

echo.
echo Instalacao concluida.
echo Abra pelo atalho "App Escala" na Area de Trabalho ou no Menu Iniciar.
pause
