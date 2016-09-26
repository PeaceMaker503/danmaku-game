
/* A Bison parser, made by GNU Bison 2.4.1.  */

/* Skeleton interface for Bison's Yacc-like parsers in C
   
      Copyright (C) 1984, 1989, 1990, 2000, 2001, 2002, 2003, 2004, 2005, 2006
   Free Software Foundation, Inc.
   
   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.
   
   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.
   
   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.
   
   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */


/* Tokens.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
   /* Put the tokens into the symbol table, so that GDB and other debuggers
      know about them.  */
   enum yytokentype {
     tON = 258,
     tTHEN = 259,
     tLOOP = 260,
     tFSPEED = 261,
     tEVERY = 262,
     tFOR = 263,
     tDOT = 264,
     tPARTICLE = 265,
     tSHARP = 266,
     tFDIR = 267,
     tHEALTH = 268,
     tADD = 269,
     tASYNC = 270,
     tWAIT = 271,
     tSYNC = 272,
     tDP = 273,
     tLET = 274,
     tADP = 275,
     tCO = 276,
     tCF = 277,
     tACTION = 278,
     tDEST = 279,
     tALL = 280,
     tPOS = 281,
     tDIR = 282,
     tSPEED = 283,
     tTYPE = 284,
     tCREATE = 285,
     tAO = 286,
     tAF = 287,
     tPO = 288,
     tPF = 289,
     tBARRE = 290,
     tFL = 291,
     tPV = 292,
     tV = 293,
     tEQ = 294,
     tSUB = 295,
     tMUL = 296,
     tDIV = 297,
     tSHOOT = 298,
     tMOVE = 299,
     tEXP = 300,
     tNB = 301,
     tSTRING = 302
   };
#endif
/* Tokens.  */
#define tON 258
#define tTHEN 259
#define tLOOP 260
#define tFSPEED 261
#define tEVERY 262
#define tFOR 263
#define tDOT 264
#define tPARTICLE 265
#define tSHARP 266
#define tFDIR 267
#define tHEALTH 268
#define tADD 269
#define tASYNC 270
#define tWAIT 271
#define tSYNC 272
#define tDP 273
#define tLET 274
#define tADP 275
#define tCO 276
#define tCF 277
#define tACTION 278
#define tDEST 279
#define tALL 280
#define tPOS 281
#define tDIR 282
#define tSPEED 283
#define tTYPE 284
#define tCREATE 285
#define tAO 286
#define tAF 287
#define tPO 288
#define tPF 289
#define tBARRE 290
#define tFL 291
#define tPV 292
#define tV 293
#define tEQ 294
#define tSUB 295
#define tMUL 296
#define tDIV 297
#define tSHOOT 298
#define tMOVE 299
#define tEXP 300
#define tNB 301
#define tSTRING 302




#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef union YYSTYPE
{

/* Line 1676 of yacc.c  */
#line 66 "source.y"

   char* string;



/* Line 1676 of yacc.c  */
#line 152 "y.tab.h"
} YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif

extern YYSTYPE yylval;


