
/* A Bison parser, made by GNU Bison 2.4.1.  */

/* Skeleton implementation for Bison's Yacc-like parsers in C
   
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

/* C LALR(1) parser skeleton written by Richard Stallman, by
   simplifying the original so-called "semantic" parser.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Bison version.  */
#define YYBISON_VERSION "2.4.1"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Push parsers.  */
#define YYPUSH 0

/* Pull parsers.  */
#define YYPULL 1

/* Using locations.  */
#define YYLSP_NEEDED 0



/* Copy the first part of user declarations.  */

/* Line 189 of yacc.c  */
#line 1 "source.y"

   #include<stdio.h>
 	#include<stdlib.h>
	#include<string.h>
	#include<math.h>

	#define MAX_BEHAVIOR_ARGS 10;
	#define ARITHMETIC_OPERATION_CODE_ADD 0
	#define ARITHMETIC_OPERATION_CODE_SUB 1
	#define ARITHMETIC_OPERATION_CODE_MUL 2
	#define ARITHMETIC_OPERATION_CODE_DIV 3
	#define ARITHMETIC_OPERATION_CODE_MOD 4
	#define TYPE_FLOAT "FLOAT"
	#define TYPE_VECTOR "VECTOR"
	#define TYPE_STRING "STRING"
	#define TYPE_NUMBER "NUMBER"
	#define BOOL_OP_EQ "=="
	#define BOOL_OP_INF "<"
	#define BOOL_OP_INF_EQ "<="
	#define BOOL_OP_SUP ">"
	#define BOOL_OP_SUP_EQ ">="
	#define BOOL_OP_DIFF "!="
	
	int yylex();
	void yyerror(const char *s);
	int yywrap();
	char* getNewArithmeticOperation(char * left, char * right, int opCode);
	char* getNewDecimal(char* left, char* right);
	char* getNewVector(char* left, char* right);
   char* getArgsDeclaration(char * id, char * type, char* currentDeclaration);
   char* getFirstArgsDeclaration(char * id, char * type);
   char* getArgsCall(char * value, char* currentValues);
   char* getNewString(char* value);
   void replace_char(char *str, char orig, char rep);
   char* getNewVarTempName();
	int loopId = 0;
	int caseId = 0;
	int behaviorId = 0;
	int varTempId = 0;
	FILE* out;


/* Line 189 of yacc.c  */
#line 116 "y.tab.c"

/* Enabling traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif

/* Enabling verbose error messages.  */
#ifdef YYERROR_VERBOSE
# undef YYERROR_VERBOSE
# define YYERROR_VERBOSE 1
#else
# define YYERROR_VERBOSE 0
#endif

/* Enabling the token table.  */
#ifndef YYTOKEN_TABLE
# define YYTOKEN_TABLE 0
#endif


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

/* Line 214 of yacc.c  */
#line 49 "source.y"

   char* string;



/* Line 214 of yacc.c  */
#line 258 "y.tab.c"
} YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif


/* Copy the second part of user declarations.  */


/* Line 264 of yacc.c  */
#line 270 "y.tab.c"

#ifdef short
# undef short
#endif

#ifdef YYTYPE_UINT8
typedef YYTYPE_UINT8 yytype_uint8;
#else
typedef unsigned char yytype_uint8;
#endif

#ifdef YYTYPE_INT8
typedef YYTYPE_INT8 yytype_int8;
#elif (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
typedef signed char yytype_int8;
#else
typedef short int yytype_int8;
#endif

#ifdef YYTYPE_UINT16
typedef YYTYPE_UINT16 yytype_uint16;
#else
typedef unsigned short int yytype_uint16;
#endif

#ifdef YYTYPE_INT16
typedef YYTYPE_INT16 yytype_int16;
#else
typedef short int yytype_int16;
#endif

#ifndef YYSIZE_T
# ifdef __SIZE_TYPE__
#  define YYSIZE_T __SIZE_TYPE__
# elif defined size_t
#  define YYSIZE_T size_t
# elif ! defined YYSIZE_T && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# else
#  define YYSIZE_T unsigned int
# endif
#endif

#define YYSIZE_MAXIMUM ((YYSIZE_T) -1)

#ifndef YY_
# if YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(msgid) dgettext ("bison-runtime", msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(msgid) msgid
# endif
#endif

/* Suppress unused-variable warnings by "using" E.  */
#if ! defined lint || defined __GNUC__
# define YYUSE(e) ((void) (e))
#else
# define YYUSE(e) /* empty */
#endif

/* Identity function, used to suppress warnings about constant conditions.  */
#ifndef lint
# define YYID(n) (n)
#else
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static int
YYID (int yyi)
#else
static int
YYID (yyi)
    int yyi;
#endif
{
  return yyi;
}
#endif

