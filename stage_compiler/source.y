%{
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
%}

%start Script ;
%token tVAR tWITH tTYPE tDESTINATION tDIRECTION tPOSITION tMOVE tMAKE tSPEED tANGLE tLOOP tCASE tFLOAT tVECTOR tSTRING tNUMBER tBEHAVIOR tQUOTE tINF tSUP tDIFF tEQ tDP tV tCO tCF tAO tAF tPO tPF tPV tADD tSUB tMUL tDIV tDOT tMOD tDELAY tCALL tARGS tSID tCONCAT tCOS tSIN tTAN;
%left tADD tSUB
%left tMUL tDIV tMOD
%left tPO tPF
%union
{
   char* string;
}
%token <string> tNB;
%token <string> tID;
%token <string> tRUNVAR;
%type <string> Number;
%type <string> ArithmeticExp ;
%type <string> Type ;
%type <string> String;
%type <string> Vector;
%type <string> BoolOp;
%type <string> ArgsDeclaration;
%type <string> ArgsCall;
%type <string> Value;
%%
Script : Instruction Script;
Script : Instruction ;

Instruction : Declaration;
Instruction : Affection;
Instruction : Loop;
Instruction : Case;
Instruction : Behavior;
Instruction : Delay;
Instruction : Make;
Instruction : Call;
Instruction : SpellDeclaration;
Instruction : Move;

SpellDeclaration : tARGS tPO ArgsDeclaration tPF tPV { fprintf(out, "ARGS([%s])\n", $3); free($3); } ;
Move : tMOVE tPO MoveArgs tPF tPV {fprintf(out, "MOVE()\n"); };

MoveArgs : MoveArg tV MoveArgs;
MoveArgs : MoveArg;

MoveArg : tANGLE tEQ ArithmeticExp {fprintf(out, "WITH_ANGLE(%s)\n", $3); free($3); } ;
MoveArg : tSPEED tEQ ArithmeticExp {fprintf(out, "WITH_SPEED(%s)\n", $3); free($3); } ;
MoveArg : tDESTINATION tEQ Vector { fprintf(out, "WITH_DESTINATION(%s)\n", $3); free($3); } ;
MoveArg : tPOSITION tEQ Vector { fprintf(out, "WITH_POSITION(%s)\n", $3); free($3); } ;
MoveArg : tSID tEQ String {fprintf(out, "WITH_ID(%s)\n", $3); free($3); } ;

Call : tCALL tID tPO ArgsCall tPF tPV {fprintf(out, "CALL(%s, [%s])\n", $2, $4); free($4); };
Call : tCALL tID tPO tPF tPV {fprintf(out, "CALL(%s, [])\n", $2); };
Delay : tDELAY tPO ArithmeticExp tPF tPV {fprintf(out, "DELAY(%s)\n", $3); free($3); } ;
Make : tMAKE tPO MakeArgs tPF tPV {fprintf(out, "MAKE()\n"); };
Make : tMAKE tPO MakeArgs tPF tWITH tID tPO ArgsCall tPF tPV {fprintf(out, "MAKE(%s, [%s])\n", $6, $8); free($6); } ;
Make : tMAKE tPO MakeArgs tPF tWITH tID tPO tPF tPV {fprintf(out, "MAKE(%s, [])\n", $6); free($6); } ;
MakeArgs : MakeArg tV MakeArgs;
MakeArgs : MakeArg;
MakeArg : tANGLE tEQ ArithmeticExp {fprintf(out, "WITH_ANGLE(%s)\n", $3); free($3); } ;
MakeArg : tSPEED tEQ ArithmeticExp {fprintf(out, "WITH_SPEED(%s)\n", $3); free($3); } ;
MakeArg : tTYPE tEQ String {fprintf(out, "WITH_TYPE(%s)\n", $3); free($3); } ;
MakeArg : tSID tEQ String {fprintf(out, "WITH_ID(%s)\n", $3); free($3); } ;
MakeArg : tDESTINATION tEQ Vector { fprintf(out, "WITH_DESTINATION(%s)\n", $3); free($3); } ;
MakeArg : tPOSITION tEQ Vector { fprintf(out, "WITH_POSITION(%s)\n", $3); free($3); } ;
Loop : tLOOP tPO Number tPF {fprintf(out, "START_LOOP(%d, %s)\n", loopId++, $3); free($3); } tAO Script tAF {fprintf(out, "END_LOOP(%d)\n", --loopId); };
Case : tCASE tPO Value BoolOp Value tPF {fprintf(out, "START_CASE(%d, %s, %s, %s)\n", caseId++, $3, $4, $5); free($3); free($5); } tAO Script tAF {fprintf(out, "END_CASE(%d)\n", --caseId); } ;
Behavior : tBEHAVIOR tID tPO ArgsDeclaration tPF { fprintf(out, "START_BEHAVIOR(%d, %s, [%s])\n", behaviorId++, $2, $4); free($4); } tAO Script tAF {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); };
Behavior : tBEHAVIOR tID tPO tPF { fprintf(out, "START_BEHAVIOR(%d, %s, [])\n", behaviorId++, $2); } tAO Script tAF {fprintf(out, "END_BEHAVIOR(%d)\n", --behaviorId); };

