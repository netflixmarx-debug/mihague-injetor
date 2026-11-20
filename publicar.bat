@echo off
cd /d "E:\INJETOR DLL\INJETOR MIHAGUE"

echo.
echo [1/4] Adicionando arquivos...
git add -A

echo.
echo [2/4] Commitando...
set /p msg="Mensagem do commit: "
git commit -m "%msg%"

echo.
echo [3/4] Sincronizando com o GitHub...
git pull --rebase

echo.
echo [4/4] Enviando para o GitHub...
git push

echo.
echo Aguardando GitHub Actions compilar...
echo.

:AGUARDA
timeout /t 10 /nobreak >nul

for /f "delims=" %%i in ('powershell -Command "(Invoke-RestMethod -Uri 'https://api.github.com/repos/netflixmarx-debug/mihague-injetor/actions/runs?per_page=1' -Headers @{Authorization='token %GH_TOKEN%'}).workflow_runs[0].status"') do set STATUS=%%i

for /f "delims=" %%i in ('powershell -Command "(Invoke-RestMethod -Uri 'https://api.github.com/repos/netflixmarx-debug/mihague-injetor/actions/runs?per_page=1' -Headers @{Authorization='token %GH_TOKEN%'}).workflow_runs[0].conclusion"') do set CONCLUSION=%%i

echo Status: %STATUS% - Conclusao: %CONCLUSION%

if /i "%STATUS%"=="in_progress" goto AGUARDA
if /i "%STATUS%"=="queued"      goto AGUARDA
if /i "%STATUS%"=="waiting"     goto AGUARDA

echo.
if /i "%CONCLUSION%"=="success" (
    echo [OK] Compilado e Release criado com sucesso!
) else (
    echo [ERRO] Falhou! Verifique em: https://github.com/netflixmarx-debug/mihague-injetor/actions
)

echo.
pause
