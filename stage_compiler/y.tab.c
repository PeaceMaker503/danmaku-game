
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
     tLET = 258,
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
     tSUBID = 298,
     tNB = 299,
     tID = 300,
     tRUNVAR = 301
   };
#endif
/* Tokens.  */
#define tLET 258
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
#define tSUBID 298
#define tNB 299
#define tID 300
#define tRUNVAR 301




#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef union YYSTYPE
{

/* Line 214 of yacc.c  */
#line 49 "source.y"

   char* string;



/* Line 214 of yacc.c  */
#line 250 "y.tab.c"
} YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define yystype YYSTYPE /* obsolescent; will be withdrawn */
# define YYSTYPE_IS_DECLARED 1
#endif


/* Copy the second part of user declarations.  */


/* Line 264 of yacc.c  */
#line 262 "y.tab.c"

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
#define YYLAST   204

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  47
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  30
/* YYNRULES -- Number of rules.  */
#define YYNRULES  79
/* YYNRULES -- Number of states.  */
#define YYNSTATES  187

/* YYTRANSLATE(YYLEX) -- Bison symbol number corresponding to YYLEX.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   301

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
      45,    46
};

#if YYDEBUG
/* YYPRHS[YYN] -- Index of the first RHS symbol of rule number YYN in
   YYRHS.  */
static const yytype_uint16 yyprhs[] =
{
       0,     0,     3,     6,     8,    10,    12,    14,    16,    18,
      20,    22,    24,    26,    28,    34,    40,    50,    54,    56,
      60,    64,    68,    72,    79,    85,    91,    97,   108,   118,
     122,   124,   128,   132,   136,   140,   144,   145,   154,   155,
     166,   167,   177,   178,   187,   191,   197,   199,   203,   205,
     207,   209,   212,   214,   217,   219,   222,   225,   231,   239,
     244,   246,   248,   250,   252,   256,   258,   260,   266,   268,
     270,   272,   274,   278,   280,   284,   288,   292,   296,   300
};

/* YYRHS -- A `-1'-separated list of the rules' RHS.  */
static const yytype_int8 yyrhs[] =
{
      48,     0,    -1,    49,    48,    -1,    49,    -1,    70,    -1,
      71,    -1,    59,    -1,    61,    -1,    63,    -1,    55,    -1,
      56,    -1,    54,    -1,    50,    -1,    51,    -1,    42,    31,
      66,    32,    33,    -1,     9,    31,    52,    32,    33,    -1,
       9,    31,    52,    32,     4,    43,    24,    75,    33,    -1,
      53,    26,    52,    -1,    53,    -1,    12,    24,    76,    -1,
      11,    24,    76,    -1,     6,    24,    74,    -1,     8,    24,
      74,    -1,    41,    45,    31,    67,    32,    33,    -1,    41,
      45,    31,    32,    33,    -1,    40,    31,    76,    32,    33,
      -1,    10,    31,    57,    32,    33,    -1,    10,    31,    57,
      32,     4,    45,    31,    67,    32,    33,    -1,    10,    31,
      57,    32,     4,    45,    31,    32,    33,    -1,    58,    26,
      57,    -1,    58,    -1,    12,    24,    76,    -1,    11,    24,
      76,    -1,     5,    24,    73,    -1,     6,    24,    74,    -1,
       8,    24,    74,    -1,    -1,    13,    31,    75,    32,    60,
      29,    48,    30,    -1,    -1,    14,    31,    68,    69,    68,
      32,    62,    29,    48,    30,    -1,    -1,    19,    45,    31,
      66,    32,    64,    29,    48,    30,    -1,    -1,    19,    45,
      31,    32,    65,    29,    48,    30,    -1,    45,    25,    72,
      -1,    45,    25,    72,    26,    66,    -1,    68,    -1,    68,
      26,    67,    -1,    76,    -1,    73,    -1,    74,    -1,    24,
      24,    -1,    21,    -1,    21,    24,    -1,    22,    -1,    22,
      24,    -1,    23,    24,    -1,     3,    45,    25,    72,    33,
      -1,     3,    45,    25,    72,    24,    68,    33,    -1,    45,
      24,    68,    33,    -1,    15,    -1,    16,    -1,    17,    -1,
      18,    -1,    20,    45,    20,    -1,    45,    -1,    45,    -1,
      27,    76,    26,    76,    28,    -1,    46,    -1,    45,    -1,
      44,    -1,    45,    -1,    44,    38,    44,    -1,    44,    -1,
      76,    34,    76,    -1,    76,    35,    76,    -1,    76,    36,
      76,    -1,    76,    37,    76,    -1,    76,    39,    76,    -1,
      31,    76,    32,    -1
};

