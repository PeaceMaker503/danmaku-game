@echo off
flex lexer.l
bison -dy source.y
gcc lex.yy.c y.tab.c -o ..\stage_maker\StageMaker\spell_compiler.exe
..\stage_maker\StageMaker\spell_compiler.exe out2.txt < script.txt
pause