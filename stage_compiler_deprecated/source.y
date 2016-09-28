/*MIT License

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
SOFTWARE.*/


%{
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
	
%}

%start Scpt ;
%token tON tTHEN tLOOP tFSPEED tEVERY tFOR tDOT tPARTICLE tSHARP tFDIR tHEALTH tADD tASYNC tWAIT tSYNC tDP tLET tADP tCO tCF tACTION tDEST tALL tPOS tDIR tSPEED tTYPE tCREATE tAO tAF tPO tPF tBARRE tFL tPV tV tEQ tSUB tMUL tDIV tSHOOT tMOVE;
%union
{
   char* string;
}
%token <string> tEXP;
%token <string> tNB;
%token <string> tSTRING;
%type <string> Exp ;
%%

Scpt : On Scpt | On ;
Scpt : Onl Scpt | Onl ;
On : tON tDP tNB tDOT tNB { snprintf(loopState, sizeof(loopState), "false"); } Lets { snprintf(time, sizeof(time), "%s.%s", $3, $5) ; snprintf(end, sizeof(end), "%.2f", 0.0) ; snprintf(cadence, sizeof(cadence), "%.2f", 0.0) ; }  Body { int indice = 0; for(indice=0;indice<letID;indice++) fprintf(file, "unlet(%s)\n", letsVar[indice]); letID=0;} ;
Onl : tON tDP tNB tDOT tNB tBARRE tFOR tDP tNB tDOT tNB tBARRE tEVERY tDP tNB tDOT tNB { snprintf(loopState, sizeof(loopState), "true"); } Lets {snprintf(time, sizeof(time), "%s.%s", $3, $5); snprintf(end, sizeof(end), "%s.%s", $9, $11) ; snprintf(end, sizeof(end), "%.2f", atof(time)+atof(end)) ; snprintf(cadence, sizeof(cadence), "%s.%s", $15, $17) ; } Body { int indice = 0; for(indice=0;indice<letID;indice++) fprintf(file, "unlet(%s)\n", letsVar[indice]); letID=0;} ;
Body : tAO Code tAF ;
Code : Instr Code | Instr;
Instr : Create | Then | AffVar | Loop;
Lets : tPO ListeLet tPF;
Lets : ;
AffVar : tSTRING tEQ Exp tPV { fprintf(file, "avar(%s<=%s)\n", $1, $3); } ;
ListeLet : ;
ListeLet : Let ListeLet;

Let : tLET tSTRING tEQ tNB tDOT tNB tPV { fprintf(file, "let(%s<=%s.%s, %s)\n", $2, $4, $6, loopState); snprintf(letsVar[letID], sizeof(letsVar[letID]), $2); letID++;};
Loop : tLOOP tDP tPO tSTRING tV tNB tPF { fprintf(file, "loop(%s, %s)\n", $4, $6); } Body  { fprintf(file, "end(%s)\n", $4); } ;
/*Wait : tWAIT tDP {snprintf(instr, sizeof(instr), "w"); waitTime = atof(time); waitEnd = atof(end); waitCadence = atof(cadence); snprintf(time, sizeof(time), "%s", end) ; snprintf(end, sizeof(end), "%.2f", 0.0) ; snprintf(cadence, sizeof(cadence), "%.2f", 0.0) ; foreach=2; } ListeSpecialOn 
{ 
	foreach=0;
	snprintf(time, sizeof(time),"%.2f", waitTime);
	snprintf(end, sizeof(end),"%.2f", waitEnd);
	snprintf(cadence, sizeof(cadence),"%.2f", waitCadence);
};*/

Create : tACTION { if(firstTimeBreak==1) firstTimeBreak=0; else fprintf(file, "break\n"); } tDP tCREATE Caracs;
Move : tACTION tDP tMOVE { snprintf(currentAction, sizeof(currentAction), "move"); } SpecialCaracs ;
Shoot : tACTION tDP tSHOOT { snprintf(currentAction, sizeof(currentAction), "shoot"); } SpecialCaracs ;

SpecialListeDeclaration : tSHARP tALL tDP tCO { saveLine = 1; snprintf(savedLine, sizeof(savedLine), "", currentAction, id_enemy-nbCreate);} ListeAff tCF 
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
} ;