#if ! defined yyoverflow || YYERROR_VERBOSE

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   elif defined __BUILTIN_VA_ARG_INCR
#    include <alloca.h> /* INFRINGES ON USER NAME SPACE */
#   elif defined _AIX
#    define YYSTACK_ALLOC __alloca
#   elif defined _MSC_VER
#    include <malloc.h> /* INFRINGES ON USER NAME SPACE */
#    define alloca _alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if ! defined _ALLOCA_H && ! defined _STDLIB_H && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#     ifndef _STDLIB_H
#      define _STDLIB_H 1
#     endif
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's `empty if-body' warning.  */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (YYID (0))
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2006 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM YYSIZE_MAXIMUM
#  endif
#  if (defined __cplusplus && ! defined _STDLIB_H \
       && ! ((defined YYMALLOC || defined malloc) \
	     && (defined YYFREE || defined free)))
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   ifndef _STDLIB_H
#    define _STDLIB_H 1
#   endif
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if ! defined malloc && ! defined _STDLIB_H && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if ! defined free && ! defined _STDLIB_H && (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
# endif
#endif /* ! defined yyoverflow || YYERROR_VERBOSE */


#if (! defined yyoverflow \
     && (! defined __cplusplus \
	 || (defined YYSTYPE_IS_TRIVIAL && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  yytype_int16 yyss_alloc;
  YYSTYPE yyvs_alloc;
};

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (sizeof (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (sizeof (yytype_int16) + sizeof (YYSTYPE)) \
      + YYSTACK_GAP_MAXIMUM)

/* Copy COUNT objects from FROM to TO.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined __GNUC__ && 1 < __GNUC__
#   define YYCOPY(To, From, Count) \
      __builtin_memcpy (To, From, (Count) * sizeof (*(From)))
#  else
#   define YYCOPY(To, From, Count)		\
      do					\
	{					\
	  YYSIZE_T yyi;				\
	  for (yyi = 0; yyi < (Count); yyi++)	\
	    (To)[yyi] = (From)[yyi];		\
	}					\
      while (YYID (0))
#  endif
# endif

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack_alloc, Stack)				\
    do									\
      {									\
	YYSIZE_T yynewbytes;						\
	YYCOPY (&yyptr->Stack_alloc, Stack, yysize);			\
	Stack = &yyptr->Stack_alloc;					\
	yynewbytes = yystacksize * sizeof (*Stack) + YYSTACK_GAP_MAXIMUM; \
	yyptr += yynewbytes / sizeof (*yyptr);				\
      }									\
    while (YYID (0))

#endif

/* YYFINAL -- State number of the termination state.  */
#define YYFINAL  33
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   238

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  51
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  30
/* YYNRULES -- Number of rules.  */
#define YYNRULES  82
/* YYNRULES -- Number of states.  */
#define YYNSTATES  199

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   305

#define YYTRANSLATE(YYX)						\
  ((unsigned int) (YYX) <= YYMAXUTOK ? yytranslate[YYX] : YYUNDEFTOK)

/* YYTRANSLATE[YYLEX] -- Bison symbol number corresponding to YYLEX.  */
static const yytype_uint8 yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const yytype_uint16 yyprhs[] =
{
       0,     0,     3,     6,     8,    10,    12,    14,    16,    18,
      20,    22,    24,    26,    28,    34,    40,    44,    46,    50,
      54,    58,    62,    66,    73,    79,    85,    91,   102,   112,
     116,   118,   122,   126,   130,   134,   138,   142,   143,   152,
     153,   164,   165,   175,   176,   185,   189,   195,   197,   201,
     203,   205,   207,   210,   212,   215,   217,   220,   223,   231,
     236,   238,   240,   242,   244,   248,   250,   252,   258,   260,
     262,   264,   266,   271,   276,   281,   285,   287,   291,   295,
     299,   303,   307
};

/* YYRHS -- A `-1'-separated list of the rules' RHS.  */
static const yytype_int8 yyrhs[] =
{
      52,     0,    -1,    53,    52,    -1,    53,    -1,    74,    -1,
      75,    -1,    63,    -1,    65,    -1,    67,    -1,    59,    -1,
      60,    -1,    58,    -1,    54,    -1,    55,    -1,    42,    31,
      70,    32,    33,    -1,     9,    31,    56,    32,    33,    -1,
      57,    26,    56,    -1,    57,    -1,    12,    24,    80,    -1,
      11,    24,    80,    -1,     6,    24,    78,    -1,     8,    24,
      78,    -1,    43,    24,    77,    -1,    41,    49,    31,    71,
      32,    33,    -1,    41,    49,    31,    32,    33,    -1,    40,
      31,    80,    32,    33,    -1,    10,    31,    61,    32,    33,
      -1,    10,    31,    61,    32,     4,    49,    31,    71,    32,
      33,    -1,    10,    31,    61,    32,     4,    49,    31,    32,
      33,    -1,    62,    26,    61,    -1,    62,    -1,    12,    24,
      80,    -1,    11,    24,    80,    -1,     5,    24,    77,    -1,
      43,    24,    77,    -1,     6,    24,    78,    -1,     8,    24,
      78,    -1,    -1,    13,    31,    79,    32,    64,    29,    52,
      30,    -1,    -1,    14,    31,    72,    73,    72,    32,    66,
      29,    52,    30,    -1,    -1,    19,    49,    31,    70,    32,
      68,    29,    52,    30,    -1,    -1,    19,    49,    31,    32,
      69,    29,    52,    30,    -1,    49,    25,    76,    -1,    49,
      25,    76,    26,    70,    -1,    72,    -1,    72,    26,    71,
      -1,    80,    -1,    77,    -1,    78,    -1,    24,    24,    -1,
      21,    -1,    21,    24,    -1,    22,    -1,    22,    24,    -1,
      23,    24,    -1,     3,    49,    25,    76,    24,    72,    33,
      -1,    49,    24,    72,    33,    -1,    15,    -1,    16,    -1,
      17,    -1,    18,    -1,    20,    49,    20,    -1,    49,    -1,
      49,    -1,    27,    80,    26,    80,    28,    -1,    50,    -1,
      49,    -1,    48,    -1,    49,    -1,    45,    31,    80,    32,
      -1,    46,    31,    80,    32,    -1,    47,    31,    80,    32,
      -1,    48,    38,    48,    -1,    48,    -1,    80,    34,    80,
      -1,    80,    35,    80,    -1,    80,    36,    80,    -1,    80,
      37,    80,    -1,    80,    39,    80,    -1,    31,    80,    32,
      -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const yytype_uint8 yyrline[] =
{
       0,    65,    65,    66,    68,    69,    70,    71,    72,    73,
      74,    75,    76,    77,    79,    80,    82,    83,    85,    86,
      87,    88,    89,    91,    92,    93,    94,    95,    96,    97,
      98,    99,   100,   101,   102,   103,   104,   105,   105,   106,
     106,   107,   107,   108,   108,   111,   112,   115,   116,   119,
     120,   121,   123,   124,   125,   126,   127,   128,   131,   133,
     136,   137,   138,   139,   142,   143,   146,   147,   148,   151,
     152,   155,   156,   157,   158,   159,   160,   161,   162,   163,
     164,   165,   166
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || YYTOKEN_TABLE
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "tVAR", "tWITH", "tTYPE", "tDESTINATION",
  "tDIRECTION", "tPOSITION", "tMOVE", "tMAKE", "tSPEED", "tANGLE", "tLOOP",
  "tCASE", "tFLOAT", "tVECTOR", "tSTRING", "tNUMBER", "tBEHAVIOR",
  "tQUOTE", "tINF", "tSUP", "tDIFF", "tEQ", "tDP", "tV", "tCO", "tCF",
  "tAO", "tAF", "tPO", "tPF", "tPV", "tADD", "tSUB", "tMUL", "tDIV",
  "tDOT", "tMOD", "tDELAY", "tCALL", "tARGS", "tSID", "tCONCAT", "tCOS",
  "tSIN", "tTAN", "tNB", "tID", "tRUNVAR", "$accept", "Script",
  "Instruction", "SpellDeclaration", "Move", "MoveArgs", "MoveArg", "Call",
  "Delay", "Make", "MakeArgs", "MakeArg", "Loop", "$@1", "Case", "$@2",
  "Behavior", "$@3", "$@4", "ArgsDeclaration", "ArgsCall", "Value",
  "BoolOp", "Declaration", "Affection", "Type", "String", "Vector",
  "Number", "ArithmeticExp", 0
};
#endif

# ifdef YYPRINT
/* YYTOKNUM[YYLEX-NUM] -- Internal token number corresponding to
   token YYLEX-NUM.  */
static const yytype_uint16 yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   282,   283,   284,
     285,   286,   287,   288,   289,   290,   291,   292,   293,   294,
     295,   296,   297,   298,   299,   300,   301,   302,   303,   304,
     305
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint8 yyr1[] =
{
       0,    51,    52,    52,    53,    53,    53,    53,    53,    53,
      53,    53,    53,    53,    54,    55,    56,    56,    57,    57,
      57,    57,    57,    58,    58,    59,    60,    60,    60,    61,
      61,    62,    62,    62,    62,    62,    62,    64,    63,    66,
      65,    68,    67,    69,    67,    70,    70,    71,    71,    72,
      72,    72,    73,    73,    73,    73,    73,    73,    74,    75,
      76,    76,    76,    76,    77,    77,    78,    78,    78,    79,
      79,    80,    80,    80,    80,    80,    80,    80,    80,    80,
      80,    80,    80
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const yytype_uint8 yyr2[] =
{
       0,     2,     2,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     5,     5,     3,     1,     3,     3,
       3,     3,     3,     6,     5,     5,     5,    10,     9,     3,
       1,     3,     3,     3,     3,     3,     3,     0,     8,     0,
      10,     0,     9,     0,     8,     3,     5,     1,     3,     1,
       1,     1,     2,     1,     2,     1,     2,     2,     7,     4,
       1,     1,     1,     1,     3,     1,     1,     5,     1,     1,
       1,     1,     4,     4,     4,     3,     1,     3,     3,     3,
       3,     3,     3
};

/* YYDEFACT[STATE-NAME] -- Default rule to reduce with in state
   STATE-NUM when YYTABLE doesn't specify something else to do.  Zero
   means the default is an error.  */
static const yytype_uint8 yydefact[] =
{
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     3,    12,    13,    11,     9,    10,     6,     7,
       8,     4,     5,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     1,     2,     0,     0,     0,     0,     0,
       0,     0,    17,     0,     0,     0,     0,     0,     0,     0,
      30,    70,    69,     0,     0,     0,     0,     0,     0,     0,
      76,    65,    68,     0,    50,    51,    49,     0,    71,     0,
       0,     0,     0,     0,    60,    61,    62,    63,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,    37,     0,     0,     0,     0,     0,
       0,     0,    53,    55,     0,     0,     0,     0,     0,     0,
       0,     0,    43,     0,     0,     0,     0,    47,     0,     0,
      59,     0,    66,    20,    21,    19,    18,    65,    22,    15,
      16,    33,    35,    36,    32,    31,    34,     0,    26,    29,
       0,    64,     0,    82,     0,     0,     0,    75,    54,    56,
      57,    52,     0,    77,    78,    79,    80,    81,     0,    41,
      25,    24,     0,     0,    45,    14,     0,     0,     0,     0,
      72,    73,    74,    39,     0,     0,    23,    48,     0,    58,
       0,     0,    67,     0,     0,     0,    46,     0,     0,    38,
       0,    44,     0,    28,     0,     0,    42,    27,    40
};

/* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,    11,    12,    13,    14,    41,    42,    15,    16,    17,
      49,    50,    18,   140,    19,   183,    20,   175,   158,    72,
     116,   117,   106,    21,    22,    78,    64,    65,    53,    66
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -141
static const yytype_int16 yypact[] =
{
       3,   -42,   -20,   -16,   -11,    -1,     1,    18,     8,    20,
      34,    64,     3,  -141,  -141,  -141,  -141,  -141,  -141,  -141,
    -141,  -141,  -141,    38,    23,    13,    -7,    76,    36,    63,
      37,    16,    76,  -141,  -141,   126,    45,    67,    68,    71,
      74,   -24,    78,    81,    82,   108,   110,   125,   127,   128,
     132,  -141,  -141,   143,    51,    63,    63,   164,   170,   171,
     121,    94,  -141,   176,  -141,  -141,   118,   -23,  -141,   129,
      28,   178,   144,   172,  -141,  -141,  -141,  -141,   180,   -13,
     -13,    63,    63,   -17,   173,    23,   -17,   -13,   -13,    63,
      63,   -17,     0,    13,  -141,   187,   101,   135,    63,    63,
      63,   160,   185,   186,   188,   189,    76,    63,    63,    63,
      63,    63,  -141,   179,   181,   182,   184,   191,   126,   190,
    -141,    76,  -141,  -141,  -141,   118,   118,  -141,  -141,  -141,
    -141,  -141,  -141,  -141,   118,   118,  -141,   169,  -141,  -141,
     192,  -141,    63,  -141,   145,   151,   157,  -141,  -141,  -141,
    -141,  -141,   193,    50,    50,  -141,  -141,  -141,   195,  -141,
    -141,  -141,   194,    76,   196,  -141,   197,   198,     3,   111,
    -141,  -141,  -141,  -141,     3,   199,  -141,  -141,    16,  -141,
      70,   201,  -141,   203,   204,     3,  -141,   200,   205,  -141,
       3,  -141,   206,  -141,   202,   208,  -141,  -141,  -141
};

/* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -141,   -12,  -141,  -141,  -141,   134,  -141,  -141,  -141,  -141,
     133,  -141,  -141,  -141,  -141,  -141,  -141,  -141,  -141,   -65,
    -140,   -22,  -141,  -141,  -141,   102,     2,   -41,  -141,   -28
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If zero, do what YYDEFACT says.
   If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -72
static const yytype_int16 yytable[] =
{
      34,    69,   113,    54,   137,    63,     1,    23,    84,   112,
      73,    24,     2,     3,    55,    25,     4,     5,    43,    44,
      26,    45,     6,   177,    46,    47,    71,    96,    97,    36,
      27,    37,   127,   138,    38,    39,   122,    62,   123,   124,
     188,    51,    52,     7,     8,     9,   132,   133,    54,    29,
      28,    31,    10,   125,   126,    55,    48,    30,    32,    56,
     115,   134,   135,    35,    33,    71,    40,    67,    70,    79,
     144,   145,   146,    57,    58,    59,    60,    61,    62,   153,
     154,   155,   156,   157,   152,   128,   109,   110,   131,   111,
      54,    80,    81,   136,    56,    82,    54,    55,    83,   166,
      95,    56,   187,    55,    85,    86,    87,    56,    57,    58,
      59,    60,    68,   186,   169,    57,    58,    59,    60,    61,
      62,    57,    58,    59,    60,    61,    62,   142,   -71,   -71,
     -71,   -71,    88,   -71,    89,   107,   108,   109,   110,   182,
     111,    74,    75,    76,    77,   107,   108,   109,   110,    90,
     111,    91,   107,   108,   109,   110,   181,   111,    93,   101,
      92,   114,   184,   107,   108,   109,   110,   143,   111,   107,
     108,   109,   110,   192,   111,    94,   119,   170,   195,   107,
     108,   109,   110,   171,   111,   107,   108,   109,   110,   172,
     111,   107,   108,   109,   110,    98,   111,   102,   103,   104,
     105,    99,   100,   118,   121,   120,   129,   141,   147,   148,
     149,   159,   150,   151,   160,   161,   162,   163,   167,   130,
     164,   168,   178,   165,   174,   173,   139,   176,   185,   180,
     179,   189,   190,   193,   191,   197,   196,   194,   198
};

static const yytype_uint8 yycheck[] =
{
      12,    29,    67,    20,     4,    27,     3,    49,    32,    32,
      32,    31,     9,    10,    27,    31,    13,    14,     5,     6,
      31,     8,    19,   163,    11,    12,    49,    55,    56,     6,
      31,     8,    49,    33,    11,    12,    49,    50,    79,    80,
     180,    48,    49,    40,    41,    42,    87,    88,    20,    31,
      49,    31,    49,    81,    82,    27,    43,    49,    24,    31,
      32,    89,    90,    25,     0,    49,    43,    31,    31,    24,
      98,    99,   100,    45,    46,    47,    48,    49,    50,   107,
     108,   109,   110,   111,   106,    83,    36,    37,    86,    39,
      20,    24,    24,    91,    31,    24,    20,    27,    24,   121,
      49,    31,    32,    27,    26,    24,    24,    31,    45,    46,
      47,    48,    49,   178,   142,    45,    46,    47,    48,    49,
      50,    45,    46,    47,    48,    49,    50,    26,    34,    35,
      36,    37,    24,    39,    24,    34,    35,    36,    37,    28,
      39,    15,    16,    17,    18,    34,    35,    36,    37,    24,
      39,    24,    34,    35,    36,    37,   168,    39,    26,    38,
      32,    32,   174,    34,    35,    36,    37,    32,    39,    34,
      35,    36,    37,   185,    39,    32,    32,    32,   190,    34,
      35,    36,    37,    32,    39,    34,    35,    36,    37,    32,
      39,    34,    35,    36,    37,    31,    39,    21,    22,    23,
      24,    31,    31,    25,    24,    33,    33,    20,    48,    24,
      24,    32,    24,    24,    33,    33,    32,    26,    49,    85,
     118,    29,    26,    33,    29,    32,    93,    33,    29,    31,
      33,    30,    29,    33,    30,    33,    30,    32,    30
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,     3,     9,    10,    13,    14,    19,    40,    41,    42,
      49,    52,    53,    54,    55,    58,    59,    60,    63,    65,
      67,    74,    75,    49,    31,    31,    31,    31,    49,    31,
      49,    31,    24,     0,    52,    25,     6,     8,    11,    12,
      43,    56,    57,     5,     6,     8,    11,    12,    43,    61,
      62,    48,    49,    79,    20,    27,    31,    45,    46,    47,
      48,    49,    50,    72,    77,    78,    80,    31,    49,    80,
      31,    49,    70,    72,    15,    16,    17,    18,    76,    24,
      24,    24,    24,    24,    32,    26,    24,    24,    24,    24,
      24,    24,    32,    26,    32,    49,    80,    80,    31,    31,
      31,    38,    21,    22,    23,    24,    73,    34,    35,    36,
      37,    39,    32,    70,    32,    32,    71,    72,    25,    32,
      33,    24,    49,    78,    78,    80,    80,    49,    77,    33,
      56,    77,    78,    78,    80,    80,    77,     4,    33,    61,
      64,    20,    26,    32,    80,    80,    80,    48,    24,    24,
      24,    24,    72,    80,    80,    80,    80,    80,    69,    32,
      33,    33,    32,    26,    76,    33,    72,    49,    29,    80,
      32,    32,    32,    32,    29,    68,    33,    71,    26,    33,
      31,    52,    28,    66,    52,    29,    70,    32,    71,    30,
      29,    30,    52,    33,    32,    52,    30,    33,    30
};

#define yyerrok		(yyerrstatus = 0)
#define yyclearin	(yychar = YYEMPTY)
#define YYEMPTY		(-2)
#define YYEOF		0

#define YYACCEPT	goto yyacceptlab
#define YYABORT		goto yyabortlab
#define YYERROR		goto yyerrorlab


/* Like YYERROR except do call yyerror.  This remains here temporarily
   to ease the transition to the new meaning of YYERROR, for GCC.
   Once GCC version 2 has supplanted version 1, this can go.  */

#define YYFAIL		goto yyerrlab

#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)					\
do								\
  if (yychar == YYEMPTY && yylen == 1)				\
    {								\
      yychar = (Token);						\
      yylval = (Value);						\
      yytoken = YYTRANSLATE (yychar);				\
      YYPOPSTACK (1);						\
      goto yybackup;						\
    }								\
  else								\
    {								\
      yyerror (YY_("syntax error: cannot back up")); \
      YYERROR;							\
    }								\
while (YYID (0))


#define YYTERROR	1
#define YYERRCODE	256


/* YYLLOC_DEFAULT -- Set CURRENT to span from RHS[1] to RHS[N].
   If N is 0, then set CURRENT to the empty location which ends
   the previous symbol: RHS[0] (always defined).  */

#define YYRHSLOC(Rhs, K) ((Rhs)[K])
#ifndef YYLLOC_DEFAULT
# define YYLLOC_DEFAULT(Current, Rhs, N)				\
    do									\
      if (YYID (N))                                                    \
	{								\
	  (Current).first_line   = YYRHSLOC (Rhs, 1).first_line;	\
	  (Current).first_column = YYRHSLOC (Rhs, 1).first_column;	\
	  (Current).last_line    = YYRHSLOC (Rhs, N).last_line;		\
	  (Current).last_column  = YYRHSLOC (Rhs, N).last_column;	\
	}								\
      else								\
	{								\
	  (Current).first_line   = (Current).last_line   =		\
	    YYRHSLOC (Rhs, 0).last_line;				\
	  (Current).first_column = (Current).last_column =		\
	    YYRHSLOC (Rhs, 0).last_column;				\
	}								\
    while (YYID (0))
#endif


/* YY_LOCATION_PRINT -- Print the location on the stream.
   This macro was not mandated originally: define only if we know
   we won't break user code: when these are the locations we know.  */

#ifndef YY_LOCATION_PRINT
# if YYLTYPE_IS_TRIVIAL
#  define YY_LOCATION_PRINT(File, Loc)			\
     fprintf (File, "%d.%d-%d.%d",			\
	      (Loc).first_line, (Loc).first_column,	\
	      (Loc).last_line,  (Loc).last_column)
# else
#  define YY_LOCATION_PRINT(File, Loc) ((void) 0)
# endif
#endif


/* YYLEX -- calling `yylex' with the right arguments.  */

#ifdef YYLEX_PARAM
# define YYLEX yylex (YYLEX_PARAM)
#else
# define YYLEX yylex ()
#endif

/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)			\
do {						\
  if (yydebug)					\
    YYFPRINTF Args;				\
} while (YYID (0))

# define YY_SYMBOL_PRINT(Title, Type, Value, Location)			  \
do {									  \
  if (yydebug)								  \
    {									  \
      YYFPRINTF (stderr, "%s ", Title);					  \
      yy_symbol_print (stderr,						  \
		  Type, Value); \
      YYFPRINTF (stderr, "\n");						  \
    }									  \
} while (YYID (0))


/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

/*ARGSUSED*/
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_symbol_value_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
#else
static void
yy_symbol_value_print (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE const * const yyvaluep;
#endif
{
  if (!yyvaluep)
    return;
# ifdef YYPRINT
  if (yytype < YYNTOKENS)
    YYPRINT (yyoutput, yytoknum[yytype], *yyvaluep);
# else
  YYUSE (yyoutput);
# endif
  switch (yytype)
    {
      default:
	break;
    }
}


/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_symbol_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
#else
static void
yy_symbol_print (yyoutput, yytype, yyvaluep)
    FILE *yyoutput;
    int yytype;
    YYSTYPE const * const yyvaluep;
#endif
{
  if (yytype < YYNTOKENS)
    YYFPRINTF (yyoutput, "token %s (", yytname[yytype]);
  else
    YYFPRINTF (yyoutput, "nterm %s (", yytname[yytype]);

  yy_symbol_value_print (yyoutput, yytype, yyvaluep);
  YYFPRINTF (yyoutput, ")");
}

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_stack_print (yytype_int16 *yybottom, yytype_int16 *yytop)
#else
static void
yy_stack_print (yybottom, yytop)
    yytype_int16 *yybottom;
    yytype_int16 *yytop;
#endif
{
  YYFPRINTF (stderr, "Stack now");
  for (; yybottom <= yytop; yybottom++)
    {
      int yybot = *yybottom;
      YYFPRINTF (stderr, " %d", yybot);
    }
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)				\
do {								\
  if (yydebug)							\
    yy_stack_print ((Bottom), (Top));				\
} while (YYID (0))


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yy_reduce_print (YYSTYPE *yyvsp, int yyrule)
#else
static void
yy_reduce_print (yyvsp, yyrule)
    YYSTYPE *yyvsp;
    int yyrule;
#endif
{
  int yynrhs = yyr2[yyrule];
  int yyi;
  unsigned long int yylno = yyrline[yyrule];
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %lu):\n",
	     yyrule - 1, yylno);
  /* The symbols being reduced.  */
  for (yyi = 0; yyi < yynrhs; yyi++)
    {
      YYFPRINTF (stderr, "   $%d = ", yyi + 1);
      yy_symbol_print (stderr, yyrhs[yyprhs[yyrule] + yyi],
		       &(yyvsp[(yyi + 1) - (yynrhs)])
		       		       );
      YYFPRINTF (stderr, "\n");
    }
}

# define YY_REDUCE_PRINT(Rule)		\
do {					\
  if (yydebug)				\
    yy_reduce_print (yyvsp, Rule); \
} while (YYID (0))

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args)
# define YY_SYMBOL_PRINT(Title, Type, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef	YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif



#if YYERROR_VERBOSE

# ifndef yystrlen
#  if defined __GLIBC__ && defined _STRING_H
#   define yystrlen strlen
#  else
/* Return the length of YYSTR.  */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static YYSIZE_T
yystrlen (const char *yystr)
#else
static YYSIZE_T
yystrlen (yystr)
    const char *yystr;
#endif
{
  YYSIZE_T yylen;
  for (yylen = 0; yystr[yylen]; yylen++)
    continue;
  return yylen;
}
#  endif
# endif

# ifndef yystpcpy
#  if defined __GLIBC__ && defined _STRING_H && defined _GNU_SOURCE
#   define yystpcpy stpcpy
#  else
/* Copy YYSRC to YYDEST, returning the address of the terminating '\0' in
   YYDEST.  */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static char *
yystpcpy (char *yydest, const char *yysrc)
#else
static char *
yystpcpy (yydest, yysrc)
    char *yydest;
    const char *yysrc;
#endif
{
  char *yyd = yydest;
  const char *yys = yysrc;

  while ((*yyd++ = *yys++) != '\0')
    continue;

  return yyd - 1;
}
#  endif
# endif

# ifndef yytnamerr
/* Copy to YYRES the contents of YYSTR after stripping away unnecessary
   quotes and backslashes, so that it's suitable for yyerror.  The
   heuristic is that double-quoting is unnecessary unless the string
   contains an apostrophe, a comma, or backslash (other than
   backslash-backslash).  YYSTR is taken from yytname.  If YYRES is
   null, do not copy; instead, return the length of what the result
   would have been.  */
static YYSIZE_T
yytnamerr (char *yyres, const char *yystr)
{
  if (*yystr == '"')
    {
      YYSIZE_T yyn = 0;
      char const *yyp = yystr;

      for (;;)
	switch (*++yyp)
	  {
	  case '\'':
	  case ',':
	    goto do_not_strip_quotes;

	  case '\\':
	    if (*++yyp != '\\')
	      goto do_not_strip_quotes;
	    /* Fall through.  */
	  default:
	    if (yyres)
	      yyres[yyn] = *yyp;
	    yyn++;
	    break;

	  case '"':
	    if (yyres)
	      yyres[yyn] = '\0';
	    return yyn;
	  }
    do_not_strip_quotes: ;
    }

  if (! yyres)
    return yystrlen (yystr);

  return yystpcpy (yyres, yystr) - yyres;
}
# endif

/* Copy into YYRESULT an error message about the unexpected token
   YYCHAR while in state YYSTATE.  Return the number of bytes copied,
   including the terminating null byte.  If YYRESULT is null, do not
   copy anything; just return the number of bytes that would be
   copied.  As a special case, return 0 if an ordinary "syntax error"
   message will do.  Return YYSIZE_MAXIMUM if overflow occurs during
   size calculation.  */
static YYSIZE_T
yysyntax_error (char *yyresult, int yystate, int yychar)
{
  int yyn = yypact[yystate];

  if (! (YYPACT_NINF < yyn && yyn <= YYLAST))
    return 0;
  else
    {
      int yytype = YYTRANSLATE (yychar);
      YYSIZE_T yysize0 = yytnamerr (0, yytname[yytype]);
      YYSIZE_T yysize = yysize0;
      YYSIZE_T yysize1;
      int yysize_overflow = 0;
      enum { YYERROR_VERBOSE_ARGS_MAXIMUM = 5 };
      char const *yyarg[YYERROR_VERBOSE_ARGS_MAXIMUM];
      int yyx;

# if 0
      /* This is so xgettext sees the translatable formats that are
	 constructed on the fly.  */
      YY_("syntax error, unexpected %s");
      YY_("syntax error, unexpected %s, expecting %s");
      YY_("syntax error, unexpected %s, expecting %s or %s");
      YY_("syntax error, unexpected %s, expecting %s or %s or %s");
      YY_("syntax error, unexpected %s, expecting %s or %s or %s or %s");
# endif
      char *yyfmt;
      char const *yyf;
      static char const yyunexpected[] = "syntax error, unexpected %s";
      static char const yyexpecting[] = ", expecting %s";
      static char const yyor[] = " or %s";
      char yyformat[sizeof yyunexpected
		    + sizeof yyexpecting - 1
		    + ((YYERROR_VERBOSE_ARGS_MAXIMUM - 2)
		       * (sizeof yyor - 1))];
      char const *yyprefix = yyexpecting;

      /* Start YYX at -YYN if negative to avoid negative indexes in
	 YYCHECK.  */
      int yyxbegin = yyn < 0 ? -yyn : 0;

      /* Stay within bounds of both yycheck and yytname.  */
      int yychecklim = YYLAST - yyn + 1;
      int yyxend = yychecklim < YYNTOKENS ? yychecklim : YYNTOKENS;
      int yycount = 1;

      yyarg[0] = yytname[yytype];
      yyfmt = yystpcpy (yyformat, yyunexpected);

      for (yyx = yyxbegin; yyx < yyxend; ++yyx)
	if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR)
	  {
	    if (yycount == YYERROR_VERBOSE_ARGS_MAXIMUM)
	      {
		yycount = 1;
		yysize = yysize0;
		yyformat[sizeof yyunexpected - 1] = '\0';
		break;
	      }
	    yyarg[yycount++] = yytname[yyx];
	    yysize1 = yysize + yytnamerr (0, yytname[yyx]);
	    yysize_overflow |= (yysize1 < yysize);
	    yysize = yysize1;
	    yyfmt = yystpcpy (yyfmt, yyprefix);
	    yyprefix = yyor;
	  }

      yyf = YY_(yyformat);
      yysize1 = yysize + yystrlen (yyf);
      yysize_overflow |= (yysize1 < yysize);
      yysize = yysize1;

      if (yysize_overflow)
	return YYSIZE_MAXIMUM;

      if (yyresult)
	{
	  /* Avoid sprintf, as that infringes on the user's name space.
	     Don't have undefined behavior even if the translation
	     produced a string with the wrong number of "%s"s.  */
	  char *yyp = yyresult;
	  int yyi = 0;
	  while ((*yyp = *yyf) != '\0')
	    {
	      if (*yyp == '%' && yyf[1] == 's' && yyi < yycount)
		{
		  yyp += yytnamerr (yyp, yyarg[yyi++]);
		  yyf += 2;
		}
	      else
		{
		  yyp++;
		  yyf++;
		}
	    }
	}
      return yysize;
    }
}
#endif /* YYERROR_VERBOSE */


/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

/*ARGSUSED*/
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
static void
yydestruct (const char *yymsg, int yytype, YYSTYPE *yyvaluep)
#else
static void
yydestruct (yymsg, yytype, yyvaluep)
    const char *yymsg;
    int yytype;
    YYSTYPE *yyvaluep;
#endif
{
  YYUSE (yyvaluep);

  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yytype, yyvaluep, yylocationp);

  switch (yytype)
    {

      default:
	break;
    }
}