/* YYRLINE[YYN] -- source line where rule number YYN was defined.  */
static const yytype_uint8 yyrline[] =
{
       0,    65,    65,    66,    68,    69,    70,    71,    72,    73,
      74,    75,    76,    77,    79,    80,    81,    83,    84,    86,
      87,    88,    89,    91,    92,    93,    94,    95,    96,    97,
      98,    99,   100,   101,   102,   103,   104,   104,   105,   105,
     106,   106,   107,   107,   110,   111,   114,   115,   118,   119,
     120,   122,   123,   124,   125,   126,   127,   129,   130,   132,
     135,   136,   137,   138,   141,   142,   145,   146,   147,   150,
     151,   154,   155,   156,   157,   158,   159,   160,   161,   162
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || YYTOKEN_TABLE
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "tLET", "tWITH", "tTYPE", "tDESTINATION",
  "tDIRECTION", "tPOSITION", "tMOVE", "tMAKE", "tSPEED", "tANGLE", "tLOOP",
  "tCASE", "tFLOAT", "tVECTOR", "tSTRING", "tNUMBER", "tBEHAVIOR",
  "tQUOTE", "tINF", "tSUP", "tDIFF", "tEQ", "tDP", "tV", "tCO", "tCF",
  "tAO", "tAF", "tPO", "tPF", "tPV", "tADD", "tSUB", "tMUL", "tDIV",
  "tDOT", "tMOD", "tDELAY", "tCALL", "tARGS", "tSUBID", "tNB", "tID",
  "tRUNVAR", "$accept", "Script", "Instruction", "SpellDeclaration",
  "Move", "MoveArgs", "MoveArg", "Call", "Delay", "Make", "MakeArgs",
  "MakeArg", "Loop", "$@1", "Case", "$@2", "Behavior", "$@3", "$@4",
  "ArgsDeclaration", "ArgsCall", "Value", "BoolOp", "Declaration",
  "Affection", "Type", "String", "Vector", "Number", "ArithmeticExp", 0
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
     295,   296,   297,   298,   299,   300,   301
};
# endif

/* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint8 yyr1[] =
{
       0,    47,    48,    48,    49,    49,    49,    49,    49,    49,
      49,    49,    49,    49,    50,    51,    51,    52,    52,    53,
      53,    53,    53,    54,    54,    55,    56,    56,    56,    57,
      57,    58,    58,    58,    58,    58,    60,    59,    62,    61,
      64,    63,    65,    63,    66,    66,    67,    67,    68,    68,
      68,    69,    69,    69,    69,    69,    69,    70,    70,    71,
      72,    72,    72,    72,    73,    73,    74,    74,    74,    75,
      75,    76,    76,    76,    76,    76,    76,    76,    76,    76
};

/* YYR2[YYN] -- Number of symbols composing right hand side of rule YYN.  */
static const yytype_uint8 yyr2[] =
{
       0,     2,     2,     1,     1,     1,     1,     1,     1,     1,
       1,     1,     1,     1,     5,     5,     9,     3,     1,     3,
       3,     3,     3,     6,     5,     5,     5,    10,     9,     3,
       1,     3,     3,     3,     3,     3,     0,     8,     0,    10,
       0,     9,     0,     8,     3,     5,     1,     3,     1,     1,
       1,     2,     1,     2,     1,     2,     2,     5,     7,     4,
       1,     1,     1,     1,     3,     1,     1,     5,     1,     1,
       1,     1,     3,     1,     3,     3,     3,     3,     3,     3
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
       0,    18,     0,     0,     0,     0,     0,     0,    30,    70,
      69,     0,     0,     0,     0,    73,    65,    68,     0,    49,
      50,    48,     0,    71,     0,     0,     0,     0,     0,    60,
      61,    62,    63,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,    36,     0,     0,
       0,     0,    52,    54,     0,     0,     0,     0,     0,     0,
       0,     0,    42,     0,     0,     0,     0,    46,     0,     0,
      59,     0,    57,    66,    21,    22,    20,    19,     0,    15,
      17,    65,    33,    34,    35,    32,    31,     0,    26,    29,
       0,    64,     0,    79,    72,    53,    55,    56,    51,     0,
      74,    75,    76,    77,    78,     0,    40,    25,    24,     0,
       0,    44,    14,     0,     0,     0,     0,     0,    38,     0,
       0,    23,    47,     0,    58,     0,     0,     0,    67,     0,
       0,     0,    45,     0,     0,     0,    37,     0,    43,     0,
      16,    28,     0,     0,    41,    27,    39
};

/* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,    11,    12,    13,    14,    40,    41,    15,    16,    17,
      47,    48,    18,   130,    19,   169,    20,   160,   145,    67,
     106,   107,    96,    21,    22,    73,    59,    60,    51,    61
};

/* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
   STATE-NUM.  */
#define YYPACT_NINF -131
static const yytype_int16 yypact[] =
{
       5,   -38,     6,     7,     8,    13,    12,    22,    23,    33,
      -7,    87,     5,  -131,  -131,  -131,  -131,  -131,  -131,  -131,
    -131,  -131,  -131,    69,    90,   112,   -32,    34,    66,   -10,
      84,    55,    34,  -131,  -131,   122,    95,    98,   105,   111,
      89,   115,   128,   129,   130,   131,   132,   114,   134,  -131,
    -131,   125,   113,   -10,   -10,   123,    91,  -131,   127,  -131,
    -131,    97,   -23,  -131,    49,    -4,   137,   135,   133,  -131,
    -131,  -131,  -131,    19,   -16,   -16,   -10,   -10,    -1,    90,
     -14,   -16,   -16,   -10,   -10,     0,   112,  -131,   143,    56,
      77,   120,   144,   145,   146,   147,    34,   -10,   -10,   -10,
     -10,   -10,  -131,   140,   141,   142,   148,   150,   122,   149,
    -131,    34,  -131,  -131,  -131,  -131,    97,    97,   136,  -131,
    -131,  -131,  -131,  -131,  -131,    97,    97,   138,  -131,  -131,
     152,  -131,   -10,  -131,  -131,  -131,  -131,  -131,  -131,   153,
     106,   106,  -131,  -131,  -131,   155,  -131,  -131,  -131,   154,
      34,   151,  -131,   156,   162,   157,     5,    71,  -131,     5,
     161,  -131,  -131,    55,  -131,   -32,    31,   163,  -131,   165,
     166,     5,  -131,   158,   159,   167,  -131,     5,  -131,   168,
    -131,  -131,   164,   170,  -131,  -131,  -131
};

/* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -131,   -12,  -131,  -131,  -131,    94,  -131,  -131,  -131,  -131,
      92,  -131,  -131,  -131,  -131,  -131,  -131,  -131,  -131,   -60,
    -130,   -22,  -131,  -131,  -131,    93,   124,   -15,    30,   -28
};

/* YYTABLE[YYPACT[STATE-NUM]].  What to do in state STATE-NUM.  If
   positive, shift that token.  If negative, reduce the rule which
   number is the opposite.  If zero, do what YYDEFACT says.
   If YYTABLE_NINF, syntax error.  */
