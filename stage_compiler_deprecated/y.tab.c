
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
	#define ACTION_CREATE 0
	#define ACTION_MOVE 1
	#define ACTION_SHOOT 2
	#define ACTION_BREAK 3
	#define ACTION_LET 4
	#define ACTION_UNLET 5
	#define ACTION_AVAR 6
	#define ACTION_LOOP 7
	#define ACTION_END 8
	FILE* file;
	int id_enemy = 0;
	char time[5];
	char end[5];
	char cadence[5];
	int nbCreate=0;
	float lastTime;
	float lastEnd;
	char savedLine[300];
	int saveLine=0;
	float lastCadence;
	float waitTime;
	float waitEnd;
	float waitCadence;
	char type[50];
	char currentAction[50];
	char typeThen = 's';
	int foreach=0;
	char loopState[6];
	char instr[5];
	char letsVar[20][50];
	int letID = 0;
	char listeIds[20][4];
	int indexListe = 0;
	int indexListeTemp=0;
	int firstTimeBreak=1;
	void getExpression(const char* buffer, char* expr);
	int getLoopState(const char* buffer);
	int getFirstIndex(const char* buffer, char c);
	int findAction(const char* buffer);
	int getLastNb(const char* buffer);
	int getFirstNb(const char* buffer);
	void getEnemyType(const char* buffer, char* type);
	void getReste(const char* buffer, char* reste);
	void getOption(const char* buffer, char* option);
	int convertOptiontoIntArray(const char* options, int* ids);
	float getEnd(const char* buffer);
	float getTime(const char* buffer);
	void setTime(char* resteBuffer, float time);
	void cutUntilV(const char* buffer, char* reste);
	int getSync(const char* buffer);
	int calculPas(float time, float end, float cadence);
	int getID(const char* buffer);
	float getCadence(const char* buffer);
	int yylex();
	void yyerror(const char *s);


/* Line 189 of yacc.c  */
#line 136 "y.tab.c"

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

/* Line 214 of yacc.c  */
#line 66 "source.y"

   char* string;



/* Line 214 of yacc.c  */
#line 272 "y.tab.c"
} YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif


/* Copy the second part of user declarations.  */


/* Line 264 of yacc.c  */
#line 284 "y.tab.c"

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
#define YYFINAL  6
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   165

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  48
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  53
/* YYNRULES -- Number of rules.  */
#define YYNRULES  84
/* YYNRULES -- Number of states.  */
#define YYNSTATES  186

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   302

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
      45,    46,    47
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const yytype_uint16 yyprhs[] =
{
       0,     0,     3,     6,     8,    11,    13,    14,    15,    25,
      26,    27,    49,    53,    56,    58,    60,    62,    64,    66,
      70,    71,    76,    77,    80,    88,    89,    99,   100,   106,
     107,   113,   114,   120,   121,   129,   130,   131,   132,   139,
     143,   144,   151,   155,   156,   157,   158,   165,   167,   170,
     172,   174,   175,   176,   180,   181,   191,   192,   214,   216,
     218,   220,   222,   225,   227,   228,   234,   235,   240,   242,
     251,   256,   261,   263,   267,   269,   271,   273,   275,   277,
     279,   281,   283,   285,   287
};

