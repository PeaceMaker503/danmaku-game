%{
   
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include "y.tab.h"

%}

%%
"let" return tLET;
"with" return tWITH;
"type" return tTYPE;
"destination" return tDESTINATION;
"direction" return tDIRECTION;
"position" return tPOSITION;
"move" return tMOVE;
"make" return tMAKE;
"speed" return tSPEED;
"angle" return tANGLE;
"loop" return tLOOP;
"case" return tCASE;
"float" return tFLOAT;
"vector" return tVECTOR;
"string" return tSTRING;
"number" return tNUMBER;
"behavior" return tBEHAVIOR;
"delay" return tDELAY;
"call" return tCALL;
"args" return tARGS;
"\"" return tQUOTE;
"<" return tINF;
">" return tSUP;
"!" return tDIFF;
"=" return tEQ;
":" return tDP;
"," return tV;
"[" return tCO;
"]" return tCF;
"{" return tAO;
"}" return tAF;
"(" return tPO;
")" return tPF;
";" return tPV;
"+" return tADD;
"-" return tSUB;
"*" return tMUL;
"/" return tDIV;
"." return tDOT;
[%][A-Za-z_]+[%] { yylval.string = strdup(yytext); return tRUNVAR ; } ;
"%" return tMOD;
\t ;
\n ;
\r ;
" " ;
[0-9]+ { yylval.string = strdup(yytext); return tNB ; } ;
[A-Za-z_]+ { yylval.string=strdup(yytext); return tID ; } ; 
%%
