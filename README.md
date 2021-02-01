![GitHub top language](https://img.shields.io/github/languages/top/Alisson-tech/jogo-do-rato)
![GitHub](https://img.shields.io/github/license/Alisson-tech/jogo-do-rato)
![GitHub repo size](https://img.shields.io/github/repo-size/Alisson-tech/jogo-do-rato)


# :mouse: Jogo do Rato :mouse:

## Introdução 
  O jogo foi desenvolvido durante o curso técnico de Informática, na linguagem  de programação c# no segundo semestre de 2019.
  Foi programado orientado a objeto com o objetivo de treinar a lógica.
  
## Como Funciona
  O usuário gera diferentes tipos de Labirintos, e o Rato deve encontrar o Queijo utilizando o algoritmo Tezeu, dentro de um tempo determinado.

## Regras 
  - O Tamanho máximo do labirinto é 20x20
  - O Tamanho Minímo é 10x10
  - O Máximo de queijo é 10 (modo Time Atack)
  - O Minímo de queijo é 1
  - Caso o usuário não defina o tempo, o rato terá tempo infinito para encontrar o Queijo
  - Caso o Tempo acabe antes do rato encontrar o queijo ele perde
  
  ![Interface](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Interface.png)
  
  
## Tipos de Labirinto 
Conectado - As paredes são Conectadas, e o usuário define a quantidade de parede Vertical e Horizontal.

![Labirinto Conectado](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Interface-lab%20Conect.png)

Aleatório - As parede são geradas aleatoriamente, o usuário define a porcentagem de preenchimento do labirinto.

![Labirinto Aleatório](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Interface-lab%20Aleat%C3%B3rio.png)

Vazio - Simula um Deserto, sendo um labirinto sem paredes (ele também é gerado quando a quantidade de paredes não e compatível)

![Labirinto Vazio](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Interface-lab%20vazio.png)

## Modos de Jogo

Time Attack - Nesse modo o usuário define a quantidade de queijos e a quantidade de passos. Basicamente ele deverá encontrar todos os queijos, porém toda vez que ele ultrapassa a quantidade de passos definidos, os queijos mudam de lugar, se ele encontra um queijo a quantidade de passos que ele ja deu é resetada para 0, dando mais um tempo antes de mudar os queijos de lugar.

![Time Atack](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Time-atack.gif)

Run For The Theese - O modo Clássico onde será gerado um queijo e o rato deverá encontrá-lo.

![Run For The Theese](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Run-For-Theese.gif)

## Algoritmo Tezeu
   O algoritmo Consiste em marcar todos os lugares onde o rato passou, se ele passar duas vezes naquele local cria uma espécie de parede é o rato não pode atravessar. Caso o rato fique preso, é resetado algumas paredes criadas pelo rato.
   
   ![Tezeu](https://github.com/Alisson-tech/jogo-do-rato/blob/master/Imgs/Tezeu.gif)
   