#define YYTABLE_NINF -72
static const yytype_int16 yytable[] =
{
      34,    64,   103,   118,   127,    58,    52,    23,     1,   102,
      68,    53,    49,    50,     2,     3,    52,    32,     4,     5,
     162,    54,    66,    53,     6,    89,    90,    54,   105,   113,
      57,   121,   119,   128,    55,    63,   175,    24,    25,    26,
      55,    56,    57,   111,    27,     7,     8,     9,   116,   117,
      10,    52,   112,    29,    52,   125,   126,    28,    53,   114,
     115,    53,    54,   174,    31,    54,   123,   124,    30,   140,
     141,   142,   143,   144,   139,    55,    56,    57,    55,    56,
      57,   104,   132,    97,    98,    99,   100,    33,   101,   153,
      97,    98,    99,   100,    35,   101,    36,    62,    37,   168,
      66,    38,    39,   172,   157,    97,    98,    99,   100,   133,
     101,    97,    98,    99,   100,    65,   101,    42,    43,    74,
      44,    78,    75,    45,    46,   -71,   -71,   -71,   -71,    76,
     -71,    97,    98,    99,   100,    77,   101,    69,    70,    71,
      72,    79,    99,   100,   167,   101,    85,   170,    92,    93,
      94,    95,    80,    81,    82,    83,    84,    87,    88,   179,
      86,    91,   108,   131,   134,   183,   110,   109,   135,   136,
     137,   138,   146,   120,   147,   148,   150,   163,   129,   154,
     149,   156,   152,   155,   159,   158,   165,   161,   166,   164,
     171,   180,   181,   176,   177,   173,   178,   185,   184,   182,
     186,   151,     0,     0,   122
};

static const yytype_int16 yycheck[] =
{
      12,    29,    62,     4,     4,    27,    20,    45,     3,    32,
      32,    27,    44,    45,     9,    10,    20,    24,    13,    14,
     150,    31,    45,    27,    19,    53,    54,    31,    32,    45,
      46,    45,    33,    33,    44,    45,   166,    31,    31,    31,
      44,    45,    46,    24,    31,    40,    41,    42,    76,    77,
      45,    20,    33,    31,    20,    83,    84,    45,    27,    74,
      75,    27,    31,    32,    31,    31,    81,    82,    45,    97,
      98,    99,   100,   101,    96,    44,    45,    46,    44,    45,
      46,    32,    26,    34,    35,    36,    37,     0,    39,   111,
      34,    35,    36,    37,    25,    39,     6,    31,     8,    28,
      45,    11,    12,   163,   132,    34,    35,    36,    37,    32,
      39,    34,    35,    36,    37,    31,    39,     5,     6,    24,
       8,    32,    24,    11,    12,    34,    35,    36,    37,    24,
      39,    34,    35,    36,    37,    24,    39,    15,    16,    17,
      18,    26,    36,    37,   156,    39,    32,   159,    21,    22,
      23,    24,    24,    24,    24,    24,    24,    32,    45,   171,
      26,    38,    25,    20,    44,   177,    33,    32,    24,    24,
      24,    24,    32,    79,    33,    33,    26,    26,    86,    43,
      32,    29,    33,    45,    29,    32,    24,    33,    31,    33,
      29,    33,    33,    30,    29,   165,    30,    33,    30,    32,
      30,   108,    -1,    -1,    80
};

/* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
   symbol of state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,     3,     9,    10,    13,    14,    19,    40,    41,    42,
      45,    48,    49,    50,    51,    54,    55,    56,    59,    61,
      63,    70,    71,    45,    31,    31,    31,    31,    45,    31,
      45,    31,    24,     0,    48,    25,     6,     8,    11,    12,
      52,    53,     5,     6,     8,    11,    12,    57,    58,    44,
      45,    75,    20,    27,    31,    44,    45,    46,    68,    73,
      74,    76,    31,    45,    76,    31,    45,    66,    68,    15,
      16,    17,    18,    72,    24,    24,    24,    24,    32,    26,
      24,    24,    24,    24,    24,    32,    26,    32,    45,    76,
      76,    38,    21,    22,    23,    24,    69,    34,    35,    36,
      37,    39,    32,    66,    32,    32,    67,    68,    25,    32,
      33,    24,    33,    45,    74,    74,    76,    76,     4,    33,
      52,    45,    73,    74,    74,    76,    76,     4,    33,    57,
      60,    20,    26,    32,    44,    24,    24,    24,    24,    68,
      76,    76,    76,    76,    76,    65,    32,    33,    33,    32,
      26,    72,    33,    68,    43,    45,    29,    76,    32,    29,
      64,    33,    67,    26,    33,    24,    31,    48,    28,    62,
      48,    29,    66,    75,    32,    67,    30,    29,    30,    48,
      33,    33,    32,    48,    30,    33,    30
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
    {fprintf(out, "MOVE(1)\n"); }
    break;

  case 16:

/* Line 1455 of yacc.c  */
#line 81 "source.y"
    {fprintf(out, "MOVE(%s)\n", (yyvsp[(8) - (9)].string)); free((yyvsp[(8) - (9)].string)); }
    break;

  case 19:

