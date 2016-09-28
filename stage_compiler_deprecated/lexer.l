/*
MIT License

Copyright (c) 2016 Halim Chellal

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

%{
   
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include "y.tab.h"

%}

%%
"particleType" return tPARTICLE;
"on" return tON;
"#" return tSHARP;
"for" return tFOR;
"every" return tEVERY;
"action" return tACTION;
"then" return tTHEN;
"async" return tASYNC;
"sync" return tSYNC;
"all" return tALL;
"wait" return tWAIT;
":" return tDP;
"loop" return tLOOP;
":+" return tADP;
"let" return tLET;
"." return tDOT;
"health" return tHEALTH;
"create" return tCREATE;
"type" return tTYPE;
"direction" return tDIR;
"destination" return tDEST;
"position" return tPOS;
"speed" return tSPEED;
"move" return tMOVE;
"shoot" return tSHOOT;
"fdirection" return tFDIR;
"fspeed" return tFSPEED;
"|" return tBARRE;
"<-" return tFL;
"{" return tAO;
"}" return tAF;
"(" return tPO;
")" return tPF;
"[" return tCO;
"]" return tCF;
";" return tPV;
"," return tV;
"=" return tEQ;
" " ;
\t ;
\n ;
[-]?([0-9A-Za-z ]+)[\-\+\*\/][0-9A-Za-z\-\+\*\/ ]+ { yylval.string=strdup(yytext); return tEXP ; } ;
[-]?[0-9]+ { yylval.string=strdup(yytext); return tNB ; } ; 
[0-9A-Za-z]+ { yylval.string=strdup(yytext); return tSTRING ; } ; 
"+" return tADD;

%%

