@echo off
flex lexer.l
bison -dy source.y
gcc lex.yy.c y.tab.c -o compiler.exe
compiler.exe < script.txt
pause