/* Line 1455 of yacc.c  */
#line 86 "source.y"
    {fprintf(out, "WITH_ANGLE(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 20:

/* Line 1455 of yacc.c  */
#line 87 "source.y"
    {fprintf(out, "WITH_SPEED(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 21:

/* Line 1455 of yacc.c  */
#line 88 "source.y"
    { fprintf(out, "WITH_DESTINATION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 22:

/* Line 1455 of yacc.c  */
#line 89 "source.y"
    { fprintf(out, "WITH_POSITION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
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
    { fprintf(out, "WITH_DESTINATION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 35:

/* Line 1455 of yacc.c  */
#line 103 "source.y"
    { fprintf(out, "WITH_POSITION(%s)\n", (yyvsp[(3) - (3)].string)); free((yyvsp[(3) - (3)].string)); }
    break;

  case 36:

/* Line 1455 of yacc.c  */
#line 104 "source.y"
    {fprintf(out, "START_LOOP(%d, %s)\n", loopId++, (yyvsp[(3) - (4)].string)); free((yyvsp[(3) - (4)].string)); }
    break;

  case 37:

/* Line 1455 of yacc.c  */
#line 104 "source.y"
    {fprintf(out, "END_LOOP(%d)\n", --loopId); }
    break;

  case 38:

/* Line 1455 of yacc.c  */
#line 105 "source.y"
    {fprintf(out, "START_CASE(%d, %s, %s, %s)\n", caseId++, (yyvsp[(3) - (6)].string), (yyvsp[(4) - (6)].string), (yyvsp[(5) - (6)].string)); free((yyvsp[(3) - (6)].string)); free((yyvsp[(5) - (6)].string)); }
    break;

  case 39:

/* Line 1455 of yacc.c  */
#line 105 "source.y"
    {fprintf(out, "END_CASE(%d)\n", --caseId); }
    break;

  case 40:

/* Line 1455 of yacc.c  */
#line 106 "source.y"
    { fprintf(out, "START_BEHAVIOR(%d, %s, [%s])\n", behaviorId++, (yyvsp[(2) - (5)].string), (yyvsp[(4) - (5)].string)); free((yyvsp[(4) - (5)].string)); }
    break;

  case 41:

/* Line 1455 of yacc.c  */
#line 106 "source.y"
    {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); }
    break;

  case 42:

/* Line 1455 of yacc.c  */
#line 107 "source.y"
    { fprintf(out, "START_BEHAVIOR(%d, %s, [])\n", behaviorId++, (yyvsp[(2) - (4)].string)); }
    break;

  case 43:

/* Line 1455 of yacc.c  */
#line 107 "source.y"
    {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); }
    break;

  case 44:

/* Line 1455 of yacc.c  */
#line 110 "source.y"
    { (yyval.string) = getFirstArgsDeclaration((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); }
    break;

  case 45:

/* Line 1455 of yacc.c  */
#line 111 "source.y"
    { (yyval.string) = getArgsDeclaration((yyvsp[(1) - (5)].string), (yyvsp[(3) - (5)].string), (yyvsp[(5) - (5)].string)); }
    break;

  case 46:

/* Line 1455 of yacc.c  */
#line 114 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 47:

/* Line 1455 of yacc.c  */
#line 115 "source.y"
    { (yyval.string) = getArgsCall((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); }
    break;

  case 48:

/* Line 1455 of yacc.c  */
#line 118 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
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
#line 122 "source.y"
    { (yyval.string) = BOOL_OP_EQ; }
    break;

  case 52:

/* Line 1455 of yacc.c  */
#line 123 "source.y"
    { (yyval.string) = BOOL_OP_INF; }
    break;

  case 53:

/* Line 1455 of yacc.c  */
#line 124 "source.y"
    { (yyval.string) =BOOL_OP_INF_EQ; }
    break;

  case 54:

/* Line 1455 of yacc.c  */
#line 125 "source.y"
    { (yyval.string) = BOOL_OP_SUP; }
    break;

  case 55:

/* Line 1455 of yacc.c  */
#line 126 "source.y"
    { (yyval.string) =BOOL_OP_SUP_EQ; }
    break;

  case 56:

/* Line 1455 of yacc.c  */
#line 127 "source.y"
    { (yyval.string) =BOOL_OP_DIFF; }
    break;

  case 57:

/* Line 1455 of yacc.c  */
#line 129 "source.y"
    {fprintf(out, "LET(%s, %s)\n", (yyvsp[(2) - (5)].string), (yyvsp[(4) - (5)].string)); }
    break;

  case 58:

/* Line 1455 of yacc.c  */
#line 130 "source.y"
    {fprintf(out, "LET_AFF(%s, %s, %s)\n", (yyvsp[(2) - (7)].string), (yyvsp[(4) - (7)].string), (yyvsp[(6) - (7)].string)); free((yyvsp[(6) - (7)].string)); }
    break;

  case 59:

/* Line 1455 of yacc.c  */
#line 132 "source.y"
    {fprintf(out, "AFF(%s, %s)\n", (yyvsp[(1) - (4)].string), (yyvsp[(3) - (4)].string)); free((yyvsp[(3) - (4)].string)); }
    break;

  case 60:

/* Line 1455 of yacc.c  */
#line 135 "source.y"
    { (yyval.string) = TYPE_FLOAT; }
    break;

  case 61:

/* Line 1455 of yacc.c  */
#line 136 "source.y"
    { (yyval.string) = TYPE_VECTOR; }
    break;

  case 62:

/* Line 1455 of yacc.c  */
#line 137 "source.y"
    { (yyval.string) = TYPE_STRING; }
    break;

  case 63:

/* Line 1455 of yacc.c  */
#line 138 "source.y"
    { (yyval.string) = TYPE_NUMBER; }
    break;

  case 64:

/* Line 1455 of yacc.c  */
#line 141 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "LET_AFF(%s, %s, \"%s\")\n", tempName, TYPE_STRING, (yyvsp[(2) - (3)].string)); (yyval.string) = tempName; }
    break;

  case 65:

/* Line 1455 of yacc.c  */
#line 142 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 66:

/* Line 1455 of yacc.c  */
#line 145 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 67:

/* Line 1455 of yacc.c  */
#line 146 "source.y"
    { char* tempName = getNewVarTempName(); char* vector = getNewVector((yyvsp[(2) - (5)].string), (yyvsp[(4) - (5)].string)); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_VECTOR, vector); free(vector); (yyval.string) = tempName; }
    break;

  case 68:

/* Line 1455 of yacc.c  */
#line 147 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 69:

/* Line 1455 of yacc.c  */
#line 150 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 70:

/* Line 1455 of yacc.c  */
#line 151 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (1)].string)); (yyval.string) = tempName; }
    break;

  case 71:

/* Line 1455 of yacc.c  */
#line 154 "source.y"
    { (yyval.string) = (yyvsp[(1) - (1)].string); }
    break;

  case 72:

/* Line 1455 of yacc.c  */
#line 155 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "LET_AFF(%s, %s, %s.%s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string)); (yyval.string) = tempName; }
    break;

  case 73:

/* Line 1455 of yacc.c  */
#line 156 "source.y"
    { char* tempName = getNewVarTempName(); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, (yyvsp[(1) - (1)].string)); (yyval.string) = tempName; }
    break;

  case 74:

/* Line 1455 of yacc.c  */
#line 157 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_ADD); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 75:

/* Line 1455 of yacc.c  */
#line 158 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_SUB); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 76:

/* Line 1455 of yacc.c  */
#line 159 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_MUL); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 77:

/* Line 1455 of yacc.c  */
#line 160 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_DIV); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 78:

/* Line 1455 of yacc.c  */
#line 161 "source.y"
    { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation((yyvsp[(1) - (3)].string), (yyvsp[(3) - (3)].string), ARITHMETIC_OPERATION_CODE_MOD); fprintf(out, "LET_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); (yyval.string) = tempName; }
    break;

  case 79:

/* Line 1455 of yacc.c  */
#line 162 "source.y"
    { (yyval.string) = (yyvsp[(2) - (3)].string); }
    break;



/* Line 1455 of yacc.c  */
#line 2047 "y.tab.c"
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
#line 164 "source.y"


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