/* Prevent warnings from -Wmissing-prototypes.  */
#ifdef YYPARSE_PARAM
#if defined __STDC__ || defined __cplusplus
int yyparse (void *YYPARSE_PARAM);
#else
int yyparse ();
#endif
#else /* ! YYPARSE_PARAM */
#if defined __STDC__ || defined __cplusplus
int yyparse (void);
#else
int yyparse ();
#endif
#endif /* ! YYPARSE_PARAM */


/* The lookahead symbol.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;

/* Number of syntax errors so far.  */
int yynerrs;



/*-------------------------.
| yyparse or yypush_parse.  |
`-------------------------*/

#ifdef YYPARSE_PARAM
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
int
yyparse (void *YYPARSE_PARAM)
#else
int
yyparse (YYPARSE_PARAM)
    void *YYPARSE_PARAM;
#endif
#else /* ! YYPARSE_PARAM */
#if (defined __STDC__ || defined __C99__FUNC__ \
     || defined __cplusplus || defined _MSC_VER)
int
yyparse (void)
#else
int
yyparse ()

#endif
#endif
{


    int yystate;
    /* Number of tokens to shift before error messages enabled.  */
    int yyerrstatus;

    /* The stacks and their tools:
       `yyss': related to states.
       `yyvs': related to semantic values.

       Refer to the stacks thru separate pointers, to allow yyoverflow
       to reallocate them elsewhere.  */

    /* The state stack.  */
    yytype_int16 yyssa[YYINITDEPTH];
    yytype_int16 *yyss;
    yytype_int16 *yyssp;

    /* The semantic value stack.  */
    YYSTYPE yyvsa[YYINITDEPTH];
    YYSTYPE *yyvs;
    YYSTYPE *yyvsp;

    YYSIZE_T yystacksize;

  int yyn;
  int yyresult;
  /* Lookahead token as an internal (translated) token number.  */
  int yytoken;
  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;

#if YYERROR_VERBOSE
  /* Buffer for error messages, and its allocated size.  */
  char yymsgbuf[128];
  char *yymsg = yymsgbuf;
  YYSIZE_T yymsg_alloc = sizeof yymsgbuf;
#endif

#define YYPOPSTACK(N)   (yyvsp -= (N), yyssp -= (N))

  /* The number of symbols on the RHS of the reduced rule.
     Keep to zero when no symbol should be popped.  */
  int yylen = 0;

  yytoken = 0;
  yyss = yyssa;
  yyvs = yyvsa;
  yystacksize = YYINITDEPTH;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY; /* Cause a token to be read.  */

  /* Initialize stack pointers.
     Waste one element of value and location stack
     so that they stay on the same level as the state stack.
     The wasted elements are never initialized.  */
  yyssp = yyss;
  yyvsp = yyvs;

  goto yysetstate;

/*------------------------------------------------------------.
| yynewstate -- Push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
 yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed.  So pushing a state here evens the stacks.  */
  yyssp++;

 yysetstate:
  *yyssp = yystate;

  if (yyss + yystacksize - 1 <= yyssp)
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYSIZE_T yysize = yyssp - yyss + 1;

#ifdef yyoverflow
      {
	/* Give user a chance to reallocate the stack.  Use copies of
	   these so that the &'s don't force the real ones into
	   memory.  */
	YYSTYPE *yyvs1 = yyvs;
	yytype_int16 *yyss1 = yyss;

	/* Each stack pointer address is followed by the size of the
	   data in use in that stack, in bytes.  This used to be a
	   conditional around just the two extra args, but that might
	   be undefined if yyoverflow is a macro.  */
	yyoverflow (YY_("memory exhausted"),
		    &yyss1, yysize * sizeof (*yyssp),
		    &yyvs1, yysize * sizeof (*yyvsp),
		    &yystacksize);

	yyss = yyss1;
	yyvs = yyvs1;
      }
#else /* no yyoverflow */
# ifndef YYSTACK_RELOCATE
      goto yyexhaustedlab;
# else
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
	goto yyexhaustedlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
	yystacksize = YYMAXDEPTH;

      {
	yytype_int16 *yyss1 = yyss;
	union yyalloc *yyptr =
	  (union yyalloc *) YYSTACK_ALLOC (YYSTACK_BYTES (yystacksize));
	if (! yyptr)
	  goto yyexhaustedlab;
	YYSTACK_RELOCATE (yyss_alloc, yyss);
	YYSTACK_RELOCATE (yyvs_alloc, yyvs);
#  undef YYSTACK_RELOCATE
	if (yyss1 != yyssa)
	  YYSTACK_FREE (yyss1);
      }
# endif
#endif /* no yyoverflow */

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;

      YYDPRINTF ((stderr, "Stack size increased to %lu\n",
		  (unsigned long int) yystacksize));

      if (yyss + yystacksize - 1 <= yyssp)
	YYABORT;
    }

  YYDPRINTF ((stderr, "Entering state %d\n", yystate));

  if (yystate == YYFINAL)
    YYACCEPT;

  goto yybackup;

