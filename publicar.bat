@echo off
cd /d "E:\INJETOR DLL\INJETOR MIHAGUE"

echo.
echo [1/4] Adicionando arquivos...
git add -A

echo.
echo [2/4] Commitando...
set /p msg="Digite a mensagem do commit (ex: v1.0.1): "
git commit -m "%msg%"

echo.
echo [3/4] Sincronizando com o GitHub...
git pull --rebase

echo.
echo [4/4] Enviando para o GitHub...
git push

echo.
echo Concluido! Aguarde o GitHub Actions compilar e criar a Release.
echo.
pause
