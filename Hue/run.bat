@echo off
title Cargando juego...

echo Iniciando...

:: 1. Compila el proyecto en segundo plano primero (opcional pero recomendado)
dotnet build -c Release > nul 2>&1

:: 2. Crea un script ejecutor invisible temporal
echo Set WshShell = CreateObject("WScript.Shell") > launch_hidden.vbs
echo WshShell.Run "dotnet run -c Release --no-build", 0, False >> launch_hidden.vbs

:: 3. Ejecuta el script invisible
cscript //nologo launch_hidden.vbs

:: 4. Elimina el script temporal y cierra la terminal actual
del launch_hidden.vbs
exit