/*-----------.
| yybackup.  |
`-----------*/
yybackup:

  /* Do appropriate processing given the current state.  Read a
     lookahead token if we need one and don't already have one.  */

  /* First try to decide what to do without reference to lookahead token.  */
  yyn = yypact[yystate];
  if (yyn == YYPACT_NINF)
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either YYEMPTY or YYEOF or a valid lookahead symbol.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token: "));
      yychar = YYLEX;
    }

  if (yychar <= YYEOF)
    {
      yychar = yytoken = YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yyn == 0 || yyn == YYTABLE_NINF)
	goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  /* Shift the lookahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);

  /* Discard the shifted token.  */
  yychar = YYEMPTY;

  yystate = yyn;
  *++yyvsp = yylval;

  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- Do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     `$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
        case 14:

/* Line 1455 of yacc.c  */
#line 79 "source.y"
    { fprintf(out, "ARGS([%s])\n", (yyvsp[(3) - (5)].string)); free((yyvsp[(3) - (5)].string)); }
    break;

  case 15:

/* Line 1455 of yacc.c  */
#line 80 "source.y"
    {fprintf(out, "MOVE()\n"); }
    break;

  case 18:

/* Line 1455 of yacc.c  */
#line 85 "source.y"
    {fprintf(out, "WITH_ANGLE(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 19:

/* Line 1455 of yacc.c  */
#line 86 "source.y"
    {fprintf(out, "WITH_SPEED(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 20:

/* Line 1455 of yacc.c  */
#line 87 "source.y"
    { fprintf(out, "WITH_DESTINATION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 21:

/* Line 1455 of yacc.c  */
#line 88 "source.y"
    { fprintf(out, "WITH_POSITION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 22:

/* Line 1455 of yacc.c  */
#line 89 "source.y"
    {fprintf(out, "WITH_ID(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 23:

/* Line 1455 of yacc.c  */
#line 91 "source.y"
    {fprintf(out, "CALL(%s, [%s])\n", (yyvsp[(2) - (6)].string), (yyvsp[(4) - (6)].string)); free((yyvsp[(4) - (6)].string)); }
    break;

  case 24:

/* Line 1455 of yacc.c  */
#line 92 "source.y"
    {fprintf(out, "CALL(%s, [])\n", (yyvsp[(2) - (5)].string)); }
    break;

  case 25:

/* Line 1455 of yacc.c  */
#line 93 "source.y"
    {fprintf(out, "DELAY(%s)\n", (yyvsp[(3) - (5)].string)); free((yyvsp[(3) - (5)].string)); }
    break;

  case 26:

/* Line 1455 of yacc.c  */
#line 94 "source.y"
    {fprintf(out, "MAKE()\n"); }
    break;

  case 27:

/* Line 1455 of yacc.c  */
#line 95 "source.y"
    {fprintf(out, "MAKE(%s, [%s])\n", (yyvsp[(6) - (10)].string), (yyvsp[(8) - (10)].string)); free((yyvsp[(6) - (10)].string)); }
    break;

  case 28:

/* Line 1455 of yacc.c  */
#line 96 "source.y"
    {fprintf(out, "MAKE(%s, [])\n", (yyvsp[(6) - (9)].string)); free((yyvsp[(6) - (9)].string)); }
    break;

  case 31:

/* Line 1455 of yacc.c  */
#line 99 "source.y"
    {fprintf(out, "WITH_ANGLE(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 32:

/* Line 1455 of yacc.c  */
#line 100 "source.y"
    {fprintf(out, "WITH_SPEED(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 33:

/* Line 1455 of yacc.c  */
#line 101 "source.y"
    {fprintf(out, "WITH_TYPE(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 34:

/* Line 1455 of yacc.c  */
#line 102 "source.y"
    {fprintf(out, "WITH_ID(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 35:

/* Line 1455 of yacc.c  */
#line 103 "source.y"
    { fprintf(out, "WITH_DESTINATION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 36:

/* Line 1455 of yacc.c  */
#line 104 "source.y"
    { fprintf(out, "WITH_POSITION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 37:

/* Line 1455 of yacc.c  */
#line 105 "source.y"
    {fprintf(out, "START_LOOP(%d, %s)\n", loopId++, (yyvsp[(3) - (4)].string)); free((yyvsp[(3) - (4)].string)); }
    break;

  case 38:

/* Line 1455 of yacc.c  */
#line 105 "source.y"
    {fprintf(out, "END_LOOP(%d)\n", --loopId); }
    break;

  case 39:

/* Line 1455 of yacc.c  */
#line 106 "source.y"
    {fprintf(out, "START_CASE(%d, %s, %s, %s)\n", caseId++, (yyvsp[(3) - (6)].string), (yyvsp[(4) - (6)].string), (yyvsp[(5) - (6)].string)); free((yyvsp[(3) - (6)].string)); free((yyvsp[(5) - (6)].string)); }
    break;

  case 40:

/* Line 1455 of yacc.c  */
#line 106 "source.y"
    {fprintf(out, "END_CASE(%d)\n", --caseId); }
    break;

  case 41:

/* Line 1455 of yacc.c  */
#line 107 "source.y"
    { fprintf(out, "START_BEHAVIOR(%d, %s, [%s])\n", behaviorId++, (yyvsp[(2) - (5)].string), (yyvsp[(4) - (5)].string)); free((yyvsp[(4) - (5)].string)); }
    break;

  case 42:

/* Line 1455 of yacc.c  */
#line 107 "source.y"
    {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); }
    break;

  case 43:

/* Line 1455 of yacc.c  */
#line 108 "source.y"
    { fprintf(out, "START_BEHAVIOR(%d, %s, [])\n", behaviorId++, (yyvsp[(2) - (4)].string)); }
    break;

  case 44:

/* Line 1455 of yacc.c  */
#line 108 "source.y"
    {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); }
    break;

  case 45:

/* Line 1455 of yacc.c  */
#line 111 "source.y"
    { (yyval.string) = getFirstArgsDeclaration((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); }
    break;

  case 46:

/* Line 1455 of yacc.c  */
#line 112 "source.y"
    { (yyval.string) = getArgsDeclaration((yyvsp[(1) - (5)].string), (yyvsp[(3) - (5)].string), (yyvsp[(5) - (5)].string)); }
    break;

  case 47:

/* Line 1455 of yacc.c  */
#line 115 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 48:

/* Line 1455 of yacc.c  */
#line 116 "source.y"
    { (yyval.string) = getArgsCall((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); }
    break;

  case 49:

/* Line 1455 of yacc.c  */
#line 119 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 50:

/* Line 1455 of yacc.c  */
#line 120 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 51:

/* Line 1455 of yacc.c  */
#line 121 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 52:

/* Line 1455 of yacc.c  */
#line 123 "source.y"
    { (yyval.string) = BOOL_OP_EQ; }
    break;

  case 53:

/* Line 1455 of yacc.c  */
#line 124 "source.y"
    { (yyval.string) = BOOL_OP_INF; }
    break;

  case 54:

/* Line 1455 of yacc.c  */
#line 125 "source.y"
    { (yyval.string) =BOOL_OP_INF_EQ; }
    break;

  case 55:

/* Line 1455 of yacc.c  */
#line 126 "source.y"
    { (yyval.string) = BOOL_OP_SUP; }
    break;

  case 56:

/* Line 1455 of yacc.c  */
#line 127 "source.y"
    { (yyval.string) =BOOL_OP_SUP_EQ; }
    break;

  case 57:

/* Line 1455 of yacc.c  */
#line 128 "source.y"
    { (yyval.string) =BOOL_OP_DIFF; }
    break;

  case 58:

/* Line 1455 of yacc.c  */
#line 131 "source.y"
    {fprintf(out, "VAR_AFF(%s, %s, %s)\n", (yyvsp[(2) - (7)].string), (yyvsp[(4) - (7)].string), (yyvsp[(6) - (7)].string)); free((yyvsp[(6) - (7)].string)); }
    break;

  case 59:

/* Line 1455 of yacc.c  */
#line 133 "source.y"
    {fprintf(out, "AFF(%s, %s)\n", (yyvsp[(1) - (4)].string), (yyvsp[(3) - (4)].string)); free((yyvsp[(3) - (4)].string)); }
    break;

  case 60:

/* Line 1455 of yacc.c  */
#line 136 "source.y"
    { (yyval.string) = TYPE_FLOAT; }
    break;

  case 61:

/* Line 1455 of yacc.c  */
#line 137 "source.y"
    { (yyval.string) = TYPE_VECTOR; }
    break;

  case 62:

/* Line 1455 of yacc.c  */
#line 138 "source.y"
    { (yyval.string) = TYPE_STRING; }
    break;

  case 63:

/* Line 1455 of yacc.c  */
#line 139 "source.y"
    { (yyval.string) = TYPE_NUMBER; }
    break;

  case 64:

/* Line 1455 of yacc.c  */
#line 142 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, \"%s\")\n", tempName, TYPE_STRING, (yyvsp[(2) - (3)].string)); (yyval.string) = tempName; }
    break;

  case 65:

/* Line 1455 of yacc.c  */
#line 143 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 66:

/* Line 1455 of yacc.c  */
#line 146 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 67:

/* Line 1455 of yacc.c  */
#line 147 "source.y"
    { char* tempName = getNewVarTempName(); char* vector = getNewVector((yyvsp[(2) - (5)].string), (yyvsp[(4) - (5)].string)); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_VECTOR, vector); free(vector); (yyval.string) = tempName; }
    break;

  case 68:

/* Line 1455 of yacc.c  */
#line 148 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 69:

/* Line 1455 of yacc.c  */
#line 151 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 70:

/* Line 1455 of yacc.c  */
#line 152 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (1)].string)); (yyval.string) = tempName; }
    break;

  case 71:

/* Line 1455 of yacc.c  */
#line 155 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 72:

/* Line 1455 of yacc.c  */
#line 156 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, COS(%s))\n", tempName, TYPE_FLOAT, (yyvsp[(3) - (4)].string)); (yyval.string) = tempName; free((yyvsp[(3) - (4)].string)); }
    break;

  case 73:

/* Line 1455 of yacc.c  */
#line 157 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, SIN(%s))\n", tempName, TYPE_FLOAT, (yyvsp[(3) - (4)].string)); (yyval.string) = tempName; free((yyvsp[(3) - (4)].string)); }
    break;

  case 74:

/* Line 1455 of yacc.c  */
#line 158 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, TAN(%s))\n", tempName, TYPE_FLOAT, (yyvsp[(3) - (4)].string)); (yyval.string) = tempName; free((yyvsp[(3) - (4)].string)); }
    break;

  case 75:

/* Line 1455 of yacc.c  */
#line 159 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s.%s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); (yyval.string) = tempName; }
    break;

  case 76:

/* Line 1455 of yacc.c  */
#line 160 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (1)].string)); (yyval.string) = tempName; }
    break;

  case 77:

/* Line 1455 of yacc.c  */
#line 161 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_ADD); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 78:

/* Line 1455 of yacc.c  */
#line 162 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_SUB); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 79:

/* Line 1455 of yacc.c  */
#line 163 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_MUL); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 80:

/* Line 1455 of yacc.c  */
#line 164 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_DIV); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 81:

/* Line 1455 of yacc.c  */
#line 165 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_MOD); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 82:

/* Line 1455 of yacc.c  */
#line 166 "source.y"
    { (yyval.string) = (yyvsp[(2) - (3)].string); }
    break;



/* Line 1455 of yacc.c  */
#line 2092 "y.tab.c"
      default: break;
    }
  YY_SYMBOL_PRINT ("-> $$ =", yyr1[yyn], &yyval, &yyloc);

  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);

  *++yyvsp = yyval;

  /* Now `shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTOKENS] + *yyssp;
  if (0 <= yystate && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTOKENS];

  goto yynewstate;


