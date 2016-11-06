
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
     tVAR = 258,
     tWITH = 259,
     tTYPE = 260,
     tDESTINATION = 261,
     tDIRECTION = 262,
     tPOSITION = 263,
     tMOVE = 264,
     tMAKE = 265,
     tSPEED = 266,
     tANGLE = 267,
     tLOOP = 268,
     tCASE = 269,
     tFLOAT = 270,
     tVECTOR = 271,
     tSTRING = 272,
     tNUMBER = 273,
     tBEHAVIOR = 274,
     tQUOTE = 275,
     tINF = 276,
     tSUP = 277,
     tDIFF = 278,
     tEQ = 279,
     tDP = 280,
     tV = 281,
     tCO = 282,
     tCF = 283,
     tAO = 284,
     tAF = 285,
     tPO = 286,
     tPF = 287,
     tPV = 288,
     tADD = 289,
     tSUB = 290,
     tMUL = 291,
     tDIV = 292,
     tDOT = 293,
     tMOD = 294,
     tDELAY = 295,
     tCALL = 296,
     tARGS = 297,
     tSID = 298,
     tCONCAT = 299,
     tCOS = 300,
     tSIN = 301,
     tTAN = 302,
     tNB = 303,
     tID = 304,
     tRUNVAR = 305
   };
#endif
/* Tokens.  */
#define tVAR 258
#define tWITH 259
#define tTYPE 260
#define tDESTINATION 261
#define tDIRECTION 262
#define tPOSITION 263
#define tMOVE 264
#define tMAKE 265
#define tSPEED 266
#define tANGLE 267
#define tLOOP 268
#define tCASE 269
#define tFLOAT 270
#define tVECTOR 271
#define tSTRING 272
#define tNUMBER 273
#define tBEHAVIOR 274
#define tQUOTE 275
#define tINF 276
#define tSUP 277
#define tDIFF 278
#define tEQ 279
#define tDP 280
#define tV 281
#define tCO 282
#define tCF 283
#define tAO 284
#define tAF 285
#define tPO 286
#define tPF 287
#define tPV 288
#define tADD 289
#define tSUB 290
#define tMUL 291
#define tDIV 292
#define tDOT 293
#define tMOD 294
#define tDELAY 295
#define tCALL 296
#define tARGS 297
#define tSID 298
#define tCONCAT 299
#define tCOS 300
#define tSIN 301
#define tTAN 302
#define tNB 303
#define tID 304
#define tRUNVAR 305




#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef union YYSTYPE
{

/* Line 1676 of yacc.c  */
#line 49 "source.y"

   char* string;



/* Line 1676 of yacc.c  */
#line 158 "y.tab.h"
} YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif

extern YYSTYPE yylval;