SpecialListeDeclaration : ;
SpecialListeDeclaration : tCO
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
} ListeAff tCF { fprintf(file, "time<=%s, cadence<=%s, end<=%s):%s\n", time, cadence, end, instr); }  SpecialListeDeclaration;
SpecialCaracs : tAO SpecialListeDeclaration tAF;
Then : tTHEN Option tAO ListeSpecialOn { indexListe = 0; foreach=0; } tAF;
Caracs : tAO ListeDeclaration tAF ;
ListeDeclaration : ;
ListeDeclaration : tCO { fprintf(file, "create(id<=%d, ", id_enemy); id_enemy++; nbCreate++; } ListeAff tCF { fprintf(file, "time<=%s, cadence<=%s, end<=%s):1\n", time, cadence, end);} ListeDeclaration;
ListeAff : Aff;
ListeAff : Aff ListeAff;
SpecialOn : Onp;
SpecialOn : Onlp;
ListeSpecialOn : ;
ListeSpecialOn : SpecialOn {indexListeTemp = 0;} ListeSpecialOn;

Onp : tON tADP tNB tDOT tNB {lastTime = atof(time); lastEnd = atof(end); lastCadence = atof(cadence); snprintf(time, sizeof(time),"%.2f", atof($3) + (atof($5)/(pow(10.0, strlen($5)))) + atof(time)); snprintf(end, sizeof(end),"%.2f", atof($3) + (atof($5)/(pow(10.0, strlen($5)))) + atof(end));  snprintf(cadence, sizeof(cadence),"%.2f", 0.0); } tAO ListeSpecialActions tAF
{ 
	snprintf(time, sizeof(time),"%.2f", lastTime);
	snprintf(end, sizeof(end),"%.2f", lastEnd);
	snprintf(cadence, sizeof(cadence),"%.2f", lastCadence);
};

Onlp: tON tADP tNB tDOT tNB tBARRE tFOR tDP tNB tDOT tNB tBARRE tEVERY tDP tNB tDOT tNB { lastTime = atof(time); lastEnd = atof(end); lastCadence = atof(cadence); snprintf(cadence, sizeof(cadence),"%.2f", atof($15) + (atof($17)/(pow(10.0, strlen($17))))); snprintf(time, sizeof(time),"%.2f", atof($3) + (atof($5)/(pow(10.0, strlen($5)))) + atof(time));  snprintf(end, sizeof(end),"%.2f", atof($9) + (atof($11)/(pow(10.0, strlen($11)))) + atof(time));  } tAO ListeSpecialActions tAF
{ 
	snprintf(time, sizeof(time),"%.2f", lastTime);
	snprintf(end, sizeof(end),"%.2f", lastEnd);
	snprintf(cadence, sizeof(cadence),"%.2f", lastCadence);
};

SpecialActions : Move | Shoot | AffVar ;
ListeSpecialActions : SpecialActions | SpecialActions ListeSpecialActions;

Option : tDP {snprintf(instr, sizeof(instr), "a"); foreach=1;};
Option : tDP tCO { snprintf(instr, sizeof(instr), "a"); } ListeNb tCF;
ListeNb : tNB tV { memcpy(listeIds[indexListe], $1, sizeof(listeIds[indexListe])) ; indexListe++; } ListeNb ;
ListeNb : tNB { memcpy(listeIds[indexListe], $1, sizeof(listeIds[indexListe])) ; indexListe++; } ;
Aff : Vectors tEQ tPO Exp tV Exp tPF tPV { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s(%s, %s), ", savedLine, $4, $6); else fprintf(file, "(%s, %s), ", $4, $6); } ;
Aff : Numbers tEQ Exp tPV { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s%s, ", savedLine, $3); else fprintf(file, "%s, ", $3); } ;
Aff : Objects tEQ Exp tPV { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%s%s, ", savedLine, $3); else fprintf(file, "%s, ", $3); } ;
Exp : tEXP {$$ = $1;} ;
Exp : tNB tDOT tNB {snprintf($$, sizeof($$), "%s.%s", $1, $3); };
Exp : tNB { $$=$1; };
Exp : tSTRING {$$  = $1;};
Vectors : tDEST { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sdestination<=", savedLine); else fprintf(file, "destination<="); } | tPOS { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sposition<=", savedLine); else fprintf(file, "position<="); }  | tDIR { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sdirection<=", savedLine); else fprintf(file, "direction<="); } | tFDIR { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sfDirection<=", savedLine); else fprintf(file, "fDirection<="); };
Numbers : tSPEED { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sspeed<=", savedLine); else fprintf(file, "speed<=" ) ; } | tFSPEED { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sfSpeed<=", savedLine); else fprintf(file, "fSpeed<=" ) ; } | tHEALTH { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%shealth<=", savedLine); else fprintf(file, "health<=" ) ; } ;
Objects : tPARTICLE { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%sparticleType<=", savedLine); else fprintf(file, "particleType<="); }  | tTYPE { if(saveLine) snprintf(savedLine, sizeof(savedLine), "%stype<=", savedLine); else fprintf(file, "type<="); } ;
%%

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