/*------------------------------------.
| yyerrlab -- here on detecting error |
`------------------------------------*/
yyerrlab:
  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
#if ! YYERROR_VERBOSE
      yyerror (YY_("syntax error"));
#else
      {
	YYSIZE_T yysize = yysyntax_error (0, yystate, yychar);
	if (yymsg_alloc < yysize && yymsg_alloc < YYSTACK_ALLOC_MAXIMUM)
	  {
	    YYSIZE_T yyalloc = 2 * yysize;
	    if (! (yysize <= yyalloc && yyalloc <= YYSTACK_ALLOC_MAXIMUM))
	      yyalloc = YYSTACK_ALLOC_MAXIMUM;
	    if (yymsg != yymsgbuf)
	      YYSTACK_FREE (yymsg);
	    yymsg = (char *) YYSTACK_ALLOC (yyalloc);
	    if (yymsg)
	      yymsg_alloc = yyalloc;
	    else
	      {
		yymsg = yymsgbuf;
		yymsg_alloc = sizeof yymsgbuf;
	      }
	  }

	if (0 < yysize && yysize <= yymsg_alloc)
	  {
	    (void) yysyntax_error (yymsg, yystate, yychar);
	    yyerror (yymsg);
	  }
	else
	  {
	    yyerror (YY_("syntax error"));
	    if (yysize != 0)
	      goto yyexhaustedlab;
	  }
      }
