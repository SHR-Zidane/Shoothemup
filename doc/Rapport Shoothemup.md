# Rapport Shoothemup

![alt text](./maquette%20jeu%20v2.png)

## Introduction

Ce projet consiste à réaliser un jeu vidéo en C# et d'accquérir des compétences en programmation orientée objet. Nous devons faire un jeu vidéo de type shoothemup du thème de notre choix.

J'ai choisi de faire un jeu où le joueur serait un singe qui bougerait de palmier en palmier et qui lancera des bombes sur des gorilles qui sont là pour lui subtiliser les bananes qui sont au pieds des palmiers.
En même temps les gorilles lanceront des noix de coco sur le joueur ce qui lui infligera des dégats sur ses points de vie s'il se fait toucher.

En parralèles nous apprenons à coder en C# en Orienté Objet, ça nous permet de pouvoir

## Planification

**Semaine 1**

- Définir les fonctionnalités principales (déplacements, sauts, tirs, ennemis, collisions).
- Créer le projet et les classes (`Player`, `PalmTree`, `Gorilla`, etc).
- Faire un schéma rapide du gameplay.

**Semaine 2**

- Implémenter le déplacement horizontal et le saut du singe.
- Gérer la gravité et les collisions avec le sol.
- Limiter les mouvements aux bords de l’écran.

**Semaine 3**

- Ajouter plusieurs palmiers dans la scène.
- Gérer la détection de collision entre le singe et les palmiers.
- Permettre de sauter de l’un à l’autre sans traverser les objets.

**Semaine 4**

- Créer la classe `Gorilla` et son comportement de base.
- Leur permettre de lancer des noix de coco vers le joueur.
- Ajouter la gestion des points de vie du singe.

**Semaine 5**

- Créer une classe `Bomb` (position, trajectoire, dégâts).
- Gérer les collisions entre bombes et gorilles.
- Ajouter un effet d’explosion ou une animation simple.

**Semaine 6**

- Placer les bananes au pied des palmiers.
- Ajouter un score et un système de points de vie.

**Semaine 7**

- Créer une barre de vie.
- Faire en sorte que les gorilles tentent de voler les bananes.

**Semaine 8**

- Corriger les bugs.

## Analyse fonctionnelle

**Objectif du jeu**
Un Shoot em up est un jeu 2d type "space invader" ou on doit éliminer des ennemis, gagner des points ect... Un jeu d'arcade en somme.

**Comment jouer**
Le joueur controle un petit singe qui se déplace avec les touches A pour aller à gauche et D pour aller à droite il peut également sauter de palmier en palmier en appuyant sur espace. Pour lancer des bombes il faudra appuyer sur la touche enter. La zone rouge et la zone ou le joueur peut se déplacer, sinon quoi, il tombe. Le joueur comme les ennemis ou meme les palmiers ont des points de vie.

**Comportement des ennemis**
Les gorilles sont les ennemis des singes, c'est bien connu, ils n'hésiteront pas à envoyer des noix de coco sur juste au dessus d'eux et et d'aller automatiquement vers les bananes, à moins que vous les éliminiez...

**Les obstacles**
Les palmiers feront office d'obstacle. Ils auront des points de vie et seront donc cassables. Il apparaissent aléatoirement sur la plage au lancement du jeu.

### **User Stories**

**Le joueur doit pouvoir se déplacer et sauter**

En tant que joueur,
je veux pouvoir me déplacement via les touches A ou D et pouvoir sauter via la barre espace,
afin que mon personnage puisse se déplacer et éviter les projectiles envoyer par les gorilles.

- [x] Lorsque que le joueur appuie sur une des touches de déplacement (A pour aller à gauche et D pour aller à droite) le personnage avance dans la direction indiquée tant que la touche est appuyée.
- [x] Lorsque que le joueur appuie sur la barre espace le personnage saute à une hauteur d'environ le double de son corps.
- [x] Lorsque le joueur appuie sur la barre espace et qu'en même temps une touche de déplacement est appuyée, le joueur saute vers la direction indiquée.
- [x] Lorsque que le joueur lâche la touche de déplacement, le personnage s'arrête.

<img width="400" height="" alt="Image" src="https://github.com/user-attachments/assets/67516fa9-a9c9-4538-87e8-aa1789618109" />

**Lancer des attaques**

En tant que joueur,
Je veux pouvoir attaquer les ennemies(gorilles) en lançant des bombes,
Afin que je puisse défendre mes bananes.

- [x] En appuyant sur enter, une bombe est envoyée vers le bas
- [x] Les bombes ne sont pas envoyées en chaine, un cooldown de une seconde est implémenté
- [x] Si les bombes ne touchent personne elles explosent en sortant de l'écran.
- [x] Lorsque qu'une bombe envoyée par le joueur atteint un ennemi, l'ennemi en question perd 1 point de vie.

**Les ennemies (gorilles) doivent envoyés des attaques**

En tant que joueur,
je veux que les ennemies puissent m'attaquer en envoyant des projectiles(noix de coco),
afin que le jeu puisse avoir une certaine difficulté

- [x] Lorsqu'un projectile ennemi atteint le joueur, il perd 1 point de vie.
- [x] Lorsqu'un projectile ne touche pas le joueur, il disparait en sortant de l'écran
- [x] Un gorille a un nombre illimité de projectile
- [x] Un gorille a 3 points de vie et quand ses points de vie arrivent à 0 le gorille meurt.

**Mettre en place les palmiers**

En tant que joueur,
je veux pouvoir me déplacer de palmier en palmier et sur le palmier.

- [x] Lorsque le joueur se pose sur un palmier, il ne tombe pas dû au masque de collision (zone rouge sur la maquette 2).
- [x] Lorsque le palmier se fait tirer dessus 4 fois par les projectiles ennemis, il se détruit.
- [x] Lorsque le joueur se déplace sur un palmier, il se déplace que jusqu'au bout des feuilles, sinon, il tombe.

<img width="400" height="" alt="Image" src="https://github.com/user-attachments/assets/a040cb93-6b26-40a1-9d9f-a9d4381d3107" />

## Conception

Le diagramme UML ci-dessous illustre les classes et comment elles intéragissent entre elles. Malheureusement étant donné que je n'ai pas réussi à finir le code à temps, et bien certaines classes sont présentent là mais pas dans le code.
![alt text](./MonkeyGame_Full_UML_Diagram.png)
La classe **Beach** est là classe qui gère la logique du jeu elle a les méthode update et render qui mettent à jour et affichent ce qu'il y a sur la plage

La classe **Player** est la classe du joueur elle a en elle toute la logique de déplacement

La classe **Palm Tree** elle sert à définir les attribut des palmiers etc elle m'a permis de comprendre comment mettre en place les hitbox.

Le reste des classes sont n'ont pas été implémentée mais c'est à quoi elles auraient ressembler.

## Utilisation de l'IA

J'ai utilisé l'intelligence artificielle pour qu'elle m'explique comment certains concepts fonctionnent comme les hitbox ou les collisions. Ca ne m'a pas forcément été bénéfique étant donné que je n'ai pas réussi à bien implémenter les collisions ce qui m'a retarder sur tout mon projet.
