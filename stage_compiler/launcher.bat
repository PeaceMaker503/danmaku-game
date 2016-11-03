@echo off
flex lexer.l
bison -dy source.y
gcc lex.yy.c y.tab.c -o program.exe
program.exe < script.txt
pause