#endif
    }



  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
	 error, discard it.  */

      if (yychar <= YYEOF)
	{
	  /* Return failure if at end of input.  */
	  if (yychar == YYEOF)
	    YYABORT;
	}
      else
	{
	  yydestruct ("Error: discarding",
		      yytoken, &yylval);
	  yychar = YYEMPTY;
	}
    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:

  /* Pacify compilers like GCC when the user code never invokes
     YYERROR and the label yyerrorlab therefore never appears in user
     code.  */
  if (/*CONSTCOND*/ 0)
     goto yyerrorlab;

  /* Do not reclaim the symbols of the rule which action triggered
     this YYERROR.  */
  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;	/* Each real token shifted decrements this.  */

  for (;;)
    {
      yyn = yypact[yystate];
      if (yyn != YYPACT_NINF)
	{
	  yyn += YYTERROR;
	  if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYTERROR)
	    {
	      yyn = yytable[yyn];
	      if (0 < yyn)
		break;
	    }
	}

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
	YYABORT;


      yydestruct ("Error: popping",
		  yystos[yystate], yyvsp);
      YYPOPSTACK (1);
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  *++yyvsp = yylval;


  /* Shift the error token.  */
  YY_SYMBOL_PRINT ("Shifting", yystos[yyn], yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;

/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;

#if !defined(yyoverflow) || YYERROR_VERBOSE
/*-------------------------------------------------.
| yyexhaustedlab -- memory exhaustion comes here.  |
`-------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  /* Fall through.  */
#endif

yyreturn:
  if (yychar != YYEMPTY)
     yydestruct ("Cleanup: discarding lookahead",
		 yytoken, &yylval);
  /* Do not reclaim the symbols of the rule which action triggered
     this YYABORT or YYACCEPT.  */
  YYPOPSTACK (yylen);
  YY_STACK_PRINT (yyss, yyssp);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
		  yystos[*yyssp], yyvsp);
      YYPOPSTACK (1);
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif
#if YYERROR_VERBOSE
  if (yymsg != yymsgbuf)
    YYSTACK_FREE (yymsg);