//every ArgsDeclaration must be freed
ArgsDeclaration : tID tDP Type { $$ = getFirstArgsDeclaration($1, $3); } ;
ArgsDeclaration : tID tDP Type tV ArgsDeclaration { $$ = getArgsDeclaration($1, $3, $5); } ;

//every ArgsCall must be freed
ArgsCall : Value { $$ = $1; } ;
ArgsCall : Value tV ArgsCall { $$ = getArgsCall($1, $3); } ;

//every value must be freed, conflicts due to tID have been induced but this is not really a problem
Value : ArithmeticExp { $$ = $1; } ;
Value : String { $$ = $1; } ;
Value : Vector { $$ = $1; } ;

BoolOp : tEQ tEQ { $$ = BOOL_OP_EQ; };
BoolOp : tINF { $$ = BOOL_OP_INF; } ;
BoolOp : tINF tEQ { $$ =BOOL_OP_INF_EQ; };
BoolOp : tSUP { $$ = BOOL_OP_SUP; } ;
BoolOp : tSUP tEQ { $$ =BOOL_OP_SUP_EQ; };
BoolOp : tDIFF tEQ { $$ =BOOL_OP_DIFF; };

//Declaration : tVAR tID tDP Type tPV {fprintf(out, "VAR(%s, %s)\n", $2, $4); } ;
Declaration : tVAR tID tDP Type tEQ Value tPV {fprintf(out, "VAR_AFF(%s, %s, %s)\n", $2, $4, $6); free($6); } ;

Affection : tID tEQ Value tPV {fprintf(out, "AFF(%s, %s)\n", $1, $3); free($3); } ;


Type : tFLOAT { $$ = TYPE_FLOAT; };
Type : tVECTOR { $$ = TYPE_VECTOR; };
Type : tSTRING { $$ = TYPE_STRING; };
Type : tNUMBER { $$ = TYPE_NUMBER; };

//every string must be freed
String : tQUOTE tID tQUOTE { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, \"%s\")\n", tempName, TYPE_STRING, $2); $$ = tempName; } ;
String : tID { $$ = $1; } ;

//every vector must be freed
Vector : tID { $$ = $1; } ;
Vector : tCO ArithmeticExp tV ArithmeticExp tCF { char* tempName = getNewVarTempName(); char* vector = getNewVector($2, $4); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_VECTOR, vector); free(vector); $$ = tempName; } ;
Vector : tRUNVAR { $$ = $1; } ;

//every number must be freed
Number : tID { $$ = $1; } ;
Number : tNB  { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, $1); $$ = tempName; } ;

//every arithmetic expression must be freed
ArithmeticExp : tID { $$ = $1; } ;
ArithmeticExp : tCOS tPO ArithmeticExp tPF { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, COS(%s))\n", tempName, TYPE_FLOAT, $3); $$ = tempName; free($3); };
ArithmeticExp : tSIN tPO ArithmeticExp tPF { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, SIN(%s))\n", tempName, TYPE_FLOAT, $3); $$ = tempName; free($3); };;
ArithmeticExp : tTAN tPO ArithmeticExp tPF { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, TAN(%s))\n", tempName, TYPE_FLOAT, $3); $$ = tempName; free($3); };;
ArithmeticExp : tNB tDOT tNB { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s.%s)\n", tempName, TYPE_FLOAT, $1, $3); $$ = tempName; };
ArithmeticExp : tNB { char* tempName = getNewVarTempName(); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, $1); $$ = tempName; };
ArithmeticExp : ArithmeticExp tADD ArithmeticExp { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation($1, $3, ARITHMETIC_OPERATION_CODE_ADD); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); $$ = tempName; };
ArithmeticExp : ArithmeticExp tSUB ArithmeticExp { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation($1, $3, ARITHMETIC_OPERATION_CODE_SUB); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); $$ = tempName; };
ArithmeticExp : ArithmeticExp tMUL ArithmeticExp { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation($1, $3, ARITHMETIC_OPERATION_CODE_MUL); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); $$ = tempName; };
ArithmeticExp : ArithmeticExp tDIV ArithmeticExp { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation($1, $3, ARITHMETIC_OPERATION_CODE_DIV); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); $$ = tempName; };
ArithmeticExp : ArithmeticExp tMOD ArithmeticExp { char* tempName = getNewVarTempName(); char* opArith = getNewArithmeticOperation($1, $3, ARITHMETIC_OPERATION_CODE_MOD); fprintf(out, "VAR_AFF(%s, %s, %s)\n", tempName, TYPE_FLOAT, opArith); free(opArith); $$ = tempName; };
ArithmeticExp : tPO ArithmeticExp tPF { $$ = $2; } ;

%%

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