/* YYRHS -- A `-1'-separated list of the rules' RHS.  */
static const yytype_int8 yyrhs[] =
{
      49,     0,    -1,    50,    49,    -1,    50,    -1,    53,    49,
      -1,    53,    -1,    -1,    -1,     3,    18,    46,     9,    46,
      51,    59,    52,    56,    -1,    -1,    -1,     3,    18,    46,
       9,    46,    35,     8,    18,    46,     9,    46,    35,     7,
      18,    46,     9,    46,    54,    59,    55,    56,    -1,    31,
      57,    32,    -1,    58,    57,    -1,    58,    -1,    65,    -1,
      76,    -1,    60,    -1,    63,    -1,    33,    61,    34,    -1,
      -1,    47,    39,    97,    37,    -1,    -1,    62,    61,    -1,
      19,    47,    39,    46,     9,    46,    37,    -1,    -1,     5,
      18,    33,    47,    38,    46,    34,    64,    56,    -1,    -1,
      23,    66,    18,    30,    78,    -1,    -1,    23,    18,    44,
      68,    75,    -1,    -1,    23,    18,    43,    70,    75,    -1,
      -1,    11,    25,    18,    21,    72,    82,    22,    -1,    -1,
      -1,    -1,    21,    73,    82,    22,    74,    71,    -1,    31,
      71,    32,    -1,    -1,     4,    92,    31,    84,    77,    32,
      -1,    31,    79,    32,    -1,    -1,    -1,    -1,    21,    80,
      82,    22,    81,    79,    -1,    96,    -1,    96,    82,    -1,
      86,    -1,    88,    -1,    -1,    -1,    83,    85,    84,    -1,
      -1,     3,    20,    46,     9,    46,    87,    31,    91,    32,
      -1,    -1,     3,    20,    46,     9,    46,    35,     8,    18,
      46,     9,    46,    35,     7,    18,    46,     9,    46,    89,
      31,    91,    32,    -1,    67,    -1,    69,    -1,    60,    -1,
      90,    -1,    90,    91,    -1,    18,    -1,    -1,    18,    21,
      93,    94,    22,    -1,    -1,    46,    38,    95,    94,    -1,
      46,    -1,    98,    39,    33,    97,    38,    97,    34,    37,
      -1,    99,    39,    97,    37,    -1,   100,    39,    97,    37,
      -1,    45,    -1,    46,     9,    46,    -1,    46,    -1,    47,
      -1,    24,    -1,    26,    -1,    27,    -1,    12,    -1,    28,
      -1,     6,    -1,    13,    -1,    10,    -1,    29,    -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const yytype_uint8 yyrline[] =
{
       0,    75,    75,    75,    76,    76,    77,    77,    77,    78,
      78,    78,    79,    80,    80,    81,    81,    81,    81,    82,
      83,    84,    85,    86,    88,    89,    89,    98,    98,    99,
      99,   100,   100,   102,   102,   123,   125,   135,   124,   136,
     137,   137,   138,   139,   140,   140,   140,   141,   142,   143,
     144,   145,   146,   146,   148,   148,   155,   155,   162,   162,
     162,   163,   163,   165,   166,   166,   167,   167,   168,   169,
     170,   171,   172,   173,   174,   175,   176,   176,   176,   176,
     177,   177,   177,   178,   178
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || YYTOKEN_TABLE
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "tON", "tTHEN", "tLOOP", "tFSPEED",
  "tEVERY", "tFOR", "tDOT", "tPARTICLE", "tSHARP", "tFDIR", "tHEALTH",
  "tADD", "tASYNC", "tWAIT", "tSYNC", "tDP", "tLET", "tADP", "tCO", "tCF",
  "tACTION", "tDEST", "tALL", "tPOS", "tDIR", "tSPEED", "tTYPE", "tCREATE",
  "tAO", "tAF", "tPO", "tPF", "tBARRE", "tFL", "tPV", "tV", "tEQ", "tSUB",
  "tMUL", "tDIV", "tSHOOT", "tMOVE", "tEXP", "tNB", "tSTRING", "$accept",
  "Scpt", "On", "$@1", "$@2", "Onl", "$@3", "$@4", "Body", "Code", "Instr",
  "Lets", "AffVar", "ListeLet", "Let", "Loop", "$@5", "Create", "$@6",
  "Move", "$@7", "Shoot", "$@8", "SpecialListeDeclaration", "$@9", "$@10",
  "$@11", "SpecialCaracs", "Then", "$@12", "Caracs", "ListeDeclaration",
  "$@13", "$@14", "ListeAff", "SpecialOn", "ListeSpecialOn", "$@15", "Onp",
  "$@16", "Onlp", "$@17", "SpecialActions", "ListeSpecialActions",
  "Option", "$@18", "ListeNb", "$@19", "Aff", "Exp", "Vectors", "Numbers",
  "Objects", 0
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
     295,   296,   297,   298,   299,   300,   301,   302
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint8 yyr1[] =
{
       0,    48,    49,    49,    49,    49,    51,    52,    50,    54,
      55,    53,    56,    57,    57,    58,    58,    58,    58,    59,
      59,    60,    61,    61,    62,    64,    63,    66,    65,    68,
      67,    70,    69,    72,    71,    71,    73,    74,    71,    75,
      77,    76,    78,    79,    80,    81,    79,    82,    82,    83,
      83,    84,    85,    84,    87,    86,    89,    88,    90,    90,
      90,    91,    91,    92,    93,    92,    95,    94,    94,    96,
      96,    96,    97,    97,    97,    97,    98,    98,    98,    98,
      99,    99,    99,   100,   100
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const yytype_uint8 yyr2[] =
{
       0,     2,     2,     1,     2,     1,     0,     0,     9,     0,
       0,    21,     3,     2,     1,     1,     1,     1,     1,     3,
       0,     4,     0,     2,     7,     0,     9,     0,     5,     0,
       5,     0,     5,     0,     7,     0,     0,     0,     6,     3,
       0,     6,     3,     0,     0,     0,     6,     1,     2,     1,
       1,     0,     0,     3,     0,     9,     0,    21,     1,     1,
       1,     1,     2,     1,     0,     5,     0,     4,     1,     8,
       4,     4,     1,     3,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     1
};

/* YYDEFACT[STATE-NAME] -- Default rule to reduce with in state
   STATE-NUM when YYTABLE doesn't specify something else to do.  Zero
   means the default is an error.  */
static const yytype_uint8 yydefact[] =
{
       0,     0,     0,     3,     5,     0,     1,     2,     4,     0,
       0,     6,     0,    20,     0,    22,     7,     0,     0,     0,
      22,     0,     0,     0,    19,    23,     0,     8,     0,     0,
       0,     0,    27,     0,     0,    14,    17,    18,    15,    16,
       0,     0,    63,     0,     0,     0,     0,    12,    13,     0,
       0,    64,    51,     0,     0,    72,    74,    75,     0,     0,
       0,     0,     0,    52,    40,    49,    50,     0,     0,     0,
      21,     0,    24,    68,     0,     0,    51,     0,     0,    43,
      28,    73,     0,    66,    65,     0,    53,    41,     0,    44,
       0,     0,     0,     0,    25,     0,    42,     9,    67,    54,
       0,    81,    83,    79,    82,    76,    77,    78,    80,    84,
       0,    47,     0,     0,     0,    20,     0,     0,    26,    45,
      48,     0,     0,     0,    10,     0,     0,    43,     0,     0,
       0,     0,     0,     0,    60,    58,    59,    61,     0,    46,
       0,    70,    71,    11,     0,     0,    62,    55,     0,     0,
      31,    29,     0,     0,     0,     0,     0,     0,    35,    32,
      30,    69,     0,     0,    36,     0,     0,     0,     0,    39,
       0,     0,     0,     0,    33,    37,    56,     0,    35,     0,
       0,    38,     0,    34,     0,    57
};

/* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,     2,     3,    13,    21,     4,   115,   131,    27,    34,
      35,    16,   134,    19,    20,    37,   100,    38,    45,   135,
     155,   136,   154,   165,   177,   168,   178,   159,    39,    77,
      80,    90,    95,   127,   110,    63,    64,    76,    65,   117,
      66,   179,   137,   138,    43,    61,    74,    92,   111,    58,
     112,   113,   114
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -137
static const yytype_int16 yypact[] =
{
       7,    -3,    19,     7,     7,   -18,  -137,  -137,  -137,    20,
     -16,     5,    25,     8,    24,    28,  -137,     2,     3,     9,
      28,    13,    40,    12,  -137,  -137,    -2,  -137,     6,    14,
      35,    36,  -137,    16,    26,    -2,  -137,  -137,  -137,  -137,
      21,    50,    41,    30,    31,    45,   -33,  -137,  -137,    58,
      22,  -137,    64,    27,    39,  -137,    61,  -137,    34,    54,
      38,    32,    53,  -137,  -137,  -137,  -137,    42,    46,    33,
    -137,    37,  -137,    43,    60,    44,    64,    52,    47,    55,
    -137,  -137,    76,  -137,  -137,    77,  -137,  -137,    57,  -137,
      56,    48,    32,    49,  -137,    10,  -137,  -137,  -137,    62,
      13,  -137,  -137,  -137,  -137,  -137,  -137,  -137,  -137,  -137,
      65,    10,    59,    63,    66,     8,    81,    68,  -137,  -137,
    -137,    67,   -33,   -33,  -137,    74,   -15,    55,   -33,    69,
      70,    13,    71,    78,  -137,  -137,  -137,   -15,    72,  -137,
      73,  -137,  -137,  -137,    92,   -19,  -137,  -137,   -33,    75,
    -137,  -137,    79,    80,    83,    83,    82,    96,    -4,  -137,
    -137,  -137,    90,    84,  -137,    86,    85,    94,    10,  -137,
     101,    95,    98,    87,  -137,  -137,  -137,    10,    -4,    91,
     102,  -137,   -15,  -137,    93,  -137
};

/* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -137,    23,  -137,  -137,  -137,  -137,  -137,  -137,   -96,    88,
    -137,    11,   -17,   107,  -137,  -137,  -137,  -137,  -137,  -137,
    -137,  -137,  -137,   -50,  -137,  -137,  -137,   -26,  -137,  -137,
    -137,    15,  -137,  -137,  -111,  -137,    89,  -137,  -137,  -137,
    -137,  -137,  -137,  -136,  -137,  -137,    51,  -137,  -137,  -117,
    -137,  -137,  -137
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If zero, do what YYDEFACT says.
   If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -1
static const yytype_uint8 yytable[] =
{
     120,   146,    30,    31,   118,   129,   130,   163,   133,    36,
       1,   140,    55,    56,    57,     5,   101,   164,    36,     6,
     102,    32,   103,   104,   150,   151,     7,     8,     9,    10,
      11,   152,    33,    14,   105,   143,   106,   107,   108,   109,
      12,    15,    17,    24,    26,    33,   184,    18,    22,    28,
      23,    29,    40,    42,    44,    46,    49,   172,    47,    50,
      41,    52,    51,    54,    53,    59,   180,    62,    60,    68,
      69,    70,    71,    75,    67,    72,    89,    79,    73,    81,
      78,    83,    84,    82,    87,    91,    93,   119,    96,   125,
      85,    94,   132,    88,    97,    99,   145,   116,   121,   126,
     128,   149,   122,   162,   147,   123,   141,   142,   166,   167,
     173,   148,   171,   156,   158,   157,   174,   144,   169,   161,
     175,   153,   182,    48,   183,   185,   124,    25,   181,   160,
       0,   170,     0,   176,     0,     0,     0,     0,     0,     0,
       0,     0,   139,    98,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,    86
};

static const yytype_int16 yycheck[] =
{
     111,   137,     4,     5,   100,   122,   123,    11,    23,    26,
       3,   128,    45,    46,    47,    18,     6,    21,    35,     0,
      10,    23,    12,    13,    43,    44,     3,     4,    46,     9,
      46,   148,    47,     8,    24,   131,    26,    27,    28,    29,
      35,    33,    18,    34,    31,    47,   182,    19,    46,     9,
      47,    39,    46,    18,    18,    39,    35,   168,    32,     9,
      46,    31,    21,    18,    33,     7,   177,     3,    46,    30,
       9,    37,    18,    20,    47,    37,    21,    31,    46,    46,
      38,    38,    22,    46,    32,     9,     9,    22,    32,     8,
      46,    34,    18,    46,    46,    46,    18,    35,    39,    31,
      33,     9,    39,     7,    32,    39,    37,    37,    18,    25,
       9,    38,    18,    34,    31,    35,    21,    46,    32,    37,
      22,    46,    31,    35,    22,    32,   115,    20,   178,   155,
      -1,    46,    -1,    46,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,   127,    92,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,    -1,
      -1,    -1,    -1,    -1,    -1,    76
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,     3,    49,    50,    53,    18,     0,    49,    49,    46,
       9,    46,    35,    51,     8,    33,    59,    18,    19,    61,
      62,    52,    46,    47,    34,    61,    31,    56,     9,    39,
       4,     5,    23,    47,    57,    58,    60,    63,    65,    76,
      46,    46,    18,    92,    18,    66,    39,    32,    57,    35,
       9,    21,    31,    33,    18,    45,    46,    47,    97,     7,
      46,    93,     3,    83,    84,    86,    88,    47,    30,     9,
      37,    18,    37,    46,    94,    20,    85,    77,    38,    31,
      78,    46,    46,    38,    22,    46,    84,    32,    46,    21,
      79,     9,    95,     9,    34,    80,    32,    46,    94,    46,
      64,     6,    10,    12,    13,    24,    26,    27,    28,    29,
      82,    96,    98,    99,   100,    54,    35,    87,    56,    22,
      82,    39,    39,    39,    59,     8,    31,    81,    33,    97,
      97,    55,    18,    23,    60,    67,    69,    90,    91,    79,
      97,    37,    37,    56,    46,    18,    91,    32,    38,     9,
      43,    44,    97,    46,    70,    68,    34,    35,    31,    75,
      75,    37,     7,    11,    21,    71,    18,    25,    73,    32,
      46,    18,    82,     9,    21,    22,    46,    72,    74,    89,
      82,    71,    31,    22,    91,    32
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
        case 6:

/* Line 1455 of yacc.c  */
#line 77 "source.y"
    { snprintf(loopState, sizeof(loopState), "false"); }
    break;

  case 7:

/* Line 1455 of yacc.c  */
#line 77 "source.y"
    { snprintf(time, sizeof(time), "%s.%s", (yyvsp[(3) - (7)].string), (yyvsp[(5) - (7)].string)) ; snprintf(end, sizeof(end), "%.2f", 0.0) ; snprintf(cadence, sizeof(cadence), "%.2f", 0.0) ; }
    break;

  case 8:

/* Line 1455 of yacc.c  */
#line 77 "source.y"
    { int indice = 0; for(indice=0;indice<letID;indice++) fprintf(file, "unlet(%s)\n", letsVar[indice]); letID=0;}
    break;

  case 9:

/* Line 1455 of yacc.c  */
#line 78 "source.y"
    { snprintf(loopState, sizeof(loopState), "true"); }
    break;

  case 10:

/* Line 1455 of yacc.c  */
#line 78 "source.y"
    {snprintf(time, sizeof(time), "%s.%s", (yyvsp[(3) - (19)].string), (yyvsp[(5) - (19)].string)); snprintf(end, sizeof(end), "%s.%s", (yyvsp[(9) - (19)].string), (yyvsp[(11) - (19)].string)) ; snprintf(end, sizeof(end), "%.2f", atof(time)+atof(end)) ; snprintf(cadence, sizeof(cadence), "%s.%s", (yyvsp[(15) - (19)].string), (yyvsp[(17) - (19)].string)) ; }
    break;

  case 11:

/* Line 1455 of yacc.c  */
#line 78 "source.y"
    { int indice = 0; for(indice=0;indice<letID;indice++) fprintf(file, "unlet(%s)\n", letsVar[indice]); letID=0;}
    break;

  case 21:

/* Line 1455 of yacc.c  */
#line 84 "source.y"
    { fprintf(file, "avar(%s<=%s)\n", (yyvsp[(1) - (4)].string), (yyvsp[(3) - (4)].string)); }
    break;

  case 24:

/* Line 1455 of yacc.c  */
#line 88 "source.y"
    { fprintf(file, "let(%s<=%s.%s, %s)\n", (yyvsp[(2) - (7)].string), (yyvsp[(4) - (7)].string), (yyvsp[(6) - (7)].string), loopState); snprintf(letsVar[letID], sizeof(letsVar[letID]), (yyvsp[(2) - (7)].string)); letID++;}
    break;

  case 25:

/* Line 1455 of yacc.c  */
#line 89 "source.y"
    { fprintf(file, "loop(%s, %s)\n", (yyvsp[(4) - (7)].string), (yyvsp[(6) - (7)].string)); }
    break;

  case 26:

/* Line 1455 of yacc.c  */
#line 89 "source.y"
    { fprintf(file, "end(%s)\n", (yyvsp[(4) - (9)].string)); }
    break;

  case 27:

/* Line 1455 of yacc.c  */
#line 98 "source.y"
    { if(firstTimeBreak==1) firstTimeBreak=0; else fprintf(file, "break\n"); }
    break;

  case 29:

/* Line 1455 of yacc.c  */
#line 99 "source.y"
    { snprintf(currentAction, sizeof(currentAction), "move"); }
    break;

  case 31:

/* Line 1455 of yacc.c  */
#line 100 "source.y"
    { snprintf(currentAction, sizeof(currentAction), "shoot"); }
    break;

  case 33:

/* Line 1455 of yacc.c  */
#line 102 "source.y"
    { saveLine = 1; snprintf(savedLine, sizeof(savedLine), "", currentAction, id_enemy-nbCreate);}
    break;

  case 34:

/* Line 1455 of yacc.c  */
#line 103 "source.y"
    { 
   snprintf(savedLine, sizeof(savedLine), "%stime<=%s, cadence<=%s, end<=%s):%s\n", savedLine, time, cadence, end, instr); 
   int indice;
   if(foreach==0)
   {
      for(indice=0;indice<indexListe;indice++)
      {
         fprintf(file, "%s(id<=%d, %s", currentAction, id_enemy-nbCreate + atoi(listeIds[indice]), savedLine);
      }
   }
   else if( foreach==1)
   {
      for(indice=id_enemy-nbCreate; indice<id_enemy;indice++)
      {
         fprintf(file, "%s(id<=%d, %s", currentAction, indice, savedLine);
      }
   }
   saveLine=0;
}
    break;

  case 36:

/* Line 1455 of yacc.c  */
#line 125 "source.y"
    { 
   if(foreach==0)
   {
      fprintf(file, "%s(id<=%d, ", currentAction, id_enemy-nbCreate + atoi(listeIds[indexListeTemp]));
   }
   else if(foreach==1)
   {
      fprintf(file, "%s(id<=%d, ", currentAction, id_enemy-nbCreate+indexListeTemp);
   }
   indexListeTemp++;
}
    break;

  case 37:

/* Line 1455 of yacc.c  */
#line 135 "source.y"
    { fprintf(file, "time<=%s, cadence<=%s, end<=%s):%s\n", time, cadence, end, instr); }
    break;

  case 40:

/* Line 1455 of yacc.c  */
#line 137 "source.y"
    { indexListe = 0; foreach=0; }
    break;

  case 44:

/* Line 1455 of yacc.c  */
#line 140 "source.y"
    { fprintf(file, "create(id<=%d, ", id_enemy); id_enemy++; nbCreate++; }
    break;

  case 45:

/* Line 1455 of yacc.c  */
#line 140 "source.y"
    { fprintf(file, "time<=%s, cadence<=%s, end<=%s):1\n", time, cadence, end);}
    break;

  case 52:

/* Line 1455 of yacc.c  */
#line 146 "source.y"
    {indexListeTemp = 0;}
    break;

  case 54:

/* Line 1455 of yacc.c  */
#line 148 "source.y"
    {lastTime = atof(time); lastEnd = atof(end); lastCadence = atof(cadence); snprintf(time, sizeof(time),"%.2f", atof((yyvsp[(3) - (5)].string)) + (atof((yyvsp[(5) - (5)].string))/(pow(10.0, strlen((yyvsp[(5) - (5)].string))))) + atof(time)); snprintf(end, sizeof(end),"%.2f", atof((yyvsp[(3) - (5)].string)) + (atof((yyvsp[(5) - (5)].string))/(pow(10.0, strlen((yyvsp[(5) - (5)].string))))) + atof(end));  snprintf(cadence, sizeof(cadence),"%.2f", 0.0); }
    break;

  case 55:

/* Line 1455 of yacc.c  */
#line 149 "source.y"
    { 
	snprintf(time, sizeof(time),"%.2f", lastTime);
	snprintf(end, sizeof(end),"%.2f", lastEnd);
	snprintf(cadence, sizeof(cadence),"%.2f", lastCadence);
}
    break;

  case 56:

/* Line 1455 of yacc.c  */
#line 155 "source.y"
    { lastTime = atof(time); lastEnd = atof(end); lastCadence = atof(cadence); snprintf(cadence, sizeof(cadence),"%.2f", atof((yyvsp[(15) - (17)].string)) + (atof((yyvsp[(17) - (17)].string))/(pow(10.0, strlen((yyvsp[(17) - (17)].string)))))); snprintf(time, sizeof(time),"%.2f", atof((yyvsp[(3) - (17)].string)) + (atof((yyvsp[(5) - (17)].string))/(pow(10.0, strlen((yyvsp[(5) - (17)].string))))) + atof(time));  snprintf(end, sizeof(end),"%.2f", atof((yyvsp[(9) - (17)].string)) + (atof((yyvsp[(11) - (17)].string))/(pow(10.0, strlen((yyvsp[(11) - (17)].string))))) + atof(time));  }
    break;

  case 57:

/* Line 1455 of yacc.c  */
#line 156 "source.y"
    { 
	snprintf(time, sizeof(time),"%.2f", lastTime);
	snprintf(end, sizeof(end),"%.2f", lastEnd);
	snprintf(cadence, sizeof(cadence),"%.2f", lastCadence);
}
    break;

  case 63:

/* Line 1455 of yacc.c  */
#line 165 "source.y"
    {snprintf(instr, sizeof(instr), "a"); foreach=1;}
    break;

  case 64:

/* Line 1455 of yacc.c  */
#line 166 "source.y"
    { snprintf(instr, sizeof(instr), "a"); }
    break;

  case 66:

/* Line 1455 of yacc.c  */
#line 167 "source.y"
    { memcpy(listeIds[indexListe], (yyvsp[(1) - (2)].string), sizeof(listeIds[indexListe])) ; indexListe++; }
    break;

  case 68:

/* Line 1455 of yacc.c  */
#line 168 "source.y"
    { memcpy(listeIds[indexListe], (yyvsp[(1) - (1)].string), sizeof(listeIds[indexListe])) ; indexListe++; }
    break;

  case 69:

/* Line 1455 of yacc.c  */
#line 169 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s(%s, %s), ", savedLine, (yyvsp[(4) - (8)].string), (yyvsp[(6) - (8)].string)); else fprintf(file, "(%s, %s), ", (yyvsp[(4) - (8)].string), (yyvsp[(6) - (8)].string)); }
    break;

  case 70:

/* Line 1455 of yacc.c  */
#line 170 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s%s, ", savedLine, (yyvsp[(3) - (4)].string)); else fprintf(file, "%s, ", (yyvsp[(3) - (4)].string)); }
    break;

  case 71:

/* Line 1455 of yacc.c  */
#line 171 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s%s, ", savedLine, (yyvsp[(3) - (4)].string)); else fprintf(file, "%s, ", (yyvsp[(3) - (4)].string)); }
    break;

  case 72:

/* Line 1455 of yacc.c  */
#line 172 "source.y"
    {(yyval.string) = (yyvsp[(1) - (1)].string);}
    break;

  case 73:

/* Line 1455 of yacc.c  */
#line 173 "source.y"
    {snprintf((yyval.string), sizeof((yyval.string)), "%s.%s", (yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); }
    break;

  case 74:

/* Line 1455 of yacc.c  */
#line 174 "source.y"
    { (yyval.string)=(yyvsp[(1) - (1)].string); }
    break;

  case 75:

/* Line 1455 of yacc.c  */
#line 175 "source.y"
    {(yyval.string)  = (yyvsp[(1) - (1)].string);}
    break;

  case 76:

/* Line 1455 of yacc.c  */
#line 176 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sdestination<=", savedLine); else fprintf(file, "destination<="); }
    break;

  case 77:

/* Line 1455 of yacc.c  */
#line 176 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sposition<=", savedLine); else fprintf(file, "position<="); }
    break;

  case 78:

/* Line 1455 of yacc.c  */
#line 176 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sdirection<=", savedLine); else fprintf(file, "direction<="); }
    break;

  case 79:

/* Line 1455 of yacc.c  */
#line 176 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sfDirection<=", savedLine); else fprintf(file, "fDirection<="); }
    break;

  case 80:

/* Line 1455 of yacc.c  */
#line 177 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sspeed<=", savedLine); else fprintf(file, "speed<=" ) ; }
    break;

  case 81:

/* Line 1455 of yacc.c  */
#line 177 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sfSpeed<=", savedLine); else fprintf(file, "fSpeed<=" ) ; }
    break;

  case 82:

/* Line 1455 of yacc.c  */
#line 177 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%shealth<=", savedLine); else fprintf(file, "health<=" ) ; }
    break;

  case 83:

/* Line 1455 of yacc.c  */
#line 178 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sparticleType<=", savedLine); else fprintf(file, "particleType<="); }
    break;

  case 84:

/* Line 1455 of yacc.c  */
#line 178 "source.y"
    { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%stype<=", savedLine); else fprintf(file, "type<="); }
    break;



/* Line 1455 of yacc.c  */
#line 1989 "y.tab.c"
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
#line 179 "source.y"


void main(void) {
   file= fopen("temp", "w" );
   yyparse();
   fclose(file);
	FILE* fileScpt = fopen("stage.dat", "w");
	file = fopen("temp", "r") ;
	char buffer[200];
	int id=0, lastid = -1;
	int nb = 0;
	int inLoop=0, nbExpr=0;
	int affInLoop=0;
	char expr[20][100];
	int createSeen = 0;
	int copyLoop=0;
	float createCadence=0, createTime = 0, createEnd = 0, lastEnd = 0;
	while(fgets (buffer, 200, file) != NULL ) 
   {
		int i=0, j=0, loopCreate=0, typeAct=0;
		char type[20];
		char reste[200];
		typeAct = findAction(buffer);
		if(typeAct == ACTION_BREAK)
		{
			lastid = id;
			nb=0;
			createSeen = 0;
		}
		else if(typeAct == ACTION_LET || typeAct == ACTION_UNLET)
		{
         fprintf(fileScpt, "%s", buffer);
         if(typeAct == ACTION_LET)
         {
            affInLoop = getLoopState(buffer);
            
         }
         else
         {
            affInLoop = 0;
            nbExpr=0;
         }
		}
		else if(typeAct == ACTION_LOOP || typeAct == ACTION_END)
		{
		   if(typeAct==ACTION_LOOP)
		   {
		      int h;
            for(h=0;h<nbExpr;h++)
			   {
               fprintf(fileScpt, "avar(%s)\n", expr[h]);
			   }
			   nbExpr = 0;
		   }
         fprintf(fileScpt, "%s", buffer);
         createSeen = 0;
		}
		else if(typeAct == ACTION_AVAR)
      {
         if(createSeen==1)
         {
            nbExpr=0;
            createSeen = 0;
         }
         if(affInLoop==1)
         {
            getExpression(buffer, expr[nbExpr]);
            nbExpr++;
         }
         else if(affInLoop==0)
         {
            fprintf(fileScpt, "%s", buffer);
         }
	   }
		else if(typeAct == ACTION_CREATE)
		{
		   createSeen = 1;
			loopCreate = getLastNb(buffer);
			nb++;
			getEnemyType(buffer, type);
			cutUntilV(buffer, reste); //...end<=...):...
			getReste(reste, reste); //...cadence<=...)
		   getReste(reste, reste); //...time<=...)
			float cadence = getCadence(buffer);
			if(cadence==0)
			{
				for(i=0;i<loopCreate;i++)
				{
					fprintf(fileScpt, "create(aId<=%d%s\n", id, reste);
					id++;
				}
				inLoop = 0;
			}
			else
			{
				float end = getEnd(buffer);
				float time = getTime(buffer);
				createCadence = cadence;
				createEnd = end;
				createTime = time;
				int pas = calculPas(time, end, cadence);
				int i = 0;
				inLoop = 1;
				int h=0;
				for(i=0;i<pas;i++)
				{
					setTime(reste, time+(i*cadence));
					for(h=0;h<nbExpr;h++)
			   	{
                   fprintf(fileScpt, "avar(%s)\n", expr[h]);
				   }
				   
					for(j=0;j<loopCreate;j++)
					{
						fprintf(fileScpt, "create(aId<=%d%s\n", id, reste);
						id++;
					}
					lastEnd = time+(i*cadence);
				}
			}
		}
		else
		{
			char option[100];
			getOption(buffer, option);
			getEnemyType(buffer, type);
			cutUntilV(buffer, reste); //...end<=...):...
			getReste(reste, reste); //...cadence<=...)
		   getReste(reste, reste); //...time<=...)
			float cadence = getCadence(buffer);
			if(option[0]=='w') //wait for all
			{
				//printf("wait !\n");
				if(cadence==0 && inLoop==1) //onl wait onp equivaut à on on
				{
					//printf("ok ! : %d\n", lastid);
					if(typeAct == ACTION_MOVE)
					{
						for(i=lastid;i<id;i++)
							fprintf(fileScpt, "move(aId<=%d%s\n", i, reste);
					}
					else if(typeAct == ACTION_SHOOT)
					{
						for(i=lastid;i<id;i++)
							fprintf(fileScpt, "shoot(aId<=%d%s\n", i, reste);
					}
				}
				else if(cadence!=0 && inLoop==1) //onl wait onp equivaut à on onlp
				{
					float time = getTime(buffer);
					float end = getEnd(buffer);
					int pas = calculPas(time, end, cadence);
					int k = 0, j=0;
					for(k=0;k<pas;k++)
					{
						setTime(reste, time+(k*cadence)); 
						if(typeAct == ACTION_MOVE)
						{
							for(i=lastid;i<id;i++)
								fprintf(fileScpt, "move(aId<=%d%s\n", i, reste);
						}
						else if(typeAct == ACTION_SHOOT)
						{
							for(i=lastid;i<id;i++)
								fprintf(fileScpt, "shoot(aId<=%d%s\n", i, reste);
						}
					}
				}
			}
			else if(option[0]=='a') //all, vérifiée
			{
				//printf("all !\n");
				float cadence = getCadence(buffer);
				int currentID = getID(buffer);
				if(cadence==0 && inLoop==0) //on onp -> tjrs sync marche
				{
					if(typeAct == ACTION_MOVE)
					{
						fprintf(fileScpt, "move(aId<=%d%s\n", lastid + currentID, reste);
					}
					else if(typeAct == ACTION_SHOOT)
					{
						fprintf(fileScpt, "shoot(aId<=%d%s\n", lastid + currentID, reste);
					}
				}
				else if(cadence!=0 && inLoop==0) //on onlp -> tjrs sync marche
				{
					float time = getTime(buffer);
					float end = getEnd(buffer);
					int pas = calculPas(time, end, cadence);
					int k = 0, j=0;
					int currentID = getID(buffer);
					for(k=0;k<pas;k++)
					{
						if(typeAct == ACTION_MOVE)
						{
							setTime(reste, time+(k*cadence)); 
							fprintf(fileScpt, "move(aId<=%d%s\n", currentID+lastid, reste);
						}
						else if(typeAct == ACTION_SHOOT)
						{
							setTime(reste, time+(k*cadence)); 
							fprintf(fileScpt, "shoot(aId<=%d%s\n", currentID+lastid, reste);
						}
					}
				}
				else if(cadence==0 && inLoop==1) //onl onp trjs async car ennemis pas encore créés etc... marche
				{
					float time = getTime(buffer);
					int k, j=0;
					int pasCreate = calculPas(createTime, createEnd, createCadence);
					float currentTime = time;
					int currentID = getID(buffer)*pasCreate;
					for(i=0;i<pasCreate;i++)
					{
					      setTime(reste, time + i*createCadence);
					      int h;
					      for(h=0;h<nbExpr;h++)
			         	{
                         fprintf(fileScpt, "avar(%s)\n", expr[h]);
				         }
                     if(typeAct == ACTION_MOVE)
							{
								fprintf(fileScpt, "move(aId<=%d%s\n", currentID+lastid, reste);
							}
							else if(typeAct == ACTION_SHOOT)
							{
								fprintf(fileScpt, "shoot(aId<=%d%s\n", currentID+lastid, reste);
							}
							currentID++;
					}
				}
				else if(cadence!=0 && inLoop==1) //marche, onl onlp trjs async car si tout est fait en meme temps certains ennemis ne seront pas créés et on leur demandera de faire une action autre qu'un create
				{
					float time = getTime(buffer);
					float end = getEnd(buffer);
					int pas = calculPas(time, end, cadence);
					int k, j=0;
					int pasCreate = calculPas(createTime, createEnd, createCadence);
					float currentTime = time;
					int debut = 0;
					int fin = nb;
					int currentID = getID(buffer);
					for(i=0;i<pasCreate;i++)
					{
					   currentTime = time + i*createCadence;
                  for(j=0;j<pas;j++)
                  {
                     setTime(reste, currentTime); 
                     if(typeAct == ACTION_MOVE)
							{
								fprintf(fileScpt, "move(aId<=%d%s\n", i+(currentID*pasCreate)+lastid, reste);
							}
							else if(typeAct == ACTION_SHOOT)
							{
								fprintf(fileScpt, "shoot(aId<=%d%s\n", i+(currentID*pasCreate)+lastid, reste);
							}
							currentTime+=cadence;
                  }
                  
					}
				}
			}
   	}
	}
	fclose(file);
	fclose(fileScpt);
	//unlink("temp");
}

int findAction(const char* buffer)
{
	char action[4];
	int typeAct=0;
	memcpy(action, buffer, sizeof(action));
	if(strcmp(action, "crea")==0)
	{
		return ACTION_CREATE;
	}
	else if(strcmp(action, "move")==0)
	{
		return ACTION_MOVE;
	}
	else if(strcmp(action, "shoo")==0)
	{
		return ACTION_SHOOT;
	}
	else if(strcmp(action, "brea")==0)
	{
		return ACTION_BREAK;
	}
	else if(strcmp(action, "let(")==0)
	{
      return ACTION_LET;
	}
	else if(strcmp(action, "unle")==0)
	{
	   return ACTION_UNLET;
	}
	else if(strcmp(action, "avar")==0)
	{
      return ACTION_AVAR;
	}
	else if(strcmp(action, "loop")==0)
	{
      return ACTION_LOOP;
	}
	else if(strcmp(action, "end(")==0)
	{
      return ACTION_END;
	}
}
int convertOptiontoIntArray(const char* option, int* ids)
{
	char temp[100];
	char temp2[100];
	char tempNB[5];
	int k = 1, j = 0, h= 0;
	int i = getFirstIndex(option, ';');
	if(i==-1)
	{
		i = getFirstIndex(option, '[');
		j = getFirstIndex(option, ']');
		memcpy(tempNB, option+1, j-i);
		tempNB[j-i] = '\0';
		ids[0] = atoi(tempNB);
	}
	else
	{
		memcpy(temp, option, sizeof(temp));
		memcpy(tempNB, temp+1, i-1);
		tempNB[i-1] = '\0';
		ids[0] = atoi(tempNB);
		int i = getFirstIndex(temp, ';');
		memcpy(temp, temp+i+1, sizeof(temp));
		i = getFirstIndex(temp, ';');
		while(i!=-1)
		{
			memcpy(tempNB, temp, i);
			tempNB[i] = '\0';
			ids[k] = atoi(tempNB);
			k++;
			memcpy(temp, temp+i+1, sizeof(temp));
			i = getFirstIndex(temp, ';');
		}
		i = getFirstIndex(temp, ']');
		memcpy(tempNB, temp, i);
		tempNB[i] = '\0';
		ids[k] = atoi(tempNB);
		k++;
	}
	return k;
}

int calculPas(float time, float end, float cadence)
{
	int i = 0;
	while(time<=end)
	{
		time+=cadence;
		i++;
	}
	return i;
}

int getLastNb(const char* buffer)
{
	char buffer2[200];
	int i = getFirstIndex(buffer, ':');
	int j = getFirstIndex(buffer, '\n');
	i++;
	memcpy(buffer2, buffer+i, j-i);
	buffer2[j-i] = '\0';
	return atoi(buffer2);
}

void setTime(char* resteBuffer, float time)
{
	int i = getFirstIndex(resteBuffer, '=');
	char temp[200];
	memcpy(temp, resteBuffer, sizeof(temp));
	int r= 0;
	while(i!=-1)
	{
		r += i+1;
		memcpy(temp, temp+i+1, sizeof(temp));
		i = getFirstIndex(temp, '=');
	}
	int j = 0;
	char tempNB[10] = {0} ;
	snprintf(tempNB, sizeof(tempNB), "%.2f", time);
	for(j=0;j<10;j++)
	{
		if(tempNB[j]=='\0')
		{
			resteBuffer[r+j] = ')';
			resteBuffer[r+j+1] = '\0';
			break;
		}
		else
			resteBuffer[r+j] = tempNB[j];
	}
}

int getFirstNb(const char* buffer)
{
	int i =0;
	while(!(buffer[i]>='0' && buffer[i]<='9'))
		i++;

	return i;
}

void getOption(const char* buffer, char* option)
{
	int i = getFirstIndex(buffer, ':');
	int j = getFirstIndex(buffer, '\n');
	i++;
	memcpy(option, buffer+i, j-i);
	option[j-i] = '\0';
}

void getEnemyType(const char* buffer, char* type)
{
	int i = getFirstIndex(buffer, '=');
	int j = getFirstIndex(buffer, ',');
	memcpy(type, buffer+i+1, j-i-1);
	type[j-i-1] = '\0';
}

int getSync(const char* buffer)
{
	int i = getFirstIndex(buffer, '|');
	if(buffer[i+1]=='s')
	{
		return 0;
	}
	else if(buffer[i+1]=='z')
	{
		return 1;
	}
	else
	{	
		return -1;
	}
}

float getCadence(const char* buffer)
{
	char* cadence = strstr(buffer, "cadence");
	char tempNB[5];
	int i = getFirstIndex(cadence, '=');
	int j = getFirstIndex(cadence, ',');
	memcpy(tempNB, cadence + i +1, j-i);
	tempNB[j-i-1] = '\0';
	return atof(tempNB);
}

float getTime(const char* buffer)
{
	char* time = strstr(buffer, "time");
	char tempNB[5];
	int i = getFirstIndex(time, '=');
	int j = getFirstIndex(time, ',');
	memcpy(tempNB, time + i +1, j-i);
	tempNB[j-i-1] = '\0';
	return atof(tempNB);
}

float getEnd(const char* buffer)
{
	char* end = strstr(buffer, "end");
	char tempNB[5];
	int i = getFirstIndex(end, '=');
	int j = getFirstIndex(end, ')');
	memcpy(tempNB, end + i +1, j-i);
	tempNB[j-i-1] = '\0';
	return atof(tempNB);
}

void cutUntilV(const char* buffer, char* reste)
{
	int i = getFirstIndex(buffer, ',');
	memcpy(reste, buffer+i, 200);
	int j = 0;
	while(buffer[j]!='\0')
	{
		j++;
	}
	reste[j-i] = '\0';
}

void getReste(const char* buffer, char* reste)
{
	char temp[200];
	memcpy(temp, buffer, sizeof(temp));
	int i = getFirstIndex(buffer, '\n');

	temp[i] = '\0';
	i = getFirstIndex(temp, ',');
	int r=0;
	while(i!=-1)
	{
		r += i+1;
		memcpy(temp, temp+i+1, sizeof(temp));
		i = getFirstIndex(temp, ',');
		
	}
	memcpy(reste, buffer, r);
	reste[r-1] = ')';
	reste[r] = '\0';
}

int getFirstIndex(const char* buffer, char c)
{
	int i = 0, j=0;
	while(buffer[i]!='\0')
		i++;

	while(j<i)
	{
		if(buffer[j]==c)
		{
			return j;
		}
		j++;
	}
	return -1;
}	

void getExpression(const char* buffer, char* expr)
{
   int ipo = getFirstIndex(buffer, '(');
   int i =0;
   while(buffer[i]!='\0')
      i++;

   memcpy(expr, buffer + ipo+1, i-ipo-3);
   expr[i-ipo-3] = '\0';
}

int getLoopState(const char* buffer)
{
   int ipv = getFirstIndex(buffer, ',');
   int i = 0;
   while(buffer[i]!='\0')
      i++;

   
   char state[6];
   memcpy(state, buffer + ipv+2, i-ipv-4);
   state[5] = '\0';
   if(strcmp(state, "false")==0)
   {
      return 0;
   }
   else
   {
      return 1;
   }
}

int getID(const char* buffer)
{
	char* id = strstr(buffer, "id");
	char tempNB[5];
	int i = getFirstIndex(id, '=');
	int j = getFirstIndex(id, ',');
	memcpy(tempNB, id + i +1, j-i);
	tempNB[j-i-1] = '\0';
	return atoi(tempNB);
}

void yyerror(const char *s)
{
   fprintf(stderr, "%s\n", s);
}

int yywrap() {
   return 1;
}