#endif
  /* Make sure YYID is used.  */
  return YYID (yyresult);
}



/* Line 1675 of yacc.c  */
#line 168 "source.y"


void main(int argc, char** argv) {

   if(argc == 1)
   {
      printf("No path specified.");
      exit(-1);
   }
      
   out = fopen(argv[1], "w" );
   yyparse();
   fclose(out);
   exit(0);
}

void yyerror(const char *s)
{
   fprintf(stderr, "%s\n", s);
}

int yywrap() {
   return 1;
}

char* getNewDecimal(char* left, char* right)
{
   int size = strlen(left) + strlen(right) + 2;
   char* result = (char*)malloc(size);
   snprintf(result, size, "%s.%s", left, right);
   free(left); 
   free(right);
   return result;
}

char* getNewArithmeticOperation(char * left, char * right, int opCode)
{
   int size = strlen(left) + strlen(right) + 8;
   char* result = (char*)malloc(size);
   
   switch(opCode)
   {
      case ARITHMETIC_OPERATION_CODE_ADD : snprintf(result, size, "ADD(%s; %s)", left, right); break;
      case ARITHMETIC_OPERATION_CODE_SUB : snprintf(result, size, "SUB(%s; %s)", left, right); break;
      case ARITHMETIC_OPERATION_CODE_MUL : snprintf(result, size, "MUL(%s; %s)", left, right); break;
      case ARITHMETIC_OPERATION_CODE_DIV : snprintf(result, size, "DIV(%s; %s)", left, right); break;
      case ARITHMETIC_OPERATION_CODE_MOD : snprintf(result, size, "MOD(%s; %s)", left, right); break;
   }
   
   free(left); 
   free(right);
   return result;
}

char* getNewVector(char* left, char* right)
{
   int size = strlen(left) + strlen(right) + 5;
   char* result = (char*)malloc(size);
   snprintf(result, size, "[%s; %s]", left, right);
   free(left); 
   free(right);
   return result;
}


char* getNewString(char* value)
{
   int size = strlen(value) + 3;
   char* result = (char*)malloc(size);
   snprintf(result, size, "\"%s\"", value);
   free(value); 
   return result;
}

char* getNewVarTempName()
{
   char* result = (char*)malloc(12);
   snprintf(result, 12, "<temp%d>", varTempId++);
   return result;
}

char* getArgsDeclaration(char * id, char * type, char* currentDeclaration)
{
   int size = strlen(currentDeclaration) + strlen(id) + strlen(type) + 7;
   char* result = (char*)malloc(size);
   snprintf(result, size, "(%s: %s); %s", id, type, currentDeclaration);
   free(id); 
   free(currentDeclaration);
   return result;
}

char* getFirstArgsDeclaration(char * id, char * type)
{
   int size = strlen(id) + strlen(type) + 5;
   char* result = (char*)malloc(size);
   snprintf(result, size, "(%s: %s)", id, type);
   free(id); 
   return result;
}

char* getArgsCall(char * value, char* currentValues)
{
   int size = strlen(value) + strlen(currentValues) + 3;
   char* result = (char*)malloc(size);
   snprintf(result, size, "%s; %s", value, currentValues);
   free(value); 
   free(currentValues);
   return result;
}

void replace_char(char *str, char orig, char rep)
{
   int i =0;
   int length = strlen(str);
   for(i=0;i<length;i++)
   {
      if(str[i] == orig)
         str[i] = rep;
   }
}

